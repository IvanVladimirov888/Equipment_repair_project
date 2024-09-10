
namespace WinFormsApp1
{
    partial class RegisterForm
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
        /// </summary>'

        private void InitializeComponent()
        {
            panel1 = new Panel();
            ButtonRegistration = new Button();
            PassField = new TextBox();
            LoginField = new TextBox();
            UserInitialsField = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            ToLoginLabel = new Label();
            CloseButton = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(ButtonRegistration);
            panel1.Controls.Add(PassField);
            panel1.Controls.Add(LoginField);
            panel1.Controls.Add(UserInitialsField);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 346);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // ButtonRegistration
            // 
            ButtonRegistration.BackColor = Color.FromArgb(179, 167, 218);
            ButtonRegistration.Cursor = Cursors.Hand;
            ButtonRegistration.FlatAppearance.BorderSize = 0;
            ButtonRegistration.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            ButtonRegistration.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            ButtonRegistration.FlatStyle = FlatStyle.Flat;
            ButtonRegistration.Font = new Font("Comic Sans MS", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonRegistration.ForeColor = Color.WhiteSmoke;
            ButtonRegistration.Location = new Point(107, 277);
            ButtonRegistration.Name = "ButtonRegistration";
            ButtonRegistration.Size = new Size(215, 40);
            ButtonRegistration.TabIndex = 6;
            ButtonRegistration.Text = "Зарегистрироваться";
            ButtonRegistration.UseVisualStyleBackColor = false;
            ButtonRegistration.Click += ButtonRegistration_Click;
            // 
            // PassField
            // 
            PassField.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PassField.Location = new Point(74, 226);
            PassField.MaxLength = 100;
            PassField.Name = "PassField";
            PassField.PlaceholderText = "Password";
            PassField.Size = new Size(283, 29);
            PassField.TabIndex = 7;
            PassField.UseSystemPasswordChar = true;
            // 
            // LoginField
            // 
            LoginField.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoginField.Location = new Point(74, 175);
            LoginField.MaxLength = 100;
            LoginField.Multiline = true;
            LoginField.Name = "LoginField";
            LoginField.PlaceholderText = "Email";
            LoginField.Size = new Size(283, 45);
            LoginField.TabIndex = 2;
            LoginField.Tag = "";
            // 
            // UserInitialsField
            // 
            UserInitialsField.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            UserInitialsField.Location = new Point(74, 124);
            UserInitialsField.MaxLength = 100;
            UserInitialsField.Multiline = true;
            UserInitialsField.Name = "UserInitialsField";
            UserInitialsField.PlaceholderText = "Initials";
            UserInitialsField.Size = new Size(283, 45);
            UserInitialsField.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icon1;
            pictureBox3.InitialImage = null;
            pictureBox3.Location = new Point(23, 124);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 45);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._lock;
            pictureBox2.Location = new Point(23, 226);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user1;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(23, 175);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(112, 135, 208);
            panel2.Controls.Add(ToLoginLabel);
            panel2.Controls.Add(CloseButton);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 100);
            panel2.TabIndex = 9;
            // 
            // ToLoginLabel
            // 
            ToLoginLabel.AutoSize = true;
            ToLoginLabel.Cursor = Cursors.Hand;
            ToLoginLabel.FlatStyle = FlatStyle.Flat;
            ToLoginLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ToLoginLabel.ForeColor = Color.White;
            ToLoginLabel.Location = new Point(0, -3);
            ToLoginLabel.Name = "ToLoginLabel";
            ToLoginLabel.Size = new Size(50, 37);
            ToLoginLabel.TabIndex = 12;
            ToLoginLabel.Text = "←";
            ToLoginLabel.Click += ToLoginLabel_Click;
            ToLoginLabel.MouseEnter += ToLoginLabel_MouseEnter;
            ToLoginLabel.MouseLeave += ToLoginLabel_MouseLeave;
            // 
            // CloseButton
            // 
            CloseButton.AutoSize = true;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.Location = new Point(360, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 32);
            CloseButton.TabIndex = 10;
            CloseButton.Text = "x";
            CloseButton.Click += CloseButton_Click;
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
            label1.TabIndex = 11;
            label1.Text = "Регистрация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // RegisterForm
            // 
            ClientSize = new Size(386, 346);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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

        private Label label1;
        private Panel panel1;
        private TextBox PassField;
        private TextBox LoginField;
        private PictureBox pictureBox3;
        private Button ButtonRegistration;
        private TextBox UserInitialsField;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label CloseButton;
        private Label ToLoginLabel;
    }
}