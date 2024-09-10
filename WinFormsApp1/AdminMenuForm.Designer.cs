namespace WinFormsApp1
{
    partial class AdminMenuForm
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
            panel1 = new Panel();
            AdminsProfile = new Button();
            EmployeeProfile = new Button();
            UsersProfile = new Button();
            EditApplication = new Button();
            panel2 = new Panel();
            ToLoginLabel = new Label();
            CloseButton = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(AdminsProfile);
            panel1.Controls.Add(EmployeeProfile);
            panel1.Controls.Add(UsersProfile);
            panel1.Controls.Add(EditApplication);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 243);
            panel1.TabIndex = 6;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // AdminsProfile
            // 
            AdminsProfile.BackColor = Color.FromArgb(179, 167, 218);
            AdminsProfile.Cursor = Cursors.Hand;
            AdminsProfile.FlatAppearance.BorderSize = 0;
            AdminsProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            AdminsProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            AdminsProfile.FlatStyle = FlatStyle.Flat;
            AdminsProfile.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AdminsProfile.ForeColor = Color.WhiteSmoke;
            AdminsProfile.Location = new Point(460, 145);
            AdminsProfile.Name = "AdminsProfile";
            AdminsProfile.Size = new Size(140, 82);
            AdminsProfile.TabIndex = 10;
            AdminsProfile.Text = "Ваш профиль";
            AdminsProfile.UseVisualStyleBackColor = false;
            AdminsProfile.Click += AdminsProfile_Click;
            // 
            // EmployeeProfile
            // 
            EmployeeProfile.BackColor = Color.FromArgb(179, 167, 218);
            EmployeeProfile.Cursor = Cursors.Hand;
            EmployeeProfile.FlatAppearance.BorderSize = 0;
            EmployeeProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            EmployeeProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            EmployeeProfile.FlatStyle = FlatStyle.Flat;
            EmployeeProfile.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeeProfile.ForeColor = Color.WhiteSmoke;
            EmployeeProfile.Location = new Point(310, 145);
            EmployeeProfile.Name = "EmployeeProfile";
            EmployeeProfile.Size = new Size(140, 82);
            EmployeeProfile.TabIndex = 9;
            EmployeeProfile.Text = "Изменить сотрудника";
            EmployeeProfile.UseVisualStyleBackColor = false;
            EmployeeProfile.Click += EmployeeProfile_Click;
            // 
            // UsersProfile
            // 
            UsersProfile.BackColor = Color.FromArgb(179, 167, 218);
            UsersProfile.Cursor = Cursors.Hand;
            UsersProfile.FlatAppearance.BorderSize = 0;
            UsersProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            UsersProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            UsersProfile.FlatStyle = FlatStyle.Flat;
            UsersProfile.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UsersProfile.ForeColor = Color.WhiteSmoke;
            UsersProfile.Location = new Point(160, 145);
            UsersProfile.Name = "UsersProfile";
            UsersProfile.Size = new Size(140, 82);
            UsersProfile.TabIndex = 6;
            UsersProfile.Text = "Изменить пользователя";
            UsersProfile.UseVisualStyleBackColor = false;
            UsersProfile.Click += UsersProfile_Click;
            // 
            // EditApplication
            // 
            EditApplication.BackColor = Color.FromArgb(179, 167, 218);
            EditApplication.Cursor = Cursors.Hand;
            EditApplication.FlatAppearance.BorderSize = 0;
            EditApplication.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            EditApplication.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            EditApplication.FlatStyle = FlatStyle.Flat;
            EditApplication.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EditApplication.ForeColor = Color.WhiteSmoke;
            EditApplication.Location = new Point(10, 145);
            EditApplication.Name = "EditApplication";
            EditApplication.Size = new Size(140, 82);
            EditApplication.TabIndex = 5;
            EditApplication.Text = "Изменить заявку";
            EditApplication.UseVisualStyleBackColor = false;
            EditApplication.Click += CreateApplication_Click;
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
            panel2.Size = new Size(611, 100);
            panel2.TabIndex = 0;
            // 
            // ToLoginLabel
            // 
            ToLoginLabel.AutoSize = true;
            ToLoginLabel.Cursor = Cursors.Hand;
            ToLoginLabel.FlatStyle = FlatStyle.Flat;
            ToLoginLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ToLoginLabel.ForeColor = Color.White;
            ToLoginLabel.Location = new Point(0, 0);
            ToLoginLabel.Name = "ToLoginLabel";
            ToLoginLabel.Size = new Size(50, 37);
            ToLoginLabel.TabIndex = 13;
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
            CloseButton.Location = new Point(585, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 32);
            CloseButton.TabIndex = 1;
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
            label1.Size = new Size(611, 100);
            label1.TabIndex = 0;
            label1.Text = "Главное меню";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // AdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 243);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminMenuForm";
            Text = "AdminMenuForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button UsersProfile;
        private Button EditApplication;
        private Panel panel2;
        private Label ToLoginLabel;
        private Label CloseButton;
        private Label label1;
        private Button AdminsProfile;
        private Button EmployeeProfile;
    }
}