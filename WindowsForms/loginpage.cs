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
            InitializeComponent();//hi amy
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


                string connectionString = @"Server=np:\\.\pipe\LOCALDB#154346C2\tsql\query;Database=mydb;Integrated Security=true;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Query to check if the user credentials match
                        string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 1)
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
            // Rest of your code remains unchanged...
        }
    }

}
    
    

    


    

