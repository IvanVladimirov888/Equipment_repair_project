using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            // Очистим информацию о пользователе
            Authorization.Role = null;
            Authorization.User = null;
            Authorization.FIO = null;
            LoginForm.loginActive = "";
            RegisterForm.loginActive = "";
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void ToEmployeeMenuLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMenuForm employeeMenu = new EmployeeMenuForm();
            employeeMenu.Show();
        }

        private void ToEmployeeMenuLabel_MouseEnter(object sender, EventArgs e)
        {
            ToEmployeeMenuLabel.ForeColor = Color.Gray;
        }

        private void ToEmployeeMenuLabel_MouseLeave(object sender, EventArgs e)
        {
            ToEmployeeMenuLabel.ForeColor = Color.White;
        }

        /// <summary>
        /// Передвижение окна.
        /// </summary>
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        /// <summary>
        /// Запоминание позиции курсора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            CalculateData();
            FillErrorsComboBox();
        }

        private const string ConnectionString = "user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems";

        public void CalculateData()
        {
            try
            {
                long completedRequestsCount = CalculateCompletedRequestsCount(); // Изменено на тип long
                double averageExecutionTime = CalculateAverageExecutionTime();
                textBox1.Text = completedRequestsCount.ToString();
                textBox2.Text = averageExecutionTime.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }

        private long CalculateCompletedRequestsCount() // Изменен тип возвращаемого значения на long
        {
            long completedRequestsCount = 0;
            string Login = LoginForm.loginActive;
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID  WHERE Repair_Reports.End_Date <> Repair_Reports.Begin_Date AND Executors.Email = @Login;", connection);
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                {
                    completedRequestsCount = (long)command.ExecuteScalar(); // Изменено на тип long
                }
                connection.Close();
                return completedRequestsCount;
            }
        }

        private double CalculateAverageExecutionTime()
        {
            double averageExecutionTime = 0;
            string Login = LoginForm.loginActive;
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT AVG(Work_time) FROM Work_done INNER JOIN Executors ON Executors.ID = Work_done.Executor_ID  WHERE Executors.Email = @Login;", connection);
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        averageExecutionTime = Convert.ToDouble(result);
                    }
                }
                connection.Close();
                return averageExecutionTime;
            }
        }

        private void FillErrorsComboBox()
        {
            comboBox1.Items.Clear(); // Очистка comboBox1 перед заполнением
            string Login = LoginForm.loginActive;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Name FROM Requests INNER JOIN Errors ON Requests.Errors_ID = Errors.ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID WHERE Executors.Email = @Login;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string errorName = reader["Name"].ToString();
                        comboBox1.Items.Add(errorName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems"; // Замените на вашу строку подключения
            string ErrorsName = comboBox1.SelectedItem as string;
            string Login = LoginForm.loginActive;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Repair_Reports.Begin_Date, Repair_Reports.End_Date, Priority.Name, Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors.Name " +
                                " FROM Requests " +
                                " INNER JOIN Errors ON Requests.Errors_ID = Errors.ID " +
                                " INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID " +
                                " INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID " +
                                " INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID " +
                                " INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID " +
                                " INNER JOIN Priority ON Priority.ID = Request_Monitoring.Priority_ID " +
                                " WHERE Begin_Date <> End_Date AND Errors.Name = @Name AND Executors.Email = @Login;";


                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = ErrorsName;
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
