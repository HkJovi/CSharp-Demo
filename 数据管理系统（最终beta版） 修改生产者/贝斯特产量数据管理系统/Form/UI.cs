using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Drawing;
using CCWin;
using Bll;
using System.Data;

namespace 贝斯特产量数据管理系统
{
	class UI  //界面类
	{
		public delegate DataTable Delegate_GetListBox(string keyword);  //声明委托
 
		public static void SetTime(CCWin.SkinControl.SkinButton sbtn)  //显示时间
		{
			sbtn.Text = "现在时间：" + DateTime.Now.ToLongTimeString().ToString() +"   "+ DateTime.Now.ToLongDateString();
		}

		public static void SetChinaDate(CCWin.SkinControl.SkinButton sbtn)  //显示农历
		{
			DateTime dt = DateTime.Now;
			sbtn.Text = "农历：" + ChinaDate.GetChinaDate(dt);
		}

		public static bool CheckSQLConnecting(CCWin.SkinControl.SkinLabel slb,CCWin.SkinControl.SkinPictureBox spic)  //检查连接状态
		{
			int flag = BLL.CheckSQLConnecting();
			if (flag == 0)
			{
				slb.Text = "与数据库连接发生异常，1分钟后重新连接！";
				slb.ForeColor = Color.Red;
				spic.Visible = false;
				return false;
			}
			else
			{
				slb.Text = "成功连接至数据库";
				slb.ForeColor = Color.Black;
				spic.Visible = true;
				return true;
			}
		}

		public static void RingToShowUnlockBox(CCWin.SkinControl.SkinButton sbtn_unlockTx, CCWin.SkinControl.SkinLabel slb,
											   CCWin.SkinControl.SkinButton sbtn_login, CCWin.SkinControl.SkinTextBox stb_pwd)   //解锁头像向上效果
		{
			int sbtn_y = sbtn_unlockTx.Location.Y;
			int sbtn_x = sbtn_unlockTx.Location.X;
			slb.Text = " 已锁定";
			if (sbtn_login.Visible == false)
			{
				sbtn_unlockTx.Location = new Point(sbtn_x, sbtn_y - 40);
				sbtn_login.Visible = true;
				stb_pwd.Visible = true;
				stb_pwd.SkinTxt.Visible = true;
			}
			else
			{
				sbtn_unlockTx.Location = new Point(sbtn_x, sbtn_y + 40);
				sbtn_login.Visible = false;
				stb_pwd.Visible = false;
				stb_pwd.SkinTxt.Visible = false;
				stb_pwd.SkinTxt.Text = "";
			}
		}

		public static void DownToShowUnlockBox(CCWin.SkinControl.SkinButton sbtn_unlockTx, CCWin.SkinControl.SkinLabel slb,
											   CCWin.SkinControl.SkinButton sbtn_login, CCWin.SkinControl.SkinTextBox stb_pwd)   //解锁头像向下效果
		{
			int sbtn_y = sbtn_unlockTx.Location.Y;
			int sbtn_x = sbtn_unlockTx.Location.X;
			slb.Text = " 已锁定";
			if (sbtn_login.Visible == true)
			{
				sbtn_unlockTx.Location = new Point(sbtn_x, sbtn_y + 40);
				sbtn_login.Visible = false;
				stb_pwd.Visible = false;
				stb_pwd.SkinTxt.Visible = false;
				stb_pwd.SkinTxt.Text = "";
			}
		}

