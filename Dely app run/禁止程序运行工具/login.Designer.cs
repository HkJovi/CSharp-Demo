namespace 禁止程序运行工具
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.button_qd = new System.Windows.Forms.Button();
            this.button_qx = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_hide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_qd
            // 
            this.button_qd.Location = new System.Drawing.Point(14, 81);
            this.button_qd.Name = "button_qd";
            this.button_qd.Size = new System.Drawing.Size(75, 23);
            this.button_qd.TabIndex = 0;
            this.button_qd.Text = "确定";
            this.button_qd.UseVisualStyleBackColor = true;
            this.button_qd.Click += new System.EventHandler(this.button_qd_Click);
            // 
            // button_qx
            // 
            this.button_qx.Location = new System.Drawing.Point(130, 81);
            this.button_qx.Name = "button_qx";
            this.button_qx.Size = new System.Drawing.Size(75, 23);
            this.button_qx.TabIndex = 1;
            this.button_qx.Text = "取消";
            this.button_qx.UseVisualStyleBackColor = true;
            this.button_qx.Click += new System.EventHandler(this.button_qx_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入密码：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 37);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "*";
            // 
            // button_hide
            // 
            this.button_hide.BackColor = System.Drawing.Color.Transparent;
            this.button_hide.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_hide.FlatAppearance.BorderSize = 0;
            this.button_hide.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button_hide.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button_hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hide.Location = new System.Drawing.Point(0, 9);
            this.button_hide.Name = "button_hide";
            this.button_hide.Size = new System.Drawing.Size(10, 10);
            this.button_hide.TabIndex = 5;
            this.button_hide.UseVisualStyleBackColor = false;
            this.button_hide.Click += new System.EventHandler(this.button_hide_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 113);
            this.Controls.Add(this.button_hide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_qx);
            this.Controls.Add(this.button_qd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_qd;
        private System.Windows.Forms.Button button_qx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_hide;
    }
}