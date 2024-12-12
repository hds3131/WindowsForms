using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form5 : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

        public Form5()
        {
            InitializeComponent();
            LoadEvents();
            LoadPayments();
        }

        private void LoadEvents()
        {
            // Load data from the Events table into the Events ListBox
            string query = "SELECT EventName, EventDate FROM Events ORDER BY EventDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    eventsListBox.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        string eventName = reader["EventName"].ToString();
                        DateTime eventDate = Convert.ToDateTime(reader["EventDate"]);
                        eventsListBox.Items.Add($"{eventName} - {eventDate:dd MMM yyyy}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading events: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPayments()
        {
            // Load data from the PaymentDetails table into the Payments ListBox
            string query = "SELECT PaymentName, PaymentDate FROM PaymentDetails ORDER BY PaymentDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    paymentsListBox.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        string paymentName = reader["PaymentName"].ToString();
                        DateTime paymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                        paymentsListBox.Items.Add($"{paymentName} - {paymentDate:dd MMM yyyy}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading payments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            // Add a new event to the Events table
            string eventName = Prompt.ShowDialog("Enter Event Name", "Add Event");
            string eventDateStr = Prompt.ShowDialog("Enter Event Date (yyyy-MM-dd)", "Add Event");

            if (DateTime.TryParse(eventDateStr, out DateTime eventDate) && !string.IsNullOrWhiteSpace(eventName))
            {
                string query = "INSERT INTO Events (EventName, EventDate) VALUES (@EventName, @EventDate)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventName", eventName);
                        command.Parameters.AddWithValue("@EventDate", eventDate);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Event added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEvents(); // Refresh the Events ListBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid event name or date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveEventButton_Click(object sender, EventArgs e)
        {
            // Remove the selected event from the Events table
            if (eventsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an event to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedEvent = eventsListBox.SelectedItem.ToString();
            string[] parts = selectedEvent.Split('-');
            string eventName = parts[0].Trim();

            string query = "DELETE FROM Events WHERE EventName = @EventName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventName", eventName);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Event removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEvents(); // Refresh the Events ListBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Utility class for input dialog
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }
    }
}
