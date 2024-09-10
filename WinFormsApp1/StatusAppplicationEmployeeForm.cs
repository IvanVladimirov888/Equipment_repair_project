using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class StatusAppplicationEmployeeForm : Form
    {
        public StatusAppplicationEmployeeForm()
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

        private void StatusAppplicationEmployeeForm_Load(object sender, EventArgs e)
        {
            LoadSerial_Number();
        }

        private void LoadSerial_Number()
        {
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT Serial_Number FROM Requests", connection);
                // Очищаем комбобокс перед добавлением новых значений
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["Serial_Number"].ToString());
                        comboBox1.Items.Add(reader["Serial_Number"].ToString());
                    }
                }

                db.closeConnection();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox5.Text != "" && textBox3.Text != "")
            {
                try
                {
                    if (!Regex.IsMatch(textBox6.Text, @"^\d+$"))
                    {
                        MessageBox.Show("Поле должно содержать только числовые символы!");
                        return;
                    }
                    if (!Regex.IsMatch(textBox5.Text, @"^\d+$"))
                    {
                        MessageBox.Show("Поле должно содержать только числовые символы!");
                        return;
                    }
                    string selectedIDRequests = comboBox2.SelectedItem.ToString();
                    string selectedDate = comboBox3.SelectedItem.ToString();
                    // Указываем формат даты 'dd.MM.yyyy'
                    DateTime dateValue = DateTime.ParseExact(selectedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string formattedDate = dateValue.ToString("yyyy-MM-dd");
                    // Получаем подключение к базе данных
                    DB db = new DB();
                    using (MySqlConnection connection = db.getConnection())
                    {
                        db.openConnection();
                        // Создаем команду для выполнения запроса INSERT
                        MySqlCommand command = new MySqlCommand("INSERT INTO Work_done (Work_time, Description_work, Expenses, Request_ID, Executor_ID) VALUES (@Time, @Description_work, @Expenses, @Request_ID, @Executor_ID)", connection);

                        // Получение ID
                        MySqlCommand getExecutorIDCommand = new MySqlCommand($"SELECT ID FROM Executors WHERE Email = '{LoginForm.loginActive}'", connection);
                        int executorID = (int)Convert.ToInt64(getExecutorIDCommand.ExecuteScalar());
                        command.Parameters.Add("@Executor_ID", MySqlDbType.Int64).Value = executorID;
                        command.Parameters.Add("@Time", MySqlDbType.VarChar).Value = textBox6.Text;
                        command.Parameters.Add("@Description_work", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@Expenses", MySqlDbType.VarChar).Value = textBox5.Text;

                        // Получение ID
                        MySqlCommand getRequestIDCommand = new MySqlCommand($"SELECT Requests.ID FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = '{selectedIDRequests}' AND Repair_Reports.Begin_Date = '{formattedDate}'", connection);
                        int serialID = (int)Convert.ToInt64(getRequestIDCommand.ExecuteScalar());
                        command.Parameters.Add("@Request_ID", MySqlDbType.Int64).Value = serialID;
                        command.ExecuteNonQuery();



                        // Получение текущей общей стоимости из таблицы Repair_Reports
                        MySqlCommand getTotalCostCommand = new MySqlCommand($"SELECT Total_cost FROM Repair_Reports INNER JOIN Requests ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = '{selectedIDRequests}' AND Begin_Date = '{formattedDate}'", connection);
                        double currentTotalCost = Convert.ToDouble(getTotalCostCommand.ExecuteScalar());

                        // Суммирование текущей общей стоимости с добавленными расходами
                        double newTotalCost = currentTotalCost + Convert.ToDouble(textBox5.Text);

                        // Обновление общей стоимости в таблице Repair_Reports
                        MySqlCommand updateTotalCostCommand = new MySqlCommand($"UPDATE Repair_Reports INNER JOIN Requests ON Requests.ID = Repair_Reports.Request_ID SET Total_cost = @NewTotalCost WHERE Serial_Number = '{selectedIDRequests}' AND Begin_Date = '{formattedDate}'", connection);
                        updateTotalCostCommand.Parameters.AddWithValue("@NewTotalCost", newTotalCost);
                        updateTotalCostCommand.ExecuteNonQuery();
                        // Закрываем соединение
                        db.closeConnection();
                        MessageBox.Show("Данные добавлены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            else
            {
                // Не все поля заполнены
                MessageBox.Show("Необходимо заполнить все поля!");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            string selectedSerial_Number = comboBox2.SelectedItem.ToString();
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand($"SELECT Begin_Date FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = '{selectedSerial_Number}'", connection);
                comboBox3.Items.Clear();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime beginDate = Convert.ToDateTime(reader["Begin_Date"]);
                        comboBox3.Items.Add(beginDate.Date.ToShortDateString());
                    }
                }
                db.closeConnection();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedSerialNumber = comboBox1.SelectedItem.ToString();
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand($"SELECT Begin_Date FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = '{selectedSerialNumber}'", connection);
                    comboBox4.Items.Clear();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime beginDate = Convert.ToDateTime(reader["Begin_Date"]);
                            comboBox4.Items.Add(beginDate.Date.ToShortDateString());
                        }
                    }
                    db.closeConnection();
                }

                textBox4.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedSerial_Number = comboBox2.SelectedItem.ToString();
                string selectedDate = comboBox3.SelectedItem.ToString();
                // Указываем формат даты 'dd.MM.yyyy'
                DateTime dateValue = DateTime.ParseExact(selectedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string formattedDate = dateValue.ToString("yyyy-MM-dd");

                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = @selectedSerial_Number AND Repair_Reports.Begin_Date = @Date";

                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@selectedSerial_Number", selectedSerial_Number);
                    command.Parameters.AddWithValue("@Date", formattedDate);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox3.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedSerial_Number = comboBox1.SelectedItem.ToString();
                string selectedDate = comboBox4.SelectedItem.ToString();
                // Указываем формат даты 'dd.MM.yyyy'
                DateTime dateValue = DateTime.ParseExact(selectedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string formattedDate = dateValue.ToString("yyyy-MM-dd");

                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    connection.Open();

                    string selectQuery = "SELECT Begin_Date, End_Date, Description_all_work, Used_resources, Spare_parts_needed, TRUNCATE(Total_cost, 0) as Total_cost, Coordination_with_other_specialists FROM Repair_Reports INNER JOIN Requests ON Requests.ID = Repair_Reports.Request_ID Where Serial_Number = @selectedSerial_Number AND Repair_Reports.Begin_Date = @Date";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@selectedSerial_Number", selectedSerial_Number);
                    command.Parameters.Add("@Date", MySqlDbType.VarChar).Value = formattedDate;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox7.Text = reader["Total_cost"].ToString();
                            textBox9.Text = reader["Used_resources"].ToString();
                            textBox8.Text = reader["Spare_parts_needed"].ToString();
                            textBox10.Text = reader["Coordination_with_other_specialists"].ToString();
                            textBox4.Text = reader["Description_all_work"].ToString();
                            dateTimePicker1.Value = (DateTime)reader["Begin_Date"];
                            dateTimePicker2.Value = (DateTime)reader["End_Date"];
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            // Сделать все текстовые поля доступными для редактирования
            textBox4.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            ConfirmationButton.Visible = true;
        }

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            try
            {

                // Проверка введенных данных и их сохранение в базе
                string description = textBox4.Text;
                string totalCost = textBox7.Text;
                string sparePartsNeeded = textBox8.Text;
                string usedResources = textBox9.Text;
                string coordination = textBox10.Text;
                DateTime beginDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                string formBeginDate = beginDate.ToString("yyyy-MM-dd");
                string formEndDate = beginDate.ToString("yyyy-MM-dd");
                if (endDate < beginDate)
                {
                    MessageBox.Show("Дата окончания не может быть раньше даты начала!");
                    return;
                }
                if (!Regex.IsMatch(textBox7.Text, @"^\d+(\.\d+)?$"))
                {
                    MessageBox.Show("Поле должно содержать только числовые символы!");
                    return;
                }
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    connection.Open();
                    // Обновление данных в базе данных
                    string updateQuery = $"UPDATE Repair_Reports " +
                        $"SET Begin_Date = '{formBeginDate}', " +
                        $"End_Date = '{formEndDate}', " +
                        $"Description_all_work = '{description}', " +
                        $"Used_resources = '{usedResources}', " +
                        $"Spare_parts_needed = '{sparePartsNeeded}', " +
                        $"Total_cost = '{totalCost}', " +
                        $"Coordination_with_other_specialists = '{coordination}' " +
                        $"WHERE Executor_ID = @Executor_ID AND Request_ID = @Request_ID ;";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    // Получение ID
                    MySqlCommand getExecutorIDCommand = new MySqlCommand($"SELECT ID FROM Executors WHERE Email = '{LoginForm.loginActive}'", connection);
                    int executorID = (int)Convert.ToInt64(getExecutorIDCommand.ExecuteScalar());
                    command.Parameters.Add("@Executor_ID", MySqlDbType.Int64).Value = executorID;

                    string selectedIDRequests = comboBox1.SelectedItem.ToString();
                    string selectedDate = comboBox4.SelectedItem.ToString();
                    // Указываем формат даты 'dd.MM.yyyy'
                    DateTime dateValue = DateTime.ParseExact(selectedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string formattedDate = dateValue.ToString("yyyy-MM-dd");

                    // Получение ID
                    MySqlCommand getRequestIDCommand = new MySqlCommand($"SELECT Requests.ID FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID WHERE Serial_Number = '{selectedIDRequests}' AND Repair_Reports.Begin_Date = '{formattedDate}'", connection);
                    int serialID = (int)Convert.ToInt64(getRequestIDCommand.ExecuteScalar());
                    command.Parameters.Add("@Request_ID", MySqlDbType.Int64).Value = serialID;
                    command.ExecuteNonQuery();
                    connection.Close();
                    // Сделать текстовые поля недоступными для редактирования

                    textBox4.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    ConfirmationButton.Visible = false;
                    MessageBox.Show("Итоговый отчет измененён!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка данных: " + ex.Message);
            }
        }
    }
}
