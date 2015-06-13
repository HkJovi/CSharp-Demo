using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 禁止程序运行工具
{
    public partial class shutdown : Form
    {
        public shutdown()
        {
            InitializeComponent();
        }

        private void btn_no_Click(object sender, EventArgs e) //取消按钮
        {
            this.Close();
            this.Dispose();
        }

        private void tb_h_MouseClick(object sender, MouseEventArgs e)  //点击消失的效果
        {
            TextBox tb = (TextBox)sender;
            Mytime.SetEffict(tb,tb.Tag.ToString());
        }

        private void tb_h_Leave(object sender, EventArgs e) //若没有输入，还原提示框
        {
            TextBox tb = (TextBox)sender;
            Mytime.SetEffict(tb, tb.Tag.ToString());
        }

        private void btn_yes_Click(object sender, EventArgs e)   //确定按钮
        {
            int second;
            if (tb_h.Text == tb_h.Tag.ToString() || tb_m.Text == tb_m.Tag.ToString() || tb_s.Text == tb_s.Tag.ToString())
            {
                MessageBox.Show("请输入时间！");
                return;
            }
            if (Convert.ToInt32(tb_h.Text) >= 24 || Convert.ToInt32(tb_h.Text) < 0 || Convert.ToInt32(tb_m.Text) >= 60 || Convert.ToInt32(tb_m.Text) < 0 || Convert.ToInt32(tb_s.Text) >= 60 || Convert.ToInt32(tb_h.Text) < 0)
            {
                MessageBox.Show("输入时间错误！");
                return;
            }
            second = Convert.ToInt32(tb_h.Text) * 3600 + Convert.ToInt32(tb_m.Text) * 60 + Convert.ToInt32(tb_s.Text);
            System.Diagnostics.Process.Start("cmd.exe", "/cshutdown -s -t " + second.ToString());
            main m = (main)this.Owner;
            m.toolStripStatusLabel3.Text = Mytime.GetShutdownTime(Convert.ToInt32(tb_h.Text),Convert.ToInt32(tb_m.Text),Convert.ToInt32(tb_s.Text));
            this.Dispose();
            this.Close();
        }

        private void tb_h_KeyPress(object sender, KeyPressEventArgs e)  //让输入框只能输入数字
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
        }
    }
}
