namespace 定位
{
    partial class Point
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Point));
            this.Point1 = new System.Windows.Forms.Label();
            this.Point2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Point1
            // 
            this.Point1.AutoSize = true;
            this.Point1.Location = new System.Drawing.Point(83, 124);
            this.Point1.Name = "Point1";
            this.Point1.Size = new System.Drawing.Size(119, 12);
            this.Point1.TabIndex = 2;
            this.Point1.Text = "相对坐标 X：    Y：";
            // 
            // Point2
            // 
            this.Point2.AutoSize = true;
            this.Point2.Location = new System.Drawing.Point(305, 124);
            this.Point2.Name = "Point2";
            this.Point2.Size = new System.Drawing.Size(107, 12);
            this.Point2.TabIndex = 3;
            this.Point2.Text = "绝对坐标 X:    Y:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Point
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 256);
            this.Controls.Add(this.Point2);
            this.Controls.Add(this.Point1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Point";
            this.Text = "窗口定位";
            this.Load += new System.EventHandler(this.Point_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Point_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Point1;
        private System.Windows.Forms.Label Point2;
        private System.Windows.Forms.Timer timer1;
    }
}

