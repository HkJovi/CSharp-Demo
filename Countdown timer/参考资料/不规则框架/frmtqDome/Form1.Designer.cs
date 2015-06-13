namespace frmtqDome
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webView = new System.Windows.Forms.WebBrowser();
            this.btnConvter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webView.Location = new System.Drawing.Point(0, 34);
            this.webView.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView.Name = "webView";
            this.webView.ScrollBarsEnabled = false;
            this.webView.Size = new System.Drawing.Size(238, 218);
            this.webView.TabIndex = 0;
            this.webView.Tag = "表状";
            this.webView.Url = new System.Uri("http://weather.news.qq.com/inc/ss218.htm", System.UriKind.Absolute);
            // 
            // btnConvter
            // 
            this.btnConvter.BackgroundImage = global::frmtqDome.Properties.Resources.login_btn_normal;
            this.btnConvter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConvter.FlatAppearance.BorderSize = 0;
            this.btnConvter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnConvter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnConvter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvter.Location = new System.Drawing.Point(5, 2);
            this.btnConvter.Name = "btnConvter";
            this.btnConvter.Size = new System.Drawing.Size(86, 30);
            this.btnConvter.TabIndex = 1;
            this.btnConvter.Text = "转换视图模式";
            this.btnConvter.UseVisualStyleBackColor = true;
            this.btnConvter.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::frmtqDome.Properties.Resources.btn_close_disable;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(187, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 20);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnConvter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::frmtqDome.Properties.Resources.LoginPanel_window_windowBkg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(238, 248);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConvter);
            this.Controls.Add(this.webView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webView;
        private System.Windows.Forms.Button btnConvter;
        private System.Windows.Forms.Button button1;
    }
}

