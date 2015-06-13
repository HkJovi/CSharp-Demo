namespace 屏幕截图工具
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.bt_catch = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.主菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.捕捉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_hide = new System.Windows.Forms.Button();
            this.timer_hide = new System.Windows.Forms.Timer(this.components);
            this.bt_CutImageTool = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label = new System.Windows.Forms.Label();
            this.切图工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_catch
            // 
            this.bt_catch.Location = new System.Drawing.Point(12, 23);
            this.bt_catch.Name = "bt_catch";
            this.bt_catch.Size = new System.Drawing.Size(51, 23);
            this.bt_catch.TabIndex = 0;
            this.bt_catch.Text = "捕捉";
            this.bt_catch.UseVisualStyleBackColor = true;
            this.bt_catch.Click += new System.EventHandler(this.bt_catch_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(75, 23);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(54, 23);
            this.bt_exit.TabIndex = 1;
            this.bt_exit.Text = "退出";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "屏幕截图工具";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主菜单ToolStripMenuItem,
            this.捕捉ToolStripMenuItem,
            this.切图工具ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // 主菜单ToolStripMenuItem
            // 
            this.主菜单ToolStripMenuItem.Name = "主菜单ToolStripMenuItem";
            this.主菜单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.主菜单ToolStripMenuItem.Text = "主菜单";
            this.主菜单ToolStripMenuItem.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // 捕捉ToolStripMenuItem
            // 
            this.捕捉ToolStripMenuItem.Name = "捕捉ToolStripMenuItem";
            this.捕捉ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.捕捉ToolStripMenuItem.Text = "捕捉";
            this.捕捉ToolStripMenuItem.Click += new System.EventHandler(this.bt_catch_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_hide
            // 
            this.bt_hide.Location = new System.Drawing.Point(110, 3);
            this.bt_hide.Name = "bt_hide";
            this.bt_hide.Size = new System.Drawing.Size(16, 14);
            this.bt_hide.TabIndex = 2;
            this.bt_hide.Text = "-";
            this.bt_hide.UseVisualStyleBackColor = true;
            this.bt_hide.Click += new System.EventHandler(this.bt_hide_Click);
            // 
            // timer_hide
            // 
            this.timer_hide.Interval = 1100;
            this.timer_hide.Tick += new System.EventHandler(this.bt_hide_Click);
            // 
            // bt_CutImageTool
            // 
            this.bt_CutImageTool.Location = new System.Drawing.Point(30, 54);
            this.bt_CutImageTool.Name = "bt_CutImageTool";
            this.bt_CutImageTool.Size = new System.Drawing.Size(75, 23);
            this.bt_CutImageTool.TabIndex = 4;
            this.bt_CutImageTool.Text = "图片剪切";
            this.bt_CutImageTool.UseVisualStyleBackColor = true;
            this.bt_CutImageTool.Click += new System.EventHandler(this.bt_CutImageTool_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 87);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(137, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(111, 17);
            this.Status.Text = "切图快捷键:Ctrl+W";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label.Location = new System.Drawing.Point(0, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 12);
            this.label.TabIndex = 6;
            this.label.Text = "截图快捷键:Ctrl+Q";
            // 
            // 切图工具ToolStripMenuItem
            // 
            this.切图工具ToolStripMenuItem.Name = "切图工具ToolStripMenuItem";
            this.切图工具ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.切图工具ToolStripMenuItem.Text = "切图工具";
            this.切图工具ToolStripMenuItem.Click += new System.EventHandler(this.bt_CutImageTool_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(137, 109);
            this.Controls.Add(this.label);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bt_CutImageTool);
            this.Controls.Add(this.bt_hide);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_catch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕截图工具";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_catch;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button bt_hide;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 捕捉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 主菜单ToolStripMenuItem;
        private System.Windows.Forms.Timer timer_hide;
        private System.Windows.Forms.Button bt_CutImageTool;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ToolStripMenuItem 切图工具ToolStripMenuItem;
    }
}

