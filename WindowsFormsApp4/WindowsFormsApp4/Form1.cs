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
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<Flight> flights = new List<Flight>();
        private ListBox listBox2 = new ListBox();
        string flightInfo;

        public class Flight
        {
            public string Origin { get; set; }
            public string Destination { get; set; }
            public string Departure { get; set; }
            public string Arrival { get; set; }
            public string Status { get; set; }
        }
        public Form1()
        {
           
            this.ClientSize = new System.Drawing.Size(1800, 600); 
            this.Size = new System.Drawing.Size(2900, 700); 
            this.MinimumSize = new System.Drawing.Size(2800, 1400); 
            this.MaximumSize = new System.Drawing.Size(1100, 750); 
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(789, 253);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            InitializeComponent();
            listBox1.Visible = false;



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
            comboBox1.Text = "Class";
            comboBox2.Text = "Destination";
            comboBox3.Text = "Departure";
            List<string> cities = new List<string>()
            {
                "New York", "London", "Paris", "Berlin", "Rome", "Madrid", "Lisbon", "Dublin", "Edinburgh", "Oslo", "Helsinki", "Copenhagen", "Amsterdam", "Brussels", "Vienna", "Budapest", "Prague", "Warsaw", "Athens", "Istanbul", "Moscow"
            };

            comboBox2.Items.AddRange(cities.Distinct().ToArray());
            comboBox3.Items.AddRange(cities.Distinct().ToArray());
            comboBox1.Items.AddRange(flightClasses.ToArray());

            List<DateTime> randomDates = new List<DateTime>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                DateTime randomDate = DateTime.Now.AddDays(random.Next(1, 7));
                DateTime randomTime = randomDate.AddHours(random.Next(1, 24));
                randomDates.Add(randomTime);
            }

            foreach (DateTime date in randomDates)
            {
                comboBox4.Items.Add(date.ToString("dd/MM/yyyy HH:mm"));
            }
            comboBox4.Text = "Availble Date and time";
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
                System.Windows.Forms.MessageBox.Show(sb.ToString());
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

          //  test();
        }

        public void test()
        {
            string query = "SELECT TOP 1 FirstName FROM Accounts connection Success";

            try
            {
                string connectionString = "Data Source=SKYNET\\SQLEXPRESS;Initial Catalog=FLIGHT;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            System.Windows.Forms.MessageBox.Show("Fetched data from the database: " + result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error executing query: " + ex.Message);
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
            listBox1.Visible = true;



            string DestinationDestination = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";
            string Destination = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : "";



            availableFlight(Destination, Destination);
            


        }

        public  void availableFlight(string departureCity, string arrivalCity) {


            string connectionString = "Data Source=SKYNET\\SQLEXPRESS;Initial Catalog=FLIGHT;Integrated Security=True";

            string query = $"SELECT * FROM Flights AS F WHERE @DepartureCity = F.DepartureCity AND @ArrivalCity = F.ArrivalCity";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DepartureCity", departureCity);
                        cmd.Parameters.AddWithValue("@ArrivalCity", arrivalCity);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            listBox1.Items.Clear(); // Clear existing items
                            while (reader.Read())
                            {
                                 flightInfo = GetFlightInfo(reader);
                                
                                listBox1.Items.Add(flightInfo);
                               
                              

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error fetching flights: " + ex.Message);
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
        private string GetFlightInfo(SqlDataReader reader)
        {
            System.Windows.Forms.MessageBox.Show("INFO GOTTEN");

            string origin = reader["DepartureCity"].ToString();
            string destination = reader["ArrivalCity"].ToString();
            string departureTime = reader["DepartureTime"].ToString();
            string arrivalTime = reader["ArrivalTime"].ToString();
            string Level = comboBox1.SelectedItem.ToString();

            TimeSpan duration = DateTime.Parse(arrivalTime) - DateTime.Parse(departureTime);
            string formattedDuration = duration.ToString(@"hh\:mm");

            System.Windows.Forms.MessageBox.Show(" GetFlightInfo");

            return $"{origin} - {destination} ({Level}) | " +
                   $"Departs: {departureTime} | Arrives: {arrivalTime} | " +
                   $"Duration: {formattedDuration}";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 anotherForm = new Form1();  
            anotherForm.Show();

          
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
            //  set transition....
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(fadeAnimation);

            // Start the transition 
            storyboard.Begin();

            // Hide the current form after the animation completes
            storyboard.Completed += (s, args) => this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

