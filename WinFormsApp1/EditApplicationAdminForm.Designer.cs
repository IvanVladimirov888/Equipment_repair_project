namespace WinFormsApp1
{
    partial class EditApplicationAdminForm
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
            label7 = new Label();
            comboBox3 = new ComboBox();
            label8 = new Label();
            dateTimePicker2 = new DateTimePicker();
            EditApplication = new Button();
            comboBox1 = new ComboBox();
            label9 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            ToUsersMenuLabel = new Label();
            CloseButton = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel1 = new Panel();
            comboBox4 = new ComboBox();
            textBox5 = new TextBox();
            label12 = new Label();
            label11 = new Label();
            checkBox1 = new CheckBox();
            label10 = new Label();
            label13 = new Label();
            Deletebutton = new Button();
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
            ConfirmationButton.Location = new Point(5, 475);
            ConfirmationButton.Name = "ConfirmationButton";
            ConfirmationButton.Size = new Size(120, 60);
            ConfirmationButton.TabIndex = 25;
            ConfirmationButton.Text = "Подтвердить";
            ConfirmationButton.UseVisualStyleBackColor = false;
            ConfirmationButton.Visible = false;
            ConfirmationButton.Click += ConfirmationButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(152, 160, 220);
            panel3.Controls.Add(Deletebutton);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(comboBox3);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(dateTimePicker2);
            panel3.Controls.Add(EditApplication);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label9);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(576, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(213, 573);
            panel3.TabIndex = 24;
            panel3.MouseDown += panel1_MouseDown;
            panel3.MouseMove += panel1_MouseMove;
            // 
            // label7
            // 
            label7.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(25, 128);
            label7.Name = "label7";
            label7.Size = new Size(160, 45);
            label7.TabIndex = 29;
            label7.Text = "Выберете серийный номер оборудования:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(25, 183);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(173, 23);
            comboBox3.TabIndex = 28;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(25, 238);
            label8.Name = "label8";
            label8.Size = new Size(160, 45);
            label8.TabIndex = 25;
            label8.Text = "Выберете дату создания заявки:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker2.Location = new Point(25, 293);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(173, 23);
            dateTimePicker2.TabIndex = 23;
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
            EditApplication.Location = new Point(30, 338);
            EditApplication.Name = "EditApplication";
            EditApplication.Size = new Size(160, 75);
            EditApplication.TabIndex = 5;
            EditApplication.Text = "Редактировать заявку";
            EditApplication.UseVisualStyleBackColor = false;
            EditApplication.Click += EditApplication_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(25, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(173, 23);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(25, 30);
            label9.Name = "label9";
            label9.Size = new Size(160, 45);
            label9.TabIndex = 27;
            label9.Text = "Выберете ФИО клиента:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Enabled = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(419, 372);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 23);
            comboBox2.TabIndex = 26;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
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
            CloseButton.Location = new Point(763, -2);
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
            label6.Text = "Исполнитель:";
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
            textBox3.Enabled = false;
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
            textBox4.Enabled = false;
            textBox4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(130, 405);
            textBox4.MaxLength = 100;
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Description of the problem";
            textBox4.Size = new Size(283, 242);
            textBox4.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
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
            textBox1.Enabled = false;
            textBox1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(130, 130);
            textBox1.MaxLength = 100;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Type of equipment";
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
            panel2.Size = new Size(789, 100);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(789, 100);
            label1.TabIndex = 0;
            label1.Text = "Редактирование заявки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(130, 250);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(283, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(comboBox4);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(ConfirmationButton);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label13);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(789, 673);
            panel1.TabIndex = 8;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // comboBox4
            // 
            comboBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Enabled = false;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(419, 283);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(151, 23);
            comboBox4.TabIndex = 34;
            // 
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(130, 350);
            textBox5.MaxLength = 100;
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "The performer of the work";
            textBox5.Size = new Size(283, 45);
            textBox5.TabIndex = 32;
            // 
            // label12
            // 
            label12.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label12.ForeColor = Color.WhiteSmoke;
            label12.Location = new Point(408, 335);
            label12.Name = "label12";
            label12.Size = new Size(176, 45);
            label12.TabIndex = 33;
            label12.Text = "Список исполнителей:";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label11.ForeColor = Color.WhiteSmoke;
            label11.Location = new Point(20, 405);
            label11.Name = "label11";
            label11.Size = new Size(105, 45);
            label11.TabIndex = 30;
            label11.Text = "Описание проблемы:";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.WhiteSmoke;
            checkBox1.Location = new Point(431, 178);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.No;
            checkBox1.Size = new Size(145, 23);
            checkBox1.TabIndex = 29;
            checkBox1.TabStop = false;
            checkBox1.Text = "Зарегистрирована";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label10
            // 
            label10.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label10.ForeColor = Color.WhiteSmoke;
            label10.Location = new Point(431, 130);
            label10.Name = "label10";
            label10.Size = new Size(105, 45);
            label10.TabIndex = 28;
            label10.Text = "Статус заявки:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label13.ForeColor = Color.WhiteSmoke;
            label13.Location = new Point(408, 240);
            label13.Name = "label13";
            label13.Size = new Size(176, 45);
            label13.TabIndex = 35;
            label13.Text = "Приоритет выполнения";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Deletebutton
            // 
            Deletebutton.BackColor = Color.FromArgb(179, 167, 218);
            Deletebutton.Cursor = Cursors.Hand;
            Deletebutton.FlatAppearance.BorderSize = 0;
            Deletebutton.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            Deletebutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            Deletebutton.FlatStyle = FlatStyle.Flat;
            Deletebutton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Deletebutton.ForeColor = Color.WhiteSmoke;
            Deletebutton.Location = new Point(30, 431);
            Deletebutton.Name = "Deletebutton";
            Deletebutton.Size = new Size(160, 75);
            Deletebutton.TabIndex = 30;
            Deletebutton.Text = "Удалить заявку";
            Deletebutton.UseVisualStyleBackColor = false;
            Deletebutton.Click += Deletebutton_Click;
            // 
            // EditApplicationAdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 673);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditApplicationAdminForm";
            Load += EditApplicationAdminForm_Load;
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
        private Label label8;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox1;
        private Button EditApplication;
        private Label label4;
        private Label ToUsersMenuLabel;
        private Label CloseButton;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private Label label9;
        private ComboBox comboBox2;
        private CheckBox checkBox1;
        private Label label10;
        private TextBox textBox5;
        private Label label11;
        private Label label12;
        private Label label7;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label13;
        private Button Deletebutton;
    }
}