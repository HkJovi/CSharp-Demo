using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 禁止程序运行工具
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            this.Opacity = 0.8;
        }

        private void button_qd_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
                MessageBox.Show("请输入密码！");
            else
                MessageBox.Show("密码错误！");
        }

        private void button_qx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_hide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
