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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsForms
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            linkLabel4.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel4_LinkClicked);
            LoadVisitorChart();

        }

        private void LoadVisitorChart()
        {
            string connectionString = @"Server=np:\\.\pipe\LOCALDB#154346C2\tsql\query;Database=mydb;Integrated Security=true;";
            string query = "SELECT IsMember, COUNT(*) AS Count FROM VisitorTracking GROUP BY IsMember";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        chartVisitorTracking.Series.Clear();

                        // Create a new series for the chart
                        Series series = new Series
                        {
                            Name = "Visitor Data",
                            ChartType = SeriesChartType.Bar, // Set this to Line for a line chart
                            IsValueShownAsLabel = true // Display values on the chart
                        };

                        // Initialize counts for both members and non-members
                        int memberCount = 0;
                        int nonMemberCount = 0;

                        while (reader.Read())
                        {
                            bool isMember = reader.GetBoolean(0);
                            int count = reader.GetInt32(1);

                            if (isMember)
                            {
                                memberCount = count;
                            }
                            else
                            {
                                nonMemberCount = count;
                            }
                        }

                        // Add data points to the chart series
                        series.Points.AddXY("Members", memberCount);
                        series.Points.AddXY("Non-Members", nonMemberCount);

                        // Set custom colors for each point if desired
                        series.Points[0].Color = Color.Blue; // Members
                        series.Points[1].Color = Color.Orange; // Non-Members

                        chartVisitorTracking.Series.Add(series);

                        // Set chart area properties for better visual representation
                        chartVisitorTracking.ChartAreas[0].AxisX.Title = "Category";
                        chartVisitorTracking.ChartAreas[0].AxisY.Title = "Count";
                        chartVisitorTracking.ChartAreas[0].AxisX.Interval = 1;
                        chartVisitorTracking.ChartAreas[0].RecalculateAxesScale();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chartVisitorTracking_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 homeForm = new Form5();
            homeForm.Show();
            // Close the current form
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        private Form3 logoutForm = null;
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (logoutForm == null || logoutForm.IsDisposed)
            {
                logoutForm = new Form3();
                logoutForm.Show();
                this.Hide(); // Hide the current form to keep only the new form open

                // When Form3 is closed, reset the reference to null
                logoutForm.FormClosed += (s, args) => logoutForm = null;
            }
        }
    }
}



       
