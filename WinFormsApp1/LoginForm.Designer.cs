namespace WinFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Зарегистрироваться = new Label();
            registerLabel = new Label();
            LoginField = new TextBox();
            ButtonLogin = new Button();
            PassField = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            CloseButton = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(Зарегистрироваться);
            panel1.Controls.Add(registerLabel);
            panel1.Controls.Add(LoginField);
            panel1.Controls.Add(ButtonLogin);
            panel1.Controls.Add(PassField);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 337);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // Зарегистрироваться
            // 
            Зарегистрироваться.AutoSize = true;
            Зарегистрироваться.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Зарегистрироваться.ForeColor = Color.DarkSlateGray;
            Зарегистрироваться.Location = new Point(98, 292);
            Зарегистрироваться.Name = "Зарегистрироваться";
            Зарегистрироваться.Size = new Size(92, 15);
            Зарегистрироваться.TabIndex = 7;
            Зарегистрироваться.Text = "Нет аккаунта?";
            // 
            // registerLabel
            // 
            registerLabel.AutoSize = true;
            registerLabel.Cursor = Cursors.Hand;
            registerLabel.FlatStyle = FlatStyle.Flat;
            registerLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            registerLabel.ForeColor = Color.DarkSlateGray;
            registerLabel.Location = new Point(190, 292);
            registerLabel.Name = "registerLabel";
            registerLabel.Size = new Size(130, 15);
            registerLabel.TabIndex = 8;
            registerLabel.Text = "Зарегистрироваться";
            registerLabel.Click += registerLabel_Click;
            registerLabel.MouseEnter += registerLabel_MouseEnter;
            registerLabel.MouseLeave += registerLabel_MouseLeave;
            // 
            // LoginField
            // 
            LoginField.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoginField.Location = new Point(74, 129);
            LoginField.Multiline = true;
            LoginField.Name = "LoginField";
            LoginField.PlaceholderText = "Email";
            LoginField.Size = new Size(283, 45);
            LoginField.TabIndex = 3;
            LoginField.Tag = "";
            // 
            // ButtonLogin
            // 
            ButtonLogin.BackColor = Color.FromArgb(179, 167, 218);
            ButtonLogin.Cursor = Cursors.Hand;
            ButtonLogin.FlatAppearance.BorderSize = 0;
            ButtonLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            ButtonLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            ButtonLogin.FlatStyle = FlatStyle.Flat;
            ButtonLogin.Font = new Font("Comic Sans MS", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonLogin.ForeColor = Color.WhiteSmoke;
            ButtonLogin.Location = new Point(101, 249);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(215, 40);
            ButtonLogin.TabIndex = 5;
            ButtonLogin.Text = "Войти";
            ButtonLogin.UseVisualStyleBackColor = false;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // PassField
            // 
            PassField.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PassField.Location = new Point(74, 192);
            PassField.Name = "PassField";
            PassField.PlaceholderText = "Password";
            PassField.Size = new Size(283, 29);
            PassField.TabIndex = 4;
            PassField.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._lock;
            pictureBox2.Location = new Point(23, 192);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user1;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(23, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(112, 135, 208);
            panel2.Controls.Add(CloseButton);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 100);
            panel2.TabIndex = 0;
            // 
            // CloseButton
            // 
            CloseButton.AutoSize = true;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.Location = new Point(357, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 32);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "x";
            CloseButton.Click += CloseButton_Click_1;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(386, 100);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // LoginForm
            // 
            ClientSize = new Size(386, 337);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        private void panel1_MouseMove(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label CloseButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox PassField;
        private Button ButtonLogin;
        private TextBox LoginField;
        private Label Зарегистрироваться;
        private Label registerLabel;
    }
}