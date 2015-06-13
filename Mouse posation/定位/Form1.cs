using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 定位
{
    public partial class Point : Form
    {
        public Point()
        {
            InitializeComponent();
        }

        private void Point_MouseMove(object sender, MouseEventArgs e)
        {
            this.Point1.Text = "相对坐标  X：" + e.X + "    Y：" + e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Point2.Text ="绝对坐标  X：" + MousePosition.X.ToString() + "    Y：" + MousePosition.Y;
        }

        private void Point_Load(object sender, EventArgs e)
        {

        }
    }
}
