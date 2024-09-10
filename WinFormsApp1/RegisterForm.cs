using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class RegisterForm : Form
    {
        public static RegisterForm? Instance1 { get; set; }
        public static LoginForm? Instance = null;
        public static UsersMenuForm? Instance2 = null;
        public static EditApplicationAdminForm? Instance3 = null;
        static public string loginActive;


        /// <summary>
        /// Форматирование для пароля.
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();

            this.UserInitialsField.AutoSize = false;
            this.UserInitialsField.Size = new Size(this.UserInitialsField.Size.Width, 45);

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

            private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            String passUser = HashPassword(PassField.Text); // Хешируем введенный пароль 
            String loginUser = LoginField.Text;
            String initialsuser = UserInitialsField.Text;
            LoginForm.loginActive = "";

            if (isUserExists())
                return;

            // Проверка на использование определенных символов
            string[] restrictedSymbols = { "*", "&", "{", "}", "|", "+", "-", "(", ")", "№", "\"", "'", "#", ";", ":",
                                       "%", "&", ",", "?", "~", "!", "=", "\\", "/" };
            if (restrictedSymbols.Any(symbol => LoginField.Text.Contains(symbol)) || (restrictedSymbols.Any(symbol => PassField.Text.Contains(symbol))))
            {
                MessageBox.Show("Поля не должны содержать запрещенные символы: " + string.Join(" ", restrictedSymbols));
                return; // Прерываем выполнение метода

            }
            else if (string.IsNullOrWhiteSpace(initialsuser))
            {
                MessageBox.Show("Введите ФИО");
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
                DB db = new DB();
                MySqlCommand command1 = new MySqlCommand("INSERT INTO Clients (FIO, Passport, Address, Phone, Password, Email, ID_Roles) VALUES (@uI,0, '', '', @uP, @uL, 3)", db.getConnection());
                command1.Parameters.Add("@uI", MySqlDbType.VarChar).Value = initialsuser;
                command1.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                loginActive = loginUser;
                db.openConnection();
                command1.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Регистрация аккаунта произошла успешно!");
                this.Hide();
                UsersMenuForm usersMenu = new UsersMenuForm();
                usersMenu.Show();
            }
        }

        public Boolean isUserExists()
        {
            String passUser = UserInitialsField.Text;
            String loginUser = LoginField.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Clients Where Email = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Под таким логином уже существует аккаунт. Введите другой!");
                return true;
            }
            else
                return false;
        }

        private void ToLoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void ToLoginLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Gray;
        }

        private void ToLoginLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }
    }
}