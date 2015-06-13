namespace 贝斯特产量数据管理系统
{
	partial class FrmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
			this.tb_uname = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.tb_pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.btn_login = new System.Windows.Forms.Button();
			this.lb_error = new DevComponents.DotNetBar.LabelX();
			this.btn_close = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tb_uname
			// 
			this.tb_uname.BackColor = System.Drawing.SystemColors.ButtonFace;
			// 
			// 
			// 
			this.tb_uname.Border.Class = "TextBoxBorder";
			this.tb_uname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.tb_uname.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tb_uname.ForeColor = System.Drawing.Color.Gray;
			this.tb_uname.Location = new System.Drawing.Point(352, 194);
			this.tb_uname.Name = "tb_uname";
			this.tb_uname.Size = new System.Drawing.Size(220, 36);
			this.tb_uname.TabIndex = 1;
			this.tb_uname.WatermarkText = "Username:";
			// 
			// tb_pwd
			// 
			this.tb_pwd.BackColor = System.Drawing.SystemColors.ButtonFace;
			// 
			// 
			// 
			this.tb_pwd.Border.Class = "TextBoxBorder";
			this.tb_pwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.tb_pwd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tb_pwd.ForeColor = System.Drawing.Color.Gray;
			this.tb_pwd.Location = new System.Drawing.Point(352, 250);
			this.tb_pwd.Name = "tb_pwd";
			this.tb_pwd.Size = new System.Drawing.Size(172, 36);
			this.tb_pwd.TabIndex = 2;
			this.tb_pwd.UseSystemPasswordChar = true;
			this.tb_pwd.WatermarkText = "Password:";
			// 
			// btn_login
			// 
			this.btn_login.BackColor = System.Drawing.Color.Transparent;
			this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_login.FlatAppearance.BorderSize = 0;
			this.btn_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_login.Location = new System.Drawing.Point(530, 245);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(50, 47);
			this.btn_login.TabIndex = 0;
			this.btn_login.UseVisualStyleBackColor = false;
			this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
			// 
			// lb_error
			// 
			this.lb_error.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lb_error.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lb_error.ForeColor = System.Drawing.Color.Red;
			this.lb_error.Location = new System.Drawing.Point(352, 303);
			this.lb_error.Name = "lb_error";
			this.lb_error.Size = new System.Drawing.Size(218, 23);
			this.lb_error.TabIndex = 4;
			this.lb_error.Text = "账户或密码错误！";
			this.lb_error.Visible = false;
			// 
			// btn_close
			// 
			this.btn_close.BackColor = System.Drawing.Color.Transparent;
			this.btn_close.BackgroundImage = global::贝斯特产量数据管理系统.Properties.Resources.Close;
			this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_close.FlatAppearance.BorderSize = 0;
			this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_close.Location = new System.Drawing.Point(849, 407);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(46, 45);
			this.btn_close.TabIndex = 5;
			this.btn_close.UseVisualStyleBackColor = false;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CanResize = false;
			this.ClientSize = new System.Drawing.Size(924, 477);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.lb_error);
			this.Controls.Add(this.tb_pwd);
			this.Controls.Add(this.tb_uname);
			this.Controls.Add(this.btn_login);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "FrmLogin";
			this.ShowBorder = false;
			this.ShowDrawIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.Controls.TextBoxX tb_uname;
		private DevComponents.DotNetBar.Controls.TextBoxX tb_pwd;
		private System.Windows.Forms.Button btn_login;
		private DevComponents.DotNetBar.LabelX lb_error;
		private System.Windows.Forms.Button btn_close;








	}
}