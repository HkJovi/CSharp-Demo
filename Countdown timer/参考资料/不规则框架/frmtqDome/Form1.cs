using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmtqDome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           String state= webView.Tag.ToString();
           if (state=="表状")
            {
                this.Width = 405;
                this.Height = 336;
                this.webView.Url = new Uri("http://weather.news.qq.com/24.htm");
                webView.Tag = "地图";
            }
           else
           {
               this.Width = 218;
               this.Height = 238;
               this.webView.Url = new Uri("http://weather.news.qq.com/inc/ss218.htm");
               webView.Tag = "表状";
           }
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = frmtqDome.Properties.Resources.btn_close_highlight;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = frmtqDome.Properties.Resources.btn_close_disable;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //定义一个布尔变量，作为事件的开关。
        bool b = false;
        //定义一个‘点’的变量，接收鼠标的点位置。
        Point mousePonit;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //考虑是否鼠标左键按下，如果按下则开始做以下的事情。
            if (e.Button == MouseButtons.Left)
            {
                this.Opacity = 0.3;
                //给mousePonit定义为当前的鼠标位置坐标。
                mousePonit = new Point(-e.X, -e.Y);
                //设置变量b为布尔真值。
                b = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            b = false;
            this.Opacity = 100;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
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
       

    }
}
