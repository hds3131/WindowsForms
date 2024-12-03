using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsForms
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;  // Assuming a TextBox for Name
            string email = textBox4.Text;  // Assuming a TextBox for Email
            string feedback = textBox8.Text;  // Assuming a TextBox for Feedback

            SubmitFeedback(name, email, feedback);
        }

        public void SubmitFeedback(string name, string email, string feedback)
        {
            // Connection string using Integrated Security
            string connectionString = "Server=localhost;Database=FeedbackDB;Integrated Security=True;";

            try
            {
                // 'using' block to handle the database connection
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();  // Open the connection to MySQL

                    // SQL query to insert data
                    string query = "INSERT INTO FeedbackTable (Name, Email, Feedback) VALUES (@Name, @Email, @Feedback)";

                    // 'using' block to handle the command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Feedback", feedback);

                        cmd.ExecuteNonQuery();  // Execute the query
                    }
                }

                // Success message
                MessageBox.Show("Feedback submitted successfully!");
            }
            catch (Exception ex)
            {
                // Error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
