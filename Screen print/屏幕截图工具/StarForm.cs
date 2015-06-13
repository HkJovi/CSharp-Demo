using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 屏幕截图工具
{
    public partial class StarForm : Form
    {
        static int i=1;
        public StarForm()
        {
            InitializeComponent();
            Counter.Start();
        }

        private void Counter_Tick(object sender, EventArgs e)
        {
            try
            {
                if (i == 1)
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_1;
                if (i == 2)
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_2;
                if (i == 3)
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_3;
                if (i == 4)
                {
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_4;
                    label.Text = "正在启动主界面";
                }
                if (i == 5)
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_5;
                if (i == 6)
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_6;
                if (i == 7)
                {
                    StarForm.ActiveForm.BackgroundImage = Properties.Resources.UI_7;
                    label.Text = "启动成功";
                }
                if (i == 8)
                {
                    this.Hide();
                    Main main = new Main();
                    main.Show();
                    Counter.Stop();
                }
                i++;
            }
            catch
            {
                Counter.Stop();
                MessageBox.Show("注册失败,请重启程序！");
                this.Dispose();
                Application.Exit();
            }
        }
    }
}
