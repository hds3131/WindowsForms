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
    public partial class EventsPayment : Form
    {
        private string eventDetails;

        public EventsPayment(string eventDetails)
        {
            InitializeComponent();
            GenerateRandomAmount();
            this.eventDetails = eventDetails;
        }


        public void SubmitPayment(string cardType, string cardNumber, string expiryDate, string cvc)
        {
            // Use the connection string from App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert payment details
                    string query = "INSERT INTO PaymentDetails (CardType, CardNumber, ExpiryDate, CVC) VALUES (@CardType, @CardNumber, @ExpiryDate, @CVC)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CardType", cardType);
                        cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                        cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                        cmd.Parameters.AddWithValue("@CVC", cvc);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payment submitted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Debit and Credit button handlers remain the same
        private void button6_Click(object sender, EventArgs e)
        {
            string cardType = "Debit Card";
            string cardNumber = textBox4.Text; // Adjust control names as necessary
            string expiryDate = textBox6.Text;
            string cvc = textBox8.Text;

            SubmitPayment(cardType, cardNumber, expiryDate, cvc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cardType = "Credit Card";
            string cardNumber = textBox11.Text; // Adjust control names as necessary
            string expiryDate = textBox13.Text;
            string cvc = textBox15.Text;

            SubmitPayment(cardType, cardNumber, expiryDate, cvc);
        }

        public void SubmitBilling(string firstName, string lastName, string address)
        {
            // Use the connection string from App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert billing details
                    string query = "INSERT INTO BillingDetails (FirstName, LastName, Address) VALUES (@FirstName, @LastName, @Address)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Address", address);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Billing details saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void buttonSaveBilling_Click(object sender, EventArgs e)
        {
            string firstName = textBox18.Text; // Adjust control names as necessary
            string lastName = textBox20.Text;
            string address = textBox22.Text;

            SubmitBilling(firstName, lastName, address);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerateRandomAmount()
        {
            // Define the possible amounts
            int[] possibleAmounts = { 5, 10, 15, 20, 30, 40 };

            // Generate a random number
            Random random = new Random();
            int index = random.Next(possibleAmounts.Length);

            // Set the label text
            label1.Text = $"Amount Due: £{possibleAmounts[index]}";
        }
    }
}
