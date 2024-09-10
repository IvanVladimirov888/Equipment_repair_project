using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ApplicationListForm : Form
    {
        public ApplicationListForm()
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

        private void ToEmployeeLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMenuForm employeeMenu = new EmployeeMenuForm();
            employeeMenu.Show();
        }

        private void ToEmployeeLabel_MouseEnter(object sender, EventArgs e)
        {
            ToEmployeeLabel.ForeColor = Color.Gray;
        }

        private void ToEmployeeLabel_MouseLeave(object sender, EventArgs e)
        {
            ToEmployeeLabel.ForeColor = Color.White;
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

        private void ApplicationListForm_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }
        private void FillDataGridView()
        {
            try
            {
                string connectionString = "user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems"; // Замените на вашу строку подключения

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Repair_Reports.Begin_Date, Request_Monitoring.Registered, Priority.Name, Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors.Name " +
                                   "FROM Requests " +
                                   "INNER JOIN Errors ON Requests.Errors_ID = Errors.ID " +
                                   "INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID " +
                                   "INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID " +
                                   "INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID " +
                                   "INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID " +
                                   "INNER JOIN Priority ON Priority.ID = Request_Monitoring.Priority_ID " +
                                   "WHERE Request_Monitoring.Registered = true " +
                                   "ORDER BY Repair_Reports.Begin_Date DESC";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }
    }
}