		public static void ShowsczglListBox(CCWin.SkinControl.SkinListBox slistbox_sczgl ,string keyword)  //获取客户公司列表 显示在前台  
		{
			slistbox_sczgl.Items.Clear();
			DataTable dt=new DataTable();
			if (keyword == null)
				dt = BLL.GetsczglListBox();
			else
				dt = BLL.GetKeysczglListBox(keyword);
			try
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					CCWin.SkinControl.SkinListBoxItem item = new CCWin.SkinControl.SkinListBoxItem();
					item.Text = dt.Rows[i][0].ToString();
					slistbox_sczgl.Items.Add(item);
				}
				slistbox_sczgl.Enabled = true;
			}
			catch
			{
				slistbox_sczgl.Items[0].Text = "获取失败...请重试！";
			}
		}
		public static void ShowsczglListBox(CCWin.SkinControl.SkinListBox slistbox_sczgl)  //重载
		{
			ShowsczglListBox(slistbox_sczgl, null); 
		}

		public static void ShowCzListBox(CCWin.SkinControl.SkinListBox slistbox_cz, string keyword)  //获取材质列表 显示在前台  
		{
			slistbox_cz.Items.Clear();
			DataTable dt = new DataTable();
			if (keyword == null)
				dt = BLL.GetCzListBox();
			else
				dt = BLL.GetczListBox(keyword);
			try
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					CCWin.SkinControl.SkinListBoxItem item = new CCWin.SkinControl.SkinListBoxItem();
					item.Text = dt.Rows[i][0].ToString();
					slistbox_cz.Items.Add(item);
				}
				slistbox_cz.Enabled = true;
			}
			catch
			{
				slistbox_cz.Items[0].Text = "获取失败...请重试！";
			}
		}
		public static void ShowCzListBox(CCWin.SkinControl.SkinListBox slistbox_cz)  //重载
		{
			ShowCzListBox(slistbox_cz, null);
		}

		public static void ShowListBox(ListBox listbox, string keyword,Delegate_GetListBox deleglistbox)  //Textbox模糊输入，运用委托
		{
			listbox.Items.Clear();
			listbox.Items.Add(keyword);
			DataTable dt = new DataTable();
			dt = deleglistbox(keyword); //让方法参数化
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				listbox.Items.Add(dt.Rows[i][0]);
			}
			listbox.Visible = true;
			listbox.BringToFront();
			listbox.Size = new Size(182, 84);
			if (listbox.Items.Count > 1)
			listbox.SelectedIndex = 1;
			if (listbox.Items.Count == 1)  //当查询无结果自动隐藏
				listbox.Visible = false;
		}
	}

    class ChinaDate  //农历类
	{
		private static ChineseLunisolarCalendar china = new ChineseLunisolarCalendar();
		private static Hashtable gHoliday = new Hashtable();
		private static Hashtable nHoliday = new Hashtable();
		private static string[] JQ = { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
		private static int[] JQData = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };

		static ChinaDate()
		{
			//公历节日
			gHoliday.Add("0101", "元旦");
			gHoliday.Add("0214", "情人节");
			gHoliday.Add("0305", "雷锋日");
			gHoliday.Add("0308", "妇女节");
			gHoliday.Add("0312", "植树节");
			gHoliday.Add("0315", "消费者权益日");
			gHoliday.Add("0401", "愚人节");
			gHoliday.Add("0501", "劳动节");
			gHoliday.Add("0504", "青年节");
			gHoliday.Add("0601", "儿童节");
			gHoliday.Add("0701", "建党节");
			gHoliday.Add("0801", "建军节");
			gHoliday.Add("0910", "教师节");
			gHoliday.Add("1001", "国庆节");
			gHoliday.Add("1224", "平安夜");
			gHoliday.Add("1225", "圣诞节");

			//农历节日
			nHoliday.Add("0101", "春节");
			nHoliday.Add("0115", "元宵节");
			nHoliday.Add("0505", "端午节");
			nHoliday.Add("0815", "中秋节");
			nHoliday.Add("0909", "重阳节");
			nHoliday.Add("1208", "腊八节");
		}

		/// <summary>
		/// 获取农历
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetChinaDate(DateTime dt)
		{
			if (dt > china.MaxSupportedDateTime || dt < china.MinSupportedDateTime)
			{
				//日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日
				throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！", china.MinSupportedDateTime.ToString("yyyy-MM-dd"), china.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
			}
			string str = string.Format("{0} {1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));
			string strJQ = GetSolarTerm(dt);
			if (strJQ != "")
			{
				str += " (" + strJQ + ")";
			}
			string strHoliday = GetHoliday(dt);
			if (strHoliday != "")
			{
				str += " " + strHoliday;
			}
			string strChinaHoliday = GetChinaHoliday(dt);
			if (strChinaHoliday != "")
			{
				str += " " + strChinaHoliday;
			}

			return str;
		}

		/// <summary>
		/// 获取农历年份
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetYear(DateTime dt)
		{
			int yearIndex = china.GetSexagenaryYear(dt);
			string yearTG = " 甲乙丙丁戊己庚辛壬癸";
			string yearDZ = " 子丑寅卯辰巳午未申酉戌亥";
			string yearSX = " 鼠牛虎兔龙蛇马羊猴鸡狗猪";
			int year = china.GetYear(dt);
			int yTG = china.GetCelestialStem(yearIndex);
			int yDZ = china.GetTerrestrialBranch(yearIndex);

			string str = string.Format("[{1}]{2}{3}{0}", year, yearSX[yDZ], yearTG[yTG], yearDZ[yDZ]);
			return str;
		}

		/// <summary>
		/// 获取农历月份
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetMonth(DateTime dt)
		{
			int year = china.GetYear(dt);
			int iMonth = china.GetMonth(dt);
			int leapMonth = china.GetLeapMonth(year);
			bool isLeapMonth = iMonth == leapMonth;
			if (leapMonth != 0 && iMonth >= leapMonth)
			{
				iMonth--;
			}

			string szText = "正二三四五六七八九十";
			string strMonth = isLeapMonth ? "闰" : "";
			if (iMonth <= 10)
			{
				strMonth += szText.Substring(iMonth - 1, 1);
			}
			else if (iMonth == 11)
			{
				strMonth += "十一";
			}
			else
			{
				strMonth += "腊";
			}
			return strMonth + "月";
		}

		/// <summary>
		/// 获取农历日期
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetDay(DateTime dt)
		{
			int iDay = china.GetDayOfMonth(dt);
			string szText1 = "初十廿三";
			string szText2 = "一二三四五六七八九十";
			string strDay;
			if (iDay == 20)
			{
				strDay = "二十";
			}
			else if (iDay == 30)
			{
				strDay = "三十";
			}
			else
			{
				strDay = szText1.Substring((iDay - 1) / 10, 1);
				strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
			}
			return strDay;
		}

		/// <summary>
		/// 获取节气
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetSolarTerm(DateTime dt)
		{
			DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
			DateTime dtNew;
			double num;
			int y;
			string strReturn = "";

			y = dt.Year;
			for (int i = 1; i <= 24; i++)
			{
				num = 525948.76 * (y - 1900) + JQData[i - 1];
				dtNew = dtBase.AddMinutes(num);
				if (dtNew.DayOfYear == dt.DayOfYear)
				{
					strReturn = JQ[i - 1];
				}
			}

			return strReturn;
		}

		/// <summary>
		/// 获取公历节日
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetHoliday(DateTime dt)
		{
			string strReturn = "";
			object g = gHoliday[dt.Month.ToString("00") + dt.Day.ToString("00")];
			if (g != null)
			{
				strReturn = g.ToString();
			}

			return strReturn;
		}

		/// <summary>
		/// 获取农历节日
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetChinaHoliday(DateTime dt)
		{
			string strReturn = "";
			int year = china.GetYear(dt);
			int iMonth = china.GetMonth(dt);
			int leapMonth = china.GetLeapMonth(year);
			int iDay = china.GetDayOfMonth(dt);
			if (china.GetDayOfYear(dt) == china.GetDaysInYear(year))
			{
				strReturn = "除夕";
			}
			else if (leapMonth != iMonth)
			{
				if (leapMonth != 0 && iMonth >= leapMonth)
				{
					iMonth--;
				}
				object n = nHoliday[iMonth.ToString("00") + iDay.ToString("00")];
				if (n != null)
				{
					if (strReturn == "")
					{
						strReturn = n.ToString();
					}
					else
					{
						strReturn += " " + n.ToString();
					}
				}
			}

			return strReturn;
		}
	}  
}
