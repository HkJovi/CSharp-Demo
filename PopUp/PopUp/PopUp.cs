using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PopUp
{
    public partial class PopUp : Form
    {
        private Point p;
        private int speed = 10;
        public PopUp()
        {
            InitializeComponent();           
        }

        private void PopUp_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, SystemInformation.WorkingArea.Height );
            p = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //此处进行窗口位移
            if(this.Location.Y-p.Y<speed)
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);  //位移修正
            if (p.Y < this.Location.Y)
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y - speed);  //弹出位移
            else
                timer1.Stop();
        }
    }
}
