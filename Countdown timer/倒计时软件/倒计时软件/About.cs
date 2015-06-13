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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        #region[窗口移动]
        //定义一个布尔变量，作为事件的开关。
        bool b = false;
        //定义一个‘点’的变量，接收鼠标的点位置。
        Point mousePonit;
        double temp;
        private void About_MouseDown(object sender, MouseEventArgs e)
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

        private void About_MouseUp(object sender, MouseEventArgs e)
        {
            b = false;
            this.Opacity = temp;
        }

        private void About_MouseMove(object sender, MouseEventArgs e)
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

        #region[关闭About]
        private void About_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
       

        private void About_close_MouseEnter(object sender, EventArgs e)
        {
            this.About_close.Image = Properties.Resources.Close2;
        }

        private void About_close_MouseLeave(object sender, EventArgs e)
        {
            this.About_close.Image = Properties.Resources.Close;
        }

        #endregion

        private void Btn_close1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void Btn_close1_MouseEnter(object sender, EventArgs e)
        {
            this.Btn_close1.Image = Properties.Resources.aboutclose2;
        }

        private void Btn_close1_MouseLeave(object sender, EventArgs e)
        {
            this.Btn_close1.Image = Properties.Resources.aboutclose;
        }

    }
}
