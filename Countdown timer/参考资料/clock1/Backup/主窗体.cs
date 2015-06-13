using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clock1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region [ToolStripMenu菜单]
            #region [ToolStripMenu菜单的退出]
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Dispose();//设置notifyIcon，否则图标还在
            this.Close();//关闭程序
        }
        #endregion

            #region[ToolStripMenuItem的设置菜单]
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;//恢复显示任务栏
            this.WindowState = FormWindowState.Normal;//窗体恢复为正常
        }
        #endregion
        #endregion

        #region [设置消息弹出程序]
        public void set_messageshowtext()
        {
            if (tm_set == "")
            {
                tm_set = "道哥说了，不要打我电话！";
            }
            this.notifyIcon1.ShowBalloonTip(1000, st_endtime, tm_set, ToolTipIcon.Info);//NotifyIcon.ShowBalloonTip方法:时间,标题,文本,图标;
        }
        #endregion

        #region [动态显示时间Timer的Ticker事件]
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbl_showTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region [应用按钮事件]
        private void btn_setyy_Click(object sender, EventArgs e)
        {
            if (btn_setyy.Text == "重新设置")
            {
                this.btn_setyy.Text = "开始倒计时";
                notifyIcon1.Text = "";//清空托盘提示
                timer2.Enabled = true;//设置定时器生效
                set_clock_setting();//启动闹钟设置程序
            }
            else
            {
                set_clock_setting();//启动闹钟设置程序
            }
        }
        #endregion

        #region [设置闹钟属性]
        public void set_clock_setting()
        {
            tm_set = this.ttx_set_message.Text.Trim().ToString();//获取文本赋给提示内容
            string st_systime = DateTime.Now.ToString();//获取系统时间为string格式
            st_endtime = dtp_input_time.Text;//获取结束时间为string格式
            DateTime DT_sys_time = Convert.ToDateTime(st_systime);//获取当前系统时间
            DateTime DT_end_time = Convert.ToDateTime(st_endtime);//从dtp_input_time获取结束时间
            TimeSpan ts_systime = new TimeSpan(DT_sys_time.Ticks);//转化系统时间为可比较日期
            TimeSpan ts_endtime = new TimeSpan(DT_end_time.Ticks);//转化结束时间为可比较日期
            TimeSpan ts_leasttime = ts_endtime.Subtract(ts_systime).Duration();//结束时间减去开始时间
            uint dd = Convert.ToUInt32(ts_leasttime.Days);//获取剩余时间的天数
            uint hh = Convert.ToUInt32(ts_leasttime.Hours);//获取剩余时间的小时
            uint mm = Convert.ToUInt32(ts_leasttime.Minutes);//获取剩余时间的分钟
            uint ss = Convert.ToUInt32(ts_leasttime.Seconds);//获取剩余时间的秒
            Remainder = dd * 24 * 3600 + hh * 3600 + mm * 60 + ss;//将时间转换为秒
            //this.lbl_settime.Text = ts_leasttime.ToString();//测试用
            //this.lbl_message.Text = st_endtime;//测试用
            this.lbl_show_endtime.Visible = true;//剩余时间倒计时显示
            this.lbl_systemtime.Visible = true;//系统当前时间
        }
        #endregion

        #region [设置闹钟时间Timer的Tick事件]
        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_systemtime.Text = "系统时间为："+DateTime.Now.ToLongTimeString();//只显示时间，不显示日期
            Remainder--;//剩余秒数递减
            Dayss = Remainder / 86400;//计算天数
            Hours = (Remainder-Dayss*86400) / 3600;//计算小时
            minute = (Remainder - Dayss * 86400 - Hours * 3600) / 60;//计算分钟
            sencond = Remainder%60;//计算秒
            if (Remainder <0)
            {
                lbl_show_endtime.Text = "倒计时未开始";
            }
            if (sencond < 10)
            {
                lbl_show_endtime.Text = "剩余时间：" + Dayss + "天" + Hours + "小时" + minute + "分0" + sencond + "秒";
                notifyIcon1.Text = "剩余时间：" + Dayss + "天" + Hours + "小时" + minute + "分0" + sencond + "秒";
            }
            else
            {
                lbl_show_endtime.Text = "剩余时间：" + Dayss + "天" + Hours + "小时" + minute + "分" + sencond + "秒";
                notifyIcon1.Text = "剩余时间：" + Dayss + "天" + Hours + "小时" + minute + "分" + sencond + "秒";
            }
            if (Remainder == 0)
            {
                timer2.Enabled = false;
                lbl_show_endtime.Text += "---时间到。";
                notifyIcon1.Text += "---时间到。";
                btn_setyy.Text = "重新设置";
                lbl_systemtime.Visible = false;//不显示系统时间
                set_messageshowtext();
            }
        }
        #endregion

        #region [隐藏窗体代码]
        public void function_hideForm()
        {
            this.ShowInTaskbar = false;//设置窗体任务栏为隐藏
            this.WindowState = FormWindowState.Minimized;//设置窗体为最小化
        }
        #endregion

        #region [隐藏按钮事件代码]
        private void btn_close_Click(object sender, EventArgs e)
        {
            function_hideForm();
        }
        #endregion
    }
}