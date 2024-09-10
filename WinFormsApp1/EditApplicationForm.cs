using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
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
    public partial class EditApplicationForm : Form
    {
        public EditApplicationForm()
        {
            InitializeComponent();
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

        private void ToUsersMenuLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersMenuForm usersMenu = new UsersMenuForm();
            usersMenu.Show();
        }

        private void ToUsersMenuLabel_MouseEnter(object sender, EventArgs e)
        {
            ToUsersMenuLabel.ForeColor = Color.Gray;
        }

        private void ToUsersMenuLabel_MouseLeave(object sender, EventArgs e)
        {
            ToUsersMenuLabel.ForeColor = Color.White;
        }

        private void LoadSerialNumbers()
        {
            // Получаем доступ к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                db.openConnection();

                // Выполняем запрос на получение серийных номеров из базы данных
                MySqlCommand command = new MySqlCommand($"SELECT Serial_Number FROM Requests INNER JOIN Repair_Reports on Repair_Reports.Request_ID = Requests.ID INNER JOIN Clients on Repair_Reports.Clients_ID = Clients.ID  WHERE Email = '{LoginForm.loginActive ?? RegisterForm.loginActive}'", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Очищаем ComboBox
                    comboBox1.Items.Clear();

                    // Добавляем значения в ComboBox из базы данных
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Serial_Number"].ToString());
                    }
                }

                // Закрываем соединение
                db.closeConnection();
            }
        }

        // Используйте этот метод вместо EditApplication_Click
        private void EditApplication_Click(object sender, EventArgs e)
        {
            LoadSerialNumbers(); // Загрузить серийные номера в ComboBox

            ConfirmationButton.Visible = false; // Скрыть кнопку подтверждения, пока не выбран серийный номер
        }

        // Используйте этот код для выбора данных при выборе элемента в ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный серийный номер
            var selectedSerialNumber = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSerialNumber))
            {
                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Выполняем запрос на получение данных из базы данных
                    MySqlCommand command = new MySqlCommand("SELECT Serial_Number, Creation_Date, Equipment_Type, Problem_Description, Errors.Name FROM Requests INNER JOIN Errors ON Requests.Errors_ID = Errors.ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = @selectedSerialNumber AND Begin_Date = @selectedBegin_Date", connection);
                    command.Parameters.Add("@selectedSerialNumber", MySqlDbType.VarChar).Value = selectedSerialNumber;
                    command.Parameters.Add("@selectedBegin_Date", MySqlDbType.Date).Value = dateTimePicker2.Value;
                    // Используем читатели для получения данных из базы
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем поля на форме полученными данными
                            textBox1.Text = reader["Equipment_Type"].ToString();
                            textBox2.Text = reader["Serial_Number"].ToString();
                            dateTimePicker1.Value = (DateTime)reader["Creation_Date"];
                            textBox3.Text = reader["Name"].ToString();
                            textBox4.Text = reader["Problem_Description"].ToString();

                            // Делаем поля доступными для редактирования
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            dateTimePicker1.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            ConfirmationButton.Visible = true;
                        }
                    }

                    // Закрываем соединение
                    db.closeConnection();
                }
            }
        }

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedSerialNumber = comboBox1.SelectedItem?.ToString();
                DateTime date1 = dateTimePicker2.Value;
                string formDate1 = date1.ToString("yyyy-MM-dd");
                DateTime date2 = dateTimePicker1.Value;
                string formDate2 = date2.ToString("yyyy-MM-dd");
                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Выполняем запрос на обновление данных в базе
                    MySqlCommand command = new MySqlCommand("UPDATE Requests " +
                                                            "INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID " +
                                                            "INNER JOIN Errors ON Requests.Errors_ID = Errors.ID " +
                                                            "SET Requests.Equipment_Type = @Equipment_Type, " +
                                                            "Requests.Creation_Date = @Creation_Date, " +
                                                            "Requests.Problem_Description = @Problem_Description, " +
                                                            "Errors.Name = @Name, " +
                                                            "Requests.Serial_Number = @NewSerial_Number " +
                                                            "WHERE Requests.Serial_Number = @selectedSerialNumber AND Repair_Reports.Begin_Date = @selectedBegin_Date;", connection);

                    command.Parameters.AddWithValue("@Equipment_Type", textBox1.Text);
                    command.Parameters.AddWithValue("@Creation_Date", formDate2);
                    command.Parameters.AddWithValue("@Problem_Description", textBox4.Text);
                    command.Parameters.AddWithValue("@Name", textBox3.Text);
                    command.Parameters.AddWithValue("@NewSerial_Number", textBox2.Text);
                    command.Parameters.AddWithValue("@selectedSerialNumber", selectedSerialNumber);
                    command.Parameters.AddWithValue("@selectedBegin_Date", formDate1);

                    // Выполняем запрос на обновление данных
                    command.ExecuteNonQuery();

                    // Закрываем соединение
                    db.closeConnection();
                }

                // Делаем поля доступными для редактирования
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                ConfirmationButton.Visible = false;
                MessageBox.Show("Заявка изменена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void EditApplicationForm_Load(object sender, EventArgs e)
        {
            LoadSerialNumbers(); // Загрузить данные при загрузке формы
        }
    }
}