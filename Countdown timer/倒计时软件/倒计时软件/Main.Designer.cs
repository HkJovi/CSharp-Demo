namespace 倒计时软件
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_top = new System.Windows.Forms.Button();
            this.lab_Time = new System.Windows.Forms.Label();
            this.timer_nowtime = new System.Windows.Forms.Timer(this.components);
            this.btn_transparent = new System.Windows.Forms.Button();
            this.traB_transparent = new System.Windows.Forms.TrackBar();
            this.Pic_Day1 = new System.Windows.Forms.PictureBox();
            this.Pic_Day2 = new System.Windows.Forms.PictureBox();
            this.Pic_Day3 = new System.Windows.Forms.PictureBox();
            this.lab_day = new System.Windows.Forms.Label();
            this.btn_setday = new System.Windows.Forms.Button();
            this.TimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.timer_days = new System.Windows.Forms.Timer(this.components);
            this.pic_sunshine = new System.Windows.Forms.PictureBox();
            this.lab_endtime = new System.Windows.Forms.Label();
            this.lab_TO = new System.Windows.Forms.Label();
            this.lab_message = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开主程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.traB_transparent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sunshine)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::倒计时软件.Properties.Resources.Close;
            this.btn_close.Location = new System.Drawing.Point(47, 55);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(18, 25);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_close_MouseEnter);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_close_MouseLeave);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.White;
            this.btn_minimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Image = global::倒计时软件.Properties.Resources.minimize;
            this.btn_minimize.Location = new System.Drawing.Point(71, 55);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(18, 25);
            this.btn_minimize.TabIndex = 1;
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            this.btn_minimize.MouseEnter += new System.EventHandler(this.btn_minimize_MouseEnter);
            this.btn_minimize.MouseLeave += new System.EventHandler(this.btn_minimize_MouseLeave);
            // 
            // btn_about
            // 
            this.btn_about.BackColor = System.Drawing.Color.White;
            this.btn_about.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_about.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_about.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_about.Image = global::倒计时软件.Properties.Resources.About;
            this.btn_about.Location = new System.Drawing.Point(95, 55);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(20, 25);
            this.btn_about.TabIndex = 2;
            this.btn_about.UseVisualStyleBackColor = false;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            this.btn_about.MouseEnter += new System.EventHandler(this.btn_about_MouseEnter);
            this.btn_about.MouseLeave += new System.EventHandler(this.btn_about_MouseLeave);
            // 
            // btn_top
            // 
            this.btn_top.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_top.BackColor = System.Drawing.Color.White;
            this.btn_top.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_top.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_top.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_top.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_top.Image = global::倒计时软件.Properties.Resources.unTOP;
            this.btn_top.Location = new System.Drawing.Point(341, 51);
            this.btn_top.Name = "btn_top";
            this.btn_top.Size = new System.Drawing.Size(16, 12);
            this.btn_top.TabIndex = 3;
            this.btn_top.UseVisualStyleBackColor = false;
            this.btn_top.Click += new System.EventHandler(this.btn_top_Click);
            this.btn_top.MouseEnter += new System.EventHandler(this.btn_top_MouseEnter);
            this.btn_top.MouseLeave += new System.EventHandler(this.btn_top_MouseLeave);
            // 
            // lab_Time
            // 
            this.lab_Time.AutoSize = true;
            this.lab_Time.BackColor = System.Drawing.Color.Transparent;
            this.lab_Time.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Time.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lab_Time.Location = new System.Drawing.Point(232, 208);
            this.lab_Time.Name = "lab_Time";
            this.lab_Time.Size = new System.Drawing.Size(67, 17);
            this.lab_Time.TabIndex = 4;
            this.lab_Time.Text = "ShowTime";
            // 
            // timer_nowtime
            // 
            this.timer_nowtime.Enabled = true;
            this.timer_nowtime.Tick += new System.EventHandler(this.timer_nowtime_Tick);
            // 
            // btn_transparent
            // 
            this.btn_transparent.BackColor = System.Drawing.Color.Transparent;
            this.btn_transparent.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_transparent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_transparent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_transparent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_transparent.Image = global::倒计时软件.Properties.Resources.transparent;
            this.btn_transparent.Location = new System.Drawing.Point(338, 178);
            this.btn_transparent.Name = "btn_transparent";
            this.btn_transparent.Size = new System.Drawing.Size(19, 19);
            this.btn_transparent.TabIndex = 5;
            this.btn_transparent.UseVisualStyleBackColor = false;
            this.btn_transparent.Click += new System.EventHandler(this.btn_transparent_Click);
            this.btn_transparent.MouseEnter += new System.EventHandler(this.btn_transparent_MouseEnter);
            this.btn_transparent.MouseLeave += new System.EventHandler(this.btn_transparent_MouseLeave);
            // 
            // traB_transparent
            // 
            this.traB_transparent.BackColor = System.Drawing.Color.White;
            this.traB_transparent.LargeChange = 1;
            this.traB_transparent.Location = new System.Drawing.Point(335, 99);
            this.traB_transparent.Name = "traB_transparent";
            this.traB_transparent.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.traB_transparent.Size = new System.Drawing.Size(45, 79);
            this.traB_transparent.TabIndex = 6;
            this.traB_transparent.Visible = false;
            this.traB_transparent.Scroll += new System.EventHandler(this.traB_transparent_Scroll);
            this.traB_transparent.MouseEnter += new System.EventHandler(this.traB_transparent_MouseEnter);
            // 
            // Pic_Day1
            // 
            this.Pic_Day1.BackColor = System.Drawing.Color.White;
            this.Pic_Day1.Image = ((System.Drawing.Image)(resources.GetObject("Pic_Day1.Image")));
            this.Pic_Day1.Location = new System.Drawing.Point(116, 99);
            this.Pic_Day1.Name = "Pic_Day1";
            this.Pic_Day1.Size = new System.Drawing.Size(61, 88);
            this.Pic_Day1.TabIndex = 7;
            this.Pic_Day1.TabStop = false;
            // 
            // Pic_Day2
            // 
            this.Pic_Day2.BackColor = System.Drawing.Color.White;
            this.Pic_Day2.Image = global::倒计时软件.Properties.Resources._0;
            this.Pic_Day2.Location = new System.Drawing.Point(173, 99);
            this.Pic_Day2.Name = "Pic_Day2";
            this.Pic_Day2.Size = new System.Drawing.Size(59, 88);
            this.Pic_Day2.TabIndex = 8;
            this.Pic_Day2.TabStop = false;
            // 
            // Pic_Day3
            // 
            this.Pic_Day3.BackColor = System.Drawing.Color.White;
            this.Pic_Day3.Image = global::倒计时软件.Properties.Resources._0;
            this.Pic_Day3.Location = new System.Drawing.Point(230, 99);
            this.Pic_Day3.Name = "Pic_Day3";
            this.Pic_Day3.Size = new System.Drawing.Size(61, 88);
            this.Pic_Day3.TabIndex = 9;
            this.Pic_Day3.TabStop = false;
            // 
            // lab_day
            // 
            this.lab_day.AutoSize = true;
            this.lab_day.BackColor = System.Drawing.Color.White;
            this.lab_day.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_day.Location = new System.Drawing.Point(294, 147);
            this.lab_day.Name = "lab_day";
            this.lab_day.Size = new System.Drawing.Size(38, 31);
            this.lab_day.TabIndex = 10;
            this.lab_day.Text = "天";
            // 
            // btn_setday
            // 
            this.btn_setday.BackColor = System.Drawing.Color.Transparent;
            this.btn_setday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_setday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_setday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_setday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setday.Image = global::倒计时软件.Properties.Resources.day;
            this.btn_setday.Location = new System.Drawing.Point(213, 51);
            this.btn_setday.Name = "btn_setday";
            this.btn_setday.Size = new System.Drawing.Size(28, 32);
            this.btn_setday.TabIndex = 11;
            this.btn_setday.UseVisualStyleBackColor = false;
            this.btn_setday.Click += new System.EventHandler(this.btn_setday_Click);
            this.btn_setday.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_setday_MouseDown);
            this.btn_setday.MouseEnter += new System.EventHandler(this.btn_setday_MouseEnter);
            this.btn_setday.MouseLeave += new System.EventHandler(this.btn_setday_MouseLeave);
            this.btn_setday.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_setday_MouseUp);
            // 
            // TimePicker1
            // 
            this.TimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.TimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker1.Location = new System.Drawing.Point(99, 25);
            this.TimePicker1.Name = "TimePicker1";
            this.TimePicker1.Size = new System.Drawing.Size(200, 21);
            this.TimePicker1.TabIndex = 12;
            this.TimePicker1.Visible = false;
            this.TimePicker1.ValueChanged += new System.EventHandler(this.TimePicker1_ValueChanged);
            // 
            // timer_days
            // 
            this.timer_days.Interval = 1000;
            this.timer_days.Tick += new System.EventHandler(this.timer_days_Tick);
            // 
            // pic_sunshine
            // 
            this.pic_sunshine.BackColor = System.Drawing.Color.Transparent;
            this.pic_sunshine.Image = global::倒计时软件.Properties.Resources.sunshine;
            this.pic_sunshine.Location = new System.Drawing.Point(297, 84);
            this.pic_sunshine.Name = "pic_sunshine";
            this.pic_sunshine.Size = new System.Drawing.Size(45, 45);
            this.pic_sunshine.TabIndex = 13;
            this.pic_sunshine.TabStop = false;
            // 
            // lab_endtime
            // 
            this.lab_endtime.AutoSize = true;
            this.lab_endtime.BackColor = System.Drawing.Color.Transparent;
            this.lab_endtime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_endtime.Location = new System.Drawing.Point(45, 139);
            this.lab_endtime.Name = "lab_endtime";
            this.lab_endtime.Size = new System.Drawing.Size(47, 12);
            this.lab_endtime.TabIndex = 14;
            this.lab_endtime.Text = "Endtime";
            // 
            // lab_TO
            // 
            this.lab_TO.AutoSize = true;
            this.lab_TO.BackColor = System.Drawing.Color.Transparent;
            this.lab_TO.Font = new System.Drawing.Font("Buxton Sketch", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TO.Location = new System.Drawing.Point(30, 80);
            this.lab_TO.Name = "lab_TO";
            this.lab_TO.Size = new System.Drawing.Size(76, 59);
            this.lab_TO.TabIndex = 15;
            this.lab_TO.Text = "TO";
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.BackColor = System.Drawing.Color.Transparent;
            this.lab_message.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_message.Location = new System.Drawing.Point(57, 158);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(49, 20);
            this.lab_message.TabIndex = 16;
            this.lab_message.Text = "还有";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "时间计算器";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "时间计算器";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开主程序ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(111, 70);
            // 
            // 打开主程序ToolStripMenuItem
            // 
            this.打开主程序ToolStripMenuItem.Name = "打开主程序ToolStripMenuItem";
            this.打开主程序ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.打开主程序ToolStripMenuItem.Text = "主程序";
            this.打开主程序ToolStripMenuItem.Click += new System.EventHandler(this.打开主程序ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(363, 244);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.lab_TO);
            this.Controls.Add(this.lab_endtime);
            this.Controls.Add(this.pic_sunshine);
            this.Controls.Add(this.TimePicker1);
            this.Controls.Add(this.btn_setday);
            this.Controls.Add(this.lab_day);
            this.Controls.Add(this.Pic_Day3);
            this.Controls.Add(this.Pic_Day2);
            this.Controls.Add(this.Pic_Day1);
            this.Controls.Add(this.traB_transparent);
            this.Controls.Add(this.btn_transparent);
            this.Controls.Add(this.lab_Time);
            this.Controls.Add(this.btn_top);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_minimize);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TransparencyKey = System.Drawing.SystemColors.InactiveCaption;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Main_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.traB_transparent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Day3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sunshine)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        string st_endtime;
        private uint Remainder;
        private uint Dayss;
        private uint Hours;
        //private uint minute;
        //private uint sencond;

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_top;
        private System.Windows.Forms.Label lab_Time;
        private System.Windows.Forms.Timer timer_nowtime;
        private System.Windows.Forms.Button btn_transparent;
        private System.Windows.Forms.TrackBar traB_transparent;
        private System.Windows.Forms.PictureBox Pic_Day1;
        private System.Windows.Forms.PictureBox Pic_Day2;
        private System.Windows.Forms.PictureBox Pic_Day3;
        private System.Windows.Forms.Label lab_day;
        private System.Windows.Forms.Button btn_setday;
        private System.Windows.Forms.DateTimePicker TimePicker1;
        private System.Windows.Forms.Timer timer_days;
        private System.Windows.Forms.PictureBox pic_sunshine;
        private System.Windows.Forms.Label lab_endtime;
        private System.Windows.Forms.Label lab_TO;
        private System.Windows.Forms.Label lab_message;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打开主程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

