namespace 屏幕截图工具
{
    partial class CutImageTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CutImageTool));
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_saveother = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_copychipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.UnitImagesBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveother_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Enlarge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NarrowBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.Set_Badge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_pen = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_point = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.DetermineBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_back = new System.Windows.Forms.Button();
            this.label_tip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnitImagesBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicBox
            // 
            this.PicBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicBox.ContextMenuStrip = this.contextMenuStrip1;
            this.PicBox.Enabled = false;
            this.PicBox.Location = new System.Drawing.Point(-5, 2);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(1037, 591);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBox.TabIndex = 5;
            this.PicBox.TabStop = false;
            this.PicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBox_Paint);
            this.PicBox.DoubleClick += new System.EventHandler(this.ToolStripMenuItem_copychipboard_Click);
            this.PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseDown);
            this.PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseMove);
            this.PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_saveother,
            this.ToolStripMenuItem_copychipboard});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ToolStripMenuItem_saveother
            // 
            this.ToolStripMenuItem_saveother.Name = "ToolStripMenuItem_saveother";
            this.ToolStripMenuItem_saveother.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_saveother.Text = "另存为";
            this.ToolStripMenuItem_saveother.Click += new System.EventHandler(this.ToolStripMenuItem_saveother_Click);
            // 
            // ToolStripMenuItem_copychipboard
            // 
            this.ToolStripMenuItem_copychipboard.Name = "ToolStripMenuItem_copychipboard";
            this.ToolStripMenuItem_copychipboard.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_copychipboard.Text = "复制到剪切板";
            this.ToolStripMenuItem_copychipboard.Click += new System.EventHandler(this.ToolStripMenuItem_copychipboard_Click);
            // 
            // UnitImagesBox
            // 
            this.UnitImagesBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.UnitImagesBox.Enabled = false;
            this.UnitImagesBox.Location = new System.Drawing.Point(3, 3);
            this.UnitImagesBox.Name = "UnitImagesBox";
            this.UnitImagesBox.Size = new System.Drawing.Size(161, 480);
            this.UnitImagesBox.TabIndex = 6;
            this.UnitImagesBox.TabStop = false;
            this.UnitImagesBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UnitImagesBox_Paint);
            this.UnitImagesBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UnitImagesBox_MouseClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.PicBox);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 598);
            this.panel1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.Enlarge,
            this.toolStripSeparator2,
            this.NarrowBtn,
            this.toolStripSeparator3,
            this.toolStripButton_clear,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.Set_Badge,
            this.toolStripSeparator4,
            this.toolStripButton_pen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_ToolStripMenuItem,
            this.save_ToolStripMenuItem,
            this.saveother_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // open_ToolStripMenuItem
            // 
            this.open_ToolStripMenuItem.Name = "open_ToolStripMenuItem";
            this.open_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.open_ToolStripMenuItem.Text = "打开    Ctrl+E";
            this.open_ToolStripMenuItem.Click += new System.EventHandler(this.OpenImageBtn_Click);
            // 
            // save_ToolStripMenuItem
            // 
            this.save_ToolStripMenuItem.Name = "save_ToolStripMenuItem";
            this.save_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.save_ToolStripMenuItem.Text = "保存";
            this.save_ToolStripMenuItem.Click += new System.EventHandler(this.save_ToolStripMenuItem_Click);
            // 
            // saveother_ToolStripMenuItem
            // 
            this.saveother_ToolStripMenuItem.Name = "saveother_ToolStripMenuItem";
            this.saveother_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveother_ToolStripMenuItem.Text = "另存为...";
            this.saveother_ToolStripMenuItem.Click += new System.EventHandler(this.saveother_ToolStripMenuItem_Click);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exit_ToolStripMenuItem.Text = "退出    Ctrl+R";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Enlarge
            // 
            this.Enlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Enlarge.Image = ((System.Drawing.Image)(resources.GetObject("Enlarge.Image")));
            this.Enlarge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Enlarge.Name = "Enlarge";
            this.Enlarge.Size = new System.Drawing.Size(23, 22);
            this.Enlarge.Text = "放大";
            this.Enlarge.Click += new System.EventHandler(this.Enlarge_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NarrowBtn
            // 
            this.NarrowBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NarrowBtn.Image = ((System.Drawing.Image)(resources.GetObject("NarrowBtn.Image")));
            this.NarrowBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NarrowBtn.Name = "NarrowBtn";
            this.NarrowBtn.Size = new System.Drawing.Size(23, 22);
            this.NarrowBtn.Text = "缩小";
            this.NarrowBtn.Click += new System.EventHandler(this.NarrowBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_clear
            // 
            this.toolStripButton_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_clear.Name = "toolStripButton_clear";
            this.toolStripButton_clear.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton_clear.Text = "清空";
            this.toolStripButton_clear.Click += new System.EventHandler(this.toolStripButton_clear_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel1.Text = "输入水印文字：";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "右下角",
            "右上角",
            "左下角",
            "左上角",
            "顶局中",
            "底局中"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "右下角";
            // 
            // Set_Badge
            // 
            this.Set_Badge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Set_Badge.Image = ((System.Drawing.Image)(resources.GetObject("Set_Badge.Image")));
            this.Set_Badge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Set_Badge.Name = "Set_Badge";
            this.Set_Badge.Size = new System.Drawing.Size(35, 22);
            this.Set_Badge.Text = "水印";
            this.Set_Badge.Click += new System.EventHandler(this.Set_Badge_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_pen
            // 
            this.toolStripButton_pen.CheckOnClick = true;
            this.toolStripButton_pen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pen.Enabled = false;
            this.toolStripButton_pen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_pen.Image")));
            this.toolStripButton_pen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pen.Name = "toolStripButton_pen";
            this.toolStripButton_pen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_pen.Text = "Pen";
            this.toolStripButton_pen.Click += new System.EventHandler(this.toolStripButton_pen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_point});
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 17);
            this.toolStripStatusLabel1.Text = "Version 1.0.0.0 _ 2013.11.18";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel_point
            // 
            this.toolStripStatusLabel_point.Name = "toolStripStatusLabel_point";
            this.toolStripStatusLabel_point.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel_point.Text = "坐标";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1044, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "缩略图：";
            // 
            // DetermineBtn
            // 
            this.DetermineBtn.BackColor = System.Drawing.Color.Transparent;
            this.DetermineBtn.ForeColor = System.Drawing.Color.Red;
            this.DetermineBtn.Image = ((System.Drawing.Image)(resources.GetObject("DetermineBtn.Image")));
            this.DetermineBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetermineBtn.Location = new System.Drawing.Point(1040, 250);
            this.DetermineBtn.Name = "DetermineBtn";
            this.DetermineBtn.Size = new System.Drawing.Size(23, 23);
            this.DetermineBtn.TabIndex = 11;
            this.DetermineBtn.UseVisualStyleBackColor = false;
            this.DetermineBtn.Click += new System.EventHandler(this.DetermineBtn_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.UnitImagesBox);
            this.panel2.Location = new System.Drawing.Point(1069, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 488);
            this.panel2.TabIndex = 12;
            // 
            // bt_back
            // 
            this.bt_back.BackColor = System.Drawing.Color.Transparent;
            this.bt_back.FlatAppearance.BorderSize = 0;
            this.bt_back.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.bt_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_back.Image = ((System.Drawing.Image)(resources.GetObject("bt_back.Image")));
            this.bt_back.Location = new System.Drawing.Point(1074, 568);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(52, 54);
            this.bt_back.TabIndex = 13;
            this.bt_back.UseVisualStyleBackColor = false;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.ForeColor = System.Drawing.Color.Red;
            this.label_tip.Location = new System.Drawing.Point(1067, 541);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(173, 24);
            this.label_tip.TabIndex = 14;
            this.label_tip.Text = "Tips:\r\n      双击图片可复制到剪切板";
            // 
            // CutImageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 650);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.bt_back);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DetermineBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CutImageTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "切图工具";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CutImageTool_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UnitImagesBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.PictureBox UnitImagesBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveother_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Enlarge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton NarrowBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton Set_Badge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DetermineBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_saveother;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_copychipboard;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_point;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_pen;
        private System.Windows.Forms.Label label_tip;
    }
}