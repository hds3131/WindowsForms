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
            LoadVisitorTrackingData();

        }

        private void LoadVisitorTrackingData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServiceBasedDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT VisitDate, IsMember, COUNT(*) AS VisitCount FROM VisitorTracking GROUP BY VisitDate, IsMember";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        chartVisitorTracking.Series.Clear();

                        Series membersSeries = new Series("Members")
                        {
                            ChartType = SeriesChartType.Line,
                            BorderWidth = 2
                        };

                        Series nonMembersSeries = new Series("Non-Members")
                        {
                            ChartType = SeriesChartType.Line,
                            BorderWidth = 2
                        };

                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime visitDate = row["VisitDate"] != DBNull.Value ? Convert.ToDateTime(row["VisitDate"]) : DateTime.MinValue;
                            bool isMember = row["IsMember"] != DBNull.Value && Convert.ToBoolean(row["IsMember"]);
                            int visitCount = row["VisitCount"] != DBNull.Value ? Convert.ToInt32(row["VisitCount"]) : 0;

                            if (isMember)
                            {
                                membersSeries.Points.AddXY(visitDate, visitCount);
                            }
                            else
                            {
                                nonMembersSeries.Points.AddXY(visitDate, visitCount);
                            }
                        }

                        chartVisitorTracking.Series.Add(membersSeries);
                        chartVisitorTracking.Series.Add(nonMembersSeries);

                        chartVisitorTracking.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
                        chartVisitorTracking.ChartAreas[0].AxisX.Interval = 1;
                        chartVisitorTracking.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                        chartVisitorTracking.ChartAreas[0].AxisX.Title = "Visit Date";
                        chartVisitorTracking.ChartAreas[0].AxisY.Title = "Visit Count";
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
            LoadVisitorTrackingData();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 signUpForm = new Form1();
            signUpForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 Eventsform = new Form10();
            Eventsform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 signUpForm = new Form5("192129");
            signUpForm.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    }

