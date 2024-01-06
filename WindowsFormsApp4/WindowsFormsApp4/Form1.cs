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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(789, 253);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();
            ConnectToDatabase();
        }



        private void PopulateComboBoxes()
        {
            List<string> flightClasses = new List<string>()
            {
                "Economy Class",
                "Premium Economy",
                "Business Class",
                "First Class"
            };

            List<string> cities = new List<string>()
            {
                "New York", "London", "Paris", "Berlin", "Rome", "Madrid", "Lisbon", "Dublin", "Edinburgh", "Oslo", "Helsinki", "Copenhagen", "Amsterdam", "Brussels", "Vienna", "Budapest", "Prague", "Warsaw", "Athens", "Istanbul", "Moscow"
            };

            comboBox2.Items.AddRange(cities.Distinct().ToArray());
            comboBox3.Items.AddRange(cities.Distinct().ToArray());
            comboBox1.Items.AddRange(flightClasses.ToArray());
        }


        private void ConnectToDatabase()
        {
            string connectionString = "server=SKYNET\\SQLEXPRESS;database=FLIGHT;UID=guest";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "SELECT * FROM Accounts ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.AppendLine(reader[i].ToString());
                    }
                }
                reader.Close();
                MessageBox.Show(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Departure = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";
            string Destination = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : "";

            string connectionString = "server=SKYNET\\SQLEXPRESS;database=FLIGHT;UID=guest";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = $"SELECT * FROM Flights AS F WHERE '{Departure}' = F.DepartureCity AND '{Destination}' = F.ArrivalCity ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.AppendLine(reader[i].ToString());
                    }
                }
                reader.Close();
                MessageBox.Show(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
    }
}
