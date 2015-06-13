namespace 禁止程序运行工具
{
    partial class shutdown
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
            this.btn_yes = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_s = new System.Windows.Forms.TextBox();
            this.tb_m = new System.Windows.Forms.TextBox();
            this.tb_h = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_yes
            // 
            this.btn_yes.Location = new System.Drawing.Point(12, 111);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(75, 23);
            this.btn_yes.TabIndex = 0;
            this.btn_yes.Text = "确定";
            this.btn_yes.UseVisualStyleBackColor = true;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(150, 111);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(75, 23);
            this.btn_no.TabIndex = 1;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_s);
            this.groupBox1.Controls.Add(this.tb_m);
            this.groupBox1.Controls.Add(this.tb_h);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关机时间设定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(201, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(129, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "M：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(54, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "H：";
            // 
            // tb_s
            // 
            this.tb_s.Location = new System.Drawing.Point(153, 48);
            this.tb_s.Name = "tb_s";
            this.tb_s.Size = new System.Drawing.Size(42, 21);
            this.tb_s.TabIndex = 3;
            this.tb_s.Tag = "秒";
            this.tb_s.Text = "秒";
            this.tb_s.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_h_MouseClick);
            this.tb_s.Leave += new System.EventHandler(this.tb_h_Leave);
            // 
            // tb_m
            // 
            this.tb_m.Location = new System.Drawing.Point(83, 48);
            this.tb_m.Name = "tb_m";
            this.tb_m.Size = new System.Drawing.Size(40, 21);
            this.tb_m.TabIndex = 2;
            this.tb_m.Tag = "分钟";
            this.tb_m.Text = "分钟";
            this.tb_m.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_h_MouseClick);
            this.tb_m.Leave += new System.EventHandler(this.tb_h_Leave);
            // 
            // tb_h
            // 
            this.tb_h.Location = new System.Drawing.Point(9, 48);
            this.tb_h.Name = "tb_h";
            this.tb_h.Size = new System.Drawing.Size(39, 21);
            this.tb_h.TabIndex = 1;
            this.tb_h.Tag = "小时";
            this.tb_h.Text = "小时";
            this.tb_h.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_h_MouseClick);
            this.tb_h.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_h_KeyPress);
            this.tb_h.Leave += new System.EventHandler(this.tb_h_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "距离关机时间：";
            // 
            // shutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 141);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "shutdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "shutdown";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_s;
        private System.Windows.Forms.TextBox tb_m;
        private System.Windows.Forms.TextBox tb_h;
        private System.Windows.Forms.Label label1;
    }
}