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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Easy = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Dictionary = new System.Windows.Forms.RadioButton();
            this.StateShow = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(299, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(508, 44);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "请输入IP地址";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(161, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Start
            // 
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Start.Font = new System.Drawing.Font("宋体", 14F);
            this.Start.Location = new System.Drawing.Point(169, 253);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(197, 58);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始扫描";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("宋体", 14F);
            this.Reset.Location = new System.Drawing.Point(399, 253);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(137, 58);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "重置";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.StateShow);
            this.panel1.Location = new System.Drawing.Point(166, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 356);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Easy
            // 
            this.Easy.AutoSize = true;
            this.Easy.Font = new System.Drawing.Font("宋体", 14F);
            this.Easy.Location = new System.Drawing.Point(299, 166);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(200, 42);
            this.Easy.TabIndex = 0;
            this.Easy.TabStop = true;
            this.Easy.Text = "简单密码";
            this.Easy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F);
            this.label2.Location = new System.Drawing.Point(161, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = "模式";
            this.label2.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // Dictionary
            // 
            this.Dictionary.AutoSize = true;
            this.Dictionary.Font = new System.Drawing.Font("宋体", 14F);
            this.Dictionary.Location = new System.Drawing.Point(523, 166);
            this.Dictionary.Name = "Dictionary";
            this.Dictionary.Size = new System.Drawing.Size(162, 42);
            this.Dictionary.TabIndex = 6;
            this.Dictionary.TabStop = true;
            this.Dictionary.Text = "字典序";
            this.Dictionary.UseVisualStyleBackColor = true;
            this.Dictionary.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // StateShow
            // 
            this.StateShow.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateShow.Location = new System.Drawing.Point(0, 0);
            this.StateShow.Name = "StateShow";
            this.StateShow.Size = new System.Drawing.Size(639, 354);
            this.StateShow.TabIndex = 0;
            this.StateShow.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 872);
            this.Controls.Add(this.Dictionary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Easy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "FTP扫描";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Easy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Dictionary;
        private System.Windows.Forms.RichTextBox StateShow;
    }
}

