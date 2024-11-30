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
            string connectionString = @"Server=np:\\.\pipe\LOCALDB#154346C2\tsql\query;Database=mydb;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to get the visitor tracking data
                    string query = "SELECT VisitDate, IsMember, COUNT(*) AS VisitCount FROM VisitorTracking GROUP BY VisitDate, IsMember";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        chartVisitorTracking.Series.Clear();

                        Series membersSeries = new Series("Members");
                        membersSeries.ChartType = SeriesChartType.Line;
                        membersSeries.BorderWidth = 2;

                        Series nonMembersSeries = new Series("Non-Members");
                        nonMembersSeries.ChartType = SeriesChartType.Line;
                        nonMembersSeries.BorderWidth = 2;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime visitDate = Convert.ToDateTime(row["VisitDate"]);
                            bool isMember = Convert.ToBoolean(row["IsMember"]);
                            int visitCount = Convert.ToInt32(row["VisitCount"]);

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
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
