using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
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

        private void CreateApplication_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Value != null && textBox3.Text != "" && textBox4.Text != "")
            {
                // Проверка на ввод числовых данных в поле Serial_Number
                if (!Regex.IsMatch(textBox2.Text, @"^\d+$"))
                {
                    MessageBox.Show("Поле Serial_Number должно содержать только числовые символы!");
                    return; // Прерываем выполнение метода
                }

                // Проверка на использование определенных символов
                string[] restrictedSymbols = { "*", "&", "{", "}", "|", "+", "-", "@", "_", "(", ")", "№", "\"", "'", "#", ";", ":", "%", "&", ".", ",", "?", "~", "!", "=", "\\", "/" };
                if (restrictedSymbols.Any(symbol => textBox1.Text.Contains(symbol) || textBox2.Text.Contains(symbol) || textBox3.Text.Contains(symbol)))
                {
                    MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                    return; // Прерываем выполнение метода
                }
                // Все поля заполнены

                // Получаем подключение к базе данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    //Сегодняшняя дата
                    DateTime today = DateTime.Today;
                    string formDate = today.ToString("yyyy-MM-dd");
                    //Время, которое сейчас
                    DateTime currentTime = DateTime.Now;
                    string formattedTime = currentTime.ToString("HH:mm:ss");

                    db.openConnection();
                    // Создаем команду для выполнения запроса INSERT
                    MySqlCommand command1 = new MySqlCommand("INSERT INTO Errors (Name) VALUES (@Name)", connection);
                    MySqlCommand command2 = new MySqlCommand("INSERT INTO Requests (Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors_ID) VALUES (@Equipment_Type, @Serial_Number, @Creation_Date, @Problem_Description, @Errors_ID)", connection);
                    MySqlCommand command3 = new MySqlCommand("INSERT INTO Repair_Reports (Clients_ID, Request_ID, Executor_ID, Begin_Date, End_Date, Description_all_work, Used_resources, Spare_parts_needed, Total_cost, Coordination_with_other_specialists) VALUES ( @ClientID, @Request_ID, 1,'" + formDate + "','" + formDate + "', '', '', '', 0, '')", connection);
                    MySqlCommand command4 = new MySqlCommand("INSERT INTO Request_Monitoring (Request_ID, Admin_ID, Registered,Time_receipt, Time_acceptance, Processing_time) VALUES (@Request_ID, 1, False, '" + formattedTime + "','" + formattedTime + "', 0)", connection);
                    MySqlCommand command5 = new MySqlCommand("INSERT INTO Work_done (Work_time, Description_work, Expenses, Request_ID, Executor_ID) VALUES (0,'', 0.00,@Request_ID,1)", connection);

                    // Получение ID клиента
                    MySqlCommand getClientIDCommand = new MySqlCommand($"SELECT ID FROM Clients WHERE Email = '{LoginForm.loginActive ?? RegisterForm.loginActive}'", connection);
                    int clientID = (int)Convert.ToInt64(getClientIDCommand.ExecuteScalar());
                    command3.Parameters.Add("@ClientID", MySqlDbType.Int64).Value = clientID;

                    command1.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox3.Text;
                    // Открываем соединение
                    command1.ExecuteNonQuery();
                    int lastInsertedID1 = (int)command1.LastInsertedId;
                    // Задаем параметры для запроса
                    command2.Parameters.Add("@Equipment_Type", MySqlDbType.VarChar).Value = textBox1.Text;
                    command2.Parameters.Add("@Serial_Number", MySqlDbType.VarChar).Value = textBox2.Text;
                    string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    command2.Parameters.Add("@Creation_Date", MySqlDbType.Date).Value = formattedDate;
                    command2.Parameters.Add("@Problem_Description", MySqlDbType.Text).Value = textBox4.Text;
                    command2.Parameters.Add("@Errors_ID", MySqlDbType.Int64).Value = lastInsertedID1;


                    // Выполняем запрос
                    command2.ExecuteNonQuery();

                    int lastInsertedID2 = (int)command2.LastInsertedId;
                    command3.Parameters.Add("@Request_ID", MySqlDbType.Int64).Value = lastInsertedID2;
                    command3.ExecuteNonQuery();
                    command4.Parameters.Add("@Request_ID", MySqlDbType.Int64).Value = lastInsertedID2;
                    command4.ExecuteNonQuery();
                    command5.Parameters.Add("@Request_ID", MySqlDbType.Int64).Value = lastInsertedID2;
                    command5.ExecuteNonQuery();
                    // Закрываем соединение
                    db.closeConnection();
                    MessageBox.Show("Заявка создана.");
                }
            }
            else
            {
                // Не все поля заполнены
                MessageBox.Show("Необходимо заполнить все поля!");
            }

            // По выполнению добавления возвращаемся на прошлую форму
            this.Hide();
            UsersMenuForm usersMenu = new UsersMenuForm();
            usersMenu.Show();
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
    }
}
