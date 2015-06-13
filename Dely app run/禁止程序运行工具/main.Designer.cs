namespace 禁止程序运行工具
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.btn_choosefile = new System.Windows.Forms.Button();
            this.TB_FilePosation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AddApp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_FileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cut_one = new System.Windows.Forms.Button();
            this.btn_cut_all = new System.Windows.Forms.Button();
            this.btn_add_all = new System.Windows.Forms.Button();
            this.btn_add_one = new System.Windows.Forms.Button();
            this.listBox_choosedapp = new System.Windows.Forms.ListBox();
            this.listBox_app = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton_tool = new System.Windows.Forms.ToolStripDropDownButton();
            this.定时关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_choosefile
            // 
            this.btn_choosefile.Location = new System.Drawing.Point(283, 33);
            this.btn_choosefile.Name = "btn_choosefile";
            this.btn_choosefile.Size = new System.Drawing.Size(75, 23);
            this.btn_choosefile.TabIndex = 0;
            this.btn_choosefile.Text = "选择文件";
            this.btn_choosefile.UseVisualStyleBackColor = true;
            this.btn_choosefile.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // TB_FilePosation
            // 
            this.TB_FilePosation.Location = new System.Drawing.Point(95, 20);
            this.TB_FilePosation.Name = "TB_FilePosation";
            this.TB_FilePosation.Size = new System.Drawing.Size(174, 21);
            this.TB_FilePosation.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddApp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_FileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_FilePosation);
            this.groupBox1.Controls.Add(this.btn_choosefile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加";
            // 
            // btn_AddApp
            // 
            this.btn_AddApp.Location = new System.Drawing.Point(113, 77);
            this.btn_AddApp.Name = "btn_AddApp";
            this.btn_AddApp.Size = new System.Drawing.Size(103, 23);
            this.btn_AddApp.TabIndex = 5;
            this.btn_AddApp.Text = "添加";
            this.btn_AddApp.UseVisualStyleBackColor = true;
            this.btn_AddApp.Click += new System.EventHandler(this.btn_AddApp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "可执行文件名称（*.exe)";
            // 
            // TB_FileName
            // 
            this.TB_FileName.Location = new System.Drawing.Point(169, 47);
            this.TB_FileName.Name = "TB_FileName";
            this.TB_FileName.Size = new System.Drawing.Size(100, 21);
            this.TB_FileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "程序地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_cut_one);
            this.groupBox2.Controls.Add(this.btn_cut_all);
            this.groupBox2.Controls.Add(this.btn_add_all);
            this.groupBox2.Controls.Add(this.btn_add_one);
            this.groupBox2.Controls.Add(this.listBox_choosedapp);
            this.groupBox2.Controls.Add(this.listBox_app);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 264);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管理";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "已禁止程序：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "可禁止程序：";
            // 
            // btn_cut_one
            // 
            this.btn_cut_one.Location = new System.Drawing.Point(141, 192);
            this.btn_cut_one.Name = "btn_cut_one";
            this.btn_cut_one.Size = new System.Drawing.Size(75, 23);
            this.btn_cut_one.TabIndex = 5;
            this.btn_cut_one.Text = "<";
            this.btn_cut_one.UseVisualStyleBackColor = true;
            this.btn_cut_one.Click += new System.EventHandler(this.btn_cut_one_Click);
            // 
            // btn_cut_all
            // 
            this.btn_cut_all.Location = new System.Drawing.Point(141, 144);
            this.btn_cut_all.Name = "btn_cut_all";
            this.btn_cut_all.Size = new System.Drawing.Size(75, 23);
            this.btn_cut_all.TabIndex = 4;
            this.btn_cut_all.Text = "<<";
            this.btn_cut_all.UseVisualStyleBackColor = true;
            this.btn_cut_all.Click += new System.EventHandler(this.btn_cut_all_Click);
            // 
            // btn_add_all
            // 
            this.btn_add_all.Location = new System.Drawing.Point(141, 99);
            this.btn_add_all.Name = "btn_add_all";
            this.btn_add_all.Size = new System.Drawing.Size(75, 23);
            this.btn_add_all.TabIndex = 3;
            this.btn_add_all.Text = ">>";
            this.btn_add_all.UseVisualStyleBackColor = true;
            this.btn_add_all.Click += new System.EventHandler(this.btn_add_all_Click);
            // 
            // btn_add_one
            // 
            this.btn_add_one.Location = new System.Drawing.Point(141, 56);
            this.btn_add_one.Name = "btn_add_one";
            this.btn_add_one.Size = new System.Drawing.Size(75, 23);
            this.btn_add_one.TabIndex = 2;
            this.btn_add_one.Text = ">";
            this.btn_add_one.UseVisualStyleBackColor = true;
            this.btn_add_one.Click += new System.EventHandler(this.btn_add_one_Click);
            // 
            // listBox_choosedapp
            // 
            this.listBox_choosedapp.FormattingEnabled = true;
            this.listBox_choosedapp.ItemHeight = 12;
            this.listBox_choosedapp.Location = new System.Drawing.Point(238, 41);
            this.listBox_choosedapp.Name = "listBox_choosedapp";
            this.listBox_choosedapp.Size = new System.Drawing.Size(120, 208);
            this.listBox_choosedapp.TabIndex = 1;
            // 
            // listBox_app
            // 
            this.listBox_app.FormattingEnabled = true;
            this.listBox_app.ItemHeight = 12;
            this.listBox_app.Items.AddRange(new object[] {
            "QQProtect.exe",
            "QQ.exe",
            "cmd.exe",
            "regedit.exe",
            "Client.exe",
            "LOLBox.exe",
            "QQgame.exe"});
            this.listBox_app.Location = new System.Drawing.Point(6, 41);
            this.listBox_app.Name = "listBox_app";
            this.listBox_app.Size = new System.Drawing.Size(120, 208);
            this.listBox_app.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripDropDownButton_tool,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(388, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel1.Text = "系统已经开机时间：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel2.Text = "time";
            // 
            // toolStripDropDownButton_tool
            // 
            this.toolStripDropDownButton_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.定时关机ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.toolStripDropDownButton_tool.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_tool.Image")));
            this.toolStripDropDownButton_tool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_tool.Name = "toolStripDropDownButton_tool";
            this.toolStripDropDownButton_tool.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton_tool.Text = "toolStripDropDownButton1";
            // 
            // 定时关机ToolStripMenuItem
            // 
            this.定时关机ToolStripMenuItem.Name = "定时关机ToolStripMenuItem";
            this.定时关机ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.定时关机ToolStripMenuItem.Text = "定时关机";
            this.定时关机ToolStripMenuItem.Click += new System.EventHandler(this.定时关机ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel3.Text = "定时关机未启用！";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 428);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序锁";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_choosefile;
        private System.Windows.Forms.TextBox TB_FilePosation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_FileName;
        private System.Windows.Forms.Button btn_AddApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_cut_one;
        private System.Windows.Forms.Button btn_cut_all;
        private System.Windows.Forms.Button btn_add_all;
        private System.Windows.Forms.Button btn_add_one;
        private System.Windows.Forms.ListBox listBox_choosedapp;
        private System.Windows.Forms.ListBox listBox_app;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_tool;
        private System.Windows.Forms.ToolStripMenuItem 定时关机ToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

