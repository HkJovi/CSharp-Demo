/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-09-07
 * * 说明：FrmMain.cs
 * *
********************************************************************/

using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bll;
using DevComponents.DotNetBar.Controls;
using System.Data.SqlClient;

namespace 贝斯特产量数据管理系统
{
	public partial class FrmMain : CCSkinMain
	{
		DateTime sj = DateTime.Now;  //系统日期

		public FrmMain()
		{
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			// TODO: 这行代码将数据加载到表“bstDataSet_product.t_scz”中。您可以根据需要移动或删除它。
			this.t_sczTableAdapter.Fill(this.bstDataSet_product.t_scz);
			FrmLogin fl = new FrmLogin();  //当关闭的时候会自动释放窗体
			fl.ShowDialog();
			if (BLL.CheckSQLConnecting() == 0)
			{
				System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
			if (fl.Power == 0 || fl.Power == -1)  //非法关闭和没获取权限进来都会被关闭
			{
				System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
			this.Tag = fl.Power;
			//显示登陆用户信息
			timer_time.Start();
			timer_checklink.Start();
			UI.SetChinaDate(sbtn_chinadate);
			this.sbtn_name.Text += fl.uname;
			this.sbtn_qxz.Text += (fl.Power == 1 ? "超级管理员" : "工作人员");
			fl.Dispose();
			dateTimeInput_start2.Text = DateTime.Now.ToShortDateString();
			dateTimeInput_end2.Text = DateTime.Now.ToShortDateString();
			dateTimeInput_scbj.Text = sj.ToShortDateString();
			dateTimeInput_start.Text = DateTime.Now.ToShortDateString();
			dateTimeInput_end.Text = DateTime.Now.ToShortDateString();
			dataGridView_cltj.DataSource = BLL.GetDataGridViewList(@"SELECT id AS '编号',gh '工号',cz '材质',dz '单重',sl '数量',zl '总重',bz '备注',producter'生产者',sj '时间' FROM t_scb 
            WHERE sj=@Sj", new SqlParameter("Sj", DateTime.Now.ToShortDateString())).Tables[0].DefaultView;
			label_versionid.Text = "版本号：beta 1.2.0.0";
		}

		#region  弹出菜单效果
		private void sbtn_hide_Click(object sender, EventArgs e)
		{
			this.spanel_menu.Size = new Size(252, 20);
			this.spanel_menu.Location = new Point(652, 600);
			this.spanel_menu.Visible = false;
			this.pictureBox3.Refresh();
			this.pictureBox8.Refresh();
		}

		private void sbtn_show_Click(object sender, EventArgs e)
		{
			if (this.spanel_menu.Visible == false)
			{
				this.spanel_menu.Size = new Size(252, 499);
				this.spanel_menu.Location = new Point(652, 98);
				this.spanel_menu.Visible = true;
			}
			else
				sbtn_hide.PerformClick();
		}
		#endregion

		#region 状态显示
		private void timer_Tick(object sender, EventArgs e)
		{
			UI.SetTime(sbtn_time);
		}

		private void timer_checklink_Tick(object sender, EventArgs e)
		{
			bool SQLconnect = UI.CheckSQLConnecting(slb_SQLstatus, spic_right);
			if (!SQLconnect)  //断开连接UI层锁定
			{
				sbtn_lock_Click(this, new EventArgs());
				MessageBox.Show("与数据库连接断开,自动锁定！");
			}

		}
		#endregion

		#region 锁定，修改密码，退出
		private void sbtn_exit_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

		private void sbtn_xgpwd_Click(object sender, EventArgs e)
		{
			FrmXgpwd xgpwd = new FrmXgpwd(sbtn_name.Text);
			xgpwd.ShowDialog();
		}

		private void sbtn_lock_Click(object sender, EventArgs e)
		{
			skinTabControl_main.Visible = false;
			sPanel_lock.Visible = true;
			sPanel_lock.BringToFront();  //让panel在最上层遮盖
			skinAnimatorImg1.BringToFront();  //让animatorimg在最前面
			spanel_menu.Visible = false;
			sbtn_show.Enabled = false;
			UI.DownToShowUnlockBox(sbtn_unlockTx, slb_tip, sbtn_login, stb_login);   //确保每次都是锁定状态
		}

		#endregion

		#region 锁定时候的动画

		private void sbtn_unlockTx_Click(object sender, EventArgs e)
		{
			UI.RingToShowUnlockBox(sbtn_unlockTx, slb_tip, sbtn_login, stb_login);
		}

		private void sPanel_lock_Click(object sender, EventArgs e)
		{
			UI.DownToShowUnlockBox(sbtn_unlockTx, slb_tip, sbtn_login, stb_login);
		}

		#endregion

		#region 解除锁定
		private void sbtn_login_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(this.Tag) == BLL.GetPowerID(sbtn_name.Text.Substring(4), stb_login.SkinTxt.Text))
			{
				skinTabControl_main.Visible = true;
				sPanel_lock.Visible = false;
				spanel_menu.Visible = true;
				sbtn_show.Enabled = true;
			}
			else
			{
				slb_tip.Text = "密码错误";
			}
		}

		private void FrmMain_KeyDown(object sender, KeyEventArgs e)   //回车快捷键
		{
			if (e.KeyCode == Keys.Enter && skinTabControl_main.Visible == false)
			{
				this.sbtn_login.Focus();
				sbtn_login_Click(this, new EventArgs());
			}
		}
		#endregion

		#region 客户公司管理

		private void sbtn_getsczlist_Click(object sender, EventArgs e)  //获取列表
		{
			UI.ShowsczglListBox(slistbox_khgl);
		}

		private void slistbox_sczgl_MouseClick(object sender, MouseEventArgs e)   //选定到修改框
		{
			if (slistbox_khgl.SelectedItem != null)
				stb_edit_khgl.SkinTxt.Text = slistbox_khgl.SelectedItem.ToString();
		}

		private void skinTextBox1_SkinTxt_TextChanged(object sender, EventArgs e)   //关键字查询功能
		{
			UI.ShowsczglListBox(slistbox_khgl, stb_khgl_keysearch.SkinTxt.Text);
		}

		private void sbtn_search_Click(object sender, EventArgs e)
		{
			UI.ShowsczglListBox(slistbox_khgl, stb_khgl_keysearch.SkinTxt.Text);
		}

		private void sbtn_sczglxg_Click(object sender, EventArgs e)  //修改客户公司信息
		{
			if (slistbox_khgl.SelectedItem != null)
			{
				DialogResult result = MessageBox.Show("你确定修改 " + slistbox_khgl.SelectedItem.ToString() + " 为 " + stb_edit_khgl.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
					return;
				foreach (CCWin.SkinControl.SkinListBoxItem item in slistbox_khgl.Items)
				{
					if (item.Text.Trim() == stb_edit_khgl.SkinTxt.Text.Trim())   //遍历是否重复
					{
						slistbox_khgl.SelectedItem = item; //重复则选定
						return;
					}
				}
				try
				{
					int i = BLL.SczglXg(slistbox_khgl.SelectedItem.ToString(), stb_edit_khgl.SkinTxt.Text);
					if (i == 1)
					{
						MessageBox.Show("修改成功！");
						BLL.AddLog("修改生产者名称", "修改" + slistbox_khgl.SelectedItem.ToString() + "为" + stb_edit_khgl.SkinTxt.Text.Trim(),
							sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
					}
					stb_edit_khgl.SkinTxt.Text = string.Empty;
					sbtn_getkhlist.PerformClick();
				}
				catch
				{
					MessageBox.Show("数据库修改发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void sbtn_sczglxz_Click(object sender, EventArgs e)
		{
			if (stb_edit_khgl.SkinTxt.Text.Trim() == "")
				return;
			sbtn_getkhlist.PerformClick(); //获取最新列表
			DialogResult result = MessageBox.Show("你确定增加 " + stb_edit_khgl.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			foreach (CCWin.SkinControl.SkinListBoxItem item in slistbox_khgl.Items)
			{
				if (item.Text.Trim() == stb_edit_khgl.SkinTxt.Text.Trim())   //遍历是否重复
				{
					slistbox_khgl.SelectedItem = item; //重复则选定
					return;
				}
			}
			try
			{
				int i = BLL.SczglXz(stb_edit_khgl.SkinTxt.Text.Trim());
				if (i == 1)
				{
					BLL.AddLog("新增生产者", "新增" + stb_edit_khgl.SkinTxt.Text.Trim(),
						sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
					MessageBox.Show("增加成功！");
				}
				sbtn_getkhlist.PerformClick(); //获取最新列表
			}
			catch
			{
				MessageBox.Show("数据库增加发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region 新增规格

		private void skinTextBox1_SkinTxt_TextChanged_1(object sender, EventArgs e)  //工号名
		{
			if (stb_gh.SkinTxt.Text != "")
				UI.ShowListBox(listBox_gh, stb_gh.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetghListBox));  //委托调用在UI类里
			else
			{
				listBox_gh.Visible = false;
				listBox_gh.Items.Clear();
			}
		}

		private void listBox_gh_MouseClick(object sender, MouseEventArgs e)  //选择模糊查询的工号
		{
			if (listBox_gh.SelectedItem != null)
				stb_gh.SkinTxt.Text = listBox_gh.SelectedItem.ToString().Trim();
			listBox_gh.Visible = false;
			listBox_gh.Items.Clear();
		}

		private void skinTextBox4_SkinTxt_TextChanged(object sender, EventArgs e)  //材质
		{
			if (stb_cz.SkinTxt.Text != "")
				UI.ShowListBox(listBox_cz, stb_cz.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetczListBox));  //委托调用在UI类里
			else
			{
				listBox_cz.Visible = false;
				listBox_cz.Items.Clear();
			}
		}

		private void listBox_cz_MouseClick(object sender, MouseEventArgs e)    //选择模糊查询的材质
		{
			if (listBox_cz.SelectedItem != null)
				stb_cz.SkinTxt.Text = listBox_cz.SelectedItem.ToString().Trim();
			listBox_cz.Visible = false;
			listBox_cz.Items.Clear();
		}

		private void skinTextBox7_SkinTxt_TextChanged(object sender, EventArgs e)  //所属客户公司
		{
			//if (stb_belongkh.SkinTxt.Text != "")
			//	UI.ShowListBox(listBox_belongkh, stb_belongkh.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetbelongSczListBox));  //委托调用在UI类里
			//else
			//{
			//	listBox_belongkh.Visible = false;
			//	listBox_belongkh.Items.Clear();
			//}
		}

		private void listBox_belongkh_MouseClick(object sender, MouseEventArgs e) //选择模糊查询客户公司
		{
			//if (listBox_belongkh.SelectedItem != null)
			//	stb_belongkh.SkinTxt.Text = listBox_belongkh.SelectedItem.ToString().Trim();
			//listBox_belongkh.Visible = false;
			//listBox_belongkh.Items.Clear();
		}

		private void skinTextBox1_SkinTxt_Enter(object sender, EventArgs e)
		{
			//listBox_belongkh.Visible = false;
			listBox_cz.Visible = false;
			listBox_gh.Visible = false;
		}

		private void sbtn_addgg_Click(object sender, EventArgs e)  //添加新规格
		{
			if (stb_gh.SkinTxt.Text == "" || stb_dz.SkinTxt.Text == "" )
			{
				lb_ggtips.Visible = true;
				lb_ggtips.Text = "错误提示：工号,单重不能为空！";
				return;
			}
			Regex rg = new Regex(@"^\-?([1-9]\d*|0)(\.\d*)?$");
			if (rg.IsMatch(stb_dz.SkinTxt.Text) == false)
			{
				lb_ggtips.Visible = true;
				lb_ggtips.Text = "错误提示：单重必须是实数！";
				return;
			}
			//if (BLL.CheckKhIsEmpty(stb_belongkh.SkinTxt.Text))
			//{
			//	lb_ggtips.Visible = true;
			//	lb_ggtips.Text = "错误提示：提交公司名称未在公司名称列表中！";
			//	return;
			//}
			lb_ggtips.Visible = false;
			DialogResult result = MessageBox.Show("你确定增加 " + stb_gh.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			try
			{
				if (BLL.Addgg(stb_gh.SkinTxt.Text.Trim(), stb_mc.SkinTxt.Text.Trim(), stb_gg.SkinTxt.Text.Trim(), stb_th.SkinTxt.Text.Trim()
					, stb_sbh.SkinTxt.Text.Trim(), stb_cz.SkinTxt.Text.Trim(), stb_dz.SkinTxt.Text.Trim(), stb_sl.SkinTxt.Text.Trim(),
					stb_bz.SkinTxt.Text.Trim(), stb_belongkh.SkinTxt.Text.Trim()) == 1)
				{
					BLL.AddLog("新增规格", "新增" + stb_gh.SkinTxt.Text,
					sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
					MessageBox.Show("新增规格成功！");     //进行清空操作
					stb_gh.SkinTxt.Text = "";
					stb_mc.SkinTxt.Text = "";
					stb_gg.SkinTxt.Text = "";
					stb_th.SkinTxt.Text = "";
					stb_sbh.SkinTxt.Text = "";
					stb_cz.SkinTxt.Text = "WCB";
					stb_dz.SkinTxt.Text = "";
					stb_sl.SkinTxt.Text = "";
					stb_bz.SkinTxt.Text = "";
					stb_belongkh.SkinTxt.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("工号存在！不能重复添加！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region 材质管理
		private void sbtn_getczlist_Click(object sender, EventArgs e)
		{
			UI.ShowCzListBox(slistbox_cz);
		}

		private void skinTextBox1_SkinTxt_TextChanged_2(object sender, EventArgs e)
		{
			UI.ShowCzListBox(slistbox_cz, stb_cz_keysearch.SkinTxt.Text);
		}

		private void slistbox_cz_MouseClick(object sender, MouseEventArgs e)
		{
			if (slistbox_cz.SelectedItem != null)
				stb_edit_cz.SkinTxt.Text = slistbox_cz.SelectedItem.ToString();
		}

		private void sbtn_search_cz_Click(object sender, EventArgs e)
		{
			UI.ShowCzListBox(slistbox_cz, stb_cz_keysearch.SkinTxt.Text);
		}

		private void sbtn_czxg_Click(object sender, EventArgs e)
		{
			if (slistbox_cz.SelectedItem != null)
			{
				DialogResult result = MessageBox.Show("你确定修改 " + slistbox_cz.SelectedItem.ToString() + " 为 " + stb_edit_cz.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
					return;
				foreach (CCWin.SkinControl.SkinListBoxItem item in slistbox_cz.Items)
				{
					if (item.Text.Trim() == stb_edit_cz.SkinTxt.Text.Trim())   //遍历是否重复
					{
						slistbox_cz.SelectedItem = item; //重复则选定
						return;
					}
				}
				try
				{
					int i = BLL.CzXg(slistbox_cz.SelectedItem.ToString(), stb_edit_cz.SkinTxt.Text);
					if (i == 1)
					{
						BLL.AddLog("修改材质名称", "修改" + slistbox_cz.SelectedItem.ToString() + " 为 " + stb_edit_cz.SkinTxt.Text.Trim(),
							sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
						MessageBox.Show("修改成功！");
					}
					stb_edit_cz.SkinTxt.Text = string.Empty;
					sbtn_getczlist.PerformClick();
				}
				catch
				{
					MessageBox.Show("数据库修改发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void sbtn_czxz_Click(object sender, EventArgs e)
		{
			if (stb_edit_cz.SkinTxt.Text.Trim() == "")
				return;
			sbtn_getkhlist.PerformClick(); //获取最新列表
			DialogResult result = MessageBox.Show("你确定增加 " + stb_edit_cz.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			foreach (CCWin.SkinControl.SkinListBoxItem item in slistbox_cz.Items)
			{
				if (item.Text.Trim() == stb_edit_cz.SkinTxt.Text.Trim())   //遍历是否重复
				{
					slistbox_cz.SelectedItem = item; //重复则选定
					return;
				}
			}
			int i = BLL.CzXz(stb_edit_cz.SkinTxt.Text.Trim());
			if (i == 1)
			{
				BLL.AddLog("新增客户公司名称", "新增" + stb_edit_cz.SkinTxt.Text.Trim(),
				sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
				MessageBox.Show("增加成功！");
			}
			sbtn_getczlist.PerformClick(); //获取最新列表
		}
		#endregion

		#region 规格查询修改

		private void skinTextBox4_SkinTxt_TextChanged_1(object sender, EventArgs e)
		{
			if (stb_cz2.SkinTxt.Text != "")
				UI.ShowListBox(listBox_cz2, stb_cz2.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetczListBox));  //委托调用在UI类里
			else
			{
				listBox_cz2.Visible = false;
				listBox_cz2.Items.Clear();
			}
		}

		private void listBox_cz2_MouseClick(object sender, MouseEventArgs e)
		{
			if (listBox_cz2.SelectedItem != null)
				stb_cz2.SkinTxt.Text = listBox_cz2.SelectedItem.ToString().Trim();
			listBox_cz2.Visible = false;
			listBox_cz2.Items.Clear();
		}

		private void skinTextBox10_SkinTxt_TextChanged(object sender, EventArgs e)
		{
			//if (stb_belongkh2.SkinTxt.Text != "")
			//	UI.ShowListBox(listBox_belongkh2, stb_belongkh2.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetbelongSczListBox));  //委托调用在UI类里
			//else
			//{
			//	listBox_belongkh2.Visible = false;
			//	listBox_belongkh2.Items.Clear();
			//}
		}

		private void listBox_belongkh2_MouseClick(object sender, MouseEventArgs e)
		{
			//if (listBox_belongkh2.SelectedItem != null)
			//	stb_belongkh2.SkinTxt.Text = listBox_belongkh2.SelectedItem.ToString().Trim();
			//listBox_belongkh2.Visible = false;
			//listBox_belongkh2.Items.Clear();
		}

		private void skinTextBox1_SkinTxt_Enter_1(object sender, EventArgs e)
		{
			//listBox_belongkh2.Visible = false;
			listBox_cz2.Visible = false;
		}

		private void stb_cxxgkeword_SkinTxt_TextChanged(object sender, EventArgs e)
		{
			dataGridView_gggl.DataSource = BLL.GetDataGridViewList(@"SELECT gh as '工号',mc '名称',gg '规格',th '图号',sbh '识别号',cz '材质',dz '单重',sl '数量',bz '备注',belongkh '所属公司'
            FROM t_ggb WHERE gh like @Keyword OR mc like @Keyword OR gg like @Keyword OR th like @Keyword OR sbh like @Keyword OR cz like @Keyword OR dz like @Keyword OR sl like @Keyword OR bz like @Keyword OR belongkh like @Keyword",
			new SqlParameter("Keyword", "%" + stb_cxxgkeyword.SkinTxt.Text.Trim() + "%")).Tables[0].DefaultView;
			if (stb_cxxgkeyword.SkinTxt.Text == "")
			{
				dataGridView_gggl.DataSource = null;
				dataGridView_gggl.Refresh();
			}
			stb_gh2.SkinTxt.Text = "";
			stb_mc2.SkinTxt.Text = "";
			stb_gg2.SkinTxt.Text = "";
			stb_th2.SkinTxt.Text = "";
			stb_sbh2.SkinTxt.Text = "";
			stb_cz2.SkinTxt.Text = "";
			stb_dz2.SkinTxt.Text = "";
			stb_sl2.SkinTxt.Text = "";
			stb_bz2.SkinTxt.Text = "";
			stb_belongkh2.SkinTxt.Text = "";
		}

		private void sbtn_keywordcx_Click(object sender, EventArgs e)
		{
			stb_cxxgkeword_SkinTxt_TextChanged(this, new EventArgs());
		}

		private void dataGridView_gggl_CellClick(object sender, DataGridViewCellEventArgs e) //读取点击信息
		{
			int Row = dataGridView_gggl.CurrentRow.Index;
			stb_gh2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[0].Value.ToString();
			stb_mc2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[1].Value.ToString();
			stb_gg2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[2].Value.ToString();
			stb_th2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[3].Value.ToString();
			stb_sbh2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[4].Value.ToString();
			stb_cz2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[5].Value.ToString();
			stb_dz2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[6].Value.ToString();
			stb_sl2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[7].Value.ToString();
			stb_bz2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[8].Value.ToString();
			stb_belongkh2.SkinTxt.Text = dataGridView_gggl.Rows[Row].Cells[9].Value.ToString();
			//listBox_belongkh2.Visible = false;
			listBox_cz2.Visible = false;
		}

		private void sbtn_xggg_Click(object sender, EventArgs e)
		{
			if (stb_dz2.SkinTxt.Text == "" )
			{
				lb_tips2.Visible = true;
				lb_tips2.Text = "错误提示：单重不能为空！";
				return;
			}
			Regex rg = new Regex(@"^\-?([1-9]\d*|0)(\.\d*)?$");
			if (rg.IsMatch(stb_dz2.SkinTxt.Text) == false)
			{
				lb_tips2.Visible = true;
				lb_tips2.Text = "错误提示：单重必须是实数！";
				return;
			}
			//if (BLL.CheckKhIsEmpty(stb_belongkh2.SkinTxt.Text))
			//{
			//	lb_tips2.Visible = true;
			//	lb_tips2.Text = "错误提示：提交公司名称未在公司名称列表中！";
			//	return;
			//}
			lb_tips2.Visible = false;
			DialogResult result = MessageBox.Show("你确定修改 " + stb_gh2.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			try
			{
				if (BLL.Xggg(stb_gh2.SkinTxt.Text.Trim(), stb_mc2.SkinTxt.Text.Trim(), stb_gg2.SkinTxt.Text.Trim(), stb_th2.SkinTxt.Text.Trim()
					, stb_sbh2.SkinTxt.Text.Trim(), stb_cz2.SkinTxt.Text.Trim(), stb_dz2.SkinTxt.Text.Trim(), stb_sl2.SkinTxt.Text.Trim(),
					stb_bz2.SkinTxt.Text.Trim(), stb_belongkh2.SkinTxt.Text.Trim()) == 1)
				{
					BLL.AddLog("修改规格", "修改" + stb_gh2.SkinTxt.Text.Trim(),
					sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("修改规格成功！");     //进行清空操作
					stb_gh2.SkinTxt.Text = "";
					stb_mc2.SkinTxt.Text = "";
					stb_gg2.SkinTxt.Text = "";
					stb_th2.SkinTxt.Text = "";
					stb_sbh2.SkinTxt.Text = "";
					stb_cz2.SkinTxt.Text = "";
					stb_dz2.SkinTxt.Text = "";
					stb_sl2.SkinTxt.Text = "";
					stb_bz2.SkinTxt.Text = "";
					stb_belongkh2.SkinTxt.Text = "";
					stb_cxxgkeword_SkinTxt_TextChanged(this, new EventArgs());
				}
			}
			catch
			{
				MessageBox.Show("数据库修改发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region 生产管理
		private void skinTextBox1_SkinTxt_TextChanged_3(object sender, EventArgs e)
		{
			try
			{
				string cmd = @"SELECT id AS '编号',gh '工号',cz '材质',dz '单重',sl '数量',zl '总重',bz '备注',producter'生产者',sj '时间' FROM t_scb 
            WHERE (gh LIKE @Keyword OR cz LIKE @Keyword OR dz LIKE @Keyword OR sl LIKE @Keyword OR zl LIKE @Keyword OR bz LIKE @Keyword OR sj LIKE @Keyword OR producter LIKE @Keyword)";
				List<SqlParameter> SpList = new List<SqlParameter>();  //把参数处理成数组形式
				SpList.Add(new SqlParameter("Keyword", "%" + stb_sckeyword.SkinTxt.Text.Trim() + "%"));
				if (scheckbox_sc.Checked)
				{
					if (sCheckBox_gh.Checked)
					{
						string gh = "%" + stb_scheckbox_gh.SkinTxt.Text + "%";
						cmd = cmd + " and gh like @Gh";
						SpList.Add(new SqlParameter("Gh", gh));
					}
					if (sCheckBox_cz.Checked)
					{
						string cz = "%" + stb_scheckbox_cz.SkinTxt.Text + "%";
						cmd = cmd + " and cz like @Cz";
						SpList.Add(new SqlParameter("Cz", cz));
					}
					if (sCheckBox_dz.Checked)
					{
						float low, high;
						BLL.GetRange(stb_scheckbox_dz.SkinTxt.Text, out low, out high);
						if (low != -1 && high != -1)
						{
							cmd = cmd + " and dz BETWEEN @Low_dz AND @High_dz";
							SpList.Add(new SqlParameter("Low_dz", low));
							SpList.Add(new SqlParameter("High_dz", high));
						}
					}
					if (sCheckBox_sl.Checked)
					{
						float low, high;
						BLL.GetRange(stb_scheckbox_sl.SkinTxt.Text, out low, out high);
						if (low != -1 && high != -1)
						{
							cmd = cmd + " and sl BETWEEN @Low_sl AND @High_sl";
							SpList.Add(new SqlParameter("Low_sl", low));
							SpList.Add(new SqlParameter("High_sl", high));
						}
					}
					if (sCheckBox_zl.Checked)
					{
						float low, high;
						BLL.GetRange(stb_scheckbox_zl.SkinTxt.Text, out low, out high);
						if (low != -1 && high != -1)
						{
							cmd = cmd + " and zl BETWEEN @Low_zl AND @High_zl";
							SpList.Add(new SqlParameter("Low_zl", low));
							SpList.Add(new SqlParameter("High_zl", high));
						}
					}
					if (sCheckBox_pruducter.Checked)
					{
						string producter = "%" + stb_scheckbox_producter.SkinTxt.Text + "%";
						cmd = cmd + " and producter like @Producter";
						SpList.Add(new SqlParameter("Producter", producter));
					}
					if (sCheckBox_bz.Checked)
					{
						if (stb_scheckbox_bz.SkinTxt.Text.Trim() != "")
						{
							if (stb_scheckbox_bz.SkinTxt.Text.Trim() == "有" || stb_scheckbox_bz.SkinTxt.Text.Trim() == "无")
							{
								if (stb_scheckbox_bz.SkinTxt.Text.Trim() == "有")
								{
									cmd = cmd + " and bz is not NULL";
								}
								if (stb_scheckbox_bz.SkinTxt.Text.Trim() == "无")
								{
									cmd = cmd + " and bz is NULL";
								}
							}
							else
							{
								string bz = "%" + stb_scheckbox_bz.SkinTxt.Text + "%";
								cmd = cmd + " and bz like @Bz";
								SpList.Add(new SqlParameter("Bz", bz));
							}
						}
					}
					if (sCheckBox_sj.Checked)
					{
						dateTimeInput_start.Text = dateTimeInput_start.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_start.Text;
						dateTimeInput_end.Text = dateTimeInput_end.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_end.Text;
						cmd = cmd + " and sj BETWEEN @start AND @end";
						SpList.Add(new SqlParameter("start", dateTimeInput_start.Text));
						SpList.Add(new SqlParameter("end", dateTimeInput_end.Text));
					}
				}
				SqlParameter[] param = SpList.ToArray();
				dataGridView_sc.DataSource = BLL.GetDataGridViewList(cmd,
				param).Tables[0].DefaultView;
				if (stb_sckeyword.SkinTxt.Text == "")
				{
					dataGridView_sc.DataSource = null;
					dataGridView_sc.Refresh();
				}
				//stb_gh3.SkinTxt.Text = "";
				//stb_cz3.SkinTxt.Text = "";
				//stb_dz3.SkinTxt.Text = "";
				stb_sl3.SkinTxt.Text = "";
				//stb_bz3.SkinTxt.Text = "";
				dateTimeInput_scbj.Text = sj.ToShortDateString();
			}
			catch
			{
				MessageBox.Show("数据库获取数据发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView_sc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int Row = dataGridView_sc.CurrentRow.Index;
			stb_gh3.SkinTxt.Tag = dataGridView_sc.Rows[Row].Cells[0].Value.ToString(); //保存编号
			stb_gh3.SkinTxt.Text = dataGridView_sc.Rows[Row].Cells[1].Value.ToString();
			stb_cz3.SkinTxt.Text = dataGridView_sc.Rows[Row].Cells[2].Value.ToString();
			stb_dz3.SkinTxt.Text = dataGridView_sc.Rows[Row].Cells[3].Value.ToString();
			stb_sl3.SkinTxt.Text = dataGridView_sc.Rows[Row].Cells[4].Value.ToString();
			stb_bz3.SkinTxt.Text = dataGridView_sc.Rows[Row].Cells[6].Value.ToString();
			combox_producter.Text = dataGridView_sc.Rows[Row].Cells[7].Value.ToString();
			dateTimeInput_scbj.Text = dataGridView_sc.Rows[Row].Cells[8].Value.ToString();
			listBox_cz3.Visible = false;
			listBox_gh3.Visible = false;
		}

		private void stb_sckeywordcx_Click(object sender, EventArgs e)
		{
			skinTextBox1_SkinTxt_TextChanged_3(this, new EventArgs());
		}

		private void scheckbox_sc_CheckedChanged(object sender, EventArgs e)
		{
			skinTextBox1_SkinTxt_TextChanged_3(this, new EventArgs());
		}

		private void stb_gh3_SkinTxt_TextChanged(object sender, EventArgs e)
		{
			if (stb_gh3.SkinTxt.Text != "")
			{
				UI.ShowListBox(listBox_gh3, stb_gh3.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetghListBox));
			}
			else
			{
				listBox_gh3.Visible = false;
				listBox_gh3.Items.Clear();
			}
		}

		private void stb_cz3_SkinTxt_TextChanged(object sender, EventArgs e)
		{
			if (stb_cz3.SkinTxt.Text != "")
			{
				UI.ShowListBox(listBox_cz3, stb_cz3.SkinTxt.Text, new UI.Delegate_GetListBox(BLL.GetczListBox));
			}
			else
			{
				listBox_cz3.Visible = false;
				listBox_cz3.Items.Clear();
			}
		}

		private void stb_gh3_Enter(object sender, EventArgs e)
		{
			listBox_gh3.Visible = false;
			listBox_cz3.Visible = false;
		}

		private void listBox_gh3_MouseClick(object sender, MouseEventArgs e)
		{
			if (listBox_gh3.SelectedItem != null)
			{
				stb_gh3.SkinTxt.Text = listBox_gh3.SelectedItem.ToString().Trim();
				DataRow dr = BLL.GetExpressghxx(listBox_gh3.SelectedItem.ToString().Trim());
				if (dr != null)
				{
					stb_dz3.SkinTxt.Text = dr["dz"].ToString();
					stb_cz3.SkinTxt.Text = dr["cz"].ToString();
					stb_bz3.SkinTxt.Text = dr["bz"].ToString();
				}
			}
			listBox_cz3.Visible = false;
			listBox_gh3.Visible = false;
			listBox_gh3.Items.Clear();
		}

		private void listBox_cz3_MouseClick(object sender, MouseEventArgs e)
		{
			if (listBox_cz3.SelectedItem != null)
				stb_cz3.SkinTxt.Text = listBox_cz3.SelectedItem.ToString().Trim();
			listBox_cz3.Visible = false;
			listBox_cz3.Items.Clear();
		}

		private void sbtn_scxz_Click(object sender, EventArgs e)
		{
			if (stb_gh3.SkinTxt.Text == "" || stb_dz3.SkinTxt.Text == "" || stb_cz3.SkinTxt.Text == "" || combox_producter.Text == "" || stb_sl3.SkinTxt.Text == "" || dateTimeInput_scbj.Text == "")
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：工号,单重,数量,材质和时间不能为空！";
				return;
			}
			Regex rg = new Regex(@"^\-?([1-9]\d*|0)(\.\d*)?$");
			if (rg.IsMatch(stb_dz3.SkinTxt.Text) == false || rg.IsMatch(stb_sl3.SkinTxt.Text) == false)
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：单重,数量必须是实数！";
				return;
			}
			if (BLL.CheckCzIsEmpty(stb_cz3.SkinTxt.Text))
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：提交材质未在材质名称列表中！";
				return;
			}
			if (BLL.CheckGhIsEmpty(stb_gh3.SkinTxt.Text))
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：提交工号未在工号名称列表中！";
				return;
			}
			lb_ggtips3.Visible = false;
			DialogResult result = MessageBox.Show("你确定增加 " + stb_gh3.SkinTxt.Text.Trim() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			try
			{
				if (BLL.Addsc(stb_gh3.SkinTxt.Text.Trim(), stb_cz3.SkinTxt.Text.Trim(), stb_dz3.SkinTxt.Text.Trim(),
					stb_sl3.SkinTxt.Text.Trim(), combox_producter.Text.Trim(), stb_bz3.SkinTxt.Text, dateTimeInput_scbj.Text) == 1)
				{
					BLL.AddLog("新增生产", "新增" + stb_gh3.SkinTxt.Text.Trim(),
					sbtn_name.Text.Substring(4), sj.ToShortDateString());   //添加日志信息
					MessageBox.Show("新增生产成功！");     //进行清空操作
					stb_sl3.SkinTxt.Text = "";
					stb_bz.SkinTxt.Text = "";
					dateTimeInput_scbj.Text = DateTime.Now.ToShortDateString();
					skinTextBox1_SkinTxt_TextChanged_3(this, new EventArgs());
				}
			}
			catch
			{
				MessageBox.Show("数据库新增发生异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_scxg_Click(object sender, EventArgs e)
		{
			if (stb_gh3.SkinTxt.Tag==null)
				return;
			if (stb_gh3.SkinTxt.Text == "" || stb_dz3.SkinTxt.Text == "" || stb_cz3.SkinTxt.Text == "" || combox_producter.Text == "" || stb_sl3.SkinTxt.Text == "" || dateTimeInput_scbj.Text == "")
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：工号,单重,数量,材质和时间不能为空！";
				return;
			}
			Regex rg = new Regex(@"^\-?([1-9]\d*|0)(\.\d*)?$");
			if (rg.IsMatch(stb_dz3.SkinTxt.Text) == false || rg.IsMatch(stb_sl3.SkinTxt.Text) == false)
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：单重,数量必须是实数！";
				return;
			}
			if (BLL.CheckCzIsEmpty(stb_cz3.SkinTxt.Text))
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：提交材质未在材质名称列表中！";
				return;
			}
			if (BLL.CheckGhIsEmpty(stb_gh3.SkinTxt.Text))
			{
				lb_ggtips3.Visible = true;
				lb_ggtips3.Text = "错误提示：提交工号未在工号名称列表中！";
				return;
			}
			lb_ggtips3.Visible = false;
			DialogResult result = MessageBox.Show("你确定修改 " + stb_gh3.SkinTxt.Text.Trim() + " 编号为(" + stb_gh3.SkinTxt.Tag.ToString() + ") 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			try
			{
				if (BLL.Xgsc(stb_gh3.SkinTxt.Tag.ToString(), stb_gh3.SkinTxt.Text.Trim(), stb_cz3.SkinTxt.Text.Trim(), stb_dz3.SkinTxt.Text.Trim(),
					stb_sl3.SkinTxt.Text.Trim(), combox_producter.Text.Trim(), stb_bz3.SkinTxt.Text, dateTimeInput_scbj.Text) == 1)
				{
					BLL.AddLog("修改生产", "修改" + stb_gh3.SkinTxt.Text.Trim() + " 编号 " + stb_gh3.SkinTxt.Tag.ToString(),
					sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("修改生产成功！");     //进行清空操作
					stb_gh3.SkinTxt.Text = "";
					stb_cz3.SkinTxt.Text = "";
					stb_dz3.SkinTxt.Text = "";
					stb_sl3.SkinTxt.Text = "";
					stb_bz.SkinTxt.Text = "";
					dateTimeInput_scbj.Text = DateTime.Now.ToShortDateString();
					skinTextBox1_SkinTxt_TextChanged_3(this, new EventArgs());
				}
			}
			catch
			{
				MessageBox.Show("提交数据有误！请检查重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_scsc_Click(object sender, EventArgs e)
		{
			if (stb_gh3.SkinTxt.Tag == null)
				return;
			DialogResult result = MessageBox.Show("你确定删除 " + stb_gh3.SkinTxt.Text.Trim() + " 编号为(" + stb_gh3.SkinTxt.Tag.ToString() + ") 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return;
			try
			{
				if (BLL.Scsc(stb_gh3.SkinTxt.Tag.ToString()) == 1)
				{
					BLL.AddLog("删除生产", "删除" + stb_gh3.SkinTxt.Text.Trim() + " 编号 " + stb_gh3.SkinTxt.Tag.ToString(),
					sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("删除生产记录成功！");     //进行清空操作
					stb_gh3.SkinTxt.Text = "";
					stb_cz3.SkinTxt.Text = "";
					stb_dz3.SkinTxt.Text = "";
					stb_sl3.SkinTxt.Text = "";
					stb_bz.SkinTxt.Text = "";
					dateTimeInput_scbj.Text = DateTime.Now.ToShortDateString();
					skinTextBox1_SkinTxt_TextChanged_3(this, new EventArgs());
					stb_gh3.SkinTxt.Tag = null;
				}
			}
			catch
			{
				MessageBox.Show("删除失败！请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region 生产统计

		private void skinTextBox7_SkinTxt_TextChanged_1(object sender, EventArgs e)
		{
			if (((CCWin.SkinControl.SkinWaterTextBox)sender).Text == "")
				dataGridView_cltj.DataSource = BLL.GetDataGridViewList(@"SELECT id AS '编号',gh '工号',cz '材质',dz '单重',sl '数量',zl '总重',bz '备注',producter'生产者',sj '时间' FROM t_scb 
            WHERE sj=@Sj", new SqlParameter("Sj", DateTime.Now.ToShortDateString())).Tables[0].DefaultView;
			datagridview_sctj(this, new EventArgs());
		}

		private void sCheckBox_sj2_CheckedChanged(object sender, EventArgs e)
		{
			dataGridView_cltj.DataSource = BLL.GetDataGridViewList(@"SELECT id AS '编号',gh '工号',cz '材质',dz '单重',sl '数量',zl '总重',bz '备注',producter'生产者',sj '时间' FROM t_scb 
            WHERE sj=@Sj", new SqlParameter("Sj", DateTime.Now.ToShortDateString())).Tables[0].DefaultView;
			datagridview_sctj(this, new EventArgs());
		}

		private void datagridview_sctj(object sender, EventArgs e)
		{
			try
			{
				string cmd = @"SELECT id AS '编号',gh '工号',cz '材质',dz '单重',sl '数量',zl '总重',bz '备注',producter'生产者',sj '时间' FROM t_scb 
            WHERE 1=1";
				List<SqlParameter> SpList = new List<SqlParameter>();  //把参数处理成数组形式
				SpList.Add(new SqlParameter("Keyword", "%" + stb_sckeyword.SkinTxt.Text.Trim() + "%"));
				if (sCheckBox_gh2.Checked)
				{
					string gh = "%" + stb_sCheckBox_gh4.SkinTxt.Text + "%";
					cmd = cmd + " and gh like @Gh";
					SpList.Add(new SqlParameter("Gh", gh));
				}
				if (sCheckBox_cz2.Checked)
				{
					string cz = "%" + stb_sCheckBox_cz4.SkinTxt.Text + "%";
					cmd = cmd + " and cz like @Cz";
					SpList.Add(new SqlParameter("Cz", cz));
				}
				if (sCheckBox_dz2.Checked)
				{
					float low, high;
					BLL.GetRange(stb_sCheckBox_dz4.SkinTxt.Text, out low, out high);
					if (low != -1 && high != -1)
					{
						cmd = cmd + " and dz BETWEEN @Low_dz AND @High_dz";
						SpList.Add(new SqlParameter("Low_dz", low));
						SpList.Add(new SqlParameter("High_dz", high));
					}
				}
				if (sCheckBox_sl2.Checked)
				{
					float low, high;
					BLL.GetRange(stb_sCheckBox_sl4.SkinTxt.Text, out low, out high);
					if (low != -1 && high != -1)
					{
						cmd = cmd + " and sl BETWEEN @Low_sl AND @High_sl";
						SpList.Add(new SqlParameter("Low_sl", low));
						SpList.Add(new SqlParameter("High_sl", high));
					}
				}
				if (sCheckBox_zl2.Checked)
				{
					float low, high;
					BLL.GetRange(stb_sCheckBox_zl4.SkinTxt.Text, out low, out high);
					if (low != -1 && high != -1)
					{
						cmd = cmd + " and zl BETWEEN @Low_zl AND @High_zl";
						SpList.Add(new SqlParameter("Low_zl", low));
						SpList.Add(new SqlParameter("High_zl", high));
					}
				}
				if (sCheckBox_producter2.Checked)
				{
					string producter = "%" + stb_sCheckBox_producter4.SkinTxt.Text + "%";
					cmd = cmd + " and producter like @Producter";
					SpList.Add(new SqlParameter("Producter", producter));
				}
				if (sCheckBox_bz2.Checked)
				{
					if (stb_sCheckBox_bz4.SkinTxt.Text.Trim() != "")
					{
						if (stb_sCheckBox_bz4.SkinTxt.Text.Trim() == "有" || stb_sCheckBox_bz4.SkinTxt.Text.Trim() == "无")
						{
							if (stb_sCheckBox_bz4.SkinTxt.Text.Trim() == "有")
							{
								cmd = cmd + " and bz is not NULL";
							}
							if (stb_sCheckBox_bz4.SkinTxt.Text.Trim() == "无")
							{
								cmd = cmd + " and bz is NULL";
							}
						}
						else
						{
							string bz = "%" + stb_sCheckBox_bz4.SkinTxt.Text + "%";
							cmd = cmd + " and bz like @Bz";
							SpList.Add(new SqlParameter("Bz", bz));
						}
					}
				}
				if (sCheckBox_sj2.Checked)
				{
					dateTimeInput_start2.Text = dateTimeInput_start2.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_start2.Text;
					dateTimeInput_end2.Text = dateTimeInput_end2.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_end2.Text;
					cmd = cmd + " and sj BETWEEN @start AND @end";
					SpList.Add(new SqlParameter("start", dateTimeInput_start2.Text));
					SpList.Add(new SqlParameter("end", dateTimeInput_end2.Text));
				}
				SqlParameter[] param = SpList.ToArray();
				cmd += " ORDER BY gh,cz ASC ";
				DataTable dt = BLL.GetDataGridViewList(cmd,
				param).Tables[0];
				tb_tjresult.Text = BLL.GetResult(dt);
				dataGridView_cltj.DataSource = dt.DefaultView;
			}
			catch
			{
				MessageBox.Show("数据库获取数据发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region 主页
		private void pictureBox4_Paint(object sender, PaintEventArgs e)
		{
			PictureBox p = (PictureBox)sender;
			Pen pp = new Pen(Color.LightGray);
			e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + 193, e.ClipRectangle.Y + 164);
		}

		private void label36_Click(object sender, EventArgs e)
		{
			skinTabControl_main.SelectedIndex = 1;
		}

		private void label35_Click(object sender, EventArgs e)
		{
			skinTabControl_main.SelectedIndex = 2;
		}

		private void label38_Click(object sender, EventArgs e)
		{
			skinTabControl_main.SelectedIndex = 3;
		}

		private void FrmMain_SysBottomClick(object sender, CCWin.SkinControl.SysButtonEventArgs e)
		{
			FrmAbout about = new FrmAbout();
			about.ShowDialog();
		}

		#endregion

		#region 设置

		private void dateTimeInput_start3_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string cmd = @"SELECT id AS '编号' ,czmc '操作名称',czms '操作描述',czuser '操作人员',czsj '修改时间' from t_log";
				List<SqlParameter> SpList = new List<SqlParameter>();  //把参数处理成数组形式
				if (sCheckBox_sj5.Checked)
				{
					dateTimeInput_start3.Text = dateTimeInput_start3.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_start3.Text;
					dateTimeInput_end3.Text = dateTimeInput_end3.Text == "" ? DateTime.Now.ToShortDateString() : dateTimeInput_end3.Text;
					cmd = cmd + " where czsj BETWEEN @start AND @end";
					SpList.Add(new SqlParameter("start", dateTimeInput_start3.Text));
					SpList.Add(new SqlParameter("end", dateTimeInput_end3.Text));
				}
				SqlParameter[] param = SpList.ToArray();
				cmd += " ORDER BY czsj ASC ";
				DataTable dt = BLL.GetDataGridViewList(cmd,
				param).Tables[0];
				dataGridView_log.DataSource = dt.DefaultView;
			}
			catch
			{
				MessageBox.Show("数据库获取数据发生错误，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_Getuserlist_Click(object sender, EventArgs e)  //获取用户列表
		{
			sListBox_user.Items.Clear();
			if (sbtn_qxz.Text.Substring(3) != "超级管理员")
			{
				MessageBox.Show("您没有权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				DataTable dt = BLL.GetUserList();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					CCWin.SkinControl.SkinListBoxItem item = new CCWin.SkinControl.SkinListBoxItem();
					item.Text = dt.Rows[i]["uname"].ToString();
					if(item.Text!="admin")
					sListBox_user.Items.Add(item);
				}
			}
			catch
			{
				MessageBox.Show("获取失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sListBox_user_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (sListBox_user.SelectedItem != null)
				{
					DataRow dr = BLL.GetUserInfo(sListBox_user.SelectedItem.ToString());
					stb_uname2.SkinTxt.Text = dr["uname"].ToString();
					stb_upwd2.SkinTxt.Text = dr["upwd"].ToString();
					comboBox_qx2.SelectedIndex = Convert.ToInt32(dr["uqxz"]) - 1;
					comboBox_zt2.SelectedIndex = Convert.ToInt32(dr["uzt"]);
				}
			}
			catch
			{
				MessageBox.Show("获取失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_scuser_Click(object sender, EventArgs e)  //删除用户
		{
			if (sbtn_qxz.Text.Substring(3) != "超级管理员")
			{
				MessageBox.Show("您没有权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (sListBox_user.SelectedIndex==-1)
			{
				MessageBox.Show("你没有选择用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (sListBox_user.SelectedItem.ToString().Trim()==sbtn_name.Text.Substring(4).Trim())
			{
				MessageBox.Show("不能删除自己！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				DialogResult result = MessageBox.Show("你确定删除 " + sListBox_user.SelectedItem.ToString() + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
					return;
				if (BLL.Scuser(sListBox_user.SelectedItem.ToString()) == 1)
				{
					BLL.AddLog("删除用户", "删除用户： " + sListBox_user.SelectedItem.ToString(), sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				sbtn_Getuserlist_Click(this, new EventArgs());
			}
			catch
			{
				MessageBox.Show("出现错误，请检查是否重名，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_xguser_Click(object sender, EventArgs e) //修改用户
		{
			if (stb_uname2.SkinTxt.Text == "")
				return;
			try
			{
				DialogResult result = MessageBox.Show("你确定修改用户： " + stb_uname2.SkinTxt.Text + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
					return;
				if (BLL.XgUser(stb_uname2.SkinTxt.Text, (comboBox_qx2.SelectedIndex + 1).ToString(), comboBox_zt2.SelectedIndex.ToString()) == 1)
				{
					BLL.AddLog("修改用户", "修改用户： " + stb_uname2.SkinTxt.Text.Trim(), sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					stb_uname2.SkinTxt.Text = "";
					stb_upwd2.SkinTxt.Text = "";
					comboBox_qx2.Text = "";
					comboBox_zt2.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("出现错误，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void sbtn_addnewuser_Click(object sender, EventArgs e) //添加用户
		{
			if (sbtn_qxz.Text.Substring(3) != "超级管理员")
			{
				MessageBox.Show("您没有权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (stb_uname.SkinTxt.Text == "" || stb_upwd.SkinTxt.Text == ""||comboBox_qx.Text==""||comboBox_zt.Text=="")
			{
				MessageBox.Show("请填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (stb_uname.SkinTxt.Text.ToLower().Trim() == "admin" || stb_uname.SkinTxt.Text.ToLower().Trim() == "administrator")
			{
				MessageBox.Show("无法创建admin等关键字的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			try
			{
				DialogResult result = MessageBox.Show("你确定添加用户： " + stb_uname.SkinTxt.Text + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
					return;
				if (BLL.AddUser(stb_uname.SkinTxt.Text.Trim(), stb_upwd.SkinTxt.Text,
					comboBox_qx.Text == "工作人员" ? "2" : "1", comboBox_zt.Text == "启用" ? "1" : "0") == 1)
				{
					BLL.AddLog("新增用户", "新增用户： " + stb_uname.SkinTxt.Text.Trim(), sbtn_name.Text.Substring(4), sj.ToShortDateString());
					MessageBox.Show("新增用户" + stb_uname.SkinTxt.Text.Trim() + "成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					stb_uname.SkinTxt.Text = "";
					stb_upwd.SkinTxt.Text = "";
					comboBox_qx.Text = "";
					comboBox_zt.Text = "";
				}
			}
			catch
			{
				MessageBox.Show("创建失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

	}
}

