﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace WindowsForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox6.PasswordChar = '•';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminId = textBox2.Text;
            string email = textBox4.Text;
            string password = textBox6.Text;

            // Connection string for your local database
            string connectionString = @"Server=np:\\.\pipe\LOCALDB#653b9183\tsql\query;Database=mydbs;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Corrected query with the exact column names
                    string query = "SELECT Password FROM admin WHERE AdminID = @AdminId AND Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@AdminId", adminId);
                        command.Parameters.AddWithValue("@Email", email);

                        var dbPassword = command.ExecuteScalar() as string;

                        if (dbPassword != null && BCrypt.Net.BCrypt.Verify(password, dbPassword))
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Navigate to the admin dashboard or perform other actions as needed
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Admin ID, Email, or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur during connection or query execution
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
