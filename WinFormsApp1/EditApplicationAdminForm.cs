using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using Point = System.Drawing.Point;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1
{
    public partial class EditApplicationAdminForm : Form
    {
        private int selectedClientId; // переменная для хранения выбранного ID клиента

        public EditApplicationAdminForm()
        {
            InitializeComponent();
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
            AdminMenuForm adminMenu = new AdminMenuForm();
            adminMenu.Show();
        }

        private void ToUsersMenuLabel_MouseEnter(object sender, EventArgs e)
        {
            ToUsersMenuLabel.ForeColor = Color.Gray;
        }

        private void ToUsersMenuLabel_MouseLeave(object sender, EventArgs e)
        {
            ToUsersMenuLabel.ForeColor = Color.White;
        }

        /// <summary>
        /// Передвижение окна.
        /// </summary>
        Point lastPoint;
        private List<string> serialNumbers;

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

        private void CreateApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditApplicationAdminForm editApplicationAdmin = new EditApplicationAdminForm();
            editApplicationAdmin.Show();
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



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // При выборе ФИО загружаем соответствующие серийные номера и получаем ID клиента
                string selectedFIO = comboBox1.SelectedItem.ToString();
                comboBox3.Items.Clear(); // Очищаем ComboBox перед добавлением новых значений
                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();
                    // Выполняем запрос на получение ID клиента по выбранному ФИО
                    MySqlCommand command = new MySqlCommand("SELECT ID FROM Clients WHERE FIO = @selectedFIO", connection);
                    command.Parameters.Add("@selectedFIO", MySqlDbType.VarChar).Value = selectedFIO;

                    // Используем ExecuteScalar для получения единственного значения (ID клиента)
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        selectedClientId = Convert.ToInt32(result); // преобразуем результат в int и сохраняем в переменную*/
                        LoadSerialNumbers(); // загружаем соответствующие серийные номера
                    }
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private string FindSerialNumberByFIO()
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedFIO = comboBox1.SelectedItem.ToString();

                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    db.openConnection();

                    try
                    {
                        MySqlCommand clientIdCommand = new MySqlCommand("SELECT ID FROM Clients WHERE FIO = @selectedFIO", connection);
                        clientIdCommand.Parameters.Add("@selectedFIO", MySqlDbType.VarChar).Value = selectedFIO;

                        int clientId = Convert.ToInt32(clientIdCommand.ExecuteScalar());

                        MySqlCommand serialNumberCommand = new MySqlCommand("SELECT Serial_Number FROM Requests INNER JOIN Errors ON Errors.ID = Requests.Errors_ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Clients ON Repair_Reports.Clients_ID = Clients.ID WHERE Clients.ID = @clientId AND Begin_Date = @selectedBegin_Date", connection);
                        serialNumberCommand.Parameters.Add("@clientId", MySqlDbType.Int32).Value = clientId;
                        DateTime day = dateTimePicker2.Value;
                        string formDate = day.ToString("yyyy-MM-dd");
                        serialNumberCommand.Parameters.Add("@selectedBegin_Date", MySqlDbType.VarChar).Value = formDate;

                        string serialNumber = serialNumberCommand.ExecuteScalar()?.ToString();

                        db.closeConnection();

                        return serialNumber;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return "";
                    }
                }
            }

            return "";
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный серийный номер
            var selectedSerialNumber = FindSerialNumberByFIO();

            if (!string.IsNullOrEmpty(selectedSerialNumber))
            {
                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Выполняем запрос на получение данных из базы данных
                    MySqlCommand command = new MySqlCommand("SELECT Serial_Number, Creation_Date, Equipment_Type, Problem_Description, Errors.Name, Executors.FIO, Request_Monitoring.Registered FROM Requests INNER JOIN Errors ON Errors.ID = Requests.Errors_ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID WHERE Requests.Serial_Number = @selectedSerialNumber AND Repair_Reports.Begin_Date = @selectedBegin_Date", connection);
                    command.Parameters.Add("@selectedSerialNumber", MySqlDbType.VarChar).Value = selectedSerialNumber;
                    DateTime day = dateTimePicker2.Value;
                    string formDate = day.ToString("yyyy-MM-dd");
                    command.Parameters.Add("@selectedBegin_Date", MySqlDbType.VarChar).Value = formDate;
                    // Выполняем запрос и используем читатель для получения данных
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем поля на форме полученными данными
                            textBox1.Text = reader["Equipment_Type"].ToString();
                            textBox2.Text = reader["Serial_Number"].ToString();
                            dateTimePicker1.Value = (DateTime)reader["Creation_Date"];
                            textBox3.Text = reader["Name"].ToString();
                            textBox5.Text = reader["FIO"].ToString();
                            textBox4.Text = reader["Problem_Description"].ToString();

                            // Заполняем значение чекбокса
                            checkBox1.Checked = Convert.ToBoolean(reader["Registered"]);

                        }
                        else
                        {
                            MessageBox.Show("Запрос не вернул результатов");
                            // Если запрос не вернул результатов, очищаем текстовые поля
                            textBox1.Text = "";
                            textBox2.Text = "";
                            dateTimePicker1.Value = DateTime.Now;
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            checkBox1.Checked = false;

                            // Делаем поля недоступными для редактирования
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                            checkBox1.Enabled = false;
                        }
                    }
                    // Закрываем соединение
                    db.closeConnection();
                }
            }
        }
        private void EditApplicationAdminForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            LoadSerialNumbers(); // Загрузить данные при загрузке формы
            LoadFIO();
            LoadPriority();
            FillExecutorsComboBox();
            PriorityComboBox();
        }






        private void LoadSerialNumbers()
        {
            // Получаем доступ к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                db.openConnection();
                // Изменяем команду запроса, добавляя параметр сортировки по ID клиента
                MySqlCommand command = new MySqlCommand("SELECT Serial_Number FROM Requests " +
                "INNER JOIN Repair_Reports ON Repair_Reports.Request_ID = Requests.ID " +
                "INNER JOIN Clients ON Repair_Reports.Clients_ID = Clients.ID WHERE Clients.ID = @ID ORDER BY Clients.ID", connection);
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = selectedClientId;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["Serial_Number"].ToString());
                    }
                }

                db.closeConnection();
            }
        }
        private void LoadFIO()
        {
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT FIO FROM Clients", connection);

                comboBox1.Items.Clear(); // Очищаем комбобокс перед добавлением новых значений

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["FIO"].ToString());
                    }
                }

                db.closeConnection();
            }
        }


        private void FillExecutorsComboBox()
        {
            try
            {
                comboBox2.Items.Clear(); // Очистим comboBox2 перед добавлением новых значений

                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Выполняем запрос на получение всех ФИО исполнителей
                    MySqlCommand command = new MySqlCommand("SELECT FIO FROM Executors", connection);

                    // Используем читатели для получения данных из базы
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["FIO"].ToString());
                        }
                    }

                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadPriority()
        {
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT Name FROM Priority", connection);

                comboBox4.Items.Clear(); // Очищаем комбобокс перед добавлением новых значений

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox4.Items.Add(reader["Name"].ToString());
                    }
                }

                db.closeConnection();
            }
        }



        private string PriorityComboBox()
        {
            string selectedPriorityName = string.Empty;
            try
            {
                comboBox4.Items.Clear();
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT Name FROM Priority", connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox4.Items.Add(reader["Name"].ToString());
                        }
                    }
                    if (comboBox4.SelectedItem != null)
                    {
                        selectedPriorityName = comboBox4.SelectedItem.ToString();
                    }
                    db.closeConnection();
                }
                return selectedPriorityName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return "";
            }
        }

        private string FindIDByPriority()
        {
            if (comboBox4.SelectedItem != null)
            {
                string selectedName = comboBox4.SelectedItem.ToString();

                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    db.openConnection();

                    try
                    {
                        MySqlCommand priorityIdCommand = new MySqlCommand("SELECT ID FROM Priority WHERE Name = @selectedName", connection);
                        priorityIdCommand.Parameters.Add("@selectedName", MySqlDbType.VarChar).Value = selectedName;

                        int priorityId = Convert.ToInt32(priorityIdCommand.ExecuteScalar());

                        db.closeConnection();

                        return priorityId.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return "";
                    }
                }
            }

            return "";
        }

        // Обработчик события comboBox2_SelectedIndexChanged
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                // Присваиваем выбранное ФИО из comboBox2 в textBox5
                textBox5.Text = comboBox2.SelectedItem.ToString();
            }
        }

        private void EditApplication_Click(object sender, EventArgs e)
        {
            ConfirmationButton.Visible = true;
            LoadSerialNumbers(); // Загрузить данные при загрузке формы
            FillExecutorsComboBox();
            PriorityComboBox();
            // Делаем поля доступными для редактирования
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox2.Enabled = true;
            comboBox4.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            var selectedSerialNumber = FindSerialNumberByFIO();
            var selectedPriorityID = FindIDByPriority();
            // Получаем доступ к базе данных
            DB db = new DB();
            try
            {
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Создаем команду SQL для обновления данных
                    MySqlCommand command = new MySqlCommand(@"UPDATE Requests
                                                INNER JOIN Errors ON Requests.Errors_ID = Errors.ID
                                                INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID
                                                INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
                                                INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID
                                                INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID
                                                SET Requests.Equipment_Type = @Equipment_Type,
                                                Requests.Serial_Number = @Serial_Number,
                                                Requests.Creation_Date = @Creation_Date,
                                                Errors.Name = @Name,
                                                Repair_Reports.Executor_ID = @ExecutorID,
                                                Requests.Problem_Description = @Problem_Description,
                                                Work_done.Executor_ID = @ExecutorID,
                                                Request_Monitoring.Priority_ID = @PriorityID
                                                WHERE Requests.Serial_Number = @SerialNumber AND Repair_Reports.Begin_Date = @selectedBeginDate;", connection);

                    // Установка значений параметров
                    command.Parameters.AddWithValue("@Equipment_Type", textBox1.Text);
                    command.Parameters.AddWithValue("@Serial_Number", textBox2.Text);
                    command.Parameters.AddWithValue("@Creation_Date", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@Name", textBox3.Text);
                    command.Parameters.AddWithValue("@FIO", textBox5.Text); // Заменили textBox5.Text на textBox с выбором ID исполнителя
                    command.Parameters.AddWithValue("@Problem_Description", textBox4.Text);

                    // Получаем ExecutorID
                    MySqlCommand command1 = new MySqlCommand("SELECT ID FROM Executors WHERE FIO = @FIO", connection);
                    command1.Parameters.AddWithValue("@FIO", textBox5.Text);
                    int executorID = Convert.ToInt32(command1.ExecuteScalar());
                    command1.ExecuteNonQuery();
                    command.Parameters.AddWithValue("@ExecutorID", executorID);
                    command.Parameters.AddWithValue("@PriorityID", selectedPriorityID);

                    // Форматируем выбранную дату
                    string selectedBeginDate = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                    command.Parameters.AddWithValue("@selectedBeginDate", selectedBeginDate);

                    // Добавляем ID заявки
                    command.Parameters.AddWithValue("@SerialNumber", selectedSerialNumber);

                    // Выполняем запрос на обновление данных в базе
                    command.ExecuteNonQuery();
                    ConfirmationButton.Visible = false; // Скрываем кнопку подтверждения
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var selectedSerialNumber = FindSerialNumberByFIO();
            // Проверяем, является ли чекбокс отмеченным
            if (checkBox1.Checked = true)
            {
                // Получаем доступ к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    // Открываем соединение
                    db.openConnection();

                    // Получаем текущее время
                    DateTime timeAcceptance = DateTime.Now;

                    try
                    {
                        // Создаем команду SQL для обновления данных
                        MySqlCommand commandUpdate = new MySqlCommand("UPDATE Request_Monitoring INNER JOIN Requests ON Requests.ID = Request_Monitoring.Request_ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID SET Registered = true, Time_acceptance = @Time_acceptance, Processing_time = TIMESTAMPDIFF(MINUTE, Time_receipt, Time_acceptance) WHERE Serial_Number = @selectedSerialNumber AND Repair_Reports.Begin_Date = @selectedBegin_Date;", connection);

                        // Присваиваем значения параметрам для запроса
                        commandUpdate.Parameters.AddWithValue("@Time_acceptance", timeAcceptance);
                        commandUpdate.Parameters.Add("@selectedSerialNumber", MySqlDbType.VarChar).Value = selectedSerialNumber;
                        DateTime day = dateTimePicker2.Value;
                        string formDate = day.ToString("yyyy-MM-dd");
                        commandUpdate.Parameters.Add("@selectedBegin_Date", MySqlDbType.VarChar).Value = formDate;

                        // Выполняем запрос на обновление данных
                        commandUpdate.ExecuteNonQuery();

                        // Делаем чекбокс недоступным для редактирования
                        checkBox1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
                    }

                    // Закрываем соединение
                    db.closeConnection();
                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            // Подключение к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Получение серийного номера из формы
                string serialNumber = textBox2.Text;
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM Requests WHERE Serial_Number = @SerialNumber;", connection);
                command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                command.ExecuteNonQuery();
                connection.Close();
            }
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            LoadSerialNumbers(); 
            LoadFIO();
            LoadPriority();
            FillExecutorsComboBox();
            PriorityComboBox();
        }
    }
}
