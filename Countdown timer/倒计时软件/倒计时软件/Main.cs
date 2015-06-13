using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 倒计时软件
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region [关闭]
        private void btn_close_Click(object sender, EventArgs e)
        {
            //关闭窗口
            this.Dispose();
            this.Close();
        }
        #endregion
        #region[最小化]
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;//设置窗体任务栏为隐藏

            this.WindowState = FormWindowState.Minimized;//最小化窗口
        }
        #endregion
        #region[关于]
        private void btn_about_Click(object sender, EventArgs e)
        {
            //关于窗口
            About ab = new About();
            ab.Show();
        }
        #endregion

        #region[窗口移动]
        //定义一个布尔变量，作为事件的开关。
        bool b = false;
        //定义一个‘点’的变量，接收鼠标的点位置。
        Point mousePonit;
        double temp;
        private void Main_MouseDown(object sender, MouseEventArgs e)
        { 
            //考虑是否鼠标左键按下，如果按下则开始做以下的事情。
            if (e.Button == MouseButtons.Left)
            {
                temp = this.Opacity;
                this.Opacity = 0.3;
                //给mousePonit定义为当前的鼠标位置坐标。
                mousePonit = new Point(-e.X, -e.Y);
                //设置变量b为布尔真值。
                b = true;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            b = false;
            this.Opacity = temp;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (b)
            {
                //定义一个‘点’变量，为组件的鼠标光标位置
                Point p = Control.MousePosition;
                //平移mousePonit为p变量。
                p.Offset(mousePonit);
                //控件的位置，为p位置。
                this.Location = p;
            }
        }

        private void Main_MouseEnter(object sender, EventArgs e)
        {
            //透明度trackbar 菜单消失
            this.traB_transparent.Visible = false;
        }
        #endregion

        #region[按钮美化]
        private void btn_close_MouseEnter(object sender, EventArgs e)
        {
            this.btn_close.Image = Properties.Resources.Close2;
            ToolTip close = new ToolTip();
            close.ShowAlways = true;
            close.SetToolTip(this.btn_close, "关闭");
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            this.btn_close.Image = Properties.Resources.Close;
        }

        private void btn_minimize_MouseEnter(object sender, EventArgs e)
        {
            this.btn_minimize.Image = Properties.Resources.minimize2;
            ToolTip minimize = new ToolTip();
            minimize.ShowAlways = true;
            minimize.SetToolTip(this.btn_minimize, "最小化");
        }

        private void btn_minimize_MouseLeave(object sender, EventArgs e)
        {
            this.btn_minimize.Image = Properties.Resources.minimize;
        }

        private void btn_about_MouseEnter(object sender, EventArgs e)
        {
            this.btn_about.Image = Properties.Resources.About2;
            ToolTip about = new ToolTip();
            about.ShowAlways = true;
            about.SetToolTip(this.btn_about, "关于");
        }

        private void btn_about_MouseLeave(object sender, EventArgs e)
        {
            this.btn_about.Image = Properties.Resources.About;
        }
        #endregion
        #region[置顶功能及美化]
        private void btn_top_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
                this.TopMost = false;
            else
                this.TopMost = true;
        }
        private void btn_top_MouseEnter(object sender, EventArgs e)
        {
            this.btn_top.Image = Properties.Resources.TOP;
            ToolTip top = new ToolTip();
            top.ShowAlways = true;
            if(this.TopMost == true)
            top.SetToolTip(this.btn_top, "取消置顶");
            else
            top.SetToolTip(this.btn_top, "置顶功能");
        }

        private void btn_top_MouseLeave(object sender, EventArgs e)
        {
            this.btn_top.Image = Properties.Resources.unTOP;
        }
        #endregion

        #region[现在时间]
        private void timer_nowtime_Tick(object sender, EventArgs e)
        {
            this.lab_Time.Text = DateTime.Now.ToString();
        }
        #endregion

        #region[透明度设定]
        private void btn_transparent_MouseEnter(object sender, EventArgs e)
        {
            this.btn_transparent.Image = Properties.Resources.transparent2;
            ToolTip transparent = new ToolTip();
            transparent.ShowAlways = true;
            transparent.SetToolTip(this.btn_transparent, "透明度设置");
            this.traB_transparent.Visible = true;
        }

        private void btn_transparent_MouseLeave(object sender, EventArgs e)
        {
            this.btn_transparent.Image = Properties.Resources.transparent;
        }
       

        private void btn_transparent_Click(object sender, EventArgs e)
        {
            this.traB_transparent.Visible = true;
        }

        private void traB_transparent_MouseEnter(object sender, EventArgs e)
        {
            this.traB_transparent.Visible = true;
        }

        private void traB_transparent_Scroll(object sender, EventArgs e)
        {
            
            //设定透明度
            this.Opacity =1- (float)(traB_transparent.Value)/10;
            //设定滑块刻度
            traB_transparent.Value = (int)((1 - this.Opacity) * 10);
        }
        #endregion

        #region[倒计时日期设定]
        //以下进行时间设定界面的处理
        #region[界面处理]
        private void btn_setday_MouseEnter(object sender, EventArgs e)
        {
            this.btn_setday.Image = Properties.Resources.day2;
            ToolTip setday = new ToolTip();
            setday.ShowAlways = true;
            setday.SetToolTip(this.btn_setday, "设定日期");
        }
       
        private void btn_setday_MouseLeave(object sender, EventArgs e)
        {
            this.btn_setday.Image = Properties.Resources.day;
        }

        private void btn_setday_MouseDown(object sender, MouseEventArgs e)
        {
            this.btn_setday.Image = Properties.Resources.day2;
        }

        private void btn_setday_MouseUp(object sender, MouseEventArgs e)
        {
            this.btn_setday.Image = Properties.Resources.day;
        }

        private void btn_setday_Click(object sender, EventArgs e)
        {
            if (this.TimePicker1.Visible) 
            this.TimePicker1.Visible = false;
            else
            this.TimePicker1.Visible = true;
        }

        private void TimePicker1_ValueChanged(object sender, EventArgs e)
        {
           // this.TimePicker1.Visible = false;  //此处测试不行，改变月期有闪退
            set_clock_setting();
            timer_days.Enabled = true;
        }
        #endregion
        #region[得到剩余秒数]
        public void set_clock_setting()
        {
            string st_systime = DateTime.Now.ToString();//获取系统时间为string格式
            st_endtime = TimePicker1.Text;//获取结束时间为string格式
            DateTime DT_sys_time = Convert.ToDateTime(st_systime);//获取当前系统时间
            DateTime DT_end_time = Convert.ToDateTime(st_endtime);//从Time picker1获取结束时间
            TimeSpan ts_systime = new TimeSpan(DT_sys_time.Ticks);//转化系统时间为可比较日期
            TimeSpan ts_endtime = new TimeSpan(DT_end_time.Ticks);//转化结束时间为可比较日期
            TimeSpan ts_leasttime = ts_endtime.Subtract(ts_systime).Duration();//结束时间减去开始时间的绝对值


            TimeSpan ts_leasttime2 = ts_endtime.Subtract(ts_systime);//获取日子是否为过去日子
            int TEMP_dd = Convert.ToInt32(ts_leasttime2.Days);//获取剩余时间的天数
            if (TEMP_dd < 0)
                this.lab_message.Text = "已过";
            else
                this.lab_message.Text = "还有";


            uint dd = Convert.ToUInt32(ts_leasttime.Days);//获取剩余时间的天数
            uint hh = Convert.ToUInt32(ts_leasttime.Hours);//获取剩余时间的小时
            uint mm = Convert.ToUInt32(ts_leasttime.Minutes);//获取剩余时间的分钟
            uint ss = Convert.ToUInt32(ts_leasttime.Seconds);//获取剩余时间的秒
            Remainder = dd * 24 * 3600 + hh * 3600 + mm * 60 + ss;//将时间转换为秒
        }
        #endregion
        #region[显示剩余天数] 

        //不足一天显示小时，已过功能

        private void timer_days_Tick(object sender, EventArgs e)
        {
            this.lab_endtime.Text = TimePicker1.Value.ToShortDateString();//获取结束时间显示出来
            //计算天数
            Remainder--;//剩余秒数递减
            Dayss = Remainder / 86400;//计算天数
            Hours = (Remainder - Dayss * 86400) / 3600;//计算小时
            //minute = (Remainder - Dayss * 86400 - Hours * 3600) / 60;//计算分钟
            //sencond = Remainder % 60;//计算秒
            if (Remainder < 0)
            {
                //未开始
            }
            if ( Dayss <= 999)
            {
                switch (Dayss % 10)
                {
                    case 0: this.Pic_Day3.Image = Properties.Resources._0;
                        break;
                    case 1: this.Pic_Day3.Image = Properties.Resources._1;
                        break;
                    case 2: this.Pic_Day3.Image = Properties.Resources._2;
                        break;
                    case 3: this.Pic_Day3.Image = Properties.Resources._3;
                        break;
                    case 4: this.Pic_Day3.Image = Properties.Resources._4;
                        break;
                    case 5: this.Pic_Day3.Image = Properties.Resources._5;
                        break;
                    case 6: this.Pic_Day3.Image = Properties.Resources._6;
                        break;
                    case 7: this.Pic_Day3.Image = Properties.Resources._7;
                        break;
                    case 8: this.Pic_Day3.Image = Properties.Resources._8;
                        break;
                    case 9: this.Pic_Day3.Image = Properties.Resources._9;
                        break;
                }
                switch ((Dayss/10) % 10)
                {
                    case 0: this.Pic_Day2.Image = Properties.Resources._0;
                        break;
                    case 1: this.Pic_Day2.Image = Properties.Resources._1;
                        break;
                    case 2: this.Pic_Day2.Image = Properties.Resources._2;
                        break;
                    case 3: this.Pic_Day2.Image = Properties.Resources._3;
                        break;
                    case 4: this.Pic_Day2.Image = Properties.Resources._4;
                        break;
                    case 5: this.Pic_Day2.Image = Properties.Resources._5;
                        break;
                    case 6: this.Pic_Day2.Image = Properties.Resources._6;
                        break;
                    case 7: this.Pic_Day2.Image = Properties.Resources._7;
                        break;
                    case 8: this.Pic_Day2.Image = Properties.Resources._8;
                        break;
                    case 9: this.Pic_Day2.Image = Properties.Resources._9;
                        break;
                }
                switch (Dayss/100)
                {
                    case 0: this.Pic_Day1.Image = Properties.Resources._0;
                        break;
                    case 1: this.Pic_Day1.Image = Properties.Resources._1;
                        break;
                    case 2: this.Pic_Day1.Image = Properties.Resources._2;
                        break;
                    case 3: this.Pic_Day1.Image = Properties.Resources._3;
                        break;
                    case 4: this.Pic_Day1.Image = Properties.Resources._4;
                        break;
                    case 5: this.Pic_Day1.Image = Properties.Resources._5;
                        break;
                    case 6: this.Pic_Day1.Image = Properties.Resources._6;
                        break;
                    case 7: this.Pic_Day1.Image = Properties.Resources._7;
                        break;
                    case 8: this.Pic_Day1.Image = Properties.Resources._8;
                        break;
                    case 9: this.Pic_Day1.Image = Properties.Resources._9;
                        break;
                }
            }
            else
            {
                this.Pic_Day3.Image = Properties.Resources._9;
                this.Pic_Day2.Image = Properties.Resources._9;
                this.Pic_Day1.Image = Properties.Resources._9;
            }
            //if (Remainder == 0)
            //{
            //    timer2.Enabled = false;
            //    lbl_show_endtime.Text += "---时间到。";
            //    notifyIcon1.Text += "---时间到。";
            //    btn_setyy.Text = "重新设置";
            //    lbl_systemtime.Visible = false;//不显示系统时间
            //    set_messageshowtext();
            //}
        }
        #endregion
        #endregion

        #region[菜单]
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //关于窗口
            About ab = new About();
            ab.Show();
        }
        private void 打开主程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;//最小化窗口
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;//最小化窗口
        }
        #endregion
    }
}
