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

        private void Form10_Load(object sender, EventArgs e)
        {
            LoadUpcomingEvents();
        }

        private void LoadUpcomingEvents()
        {
            string connectionString = @"Server=np:\\.\pipe\LOCALDB#653b9183\tsql\query;Database=mydbs;Integrated Security=true;";
            string query = "SELECT EventName, EventDate FROM events ORDER BY EventDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string eventName = reader["EventName"].ToString();
                        DateTime eventDate = Convert.ToDateTime(reader["EventDate"]);
                        upcomingEventsList.Items.Add($"{eventName} - {eventDate:dd MMM yyyy}");
                        eventCalendar.AddBoldedDate(eventDate);
                    }

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
            string connectionString = @"Server=np:\\.\pipe\LOCALDB#653b9183\tsql\query;Database=mydbs;Integrated Security=true;";
            string query = "SELECT EventName, EventDate FROM events WHERE EventDate = @SelectedDate";

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
                        eventDetails += $"Event: {eventName}\n";
                    }

                    if (!string.IsNullOrEmpty(eventDetails))
                    {
                        eventDetails += "\nWould you like to book this event?";
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
    }
}
