using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Authorization
    {
        static public string Role, FIO, User;

        static public void Authorization1(string login, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems;"))
                {
                    connection.Open();

                    // Массив запросов
                    string[] queries1 = new string[]
                    {
                @"SELECT Name FROM Roles INNER JOIN Clients on Roles.ID = Clients.ID_Roles WHERE Email = @Email AND Password = @Password",
                @"SELECT Name FROM Roles INNER JOIN Executors on Roles.ID = Executors.ID_Roles WHERE Email = @Email AND Password = @Password",
                @"SELECT Name FROM Roles INNER JOIN Admins on Roles.ID = Admins.ID_Roles WHERE Email = @Email AND Password = @Password"
                    };
                    string[] queries2 = new string[]
                    {
                @"SELECT Name FROM Roles INNER JOIN Clients on Roles.ID = Clients.ID_Roles WHERE Email = @Email AND Password = @hashedPassword",
                @"SELECT Name FROM Roles INNER JOIN Executors on Roles.ID = Executors.ID_Roles WHERE Email = @Email AND Password = @hashedPassword",
                @"SELECT Name FROM Roles INNER JOIN Admins on Roles.ID = Admins.ID_Roles WHERE Email = @Email AND Password = @hashedPassword"
                    };


                    string hashedPassword = HashPassword(password);

                    bool foundResult = false;

                    if (!foundResult)
                    {
                        for (int i = 0; i < queries1.Length; i++)
                        {
                            string query = queries1[i];
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Email", login);
                            command.Parameters.AddWithValue("@Password", password);
                            Object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                Role = result.ToString();
                                User = login;
                                foundResult = true;  // Устанавливаем флаг, что результат получен
                                break; // Выходим из цикла, если результат получен
                            }
                            else
                            {
                                Role = null;
                                FIO = null;
                            }
                        }
                    }

                    if (!foundResult)
                    {
                        for (int i = 0; i < queries2.Length; i++)
                        {
                            string query = queries2[i];
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Email", login);
                            command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                            Object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                Role = result.ToString();
                                User = login;
                                foundResult = true; // Устанавливаем флаг, что результат получен
                                break; // Выходим из цикла, если результат получен
                            }
                            else
                            {
                                Role = null;
                                FIO = null;
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                Role = User = null;
                MessageBox.Show("Ошибка при авторизации!");
            }
        }

        private static string HashPassword(string password)
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
        static public string AuthorizationName(string login)
        {
            try
            {
                string FIO = null; // Переменная для хранения найденной фамилии

                using (MySqlConnection connection = new MySqlConnection("user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems;"))
                {
                    connection.Open();

                    string[] queries = new string[]
                    {
        @"SELECT FIO FROM Clients WHERE Email = @Email",
        @"SELECT FIO FROM Executors WHERE Email = @Email",
        @"SELECT FIO FROM Admins WHERE Email = @Email"
                    };

                    for (int i = 0; i < queries.Length; i++)
                    {
                        using (MySqlCommand command = new MySqlCommand(queries[i], connection))
                        {
                            command.Parameters.AddWithValue("@Email", login);
                            Object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                FIO = result.ToString();
                                break; // Завершаем цикл, если совпадение найдено
                            }
                        }
                    }
                }

                return FIO; // Возвращаем фамилию или null, если ничего не найдено
            }
            catch
            {
                return null;
            }
        }
    }
}
