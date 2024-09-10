namespace WinFormsApp1
{
    partial class ApplicationForm
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            CreateApplication = new Button();
            panel2 = new Panel();
            ToUsersMenuLabel = new Label();
            CloseButton = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(CreateApplication);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 604);
            panel1.TabIndex = 6;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // label6
            // 
            label6.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(20, 350);
            label6.Name = "label6";
            label6.Size = new Size(105, 45);
            label6.TabIndex = 21;
            label6.Text = "Описание проблемы:";
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
            label5.Text = "Название ошибки:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(20, 240);
            label4.Name = "label4";
            label4.Size = new Size(105, 45);
            label4.TabIndex = 19;
            label4.Text = "Дата создания:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(20, 185);
            label3.Name = "label3";
            label3.Size = new Size(105, 45);
            label3.TabIndex = 18;
            label3.Text = "Серийный номер:";
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
            label2.Text = "Тип оборудования:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(130, 295);
            textBox3.MaxLength = 100;
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "The name of the error";
            textBox3.Size = new Size(283, 45);
            textBox3.TabIndex = 16;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(130, 350);
            textBox4.MaxLength = 100;
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Description of the problem";
            textBox4.Size = new Size(283, 242);
            textBox4.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(130, 185);
            textBox2.MaxLength = 100;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Serial number";
            textBox2.Size = new Size(283, 45);
            textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(130, 130);
            textBox1.MaxLength = 100;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Type of equipment";
            textBox1.Size = new Size(283, 45);
            textBox1.TabIndex = 13;
            // 
            // CreateApplication
            // 
            CreateApplication.BackColor = Color.FromArgb(179, 167, 218);
            CreateApplication.Cursor = Cursors.Hand;
            CreateApplication.FlatAppearance.BorderSize = 0;
            CreateApplication.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            CreateApplication.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            CreateApplication.FlatStyle = FlatStyle.Flat;
            CreateApplication.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateApplication.ForeColor = Color.WhiteSmoke;
            CreateApplication.Location = new Point(20, 411);
            CreateApplication.Name = "CreateApplication";
            CreateApplication.Size = new Size(100, 60);
            CreateApplication.TabIndex = 5;
            CreateApplication.Text = "Создать заявку";
            CreateApplication.UseVisualStyleBackColor = false;
            CreateApplication.Click += CreateApplication_Click;
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
            panel2.Size = new Size(444, 100);
            panel2.TabIndex = 0;
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
            CloseButton.Location = new Point(418, 1);
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
            label1.Size = new Size(444, 100);
            label1.TabIndex = 0;
            label1.Text = "Регистрация заявки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(130, 240);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(283, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 604);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ApplicationForm";
            Text = "ApplicationForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button CreateApplication;
        private Label ToUsersMenuLabel;
        private Label CloseButton;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label5;
    }
}