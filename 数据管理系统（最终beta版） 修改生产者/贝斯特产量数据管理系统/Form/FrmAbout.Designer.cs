namespace 贝斯特产量数据管理系统
{
	partial class FrmAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
			this.label27 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.skinButton1 = new CCWin.SkinControl.SkinButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label27.ForeColor = System.Drawing.Color.White;
			this.label27.Location = new System.Drawing.Point(26, 14);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(249, 38);
			this.label27.TabIndex = 1;
			this.label27.Text = "产量数据管理系统";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label37.Location = new System.Drawing.Point(263, 52);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(131, 12);
			this.label37.TabIndex = 5;
			this.label37.Text = "Version: Beta 1.2.0.0";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(33, 55);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(95, 95);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(263, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "2014 2.10 At Sicau\r\n";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Location = new System.Drawing.Point(31, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "Copyright © Jovi  2014";
			// 
			// skinButton1
			// 
			this.skinButton1.BackColor = System.Drawing.Color.Transparent;
			this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.skinButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.skinButton1.DownBack = null;
			this.skinButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.skinButton1.Location = new System.Drawing.Point(301, 164);
			this.skinButton1.MouseBack = null;
			this.skinButton1.Name = "skinButton1";
			this.skinButton1.NormlBack = null;
			this.skinButton1.Size = new System.Drawing.Size(75, 23);
			this.skinButton1.TabIndex = 9;
			this.skinButton1.Text = "关闭";
			this.skinButton1.UseVisualStyleBackColor = false;
			this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
			// 
			// FrmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(165)))), ((int)(((byte)(58)))));
			this.CancelButton = this.skinButton1;
			this.CanResize = false;
			this.ClientSize = new System.Drawing.Size(401, 203);
			this.ControlBox = false;
			this.Controls.Add(this.skinButton1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.label27);
			this.Name = "FrmAbout";
			this.ShowDrawIcon = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private CCWin.SkinControl.SkinButton skinButton1;
	}
}