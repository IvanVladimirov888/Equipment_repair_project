using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EmployeeMenuForm : Form
    {
        public EmployeeMenuForm()
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
            ToLoginLabel.ForeColor = Color.Gray;
        }

        private void ToLoginLabel_MouseLeave(object sender, EventArgs e)
        {
            ToLoginLabel.ForeColor = Color.White;
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


        private void CreateApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationListForm applicationList = new ApplicationListForm();
            applicationList.Show();
        }
        private void StatusApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatusAppplicationEmployeeForm statusAppplicationEmployee = new StatusAppplicationEmployeeForm();
            statusAppplicationEmployee.Show();
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatisticsForm statistics = new StatisticsForm();
            statistics.Show();
        }

        private void EmployeeProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeProfileForm employeeProfile = new EmployeeProfileForm();
            employeeProfile.Show();
        }
    }
}
