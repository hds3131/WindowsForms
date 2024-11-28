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
using BCrypt.Net;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.PasswordChar = '•';
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
            string username = textBox3.Text;
            string password = textBox4.Text;

            string connectionString = @"Server=np:\\.\pipe\LOCALDB#154346C2\tsql\query;Database=mydb;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to get the hashed password from the database
                    string query = "SELECT Password FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        var dbPassword = command.ExecuteScalar() as string;

                        if (dbPassword != null && BCrypt.Net.BCrypt.Verify(password, dbPassword))
                        {
                            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, dbPassword);
                            if (isValidPassword)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                Form6 form6 = new Form6();
                                form6.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
