namespace clock1
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_showTime = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_close = new System.Windows.Forms.Button();
            this.dtp_input_time = new System.Windows.Forms.DateTimePicker();
            this.lbl_systemtime = new System.Windows.Forms.Label();
            this.lbl_show_endtime = new System.Windows.Forms.Label();
            this.btn_setyy = new System.Windows.Forms.Button();
            this.ttx_set_message = new System.Windows.Forms.TextBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.lbl_settime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "暂无";
            this.notifyIcon1.BalloonTipTitle = "闹钟程序";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "闹钟程序";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 260);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_showTime);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "时间";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_showTime
            // 
            this.lbl_showTime.AutoSize = true;
            this.lbl_showTime.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_showTime.Location = new System.Drawing.Point(6, 81);
            this.lbl_showTime.Name = "lbl_showTime";
            this.lbl_showTime.Size = new System.Drawing.Size(177, 40);
            this.lbl_showTime.TabIndex = 0;
            this.lbl_showTime.Text = "闹钟程序";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_close);
            this.tabPage2.Controls.Add(this.dtp_input_time);
            this.tabPage2.Controls.Add(this.lbl_systemtime);
            this.tabPage2.Controls.Add(this.lbl_show_endtime);
            this.tabPage2.Controls.Add(this.btn_setyy);
            this.tabPage2.Controls.Add(this.ttx_set_message);
            this.tabPage2.Controls.Add(this.lbl_message);
            this.tabPage2.Controls.Add(this.lbl_settime);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置闹钟";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_close.Location = new System.Drawing.Point(260, 186);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 21;
            this.btn_close.Text = "隐藏窗口";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dtp_input_time
            // 
            this.dtp_input_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_input_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_input_time.Location = new System.Drawing.Point(123, 24);
            this.dtp_input_time.Name = "dtp_input_time";
            this.dtp_input_time.Size = new System.Drawing.Size(139, 21);
            this.dtp_input_time.TabIndex = 20;
            // 
            // lbl_systemtime
            // 
            this.lbl_systemtime.AutoSize = true;
            this.lbl_systemtime.Location = new System.Drawing.Point(6, 60);
            this.lbl_systemtime.Name = "lbl_systemtime";
            this.lbl_systemtime.Size = new System.Drawing.Size(65, 12);
            this.lbl_systemtime.TabIndex = 19;
            this.lbl_systemtime.Text = "系统时间：";
            this.lbl_systemtime.Visible = false;
            // 
            // lbl_show_endtime
            // 
            this.lbl_show_endtime.AutoSize = true;
            this.lbl_show_endtime.Location = new System.Drawing.Point(6, 137);
            this.lbl_show_endtime.Name = "lbl_show_endtime";
            this.lbl_show_endtime.Size = new System.Drawing.Size(53, 12);
            this.lbl_show_endtime.TabIndex = 18;
            this.lbl_show_endtime.Text = "剩余时间";
            this.lbl_show_endtime.Visible = false;
            // 
            // btn_setyy
            // 
            this.btn_setyy.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_setyy.Location = new System.Drawing.Point(80, 186);
            this.btn_setyy.Name = "btn_setyy";
            this.btn_setyy.Size = new System.Drawing.Size(75, 23);
            this.btn_setyy.TabIndex = 15;
            this.btn_setyy.Text = "开始倒计时";
            this.btn_setyy.UseVisualStyleBackColor = true;
            this.btn_setyy.Click += new System.EventHandler(this.btn_setyy_Click);
            // 
            // ttx_set_message
            // 
            this.ttx_set_message.Location = new System.Drawing.Point(123, 89);
            this.ttx_set_message.Name = "ttx_set_message";
            this.ttx_set_message.Size = new System.Drawing.Size(226, 21);
            this.ttx_set_message.TabIndex = 13;
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(16, 92);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(89, 12);
            this.lbl_message.TabIndex = 12;
            this.lbl_message.Text = "设置提示文字：";
            // 
            // lbl_settime
            // 
            this.lbl_settime.AutoSize = true;
            this.lbl_settime.Location = new System.Drawing.Point(40, 28);
            this.lbl_settime.Name = "lbl_settime";
            this.lbl_settime.Size = new System.Drawing.Size(65, 12);
            this.lbl_settime.TabIndex = 11;
            this.lbl_settime.Text = "设置时间：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 270);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "倒计时";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        string st_endtime;
        string tm_set;
        private uint Remainder;
        private uint Dayss;
        private uint Hours;
        private uint minute;
        private uint sencond;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_setyy;
        private System.Windows.Forms.TextBox ttx_set_message;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Label lbl_settime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_showTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbl_show_endtime;
        private System.Windows.Forms.Label lbl_systemtime;
        private System.Windows.Forms.DateTimePicker dtp_input_time;
        private System.Windows.Forms.Button btn_close;
    }
}