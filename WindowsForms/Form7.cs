using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
<<<<<<< HEAD
=======
            LoadVisitorChart();
>>>>>>> parent of 9277bb5 (form 7 almost completed)
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
<<<<<<< HEAD
            //yuhkj
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
=======
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

                        Series series = new Series
                        {
                            Name = "Visitors",
                            ChartType = SeriesChartType.Pie, // You can use Pie, Bar, or Column
                            IsValueShownAsLabel = true
                        };

                        while (reader.Read())
                        {
                            bool isMember = reader.GetBoolean(0);
                            int count = reader.GetInt32(1);
                            string label = isMember ? "Members" : "Non-Members";
                            series.Points.AddXY(label, count);
                        }

                        chartVisitorTracking.Series.Add(series);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


       
>>>>>>> parent of 9277bb5 (form 7 almost completed)
