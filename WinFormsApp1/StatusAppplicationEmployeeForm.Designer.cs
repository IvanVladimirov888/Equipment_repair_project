namespace WinFormsApp1
{
    partial class StatusAppplicationEmployeeForm
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
            panel3 = new Panel();
            label17 = new Label();
            comboBox4 = new ComboBox();
            Edit = new Button();
            ConfirmationButton = new Button();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            panel2 = new Panel();
            ToEmployeeMenuLabel = new Label();
            CloseButton = new Label();
            panel1 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label15 = new Label();
            textBox10 = new TextBox();
            label14 = new Label();
            textBox9 = new TextBox();
            label13 = new Label();
            textBox8 = new TextBox();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label4 = new Label();
            panel6 = new Panel();
            label16 = new Label();
            comboBox3 = new ComboBox();
            Add = new Button();
            label5 = new Label();
            comboBox2 = new ComboBox();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(152, 160, 220);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(comboBox4);
            panel3.Controls.Add(Edit);
            panel3.Controls.Add(ConfirmationButton);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(comboBox1);
            panel3.Location = new Point(720, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(187, 574);
            panel3.TabIndex = 24;
            panel3.MouseDown += panel1_MouseDown;
            panel3.MouseMove += panel1_MouseMove;
            // 
            // label17
            // 
            label17.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label17.ForeColor = Color.WhiteSmoke;
            label17.Location = new Point(10, 152);
            label17.Name = "label17";
            label17.Size = new Size(160, 45);
            label17.TabIndex = 29;
            label17.Text = "Выберите дату создания заявки:";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox4
            // 
            comboBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(10, 216);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(160, 23);
            comboBox4.TabIndex = 28;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // Edit
            // 
            Edit.BackColor = Color.FromArgb(179, 167, 218);
            Edit.Cursor = Cursors.Hand;
            Edit.FlatAppearance.BorderSize = 0;
            Edit.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            Edit.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            Edit.FlatStyle = FlatStyle.Flat;
            Edit.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Edit.ForeColor = Color.WhiteSmoke;
            Edit.Location = new Point(23, 273);
            Edit.Name = "Edit";
            Edit.Size = new Size(130, 70);
            Edit.TabIndex = 26;
            Edit.Text = "Редактировать";
            Edit.UseVisualStyleBackColor = false;
            Edit.Click += Edit_Click;
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
            ConfirmationButton.Location = new Point(23, 349);
            ConfirmationButton.Name = "ConfirmationButton";
            ConfirmationButton.Size = new Size(130, 70);
            ConfirmationButton.TabIndex = 27;
            ConfirmationButton.Text = "Подтвердить";
            ConfirmationButton.UseVisualStyleBackColor = false;
            ConfirmationButton.Visible = false;
            ConfirmationButton.Click += ConfirmationButton_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(10, 41);
            label7.Name = "label7";
            label7.Size = new Size(160, 45);
            label7.TabIndex = 24;
            label7.Text = "Выберите серийный номер оборудования:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 105);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 23);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1391, 100);
            label1.TabIndex = 0;
            label1.Text = "Статус заявки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // label6
            // 
            label6.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(5, 288);
            label6.Name = "label6";
            label6.Size = new Size(285, 57);
            label6.TabIndex = 21;
            label6.Text = "Итоговое описание выполненных работ:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(351, 172);
            label3.Name = "label3";
            label3.Size = new Size(105, 45);
            label3.TabIndex = 18;
            label3.Text = "Дата конца работы:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(5, 172);
            label2.Name = "label2";
            label2.Size = new Size(105, 45);
            label2.TabIndex = 17;
            label2.Text = "Дата начала работы:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(3, 339);
            textBox4.MaxLength = 100;
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "The final description of the work performed:";
            textBox4.Size = new Size(348, 358);
            textBox4.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(112, 135, 208);
            panel2.Controls.Add(ToEmployeeMenuLabel);
            panel2.Controls.Add(CloseButton);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1391, 100);
            panel2.TabIndex = 0;
            // 
            // ToEmployeeMenuLabel
            // 
            ToEmployeeMenuLabel.AutoSize = true;
            ToEmployeeMenuLabel.Cursor = Cursors.Hand;
            ToEmployeeMenuLabel.FlatStyle = FlatStyle.Flat;
            ToEmployeeMenuLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ToEmployeeMenuLabel.ForeColor = Color.White;
            ToEmployeeMenuLabel.Location = new Point(0, 0);
            ToEmployeeMenuLabel.Name = "ToEmployeeMenuLabel";
            ToEmployeeMenuLabel.Size = new Size(50, 37);
            ToEmployeeMenuLabel.TabIndex = 13;
            ToEmployeeMenuLabel.Text = "←";
            ToEmployeeMenuLabel.Click += ToEmployeeMenuLabel_Click;
            ToEmployeeMenuLabel.MouseEnter += ToEmployeeMenuLabel_MouseEnter;
            ToEmployeeMenuLabel.MouseLeave += ToEmployeeMenuLabel_MouseLeave;
            // 
            // CloseButton
            // 
            CloseButton.AutoSize = true;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.Location = new Point(1362, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 32);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "x";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(textBox10);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(textBox9);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(textBox8);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(481, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 100, 0, 0);
            panel1.Size = new Size(910, 706);
            panel1.TabIndex = 9;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Enabled = false;
            dateTimePicker2.Location = new Point(462, 184);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(252, 23);
            dateTimePicker2.TabIndex = 42;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(118, 182);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(233, 23);
            dateTimePicker1.TabIndex = 41;
            // 
            // label15
            // 
            label15.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label15.ForeColor = Color.WhiteSmoke;
            label15.Location = new Point(351, 547);
            label15.Name = "label15";
            label15.Size = new Size(105, 74);
            label15.TabIndex = 40;
            label15.Text = "Координация с другими специалистами::";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox10
            // 
            textBox10.Enabled = false;
            textBox10.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox10.Location = new Point(462, 547);
            textBox10.MaxLength = 100;
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.PlaceholderText = "Description";
            textBox10.Size = new Size(252, 150);
            textBox10.TabIndex = 39;
            // 
            // label14
            // 
            label14.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label14.ForeColor = Color.WhiteSmoke;
            label14.Location = new Point(351, 394);
            label14.Name = "label14";
            label14.Size = new Size(105, 45);
            label14.TabIndex = 38;
            label14.Text = "Затраченные ресурсы:";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox9
            // 
            textBox9.Enabled = false;
            textBox9.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox9.Location = new Point(462, 394);
            textBox9.MaxLength = 100;
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.PlaceholderText = "Description";
            textBox9.Size = new Size(252, 150);
            textBox9.TabIndex = 37;
            // 
            // label13
            // 
            label13.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label13.ForeColor = Color.WhiteSmoke;
            label13.Location = new Point(351, 239);
            label13.Name = "label13";
            label13.Size = new Size(105, 45);
            label13.TabIndex = 36;
            label13.Text = "Потребность в запчастях:";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox8
            // 
            textBox8.Enabled = false;
            textBox8.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox8.Location = new Point(462, 239);
            textBox8.MaxLength = 100;
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "Description";
            textBox8.Size = new Size(252, 150);
            textBox8.TabIndex = 35;
            // 
            // label11
            // 
            label11.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label11.ForeColor = Color.WhiteSmoke;
            label11.Location = new Point(5, 239);
            label11.Name = "label11";
            label11.Size = new Size(105, 45);
            label11.TabIndex = 34;
            label11.Text = "Итоговая цена:";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            textBox7.Enabled = false;
            textBox7.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.Location = new Point(118, 239);
            textBox7.MaxLength = 100;
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Cost";
            textBox7.Size = new Size(233, 45);
            textBox7.TabIndex = 33;
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(152, 160, 220);
            label12.Dock = DockStyle.Top;
            label12.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label12.ForeColor = Color.WhiteSmoke;
            label12.Location = new Point(0, 100);
            label12.Name = "label12";
            label12.Size = new Size(910, 54);
            label12.TabIndex = 32;
            label12.Text = "Итоговый отчет:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            label12.MouseDown += panel1_MouseDown;
            label12.MouseMove += panel1_MouseMove;
            // 
            // panel4
            // 
            panel4.AccessibleRole = AccessibleRole.IpAddress;
            panel4.BackColor = Color.FromArgb(152, 170, 231);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1391, 706);
            panel4.TabIndex = 10;
            // 
            // panel5
            // 
            panel5.AccessibleRole = AccessibleRole.IpAddress;
            panel5.BackColor = Color.FromArgb(152, 170, 231);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(textBox3);
            panel5.Controls.Add(textBox5);
            panel5.Controls.Add(textBox6);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(0, 100, 0, 0);
            panel5.Size = new Size(477, 706);
            panel5.TabIndex = 12;
            panel5.MouseDown += panel1_MouseDown;
            panel5.MouseMove += panel1_MouseMove;
            // 
            // label8
            // 
            label8.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(5, 288);
            label8.Name = "label8";
            label8.Size = new Size(281, 48);
            label8.TabIndex = 21;
            label8.Text = "Описание проделанной работы:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(5, 234);
            label9.Name = "label9";
            label9.Size = new Size(105, 45);
            label9.TabIndex = 18;
            label9.Text = "Цена работы:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label10.ForeColor = Color.WhiteSmoke;
            label10.Location = new Point(5, 174);
            label10.Name = "label10";
            label10.Size = new Size(105, 45);
            label10.TabIndex = 17;
            label10.Text = "Время работы (мин):";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(3, 339);
            textBox3.MaxLength = 100;
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Description of the work done";
            textBox3.Size = new Size(283, 358);
            textBox3.TabIndex = 15;
            // 
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(116, 234);
            textBox5.MaxLength = 100;
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Cost";
            textBox5.Size = new Size(117, 45);
            textBox5.TabIndex = 14;
            // 
            // textBox6
            // 
            textBox6.Enabled = false;
            textBox6.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.Location = new Point(116, 174);
            textBox6.MaxLength = 100;
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Time";
            textBox6.Size = new Size(117, 45);
            textBox6.TabIndex = 13;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(152, 160, 220);
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(0, 100);
            label4.Name = "label4";
            label4.Size = new Size(477, 54);
            label4.TabIndex = 32;
            label4.Text = "Исполняемые работы";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.MouseDown += panel1_MouseDown;
            label4.MouseMove += panel1_MouseMove;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(152, 160, 220);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(comboBox3);
            panel6.Controls.Add(Add);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(comboBox2);
            panel6.Location = new Point(292, 147);
            panel6.Name = "panel6";
            panel6.Size = new Size(187, 571);
            panel6.TabIndex = 24;
            panel6.MouseDown += panel1_MouseDown;
            panel6.MouseMove += panel1_MouseMove;
            // 
            // label16
            // 
            label16.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label16.ForeColor = Color.WhiteSmoke;
            label16.Location = new Point(10, 152);
            label16.Name = "label16";
            label16.Size = new Size(160, 45);
            label16.TabIndex = 28;
            label16.Text = "Выберите дату создания заявки:";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(10, 211);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(147, 23);
            comboBox3.TabIndex = 27;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // Add
            // 
            Add.BackColor = Color.FromArgb(179, 167, 218);
            Add.Cursor = Cursors.Hand;
            Add.FlatAppearance.BorderSize = 0;
            Add.FlatAppearance.MouseDownBackColor = Color.FromArgb(112, 104, 136);
            Add.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 40, 118);
            Add.FlatStyle = FlatStyle.Flat;
            Add.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Add.ForeColor = Color.WhiteSmoke;
            Add.Location = new Point(16, 262);
            Add.Name = "Add";
            Add.Size = new Size(130, 70);
            Add.TabIndex = 26;
            Add.Text = "Добавить";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(10, 41);
            label5.Name = "label5";
            label5.Size = new Size(160, 45);
            label5.TabIndex = 24;
            label5.Text = "Выберите серийный номер оборудования:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(10, 105);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(147, 23);
            comboBox2.TabIndex = 22;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // StatusAppplicationEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 706);
            Controls.Add(panel2);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StatusAppplicationEmployeeForm";
            Text = "StatusAppplicationEmployeeForm";
            Load += StatusAppplicationEmployeeForm_Load;
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label label7;
        private ComboBox comboBox1;
        private Label label1;
        private Label label6;
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private Panel panel2;
        private Label ToEmployeeMenuLabel;
        private Label CloseButton;
        private Panel panel1;
        private Panel panel4;
        private Label label12;
        private Panel panel5;
        private Label label4;
        private Panel panel6;
        private Label label5;
        private ComboBox comboBox2;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox8;
        private Label label11;
        private TextBox textBox7;
        private Label label13;
        private Label label15;
        private TextBox textBox10;
        private Label label14;
        private TextBox textBox9;
        private Button Add;
        private Button Edit;
        private Button ConfirmationButton;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label16;
        private ComboBox comboBox3;
        private Label label17;
        private ComboBox comboBox4;
    }
}