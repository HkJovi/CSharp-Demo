using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Bll;

namespace 贝斯特产量数据管理系统
{
	public partial class FrmLogin : CCSkinMain
	{
		public string uname
		{
			get
			{
				return tb_uname.Text;
			}
		}
		public int Power = 0;
		public FrmLogin()
		{
			InitializeComponent();
			ControlBox = false;
		}

		private void btn_login_Click(object sender, EventArgs e)   //power值为-1 账号密码错误   0  非法关闭   1正确权限值   
		{
			if (tb_pwd.Text == "" || tb_uname.Text == "")
			{
				lb_error.Text = "用户或者密码不能为空！";
				lb_error.Visible = true;
				return;
			}
			try
			{
				Power = BLL.GetPowerID(tb_uname.Text, tb_pwd.Text);
			}
			catch
			{
				MessageBox.Show("链接数据库失败！");
			}
			if (Power==-1)
			{
				lb_error.Text = "用户或密码错误！";
				lb_error.Visible = true;
				return;
			}
			this.Close();
		}

		private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
		{
			lb_error.Visible = false;
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FrmLogin_KeyDown(object sender, KeyEventArgs e) //设定回车快捷键
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.btn_login.Focus();
				btn_login_Click(this, new EventArgs());
			}
		}
	}
}
