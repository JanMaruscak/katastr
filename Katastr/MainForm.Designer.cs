﻿namespace Katastr
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.loadImg_btn = new System.Windows.Forms.Button();
            this.image_pBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.meritko_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.meritko_btn = new System.Windows.Forms.Button();
            this.measure_cBox = new System.Windows.Forms.ComboBox();
            this.ratio_num = new System.Windows.Forms.NumericUpDown();
            this.export_btn = new System.Windows.Forms.Button();
            this.measureMeritko_btn = new System.Windows.Forms.Button();
            this.ratio_label = new System.Windows.Forms.Label();
            this.wholeArea_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.image_pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratio_num)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImg_btn
            // 
            this.loadImg_btn.Location = new System.Drawing.Point(550, 12);
            this.loadImg_btn.Name = "loadImg_btn";
            this.loadImg_btn.Size = new System.Drawing.Size(111, 36);
            this.loadImg_btn.TabIndex = 0;
            this.loadImg_btn.Text = "Load Image";
            this.loadImg_btn.UseVisualStyleBackColor = true;
            this.loadImg_btn.Click += new System.EventHandler(this.loadImg_btn_Click);
            // 
            // image_pBox
            // 
            this.image_pBox.Location = new System.Drawing.Point(12, 12);
            this.image_pBox.Name = "image_pBox";
            this.image_pBox.Size = new System.Drawing.Size(479, 402);
            this.image_pBox.TabIndex = 2;
            this.image_pBox.TabStop = false;
            this.image_pBox.Click += new System.EventHandler(this.image_pBox_Click);
            this.image_pBox.Paint += new System.Windows.Forms.PaintEventHandler(this.image_pBox_Paint);
            this.image_pBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.image_pBox_MouseDown);
            this.image_pBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.image_pBox_MouseMove);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(550, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 27);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(550, 400);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 4;
            // 
            // meritko_txt
            // 
            this.meritko_txt.Location = new System.Drawing.Point(550, 263);
            this.meritko_txt.Name = "meritko_txt";
            this.meritko_txt.Size = new System.Drawing.Size(125, 27);
            this.meritko_txt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Meritko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Obsah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Obvod";
            // 
            // meritko_btn
            // 
            this.meritko_btn.Location = new System.Drawing.Point(738, 258);
            this.meritko_btn.Name = "meritko_btn";
            this.meritko_btn.Size = new System.Drawing.Size(111, 36);
            this.meritko_btn.TabIndex = 9;
            this.meritko_btn.Text = "Load Meritko";
            this.meritko_btn.UseVisualStyleBackColor = true;
            this.meritko_btn.Click += new System.EventHandler(this.meritko_btn_Click);
            // 
            // measure_cBox
            // 
            this.measure_cBox.FormattingEnabled = true;
            this.measure_cBox.Location = new System.Drawing.Point(681, 262);
            this.measure_cBox.Name = "measure_cBox";
            this.measure_cBox.Size = new System.Drawing.Size(51, 28);
            this.measure_cBox.TabIndex = 11;
            this.measure_cBox.SelectedIndexChanged += new System.EventHandler(this.measure_cBox_SelectedIndexChanged);
            // 
            // ratio_num
            // 
            this.ratio_num.Location = new System.Drawing.Point(561, 138);
            this.ratio_num.Name = "ratio_num";
            this.ratio_num.Size = new System.Drawing.Size(150, 27);
            this.ratio_num.TabIndex = 12;
            // 
            // export_btn
            // 
            this.export_btn.Location = new System.Drawing.Point(766, 12);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(111, 36);
            this.export_btn.TabIndex = 13;
            this.export_btn.Text = "Export Image";
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // measureMeritko_btn
            // 
            this.measureMeritko_btn.Location = new System.Drawing.Point(647, 199);
            this.measureMeritko_btn.Name = "measureMeritko_btn";
            this.measureMeritko_btn.Size = new System.Drawing.Size(120, 29);
            this.measureMeritko_btn.TabIndex = 14;
            this.measureMeritko_btn.Text = "Start Meritko";
            this.measureMeritko_btn.UseVisualStyleBackColor = true;
            this.measureMeritko_btn.Click += new System.EventHandler(this.measureMeritko_btn_Click);
            // 
            // ratio_label
            // 
            this.ratio_label.AutoSize = true;
            this.ratio_label.Location = new System.Drawing.Point(720, 304);
            this.ratio_label.Name = "ratio_label";
            this.ratio_label.Size = new System.Drawing.Size(96, 20);
            this.ratio_label.TabIndex = 15;
            this.ratio_label.Text = "1px = 1000m";
            // 
            // wholeArea_label
            // 
            this.wholeArea_label.AutoSize = true;
            this.wholeArea_label.Location = new System.Drawing.Point(635, 86);
            this.wholeArea_label.Name = "wholeArea_label";
            this.wholeArea_label.Size = new System.Drawing.Size(52, 20);
            this.wholeArea_label.TabIndex = 16;
            this.wholeArea_label.Text = "Whole";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 539);
            this.Controls.Add(this.wholeArea_label);
            this.Controls.Add(this.ratio_label);
            this.Controls.Add(this.measureMeritko_btn);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.ratio_num);
            this.Controls.Add(this.measure_cBox);
            this.Controls.Add(this.meritko_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.meritko_txt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.image_pBox);
            this.Controls.Add(this.loadImg_btn);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratio_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loadImg_btn;
        private PictureBox image_pBox;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox meritko_txt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button meritko_btn;
        private ComboBox measure_cBox;
        private NumericUpDown ratio_num;
        private Button export_btn;
        private Button measureMeritko_btn;
        private Label ratio_label;
        private Label wholeArea_label;
        private System.Windows.Forms.Timer timer1;
    }
}