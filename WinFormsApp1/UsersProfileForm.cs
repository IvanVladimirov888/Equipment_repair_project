﻿using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
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
    public partial class UsersProfileForm : Form
    {
        MySqlCommand cmd = UsersMenuForm.con.CreateCommand();
        String fioGlobal = "";
        public UsersProfileForm()
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
            string passport = textBox2.Text;
            string address = textBox3.Text;
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
            if (!IsValidPassport(passport))
            {
                MessageBox.Show("Пасспорт должен содержать ровно 10 цифр");
                return;
            }
            if (!IsValidPassword(password1))
            {
                MessageBox.Show("Пароль должен содержать от 4 до 16 символов");
                return;
            }
            // Проверка на использование определенных символов
            string[] restrictedSymbols = { "&", "{", "}", "|", "+", "-", "(", ")", "№", "\"", "'", "#", ";", ":",
                                       "%", ",", "?", "~", "!", "=", "\\", "/" };
            Func<string, bool> predicate = symbol => textBox5.Text.Contains(symbol);
            if (restrictedSymbols.Any(predicate))
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
            string oldLogin = LoginForm.loginActive ?? RegisterForm.loginActive;// Примерное название переменной, где хранится текущий логин

            // Получение старого пароля из базы данных по старому логину
            string oldPasswordFromDBQuery = $"SELECT Password FROM Clients Where Email = '{oldLogin}'";
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
            if (newLogin != LoginForm.loginActive || newPassword != oldPasswordFromDB)
            {
                // Выводим окно с подтверждением изменения логина и пароля
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите изменить логин и пароль?", "Подтверждение изменений", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Обновляем логин и пароль в базе данных
                    string updateLoginQuery = $"UPDATE Clients SET Email = '{newLogin}' WHERE Email = '{oldLogin}'";
                    string updatePasswordQuery = $"UPDATE Clients SET Password = '{newPassword}' WHERE Email = '{newLogin}'";
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
                    string updateQuery = $"UPDATE Clients SET FIO = '{fio}', Passport = {passport}, Address = '{address}', Phone = '{phone}' WHERE Email = '{newLogin}';";
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
                    string updateQuery = $"UPDATE Clients SET FIO = '{fio}', Passport = {passport}, Address = '{address}', Phone = '{phone}' WHERE Email = '{oldLogin}';";
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
        private bool IsValidPassport(string passport)
        {
            // Проверяем, что строка состоит из 10 цифр
            return !string.IsNullOrWhiteSpace(passport) && passport.Length == 10 && passport.All(c => char.IsDigit(c));
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


        private void UsersProfileForm_Load(object sender, EventArgs e)
        {
            // Получаем доступ к базе данных
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                // Открываем соединение
                db.openConnection();
                string oldLogin = "";

                if (!string.IsNullOrEmpty(LoginForm.loginActive))
                {
                    oldLogin = LoginForm.loginActive;
                }
                else if (!string.IsNullOrEmpty(RegisterForm.loginActive))
                {
                    oldLogin = RegisterForm.loginActive;
                }
                else
                {
                    // Обработка ситуации, если ни одно из значений не возвращено
                    MessageBox.Show("Ошибка: Невозможно получить текущий логин.");
                    return;
                }
                // Подготавливаем SQL-запрос
                string selectQuery = "SELECT FIO, Passport, Address, Phone, Password, Email FROM Clients WHERE Email = @Email";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Email", oldLogin);

                // Используем читатели для получения данных из базы
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Заполняем поля на форме полученными данными
                        textBox1.Text = reader["FIO"].ToString();
                        textBox2.Text = reader["Passport"].ToString();
                        textBox3.Text = reader["Address"].ToString();
                        textBox4.Text = reader["Phone"].ToString();
                        textBox5.Text = reader["Email"].ToString();
                        // В данном случае пароль получаем в открытом виде
                        textBox6.Text = "*******";


                        // Преобразуем хешированный пароль в нормальные символы
                        /*string hashedPassword = reader["Password"].ToString();
                        string decodedPassword = DecodePassword(hashedPassword);
                        textBox6.Text = decodedPassword;*/
                    }
                }

                // Закрываем соединение
                db.closeConnection();
            }
        }

        /*private string DecodePassword(string hashedPassword)
        {
            byte[] bytes = new byte[hashedPassword.Length / 2];

            for (int i = 0; i < hashedPassword.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hashedPassword.Substring(i, 2), 16);
            }

            string decodedPassword = Encoding.UTF8.GetString(bytes); // Декодирование с учетом кодировки UTF-8

            return decodedPassword;
        }*/



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

    }
}
