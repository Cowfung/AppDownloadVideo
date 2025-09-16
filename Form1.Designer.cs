namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            textBox5 = new TextBox();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            panel3 = new Panel();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBoxLog = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(-1, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(677, 82);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonShadow;
            label3.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(108, 11);
            label3.Name = "label3";
            label3.Size = new Size(451, 50);
            label3.TabIndex = 0;
            label3.Text = "Video Download Manager";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 161);
            panel2.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.GrayText;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = SystemColors.Window;
            textBox5.Location = new Point(13, 80);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(65, 16);
            textBox5.TabIndex = 4;
            textBox5.Text = "OUTPUT TO ";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(544, 111);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 3;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.GrayText;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = SystemColors.Window;
            textBox4.Location = new Point(13, 9);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(65, 16);
            textBox4.TabIndex = 2;
            textBox4.Text = "URL VIDEO";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(13, 111);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(502, 23);
            textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 38);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(502, 23);
            textBox2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(textBoxLog);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(comboBox1);
            panel3.Location = new Point(0, 270);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 187);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(217, 77);
            button2.Name = "button2";
            button2.Size = new Size(208, 29);
            button2.TabIndex = 5;
            button2.Text = "DOWNLOAD";
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(172, 8);
            label2.Name = "label2";
            label2.Size = new Size(125, 21);
            label2.TabIndex = 3;
            label2.Text = "Chọn chất lượng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(13, 8);
            label1.Name = "label1";
            label1.Size = new Size(121, 21);
            label1.TabIndex = 2;
            label1.Text = "Chọn định dạng";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.AddRange(new object[] { "Best", "1080p", "720p", "480p", "360p" });
            comboBox2.Location = new Point(164, 38);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 23);
            comboBox2.TabIndex = 1;
            comboBox2.Tag = "";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Location = new Point(13, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Tag = "";
            // 
            // textBoxLog
            // 
            textBoxLog.BackColor = SystemColors.MenuText;
            textBoxLog.ForeColor = SystemColors.MenuBar;
            textBoxLog.Location = new Point(47, 121);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(584, 52);
            textBoxLog.TabIndex = 6;
            textBoxLog.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(675, 469);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox5;
        private Panel panel3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button2;
        private TextBox textBoxLog;
    }
}
