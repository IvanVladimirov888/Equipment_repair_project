using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;
using NPOI.XWPF.UserModel;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class StatusApplicationForm : Form
    {
        public StatusApplicationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Передвижение окна.
        /// </summary>
        System.Drawing.Point lastPoint;
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
            lastPoint = new System.Drawing.Point(e.X, e.Y);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный серийный номер
            var selectedSerialNumber = comboBox1.SelectedItem?.ToString();
            // Получаем доступ к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                db.openConnection();

                // Выполняем запрос на получение данных из базы данных
                MySqlCommand command = new MySqlCommand($"SELECT Equipment_Type, Serial_Number, Begin_Date, End_Date, Processing_time, Description_all_work, Total_cost, Registered FROM Requests INNER JOIN Repair_Reports on Repair_Reports.Request_ID = Requests.ID INNER JOIN Clients on Repair_Reports.Clients_ID = Clients.ID INNER JOIN Request_Monitoring ON Request_Monitoring.Request_ID = Requests.ID WHERE Serial_Number = @selectedSerialNumber AND Begin_Date = @selectedBegin_Date", connection);
                command.Parameters.Add("@selectedSerialNumber", MySqlDbType.VarChar).Value = selectedSerialNumber;
                command.Parameters.Add("@selectedBegin_Date", MySqlDbType.Date).Value = dateTimePicker2.Value;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Заполняем поля на форме
                        textBox1.Text = reader["Equipment_Type"].ToString();
                        textBox2.Text = reader["Serial_Number"].ToString();
                        dateTimePicker1.Value = (DateTime)reader["Begin_Date"];
                        textBox3.Text = reader["Processing_time"].ToString();
                        textBox4.Text = reader["Description_all_work"].ToString();
                        textBox5.Text = reader["Total_cost"].ToString();
                        checkBox1.Checked = bool.Parse(reader["Registered"].ToString());

                        // Проверяем условия для checkBox1
                        decimal totalCost = decimal.Parse(reader["Total_cost"].ToString());
                        DateTime beginDate = DateTime.Parse(reader["Begin_Date"].ToString());
                        DateTime endDate = DateTime.Parse(reader["End_Date"].ToString());
                        string descriptionAllWork = reader["Description_all_work"].ToString();
                        bool registered = bool.Parse(reader["Registered"].ToString());

                        if ((totalCost != 0) && (beginDate != DateTime.Today) && (endDate != beginDate) && (descriptionAllWork != "") && (registered == true))
                        {
                            checkBox2.Checked = true;
                        }
                        else
                        {
                            checkBox2.Checked = false;
                        }
                    }
                }

                // Закрываем соединение
                db.closeConnection();
            }
        }

        private void StatusApplicationForm_Layout(object sender, EventArgs e)
        {
            LoadSerialNumbers(); // Загрузить данные при загрузке формы
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



        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                ConfirmationButton.Visible = true;
                var selectedSerialNumber = comboBox1.SelectedItem?.ToString();
                string Login = "";
                if (!string.IsNullOrEmpty(LoginForm.loginActive))
                {
                    Login = LoginForm.loginActive;
                }
                else if (!string.IsNullOrEmpty(RegisterForm.loginActive))
                {
                    Login = RegisterForm.loginActive;
                }
                else
                {
                    // Обработка ситуации, если ни одно из значений не возвращено
                    MessageBox.Show("Ошибка: Невозможно получить текущий логин.");
                    return;
                }

                // Создаем новый документ Word
                XWPFDocument doc = new XWPFDocument();

                // Добавляем параграф с заголовком
                XWPFParagraph title = doc.CreateParagraph();
                title.Alignment = ParagraphAlignment.CENTER;
                XWPFRun titleRun = title.CreateRun();
                titleRun.IsBold = true;
                titleRun.FontSize = 14;
                titleRun.SetText("Итоговый отчет");

                // Добавляем таблицу
                XWPFTable table = doc.CreateTable(1, 7);
                string[] headers = { "Дата начала работы", "Дата конца работы", "Описание проделанной работы", "Затраченные ресурсы ", "Потребность в запчастях ", "Итоговая цена", "Координация с другими специалистами" };

                for (int i = 0; i < headers.Length; i++)
                {
                    table.GetRow(0).GetCell(i).SetText(headers[i]);
                }

                // Добавление данных из базы данных
                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    db.openConnection();

                    MySqlCommand command = new MySqlCommand($"SELECT Begin_Date, End_Date, Description_all_work, Used_resources, Spare_parts_needed, Total_cost, Coordination_with_other_specialists FROM Repair_Reports INNER JOIN Requests on Repair_Reports.Request_ID = Requests.ID INNER JOIN Clients on Repair_Reports.Clients_ID = Clients.ID  WHERE Email = '{Login}' AND Serial_Number = '{selectedSerialNumber}'", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        XWPFTableRow newRow = table.CreateRow();
                        for (int i = 0; i < 7; i++)
                        {
                            newRow.GetCell(i).SetText(reader[i].ToString());
                        }
                    }

                    reader.Close();
                    db.closeConnection();
                }

                // Сохраняем документ Word
                string fileName = @"D:\Visual Studio Community 2022\MyProject\Project PP\Repair_Reports.docx";
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    doc.Write(fs);
                }

                MessageBox.Show("Документ Word успешно создан.");
                // Открываем файл
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = fileName,
                        UseShellExecute = true
                    };
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заявка еще не выполнена.");
            }
        }

    }
}
