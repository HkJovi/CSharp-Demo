using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bll;

namespace 贝斯特产量数据管理系统
{
	public partial class FrmXgpwd : DevComponents.DotNetBar.Metro.MetroForm
	{
		public FrmXgpwd(string uname)
		{
			InitializeComponent();
			lb_uname.Text = uname;
		}

		private void FrmXgpwd_Load(object sender, EventArgs e)
		{
			label1.ForeColor = Color.Gray;
			label2.ForeColor = Color.Gray;
			label3.ForeColor = Color.Gray;
			label4.ForeColor = Color.Gray;
			labe1.ForeColor = Color.Gray;
			lb_uname.ForeColor = Color.Orange;
			lb_tip.ForeColor = Color.Red;
		}

		private void sbtn_submit_Click(object sender, EventArgs e)
		{
			if (stb_oldpwd.Text == "" || stb_newpwd.Text == "")
			{
				lb_tip.Text = "输入密码不能为空";
				return;
			}
			if (stb_newpwd.Text != stb_repwd.Text)
			{
				lb_tip.Text = "新密码输入不一致！";
				return;
			}
			try
			{
				if (BLL.XGpwd(lb_uname.Text.Substring(4), stb_oldpwd.Text, stb_newpwd.Text) != 1)
				{
					lb_tip.Text = "修改失败，原密码错误！";
					return;
				}
				lb_tip.Text = "修改密码成功！";
			}
			catch
			{
				lb_tip.Text = "修改密码发生异常！";
			}
		}
	}
}