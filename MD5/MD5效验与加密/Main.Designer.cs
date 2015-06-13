namespace MD5效验与加密
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btn_change = new System.Windows.Forms.Button();
			this.lab_tip = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btn_Copy = new System.Windows.Forms.Button();
			this.btn_Check = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.La_MD5msg2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.La_MD5msg1 = new System.Windows.Forms.Label();
			this.btn_OpenFile = new System.Windows.Forms.Button();
			this.TB_FilePath = new System.Windows.Forms.TextBox();
			this.La_File = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btn_change2 = new System.Windows.Forms.Button();
			this.bt_strcopy = new System.Windows.Forms.Button();
			this.bt_coring = new System.Windows.Forms.Button();
			this.tb_strMD5 = new System.Windows.Forms.TextBox();
			this.la_str = new System.Windows.Forms.Label();
			this.Rtb_str = new System.Windows.Forms.RichTextBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(13, 13);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(353, 202);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btn_change);
			this.tabPage1.Controls.Add(this.lab_tip);
			this.tabPage1.Controls.Add(this.pictureBox);
			this.tabPage1.Controls.Add(this.btn_Copy);
			this.tabPage1.Controls.Add(this.btn_Check);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.La_MD5msg2);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.La_MD5msg1);
			this.tabPage1.Controls.Add(this.btn_OpenFile);
			this.tabPage1.Controls.Add(this.TB_FilePath);
			this.tabPage1.Controls.Add(this.La_File);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(345, 176);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "MD5效验工具";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btn_change
			// 
			this.btn_change.Location = new System.Drawing.Point(321, 56);
			this.btn_change.Name = "btn_change";
			this.btn_change.Size = new System.Drawing.Size(21, 28);
			this.btn_change.TabIndex = 11;
			this.btn_change.Text = "大";
			this.btn_change.UseVisualStyleBackColor = true;
			this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
			// 
			// lab_tip
			// 
			this.lab_tip.AutoSize = true;
			this.lab_tip.Location = new System.Drawing.Point(10, 132);
			this.lab_tip.Name = "lab_tip";
			this.lab_tip.Size = new System.Drawing.Size(0, 12);
			this.lab_tip.TabIndex = 10;
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(22, 99);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(29, 26);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// btn_Copy
			// 
			this.btn_Copy.Location = new System.Drawing.Point(86, 109);
			this.btn_Copy.Name = "btn_Copy";
			this.btn_Copy.Size = new System.Drawing.Size(112, 40);
			this.btn_Copy.TabIndex = 8;
			this.btn_Copy.Text = "复制文件MD5";
			this.btn_Copy.UseVisualStyleBackColor = true;
			this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
			// 
			// btn_Check
			// 
			this.btn_Check.Location = new System.Drawing.Point(222, 109);
			this.btn_Check.Name = "btn_Check";
			this.btn_Check.Size = new System.Drawing.Size(114, 41);
			this.btn_Check.TabIndex = 7;
			this.btn_Check.Text = "效验";
			this.btn_Check.UseVisualStyleBackColor = true;
			this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(85, 69);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(233, 21);
			this.textBox2.TabIndex = 6;
			// 
			// La_MD5msg2
			// 
			this.La_MD5msg2.AutoSize = true;
			this.La_MD5msg2.Location = new System.Drawing.Point(8, 72);
			this.La_MD5msg2.Name = "La_MD5msg2";
			this.La_MD5msg2.Size = new System.Drawing.Size(83, 12);
			this.La_MD5msg2.TabIndex = 5;
			this.La_MD5msg2.Text = "效验的MD5值：";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(85, 41);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(233, 21);
			this.textBox1.TabIndex = 4;
			// 
			// La_MD5msg1
			// 
			this.La_MD5msg1.AutoSize = true;
			this.La_MD5msg1.Location = new System.Drawing.Point(8, 44);
			this.La_MD5msg1.Name = "La_MD5msg1";
			this.La_MD5msg1.Size = new System.Drawing.Size(71, 12);
			this.La_MD5msg1.TabIndex = 3;
			this.La_MD5msg1.Text = "文件MD5值：";
			// 
			// btn_OpenFile
			// 
			this.btn_OpenFile.Location = new System.Drawing.Point(289, 7);
			this.btn_OpenFile.Name = "btn_OpenFile";
			this.btn_OpenFile.Size = new System.Drawing.Size(29, 23);
			this.btn_OpenFile.TabIndex = 2;
			this.btn_OpenFile.Text = ".....";
			this.btn_OpenFile.UseVisualStyleBackColor = true;
			this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
			// 
			// TB_FilePath
			// 
			this.TB_FilePath.Location = new System.Drawing.Point(86, 9);
			this.TB_FilePath.Name = "TB_FilePath";
			this.TB_FilePath.Size = new System.Drawing.Size(197, 21);
			this.TB_FilePath.TabIndex = 1;
			// 
			// La_File
			// 
			this.La_File.AutoSize = true;
			this.La_File.Location = new System.Drawing.Point(6, 12);
			this.La_File.Name = "La_File";
			this.La_File.Size = new System.Drawing.Size(65, 12);
			this.La_File.TabIndex = 0;
			this.La_File.Text = "选择文件：";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btn_change2);
			this.tabPage2.Controls.Add(this.bt_strcopy);
			this.tabPage2.Controls.Add(this.bt_coring);
			this.tabPage2.Controls.Add(this.tb_strMD5);
			this.tabPage2.Controls.Add(this.la_str);
			this.tabPage2.Controls.Add(this.Rtb_str);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(345, 176);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "MD5加密工具";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btn_change2
			// 
			this.btn_change2.Location = new System.Drawing.Point(321, 111);
			this.btn_change2.Name = "btn_change2";
			this.btn_change2.Size = new System.Drawing.Size(18, 23);
			this.btn_change2.TabIndex = 5;
			this.btn_change2.Text = "大";
			this.btn_change2.UseVisualStyleBackColor = true;
			this.btn_change2.Click += new System.EventHandler(this.btn_change2_Click);
			// 
			// bt_strcopy
			// 
			this.bt_strcopy.Location = new System.Drawing.Point(201, 141);
			this.bt_strcopy.Name = "bt_strcopy";
			this.bt_strcopy.Size = new System.Drawing.Size(89, 26);
			this.bt_strcopy.TabIndex = 4;
			this.bt_strcopy.Text = "复制MD5";
			this.bt_strcopy.UseVisualStyleBackColor = true;
			this.bt_strcopy.Click += new System.EventHandler(this.bt_strcopy_Click);
			// 
			// bt_coring
			// 
			this.bt_coring.Location = new System.Drawing.Point(57, 141);
			this.bt_coring.Name = "bt_coring";
			this.bt_coring.Size = new System.Drawing.Size(82, 27);
			this.bt_coring.TabIndex = 3;
			this.bt_coring.Text = "加密";
			this.bt_coring.UseVisualStyleBackColor = true;
			this.bt_coring.Click += new System.EventHandler(this.bt_coring_Click);
			// 
			// tb_strMD5
			// 
			this.tb_strMD5.Enabled = false;
			this.tb_strMD5.Location = new System.Drawing.Point(85, 114);
			this.tb_strMD5.Name = "tb_strMD5";
			this.tb_strMD5.Size = new System.Drawing.Size(229, 21);
			this.tb_strMD5.TabIndex = 2;
			// 
			// la_str
			// 
			this.la_str.AutoSize = true;
			this.la_str.Location = new System.Drawing.Point(6, 117);
			this.la_str.Name = "la_str";
			this.la_str.Size = new System.Drawing.Size(83, 12);
			this.la_str.TabIndex = 1;
			this.la_str.Text = "字符串的MD5：";
			// 
			// Rtb_str
			// 
			this.Rtb_str.Location = new System.Drawing.Point(3, 3);
			this.Rtb_str.Name = "Rtb_str";
			this.Rtb_str.Size = new System.Drawing.Size(336, 101);
			this.Rtb_str.TabIndex = 0;
			this.Rtb_str.Text = "";
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
			this.statusStrip.Location = new System.Drawing.Point(0, 215);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(379, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.BackColor = System.Drawing.Color.White;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(320, 218);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "By:Jovi";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 237);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MD5效验与加密工具";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label La_File;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.TextBox TB_FilePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label La_MD5msg1;
        private System.Windows.Forms.Label La_MD5msg2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lab_tip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Rtb_str;
        private System.Windows.Forms.Button bt_strcopy;
        private System.Windows.Forms.Button bt_coring;
        private System.Windows.Forms.TextBox tb_strMD5;
        private System.Windows.Forms.Label la_str;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_change2;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}

