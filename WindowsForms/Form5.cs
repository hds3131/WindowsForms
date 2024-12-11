using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form5 : Form
    {
        private string adminId;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Call a method to fetch the email based on adminId
            string email = GetAdminEmail(adminId);

            // Display the email in your label
           

            LoadLatestUsers();
            LoadNewMembers();
        }

        private string GetAdminEmail(string adminId)
        {
            string email = string.Empty;

            // Connection string for your local database
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to get the email based on AdminId
                    string query = "SELECT Email FROM admin WHERE AdminID = @AdminId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@AdminId", adminId);

                        // Execute the query and fetch the email
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            email = result.ToString();
                        }
                        else
                        {
                            email = "Email not found"; // Fallback if no email is found
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return email;
        }


        private void LoadLatestUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to retrieve all users sorted by DateCreated
                    string query = "SELECT UserID, Username, DateCreated, isBlocked FROM Users ORDER BY DateCreated DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable userDataTable = new DataTable();
                            adapter.Fill(userDataTable);

                            // Bind data to dataGridView5
                            BindUsersToDataGridView(userDataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindUsersToDataGridView(DataTable userDataTable)
        {
            // Check if the DataTable has any rows to add
            if (userDataTable.Rows.Count > 0)
            {
                // Clear existing rows before adding new data
                dataGridView7.Rows.Clear();

                // Loop through the rows of the user data table and bind to the DataGridView
                foreach (DataRow row in userDataTable.Rows)
                {
                    string username = row["Username"].ToString();
                    DateTime dateCreated = Convert.ToDateTime(row["DateCreated"]);
                    int userID = Convert.ToInt32(row["UserID"]);
                    bool isBlocked = Convert.ToBoolean(row["isBlocked"]);  // Fetching the isBlocked value

                    // Create a new row for the DataGridView
                    DataGridViewRow gridRow = new DataGridViewRow();

                    // Add the UserID (first column)
                    gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = userID });

                    // Add Username column
                    gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = username });

                    // Add Membership status column
                    bool isMember = IsUserMember(userID); // Check membership status
                    gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = isMember ? "Yes" : "No" });

                    // Add DateCreated column
                    gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = dateCreated.ToString("yyyy-MM-dd") });

                    // Create the "Block/Unblock" button cell based on isBlocked status
                    DataGridViewButtonCell blockButton = new DataGridViewButtonCell { Value = isBlocked ? "Unblock" : "Block" };
                    gridRow.Cells.Add(blockButton);

                    // Create the "Accept Membership" button for non-members
                    if (!isMember)
                    {
                        DataGridViewButtonCell acceptMembershipButton = new DataGridViewButtonCell { Value = "Accept" };
                        gridRow.Cells.Add(acceptMembershipButton);
                    }
                    else
                    {
                        // Add an empty cell for members to maintain alignment
                        gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    }

                    // Add the row to dataGridView7
                    dataGridView7.Rows.Add(gridRow);
                }
            }
        }





        private bool IsUserMember(int userId)
        {
            // Check if the UserID exists in the Members table to determine membership
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if the user exists in the Members table
                    string query = "SELECT COUNT(1) FROM Member WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0; // Return true if user is a member, false otherwise
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }




        private void LoadNewMembers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to retrieve new members, sorted by DateCreated in descending order
                    string query = "SELECT u.Username, m.MembershipTypeID, m.UserID " +
                                   "FROM Member m " +
                                   "JOIN Users u ON m.UserID = u.UserID " +
                                   "ORDER BY u.DateCreated DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable membersDataTable = new DataTable();
                            adapter.Fill(membersDataTable);

                            // Bind the fetched members to dataGridView10
                            BindNewMembersToDataGridView(membersDataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindNewMembersToDataGridView(DataTable membersDataTable)
        {
            // Clear existing rows before adding new data
            dataGridView10.Rows.Clear();

            foreach (DataRow row in membersDataTable.Rows)
            {
                string username = row["Username"].ToString();
                int membershipTypeID = Convert.ToInt32(row["MembershipTypeID"]);
                int userID = Convert.ToInt32(row["UserID"]);

                // Create a new row for the DataGridView
                DataGridViewRow gridRow = new DataGridViewRow();

                // Add the MemberID (first column)
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["UserID"].ToString() });

                // Add Username column
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = username });

                // Add Subscription Type dropdown column
                DataGridViewComboBoxCell subscriptionDropdown = new DataGridViewComboBoxCell();
                subscriptionDropdown.Items.AddRange(GetMembershipTypeOptions()); // Populate dropdown with membership types
                subscriptionDropdown.Value = GetMembershipTypeName(membershipTypeID); // Set current value
                gridRow.Cells.Add(subscriptionDropdown);

                // Create the "Remove" button cell
                DataGridViewButtonCell removeButton = new DataGridViewButtonCell { Value = "Remove" };
                gridRow.Cells.Add(removeButton);

                // Add the row to dataGridView10
                dataGridView10.Rows.Add(gridRow);
            }
        }


        private string[] GetMembershipTypeOptions()
        {
            // Query to fetch all membership type names from the MembershipType table
            string query = "SELECT TypeName FROM MembershipType";
            List<string> membershipTypes = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            membershipTypes.Add(reader["TypeName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return membershipTypes.ToArray();
        }

        private void dataGridView10_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // Assuming Subscription Type dropdown is in the 3rd column (index 2)
            {
                int userID = Convert.ToInt32(dataGridView10.Rows[e.RowIndex].Cells[0].Value); // Get UserID
                string newMembershipType = dataGridView10.Rows[e.RowIndex].Cells[2].Value.ToString(); // Get selected membership type

                UpdateMembershipType(userID, newMembershipType);
            }
        }

        private void UpdateMembershipType(int userID, string membershipTypeName)
        {
            // Query to update the MembershipTypeID based on the new membership type name
            string query = "UPDATE Member SET MembershipTypeID = (SELECT TypeID FROM MembershipType WHERE TypeName = @TypeName) WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeName", membershipTypeName);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Membership type updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private string GetMembershipTypeName(int membershipTypeID)
        {
            // Query to fetch the membership type name from MembershipType table based on MembershipTypeID
            string query = "SELECT TypeName FROM MembershipType WHERE TypeID = @TypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeID", membershipTypeID);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar()?.ToString() ?? "Unknown";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return "Error";
                }
            }
        }


        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView22_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView21_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) // Assuming "Block/Unblock" button is in the 6th column (index 5)
            {
                int userID = Convert.ToInt32(dataGridView7.Rows[e.RowIndex].Cells[0].Value); // Get UserID
                bool isBlocked = !Convert.ToBoolean(dataGridView7.Rows[e.RowIndex].Cells[4].Value == "Block");

                DialogResult result = MessageBox.Show($"Are you sure you want to {(!isBlocked ? "block" : "unblock")} user {userID}?", "Block/Unblock User", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Call the method to update the isBlocked status
                    UpdateUserBlockStatus(userID, !isBlocked);

                    // Rebind the grid to reflect the updated status
                    LoadLatestUsers();
                }
            }
            else if (e.ColumnIndex == 5) // Assuming "Accept Membership" button is in the 6th column (index 5)
            {
                int userID = Convert.ToInt32(dataGridView7.Rows[e.RowIndex].Cells[0].Value); // Get UserID
                DialogResult result = MessageBox.Show($"Are you sure you want to accept membership for user {userID}?", "Accept Membership", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Call the method to add the user as a member
                    AcceptMembership(userID);

                    // Refresh both grids to reflect the change
                    LoadLatestUsers();
                    LoadNewMembers();
                }
            }
        }


        private void AcceptMembership(int userID)
        {
            // Query to insert the user into the Member table
            string query = "INSERT INTO Member (UserID, Name, MembershipTypeID) VALUES (@UserID, @Name, @MembershipTypeID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Name", GetUsername(userID)); // Fetch the username dynamically
                command.Parameters.AddWithValue("@MembershipTypeID", 1); // Assuming default MembershipTypeID is 1

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Membership accepted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private string GetUsername(int userID)
        {
            // Query to fetch the username from the Users table
            string query = "SELECT Username FROM Users WHERE UserId = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar()?.ToString() ?? "Unknown";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Unknown";
                }
            }
        }

        private void UpdateUserBlockStatus(int userID, bool block)
        {
            // Query to update the isBlocked status of the user
            string query = "UPDATE Users SET isBlocked = @isBlocked WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@isBlocked", block);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"User {(block ? "blocked" : "unblocked")} successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 form7 = new Form7();


            form7.Show();


            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) // The "Remove" button is now in the 4th column (index 3)
            {
                int userID = Convert.ToInt32(dataGridView10.Rows[e.RowIndex].Cells[0].Value); // Get UserID from the first column (MemberID)
                DialogResult result = MessageBox.Show($"Are you sure you want to remove user {userID}?", "Remove User", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Call the RemoveMember method to remove the user
                    RemoveMember(userID);

                    // Rebind the grid to reflect the change
                    LoadNewMembers();
                }
            }
        }


        private void RemoveMember(int userID)
        {
            // Query to delete the member from the Member table
            string query = "DELETE FROM Member WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User removed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void adminEmail_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
