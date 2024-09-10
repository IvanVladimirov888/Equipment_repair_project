namespace WinFormsApp1
{
    partial class StatisticsForm
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
            textBox2 = new TextBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            ToEmployeeMenuLabel = new Label();
            CloseButton = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.IpAddress;
            panel1.BackColor = Color.FromArgb(152, 170, 231);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 7;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(194, 175);
            textBox2.MaxLength = 100;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Time";
            textBox2.Size = new Size(283, 45);
            textBox2.TabIndex = 31;
            // 
            // label3
            // 
            label3.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(12, 175);
            label3.Name = "label3";
            label3.Size = new Size(151, 45);
            label3.TabIndex = 30;
            label3.Text = "Среднее время выполнения работы";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(152, 170, 231);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(152, 170, 231);
            dataGridView1.Location = new Point(3, 240);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(797, 210);
            dataGridView1.TabIndex = 29;
            // 
            // label2
            // 
            label2.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(12, 112);
            label2.Name = "label2";
            label2.Size = new Size(151, 45);
            label2.TabIndex = 26;
            label2.Text = "Количество выполненных заявок:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(194, 112);
            textBox1.MaxLength = 100;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Quantity";
            textBox1.Size = new Size(283, 45);
            textBox1.TabIndex = 25;
            // 
            // label7
            // 
            label7.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(613, 163);
            label7.Name = "label7";
            label7.Size = new Size(160, 45);
            label7.TabIndex = 28;
            label7.Text = "Выберите неисправность:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(613, 211);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 23);
            comboBox1.TabIndex = 27;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            panel2.Size = new Size(800, 100);
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
            CloseButton.Location = new Point(774, 0);
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
            label1.Size = new Size(800, 100);
            label1.TabIndex = 0;
            label1.Text = "Ваша статистика";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += panel1_MouseDown;
            label1.MouseMove += panel1_MouseMove;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            Load += StatisticsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label ToEmployeeMenuLabel;
        private Label CloseButton;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label7;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private Label label3;
    }
}