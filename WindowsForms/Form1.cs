using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsForms.Form2;
using System.Data.SqlClient;

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


                string connectionString = @"Server=np:\\.\pipe\LOCALDB#D105A1FD\tsql\query;Database=mydb;Integrated Security=true;";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Query to check if the username and password match any record in the Users table
                        string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Use parameters to avoid SQL injection
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 1)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

    }
    }
    
    


    

