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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private readonly string _connectionString = "Data Source=DESKTOP-8RU4O9V\\MSSQLFLUFFY; Initial Catalog=test_1; Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM log_1";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                           
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                listBox1.Items.Clear();
                                listBox1.Items.Add("Выбирает из таблицы МАРШРУТЫ информацию о маршрутах в некоторую заданную страну: \n\n");
                                listBox1.Items.Add("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                                while (reader.Read())
                                {
                                    listBox1.Items.Add("Cod_routes: " + reader["nomer_3"].ToString() + "; Destination_country: " + reader["login"].ToString() + "; Cost_of_1_day_stay: " + reader["pass"].ToString() + "; The_cost_transport_services: " + reader["yroven"].ToString());
                                    listBox1.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
