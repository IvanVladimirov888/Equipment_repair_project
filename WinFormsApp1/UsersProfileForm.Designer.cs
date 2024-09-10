namespace WinFormsApp1
{
    partial class UsersProfileForm
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
        private void InitializeComponent()
        {
            ConfirmationButton = new Button();
            panel3 = new Panel();
            EditProfile = new Button();
            label4 = new Label();
            ToUsersMenuLabel = new Label();
            CloseButton = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            textBox6 = new TextBox();
            label9 = new Label();
            textBox5 = new TextBox();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ConfirmationButton
            // 
            ConfirmationButton.BackColor = Color.FromArgb(179, 167, 218);
            ConfirmationButton.Cursor = Cursors.Hand;
            ConfirmationButton.FlatAppearance.BorderSize = 0;
            ConfirmationButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            ConfirmationButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            ConfirmationButton.FlatStyle = FlatStyle.Flat;
            ConfirmationButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmationButton.ForeColor = Color.WhiteSmoke;
            ConfirmationButton.Location = new Point(8, 150);
            ConfirmationButton.Name = "ConfirmationButton";
            ConfirmationButton.Size = new Size(130, 70);
            ConfirmationButton.TabIndex = 25;
            ConfirmationButton.Text = "Подтвердить";
            ConfirmationButton.UseVisualStyleBackColor = false;
            ConfirmationButton.Visible = false;
            ConfirmationButton.Click += ConfirmationButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(152, 160, 220);
            panel3.Controls.Add(EditProfile);
            panel3.Controls.Add(ConfirmationButton);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(427, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(144, 366);
            panel3.TabIndex = 24;
            panel3.MouseDown += panel1_MouseDown;
            panel3.MouseMove += panel1_MouseMove;
            // 
            // EditProfile
            // 
            EditProfile.BackColor = Color.FromArgb(179, 167, 218);
            EditProfile.Cursor = Cursors.Hand;
            EditProfile.FlatAppearance.BorderSize = 0;
            EditProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            EditProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            EditProfile.FlatStyle = FlatStyle.Flat;
            EditProfile.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EditProfile.ForeColor = Color.WhiteSmoke;
            EditProfile.Location = new Point(8, 50);
            EditProfile.Name = "EditProfile";
            EditProfile.Size = new Size(130, 70);
            EditProfile.TabIndex = 5;
            EditProfile.Text = "Редактировать профиль";
            EditProfile.UseVisualStyleBackColor = false;
            EditProfile.Click += EditProfile_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(20, 240);
            label4.Name = "label4";
            label4.Size = new Size(105, 45);
            label4.TabIndex = 19;
            label4.Text = "Адресные данные:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ToUsersMenuLabel
            // 
            ToUsersMenuLabel.AutoSize = true;
            ToUsersMenuLabel.Cursor = Cursors.Hand;
            ToUsersMenuLabel.FlatStyle = FlatStyle.Flat;
            ToUsersMenuLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ToUsersMenuLabel.ForeColor = Color.White;
            ToUsersMenuLabel.Location = new Point(0, -2);
            ToUsersMenuLabel.Name = "ToUsersMenuLabel";
            ToUsersMenuLabel.Size = new Size(50, 37);
            ToUsersMenuLabel.TabIndex = 13;
            ToUsersMenuLabel.Text = "←";
            ToUsersMenuLabel.Click += ToUsersMenuLabel_Click;
            ToUsersMenuLabel.MouseEnter += ToUsersMenuLabel_MouseEnter;
            ToUsersMenuLabel.MouseLeave += ToUsersMenuLabel_MouseLeave;
            // 
            // CloseButton
            // 
            CloseButton.AutoSize = true;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.Location = new Point(545, -2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 32);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "x";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // label6
            // 
            label6.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(20, 350);
            label6.Name = "label6";
            label6.Size = new Size(105, 45);
            label6.TabIndex = 21;
            label6.Text = "Ваш логин (почта):";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(20, 295);
            label5.Name = "label5";
            label5.Size = new Size(105, 45);
            label5.TabIndex = 20;
            label5.Text = "Ваш номер телефона:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(20, 185);
            label3.Name = "label3";
            label3.Size = new Size(105, 45);
            label3.TabIndex = 18;
            label3.Text = "Паспортные данные:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(20, 130);
            label2.Name = "label2";
            label2.Size = new Size(105, 45);
            label2.TabIndex = 17;
            label2.Text = "Ваше ФИО:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(130, 295);
            textBox4.MaxLength = 100;
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Your phone number";
            textBox4.Size = new Size(283, 45);
            textBox4.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(130, 240);
            textBox3.MaxLength = 100;
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Your address data";
            textBox3.Size = new Size(283, 45);
            textBox3.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(130, 185);
            textBox2.MaxLength = 100;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Your passport details";
            textBox2.Size = new Size(283, 45);
            textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(130, 130);
            textBox1.MaxLength = 100;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Your full name";
            textBox1.Size = new Size(283, 45);
            textBox1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(112, 135, 208);
            panel2.Controls.Add(ToUsersMenuLabel);
            panel2.Controls.Add(CloseButton);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 100);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(571, 100);
            label1.TabIndex = 0;
            label1.Text = "Профиль";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 466);
            panel1.TabIndex = 8;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // textBox6
            // 
            textBox6.Enabled = false;
            textBox6.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.Location = new Point(130, 405);
            textBox6.MaxLength = 100;
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.PasswordChar = '*';
            textBox6.PlaceholderText = "Your password";
            textBox6.Size = new Size(283, 45);
            textBox6.TabIndex = 28;
            textBox6.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            label9.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(20, 405);
            label9.Name = "label9";
            label9.Size = new Size(105, 45);
            label9.TabIndex = 27;
            label9.Text = "Ваш пароль:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(130, 350);
            textBox5.MaxLength = 100;
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Your login";
            textBox5.Size = new Size(283, 45);
            textBox5.TabIndex = 26;
            // 
            // UsersProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 466);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsersProfileForm";
            Text = "UsersProfileForm";
            Load += UsersProfileForm_Load;
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ConfirmationButton;
        private Panel panel3;
        private Button EditProfile;
        private Label label4;
        private Label ToUsersMenuLabel;
        private Label CloseButton;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private Label label1;
        private Panel panel1;
        private TextBox textBox5;
        private Label label9;
        private TextBox textBox6;
    }
}