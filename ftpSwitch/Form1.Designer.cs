namespace ftpSwitch
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Reset = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Easy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Dictionary = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StateShow = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("宋体", 14F);
            this.Reset.Location = new System.Drawing.Point(315, 170);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(137, 58);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "重置";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.button2_Click);
            // 
            // Start
            // 
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Start.Font = new System.Drawing.Font("宋体", 14F);
            this.Start.Location = new System.Drawing.Point(93, 170);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(197, 58);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始扫描";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Easy
            // 
            this.Easy.AutoSize = true;
            this.Easy.Checked = true;
            this.Easy.Font = new System.Drawing.Font("宋体", 14F);
            this.Easy.Location = new System.Drawing.Point(228, 98);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(200, 42);
            this.Easy.TabIndex = 0;
            this.Easy.TabStop = true;
            this.Easy.Text = "简单密码";
            this.Easy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(95, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F);
            this.label2.Location = new System.Drawing.Point(95, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = "模式";
            this.label2.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(164, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 44);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "请输入IP地址";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Dictionary
            // 
            this.Dictionary.AutoSize = true;
            this.Dictionary.Font = new System.Drawing.Font("宋体", 14F);
            this.Dictionary.Location = new System.Drawing.Point(462, 98);
            this.Dictionary.Name = "Dictionary";
            this.Dictionary.Size = new System.Drawing.Size(162, 42);
            this.Dictionary.TabIndex = 6;
            this.Dictionary.Text = "字典序";
            this.Dictionary.UseVisualStyleBackColor = true;
            this.Dictionary.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.tabControl1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 872);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Dictionary);
            this.tabPage1.Controls.Add(this.Reset);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.Start);
            this.tabPage1.Controls.Add(this.Easy);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(8, 51);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(987, 813);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FTP扫描";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F);
            this.label3.Location = new System.Drawing.Point(454, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 43);
            this.label3.TabIndex = 8;
            this.label3.Text = "TO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StateShow);
            this.groupBox1.Location = new System.Drawing.Point(97, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 544);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫描状态";
            // 
            // StateShow
            // 
            this.StateShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StateShow.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateShow.Location = new System.Drawing.Point(6, 42);
            this.StateShow.Name = "StateShow";
            this.StateShow.Size = new System.Drawing.Size(731, 496);
            this.StateShow.TabIndex = 0;
            this.StateShow.Text = "";
            this.StateShow.TextChanged += new System.EventHandler(this.StateShow_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 51);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(987, 813);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FTP破解";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox2.Location = new System.Drawing.Point(538, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(264, 44);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "请输入IP地址";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 872);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "FTP扫描";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.RadioButton Easy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton Dictionary;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox StateShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
    }
}

