using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace 屏幕截图工具
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Opacity = 0.8;
            this.timer_hide.Tag = "1"; //是否第一次启动，第一次启动隐藏主界面
            this.timer_hide.Start();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Common.UnregisterHotKey(Handle, 0xAAAA);
            this.Dispose();
            this.Close();
            Application.Exit();
            Application.ExitThread();
        }

        private void bt_catch_Click(object sender, EventArgs e)
        {
            string name = Common.GetImgName();
            this.Hide();
            //得到屏幕的DC
            IntPtr dc1 = Common.GetDC(IntPtr.Zero); //MSDN中说当传入指针为空时返回整个屏幕的设备驱动器句柄
            //创建一个以当前屏幕为模板的图象
            Graphics g1 = Graphics.FromHdc(dc1);
            //创建以屏幕大小为标准的位图 
            Image MyImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height, g1);
            //创建一个以当前位图为模板的图象
            Graphics g2 = Graphics.FromImage(MyImage);
            //得到Bitmap的DC 
            IntPtr dc2 = g2.GetHdc();
            //调用此API函数，实现屏幕捕获
            Common.BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc1, 0, 0, 13369376);
            //释放掉屏幕的DC
            Common.ReleaseDC(IntPtr.Zero, dc1); 
            //释放掉Bitmap的DC 
            g2.ReleaseHdc(dc2);
            //以png文件格式来保存
            MyImage.Save(name, ImageFormat.Png);
            //保存到剪贴板
            Clipboard.Clear();
            Clipboard.SetImage(MyImage);
            this.notifyIcon1.ShowBalloonTip(100, "Tip", "当前屏幕已经保存在同目录里！" + name + "  按Ctrl+W 进行切图", ToolTipIcon.Info);
            Common.name = name;
            this.Show();
        }

        private void bt_hide_Click(object sender, EventArgs e)
        {
            string tipText = "我在这里！截图快捷键：Ctrl+Q";
            this.notifyIcon1.ShowBalloonTip(1000, "Tip", tipText, ToolTipIcon.Info);
            this.Hide();
            if(this.timer_hide.Tag.ToString()=="1")
            { 
                this.timer_hide.Stop();
                this.timer_hide.Tag ="";
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

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

        #endregion

        #region 快捷键
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;            //如果m.Msg的值为0x0312那么表示用户按下了热键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 0xAAAA:
                            OnHideTaskHotKeyQ();
                            break;
                        case 0xAAAB:
                            OnHideTaskHotKeyW();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        //热键响应函数 截图
        private bool OnHideTaskHotKeyQ()
        {
            string name = Common.GetImgName();
            this.Hide();
            //得到屏幕的DC
            IntPtr dc1 = Common.GetDC(IntPtr.Zero); //MSDN中说当传入指针为空时返回整个屏幕的设备驱动器句柄
            //创建一个以当前屏幕为模板的图象
            Graphics g1 = Graphics.FromHdc(dc1);
            //创建以屏幕大小为标准的位图 
            Image MyImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);
            //创建一个以当前位图为模板的图象
            Graphics g2 = Graphics.FromImage(MyImage);
            //得到Bitmap的DC 
            IntPtr dc2 = g2.GetHdc();
            //调用此API函数，实现屏幕捕获
            Common.BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc1, 0, 0, 13369376);
            //释放掉屏幕的DC
            Common.ReleaseDC(IntPtr.Zero, dc1);
            //释放掉Bitmap的DC 
            g2.ReleaseHdc(dc2);
            //以PNG文件格式来保存
            MyImage.Save(name, ImageFormat.Png);
            //保存到剪贴板
            Clipboard.Clear();
            Clipboard.SetImage(MyImage);
            this.notifyIcon1.ShowBalloonTip(100, "Tip", "当前屏幕已经保存在同目录里！" + name + "  按Ctrl+W 进行切图", ToolTipIcon.Info);
            return true;
        }
        //热键响应函数 呼出处理框
        private bool OnHideTaskHotKeyW()
        {
            CutImageTool cut = new CutImageTool();
            cut.Show();
            return true;
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            Keys m_HotKeyQ = Keys.Q;
            Common.UnregisterHotKey(Handle, 0xAAAA);
            Common.RegisterHotKey(Handle, 0xAAAA, Common.KeyModifiers.Ctrl, m_HotKeyQ);
            Keys m_HotKeyW = Keys.W;
            Common.UnregisterHotKey(Handle, 0xAAAB);
            Common.RegisterHotKey(Handle, 0xAAAB, Common.KeyModifiers.Ctrl, m_HotKeyW);
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            string path = Application.StartupPath;   //获取当前文件的路径
            System.Diagnostics.Process.Start("explorer.exe",path);
        }

        private void bt_CutImageTool_Click(object sender, EventArgs e)
        {
            CutImageTool cut = new CutImageTool();
            cut.Show();
        }

    }
}
