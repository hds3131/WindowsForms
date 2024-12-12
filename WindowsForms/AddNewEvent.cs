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
    
    public partial class AddNewEvent : Form
    {
        //string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=mydb;Integrated Security=True;";
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=E:\DATABASE1.MDF;Integrated Security=True;";
        public AddNewEvent()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            // Retrieve input data
            string eventName = textBoxEventName.Text;
            DateTime eventDate = dateTimePickerEventDate.Value;
            string location = textBoxLocation.Text;
            string eventType = comboBoxEventType.SelectedItem?.ToString();
            string guestCount = textBoxGuestCount.Text;
            string participants = textBoxParticipants.Text;  // participants is now treated as string
            string eventDetails = textBoxEventDetails.Text;

            // Validate inputs (e.g., ensure required fields are not empty)
            if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(eventType))
            {
                MessageBox.Show("Please fill out all required fields: Event Name, Location, and Event Type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Optional: Check if guest count is numeric (if needed)
            if (!string.IsNullOrEmpty(guestCount) && !int.TryParse(guestCount, out _))
            {
                MessageBox.Show("Please enter a valid number for Guest Count.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            // Create SQL Insert query
            string insertQuery = @"
    INSERT INTO [dbo].[Events] 
    ([EventName], [EventDate], [GuestCount], [Participants], [Location], [EventDetails], [EventType]) 
    VALUES 
    (@EventName, @EventDate, @GuestCount, @Participants, @Location, @EventDetails, @EventType)";

            try
            {
                // Establish a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create SQL command and add parameters
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EventName", eventName);
                        command.Parameters.AddWithValue("@EventDate", eventDate);
                        command.Parameters.AddWithValue("@GuestCount", string.IsNullOrEmpty(guestCount) ? (object)DBNull.Value : int.Parse(guestCount));
                        command.Parameters.AddWithValue("@Participants", string.IsNullOrEmpty(participants) ? (object)DBNull.Value : participants);  // Treat participants as string
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@EventDetails", string.IsNullOrEmpty(eventDetails) ? (object)DBNull.Value : eventDetails);
                        command.Parameters.AddWithValue("@EventType", eventType);

                        // Execute the command to insert the data
                        command.ExecuteNonQuery();
                    }
                }

                // Display success message
                MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Close the dialog with OK result
                this.DialogResult = DialogResult.OK;
                this.Close();  // Close the dialog form
                               // Trigger update of dataGridView5 in Form6

                // Optionally, clear the input fields after adding the event
                textBoxEventName.Clear();
                textBoxLocation.Clear();
                comboBoxEventType.SelectedIndex = -1;
                textBoxGuestCount.Clear();
                textBoxParticipants.Clear();  // Clear participants field
                textBoxEventDetails.Clear();
            }
            catch (Exception ex)
            {
                // Handle errors, if any
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void labelGuestCount_Click(object sender, EventArgs e)
        {

        }

        private void textBoxGuestCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxParticipants_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelParticipants_Click(object sender, EventArgs e)
        {

        }
    }
}
