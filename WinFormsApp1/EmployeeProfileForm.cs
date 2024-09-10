﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EmployeeProfileForm : Form
    {
        public EmployeeProfileForm()
        {
            InitializeComponent();
        }
        private void EditProfile_Click(object sender, EventArgs e)
        {
            // Сделать все текстовые поля доступными для редактирования
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            ConfirmationButton.Visible = true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("x2")); // Преобразуем байты в HEX строки
                }

                return result.ToString();
            }
        }





        // Обработчик кнопки ConfirmationButton
        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных и их сохранение в базе
            string fio = textBox1.Text;
            string position = textBox2.Text;
            string department = textBox3.Text;
            string phone = textBox4.Text;
            // Дополнительно получаем введенные логин и пароль
            string login = textBox5.Text;
            string password = HashPassword(textBox6.Text);
            string password1 = textBox6.Text;
            // Проверка формата введенных данных
            if (!IsValidFIO(fio))
            {
                MessageBox.Show("Фамилия должна содержать только буквы");
                return;
            }
            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Номер телефона должен содержать ровно 11 цифр");
                return;
            }
            if (!IsValidPosition(position))
            {
                MessageBox.Show("Должность должна содержать только буквы");
                return;
            }
            if (!IsValidPassword(password1))
            {
                MessageBox.Show("Пароль должен содержать от 4 до 16 символов");
                return;
            }
            // Проверка на использование определенных символов
            string[] restrictedSymbols = { "*", "&", "{", "}", "|", "+", "-", "(", ")", "№", "\"", "'", "#", ";", ":",
                           "%", "&", ",", "?", "~", "!", "=", "\\", "/" };
            if (restrictedSymbols.Any(symbol => textBox5.Text.Contains(symbol)))
            {
                MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                return; // Прерываем выполнение метода
            }
            if (restrictedSymbols.Any(symbol => textBox6.Text.Contains(symbol)))
            {
                MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                return; // Прерываем выполнение метода
            }
            // Получение введенных логина и пароля
            string newLogin = textBox5.Text;
            string newPassword = HashPassword(textBox6.Text);
            string oldPasswordFromDB;
            // Получение старого логина из глобальной переменной или другого места, где он хранится
            string oldLogin = LoginForm.loginActive;// Примерное название переменной, где хранится текущий логин

            // Получение старого пароля из базы данных по старому логину
            string oldPasswordFromDBQuery = $"SELECT Password FROM Executors Where Email = '{oldLogin}'";
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                connection.Open();
                using (MySqlCommand oldPasswordFromDBCommand = new MySqlCommand(oldPasswordFromDBQuery, connection))
                {
                    oldPasswordFromDB = (string)oldPasswordFromDBCommand.ExecuteScalar();
                }
                // Закрываем соединение
                connection.Close();
            }
            if (newLogin != oldLogin || newPassword != oldPasswordFromDB)
            {
                // Выводим окно с подтверждением изменения логина и пароля
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите изменить логин и пароль?", "Подтверждение изменений", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Обновляем логин и пароль в базе данных
                    string updateLoginQuery = $"UPDATE Executors SET Email = '{newLogin}' WHERE Email = '{oldLogin}'";
                    string updatePasswordQuery = $"UPDATE Executors SET Password = '{newPassword}' WHERE Email = '{newLogin}'";
                    using (MySqlConnection connection = db.getConnection())
                    {
                        // Открываем соединение
                        connection.Open();
                        using (MySqlCommand updateLoginCommand = new MySqlCommand(updateLoginQuery, connection))
                        using (MySqlCommand updatePasswordCommand = new MySqlCommand(updatePasswordQuery, connection))
                        {
                            updateLoginCommand.ExecuteNonQuery();
                            updatePasswordCommand.ExecuteNonQuery();
                        }
                        // Закрываем соединение
                        connection.Close();
                    }
                    // Обновление данных в базе данных
                    string updateQuery = $"UPDATE Executors SET FIO = '{fio}', Position = '{position}', Department = '{department}', Phone = '{phone}' WHERE Email = '{newLogin}';";
                    using (MySqlConnection connection = db.getConnection())
                    {
                        // Открываем соединение
                        connection.Open();
                        using (MySqlCommand updateQueryCommand = new MySqlCommand(updateQuery, connection))
                        {
                            updateQueryCommand.ExecuteNonQuery();
                        }
                        // Закрываем соединение
                        connection.Close();
                    }
                    // Сделать текстовые поля недоступными для редактирования
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    ConfirmationButton.Visible = false;
                }
                else
                {
                    // Блокируем поля логина и пароля и оставляем старые данные
                    textBox5.Text = oldLogin;
                    textBox6.Text = oldPasswordFromDB; // Допустим, что мы не обновляем пароль, если изменение не подтверждено
                                                       // Обновление данных в базе данных
                    string updateQuery = $"UPDATE Executors SET FIO = '{fio}', Position = '{position}', Department = '{department}', Phone = '{phone}' WHERE Email = '{oldLogin}';";
                    using (MySqlConnection connection = db.getConnection())
                    {
                        connection.Open();
                        using (MySqlCommand updateQueryCommand = new MySqlCommand(updateQuery, connection))
                        {
                            updateQueryCommand.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    // Сделать текстовые поля недоступными для редактирования
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    ConfirmationButton.Visible = false;
                }

            }
            textBox6.Text = "*******";
            textBox6.PasswordChar = '*';
            textBox6.UseSystemPasswordChar = true;
        }

        // Метод для проверки формата ФИО
        private bool IsValidFIO(string fio)
        {
            // Проверяем, что строка состоит только из букв и пробелов
            return !string.IsNullOrWhiteSpace(fio) && fio.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        // Метод для проверки формата паспортных данных
        private bool IsValidPosition(string position)
        {
            // Проверяем, что строка состоит из 10 цифр
            return !string.IsNullOrWhiteSpace(position) && position.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        // Метод для проверки формата номера телефона
        private bool IsValidPhone(string phone)
        {
            // Проверяем, что строка состоит из 11 цифр
            return !string.IsNullOrWhiteSpace(phone) && phone.Length == 11 && phone.All(c => char.IsDigit(c));
        }
        private bool IsValidPassword(string password)
        {
            // Проверяем, что строка состоит из 10 цифр
            return !string.IsNullOrWhiteSpace(password) && password.Length <= 16 && password.Length > 4;
        }
        private void EmployeeProfileForm_Load(object sender, EventArgs e)
        {
            // Получаем доступ к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                db.openConnection();
                string oldLogin = LoginForm.loginActive;// Примерное название переменной, где хранится текущий логин

                // Подготавливаем SQL-запрос
                string selectQuery = "SELECT FIO, Position, Department, Phone, Email FROM Executors WHERE Email = @Email";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Email", oldLogin);

                // Используем читатели для получения данных из базы
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Заполняем поля на форме полученными данными
                        textBox1.Text = reader["FIO"].ToString();
                        textBox2.Text = reader["Position"].ToString();
                        textBox3.Text = reader["Department"].ToString();
                        textBox4.Text = reader["Phone"].ToString();
                        textBox5.Text = reader["Email"].ToString();
                        textBox6.Text = "*******";
                    }
                }

                // Закрываем соединение
                db.closeConnection();
            }
        }



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
    }
}