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

        // Load events from the database
        private void LoadEvents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT EventID, EventName, EventDate FROM Events ORDER BY EventDate";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    eventsListBox.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string eventInfo = $"{row["EventID"]} - {row["EventName"]} - {Convert.ToDateTime(row["EventDate"]).ToString("dd MMM yyyy")}";
                        eventsListBox.Items.Add(eventInfo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Load payments from the database
        private void LoadPayments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p.PaymentID, e.EventName, p.PaymentDate, p.Amount FROM Payments p JOIN Events e ON p.EventID = e.EventID ORDER BY p.PaymentDate";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    paymentsListBox.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string paymentInfo = $"PaymentID: {row["PaymentID"]}, Event: {row["EventName"]}, Date: {Convert.ToDateTime(row["PaymentDate"]).ToString("dd MMM yyyy")}, Amount: ${row["Amount"]}";
                        paymentsListBox.Items.Add(paymentInfo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Add a new event
        private void addEventButton_Click(object sender, EventArgs e)
        {
            string eventName = Prompt.ShowDialog("Enter Event Name:", "Add Event");
            string eventDateInput = Prompt.ShowDialog("Enter Event Date (YYYY-MM-DD):", "Add Event");

            if (!DateTime.TryParse(eventDateInput, out DateTime eventDate))
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Events (EventName, EventDate) VALUES (@EventName, @EventDate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventName", eventName);
                    command.Parameters.AddWithValue("@EventDate", eventDate);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEvents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Remove an event
        private void removeEventButton_Click(object sender, EventArgs e)
        {
            if (eventsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an event to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedEvent = eventsListBox.SelectedItem.ToString();
            int eventId = int.Parse(selectedEvent.Split('-')[0].Trim());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Events WHERE EventID = @EventID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventID", eventId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Event removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEvents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Helper class for input dialogs
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
