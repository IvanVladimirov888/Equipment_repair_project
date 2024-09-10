using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public static LoginForm? Instance { get; set; }
        public static RegisterForm? Instance1 = null;
        public static UsersMenuForm? Instance2 = null;
        public static EmployeeMenuForm? Instance3 = null;



        static public string loginActive;
        static public string WhoIs;






        /// <summary>
        /// Закрытие окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        /// <summary>
        /// Форматирование для пароля.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, 45);
        }
        /// <summary>
        /// Событие по наведению мышкой на кнопку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }
        /// <summary>
        /// Событие по отпусканию кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            String passUser = PassField.Text;
            String loginUser = LoginField.Text;
            DB db = new DB();
            loginActive = loginUser;
            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM Clients Where Email = @uL AND (Password = @uP1 OR Password = @uP2);", db.getConnection());
            command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command1.Parameters.Add("@uP1", MySqlDbType.VarChar).Value = passUser;
            command1.Parameters.Add("@uP2", MySqlDbType.VarChar).Value = HashPassword(passUser);
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            DataTable table2 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM Executors Where Email = @uL AND (Password = @uP1 OR Password = @uP2);", db.getConnection());
            command2.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            loginActive = loginUser;
            command2.Parameters.Add("@uP1", MySqlDbType.VarChar).Value = passUser;
            command2.Parameters.Add("@uP2", MySqlDbType.VarChar).Value = HashPassword(passUser);
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            DataTable table3 = new DataTable();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM Admins Where Email = @uL AND (Password = @uP1 OR Password = @uP2);", db.getConnection());
            command3.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command3.Parameters.Add("@uP1", MySqlDbType.VarChar).Value = passUser;
            command3.Parameters.Add("@uP2", MySqlDbType.VarChar).Value = HashPassword(passUser);
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);


            DataTable table4 = new DataTable();
            MySqlConnection connection = new MySqlConnection("user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems;"); 
            connection.Open();

            MySqlDataAdapter adapter4 = new MySqlDataAdapter();
            string[] commands = new string[]
            {
                @"SELECT Email, Password FROM Clients WHERE Email = @uL",
                @"SELECT Email, Password FROM Executors WHERE Email = @uL",
                @"SELECT Email, Password FROM Admins WHERE Email = @uL"
            };

            foreach (string commandText in commands)
            {
                MySqlCommand command = new MySqlCommand(commandText, connection);
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser; // loginUser - ваш параметр поиска
                adapter4.SelectCommand = command;
                adapter4.Fill(table4);
            }

            // Проверка на использование определенных символов
            string[] restrictedSymbols = { "*", "&", "{", "}", "|", "+", "-", "(", ")", "№", "\"", "'", "#", ";", ":",
                                       "%", "&", ",", "?", "~", "!", "=", "\\", "/" };
            if (restrictedSymbols.Any(symbol => LoginField.Text.Contains(symbol)))
            {
                MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                return; // Прерываем выполнение метода
            }
            if (restrictedSymbols.Any(symbol => PassField.Text.Contains(symbol)))
            {
                MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                return; // Прерываем выполнение метода
            }

            if ((table4.Rows.Count > 0) && ((table4.Rows[0]["Password"].ToString() != HashPassword(passUser)) && (table4.Rows[0]["Email"].ToString() == loginUser)))
            {
                MessageBox.Show("Введен неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(loginUser))
            {
                MessageBox.Show("Введите логин");
            }
            else if (string.IsNullOrWhiteSpace(passUser))
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                if (passUser != "" && loginUser != "")
                {

                    Authorization.Authorization1(loginUser, passUser);
                    switch (Authorization.Role)
                    {
                        case null:
                            {
                                MessageBox.Show("Такого аккаунта не существует!", "Проверьте данные и попробуйте снова.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        case "admin":
                            {
                                WhoIs = "Администратор";
                                Authorization.User = LoginField.Text;

                                string FIO = Authorization.AuthorizationName(loginUser);
                                Authorization.FIO = FIO;
                                MessageBox.Show(FIO + ", добро пожаловать в меню администратора!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                AdminMenuForm admin = new AdminMenuForm();
                                admin.Show();
                                break;
                            }
                        case "user":
                            {
                                WhoIs = "Пользователь";
                                Authorization.User = LoginField.Text;

                                string FIO = Authorization.AuthorizationName(loginUser);
                                Authorization.FIO = FIO;
                                MessageBox.Show(FIO + ", добро пожаловать в меню пользователя!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                UsersMenuForm user = new UsersMenuForm();
                                user.Show();
                                break;
                            }
                        case "employee":
                            {
                                WhoIs = "Сотрудник";
                                Authorization.User = LoginField.Text;

                                string FIO = Authorization.AuthorizationName(loginUser);
                                Authorization.FIO = FIO;
                                MessageBox.Show(FIO + ", добро пожаловать в меню сотрудника!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                EmployeeMenuForm employee = new EmployeeMenuForm();
                                employee.Show();
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }





        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void registerLabel_MouseEnter(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.AliceBlue;
        }

        private void registerLabel_MouseLeave(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.DarkSlateGray;
        }

    }
}