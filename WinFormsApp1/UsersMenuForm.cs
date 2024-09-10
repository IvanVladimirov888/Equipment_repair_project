using MySql.Data.MySqlClient;


namespace WinFormsApp1
{
    public partial class UsersMenuForm : Form
    {
        public static MySqlConnection con = new MySqlConnection("user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems;");
        public static UsersMenuForm? Instance { get; set; }
        public static EditApplicationAdminForm? Instance2 = null;
        public UsersMenuForm()
        {
            InitializeComponent();
            //con.Open();
            Instance = this;
        }

        private void UsersMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //con.Close();
        }

        private void CreateApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationForm application = new ApplicationForm();
            application.Show();
        }


        private void StatusApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatusApplicationForm statusApplication = new StatusApplicationForm();
            statusApplication.Show();
        }

        private void EditApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditApplicationForm editApplication = new EditApplicationForm();
            editApplication.Show();
        }

        private void UsersProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersProfileForm usersProfileForm = new UsersProfileForm();
            usersProfileForm.Show();
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

        private void ToLoginLabel_Click(object sender, EventArgs e)
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

        private void ToLoginLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Gray;
        }

        private void ToLoginLabel_MouseLeave(object sender, EventArgs e)
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
    }
}
