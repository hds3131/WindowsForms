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
using static WindowsForms.Form2;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
<<<<<<< HEAD
            InitializeComponent();//hi amy
=======
            InitializeComponent();
            //hi amy
>>>>>>> parent of a844f7b (completed till week)
        }


        
        


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 signUpForm = new Form2();
            signUpForm.Show();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
            string username = textBox3.Text;
            string password = textBox4.Text;


<<<<<<< HEAD
                string connectionString = @"Server=np:\\.\pipe\LOCALDB#CE1246A4\tsql\query;Database=mydb;Integrated Security=true;";
=======
                string connectionString = @"Server=np:\\.\pipe\LOCALDB#154346C2\tsql\query;Database=mydb;Integrated Security=true;";
>>>>>>> parent of a844f7b (completed till week)

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
<<<<<<< HEAD
                        // Open the connection
                        connection.Open();

                        // Query to check if the username and password match any record in the Users table
                        string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Use parameters to avoid SQL injection
=======
                        connection.Open();

                        // Query to check if the user credentials match
                        string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
>>>>>>> parent of a844f7b (completed till week)
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 1)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
<<<<<<< HEAD
=======

                                // Record member login in VisitorTracking table
                                string insertVisitorQuery = "INSERT INTO VisitorTracking (VisitDate, PageVisited, VisitCount, IsMember) VALUES (@VisitDate, @PageVisited, @VisitCount, @IsMember)";
                                using (SqlCommand visitorCommand = new SqlCommand(insertVisitorQuery, connection))
                                {
                                    visitorCommand.Parameters.AddWithValue("@VisitDate", DateTime.Now);
                                    visitorCommand.Parameters.AddWithValue("@PageVisited", "LoginPage");
                                    visitorCommand.Parameters.AddWithValue("@VisitCount", 1);
                                    visitorCommand.Parameters.AddWithValue("@IsMember", 1); // Mark this as a member visit

                                    visitorCommand.ExecuteNonQuery();
                                }

                                // Proceed to the member area or dashboard as needed
>>>>>>> parent of a844f7b (completed till week)
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
<<<<<<< HEAD
                        // Handle any errors that may occur during connection or query execution
=======
>>>>>>> parent of a844f7b (completed till week)
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
<<<<<<< HEAD

            // Rest of your code remains unchanged...
=======
            // Rest of your code remains unchanged...
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();


            form3.Show();


            this.Hide();
>>>>>>> parent of a844f7b (completed till week)
        }
    }

}
    
    

    


    

