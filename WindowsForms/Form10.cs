using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsForms
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void upcomingEventsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUpcomingEvents();
        }

        private void LoadUpcomingEvents()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

            string query = "SELECT EventName, EventDate, Location, Attendees, EventDetails, EventType FROM events ORDER BY EventDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    upcomingEventsList.Items.Clear(); // Clear existing items

                    while (reader.Read())
                    {
                        // Read event details safely, handling potential null values
                        string eventName = reader["EventName"] != DBNull.Value ? reader["EventName"].ToString() : "N/A";
                        DateTime eventDate = reader["EventDate"] != DBNull.Value ? Convert.ToDateTime(reader["EventDate"]) : DateTime.MinValue;
                        string location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : "N/A";
                        int attendees = reader["Attendees"] != DBNull.Value ? Convert.ToInt32(reader["Attendees"]) : 0;
                        string eventDetails = reader["EventDetails"] != DBNull.Value ? reader["EventDetails"].ToString() : "N/A";
                        string eventType = reader["EventType"] != DBNull.Value ? reader["EventType"].ToString() : "N/A";

                        // Debugging: Log the values to verify they are correct
                        Console.WriteLine($"Event: {eventName}, Date: {eventDate}, Location: {location}, Attendees: {attendees}, Type: {eventType}");

                        // Format the event information for the upcoming events list
                        string eventInfo = $"{eventName} - {eventDate:dd MMM yyyy} - {location} - {eventType} - {attendees} attendees";
                        upcomingEventsList.Items.Add(eventInfo);

                        // Add the event date to the calendar as bolded
                        if (eventDate != DateTime.MinValue)
                        {
                            eventCalendar.AddBoldedDate(eventDate);
                        }
                    }

                    // Refresh calendar to show bolded dates
                    eventCalendar.UpdateBoldedDates();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void ShowEventsOnDate(object sender, DateRangeEventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;
            string query = "SELECT EventName, EventDate, EventDetails FROM events WHERE EventDate = @SelectedDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", e.Start.Date);
                    SqlDataReader reader = command.ExecuteReader();

                    string eventDetails = "";
                    while (reader.Read())
                    {
                        string eventName = reader["EventName"].ToString();
                        string details = reader["EventDetails"].ToString();
                        eventDetails += $"Event: {eventName}\nDetails: {details}\n\n";
                    }

                    if (!string.IsNullOrEmpty(eventDetails))
                    {
                        eventDetails += "Would you like to book this event?";
                        DialogResult result = MessageBox.Show(eventDetails, "Event Details", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            BookEvent(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No events found for the selected date.", "No Events", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NavigateToDashboard(object sender, EventArgs e)
        {
            // Add code to navigate to the dashboard
        }

        private void NavigateToCommunity(object sender, EventArgs e)
        {
            // Add code to navigate to community and chats
        }

        private void ShowMoreOptions(object sender, EventArgs e)
        {
            // Add code to show more options
        }

        private void BookEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Event booked successfully!", "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CancelBooking(object sender, EventArgs e)
        {
            // Add code to cancel a booking
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Add code to log out the user
        }

        private void upcomingEventsLabel_Click(object sender, EventArgs e)
        {

        }

        private void eventCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            ShowEventsOnDate(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quickActionsLabel_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void upcomingEventsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadUpcomingEvents();
        }
    }
}
