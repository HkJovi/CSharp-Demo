namespace 一元二次方程计算器
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TB_a = new System.Windows.Forms.TextBox();
            this.TB_b = new System.Windows.Forms.TextBox();
            this.TB_c = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_x2 = new System.Windows.Forms.Label();
            this.label_x1 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.X2 = new System.Windows.Forms.Label();
            this.X1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_a
            // 
            this.TB_a.Location = new System.Drawing.Point(6, 20);
            this.TB_a.MaxLength = 26;
            this.TB_a.Name = "TB_a";
            this.TB_a.Size = new System.Drawing.Size(44, 21);
            this.TB_a.TabIndex = 0;
            // 
            // TB_b
            // 
            this.TB_b.Location = new System.Drawing.Point(91, 20);
            this.TB_b.MaxLength = 26;
            this.TB_b.Name = "TB_b";
            this.TB_b.Size = new System.Drawing.Size(41, 21);
            this.TB_b.TabIndex = 1;
            // 
            // TB_c
            // 
            this.TB_c.Location = new System.Drawing.Point(167, 20);
            this.TB_c.MaxLength = 26;
            this.TB_c.Name = "TB_c";
            this.TB_c.Size = new System.Drawing.Size(40, 21);
            this.TB_c.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "X² +";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "X +";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "= 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_calculate);
            this.groupBox1.Controls.Add(this.TB_a);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_c);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_b);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入参数：";
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(79, 71);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate.TabIndex = 7;
            this.btn_calculate.Text = "计算";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_x2);
            this.groupBox2.Controls.Add(this.label_x1);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.X2);
            this.groupBox2.Controls.Add(this.X1);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果：";
            // 
            // label_x2
            // 
            this.label_x2.AutoSize = true;
            this.label_x2.ForeColor = System.Drawing.Color.Red;
            this.label_x2.Location = new System.Drawing.Point(56, 33);
            this.label_x2.Name = "label_x2";
            this.label_x2.Size = new System.Drawing.Size(23, 12);
            this.label_x2.TabIndex = 4;
            this.label_x2.Text = "   ";
            // 
            // label_x1
            // 
            this.label_x1.AutoSize = true;
            this.label_x1.ForeColor = System.Drawing.Color.Red;
            this.label_x1.Location = new System.Drawing.Point(56, 17);
            this.label_x1.Name = "label_x1";
            this.label_x1.Size = new System.Drawing.Size(23, 12);
            this.label_x1.TabIndex = 3;
            this.label_x1.Text = "   ";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(79, 53);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // X2
            // 
            this.X2.AutoSize = true;
            this.X2.Location = new System.Drawing.Point(21, 33);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(29, 12);
            this.X2.TabIndex = 1;
            this.X2.Text = "x2 =";
            // 
            // X1
            // 
            this.X1.AutoSize = true;
            this.X1.Location = new System.Drawing.Point(21, 17);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(29, 12);
            this.X1.TabIndex = 0;
            this.X1.Text = "x1 =";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 206);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "方程计算器  by Jovi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_a;
        private System.Windows.Forms.TextBox TB_b;
        private System.Windows.Forms.TextBox TB_c;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label X2;
        private System.Windows.Forms.Label X1;
        private System.Windows.Forms.Label label_x2;
        private System.Windows.Forms.Label label_x1;
        private System.Windows.Forms.Button btn_clear;
    }
}

