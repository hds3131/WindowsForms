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
    public partial class Form6 : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;
        public Form6()
        {
            InitializeComponent();
        }



        private void dataGridView17_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Call the method to update DataGridView when the form loads
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            // Create SQL query to fetch required data from the Event table, ordered by Date in descending order
            string query = "SELECT EventName, Date, Location, EventType FROM [dbo].[Event] ORDER BY Date DESC";

            // Create a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create a data adapter to fill the data into a DataTable
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Add a new column for the status (Upcoming, Passed, Today)
                    dt.Columns.Add("EventStatus", typeof(string));

                    // Loop through the rows in the DataTable to set the EventStatus column
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime eventDate = Convert.ToDateTime(row["Date"]);
                        if (eventDate.Date == DateTime.Today) // Event is today
                        {
                            row["EventStatus"] = "Today";
                        }
                        else if (eventDate.Date > DateTime.Today) // Event is in the future
                        {
                            row["EventStatus"] = "Upcoming";
                        }
                        else // Event is in the past
                        {
                            row["EventStatus"] = "Passed";
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView5.DataSource = dt;
                }
                catch (Exception ex)
                {
                    // Handle any errors (e.g., connection issues)
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewEvent addNewEvent = new AddNewEvent();
            addNewEvent.ShowDialog();
            if (addNewEvent.DialogResult == DialogResult.OK)
            {
                // If the event was successfully added, update the DataGridView
                UpdateDataGridView();
            }

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void dataGridView14_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
