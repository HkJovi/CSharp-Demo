namespace 屏幕截图工具
{
    partial class StarForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarForm));
            this.Counter = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.label_tip = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Counter
            // 
            this.Counter.Interval = 400;
            this.Counter.Tick += new System.EventHandler(this.Counter_Tick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Location = new System.Drawing.Point(157, 213);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(89, 12);
            this.label.TabIndex = 0;
            this.label.Text = "正在注册快捷键";
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.BackColor = System.Drawing.Color.Transparent;
            this.label_tip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_tip.Location = new System.Drawing.Point(0, 261);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(246, 34);
            this.label_tip.TabIndex = 1;
            this.label_tip.Text = "Tips:\r\n      截图快捷键:Ctrl+Q  切图快捷键:Ctrl+W";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_info.Location = new System.Drawing.Point(279, 261);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(117, 34);
            this.label_info.TabIndex = 2;
            this.label_info.Text = "                By Jovi\r\nCopyright ©  2013";
            // 
            // StarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::屏幕截图工具.Properties.Resources.UI_1;
            this.ClientSize = new System.Drawing.Size(397, 294);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Counter;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.Label label_info;
    }
}