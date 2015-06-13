using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace 一元二次方程计算器
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            double a, b, c, det;
            if (TB_a.Text == "" || TB_b.Text == "" || TB_c.Text == "")
                return;
            if (Regex.IsMatch(TB_a.Text, @"^[+-]?(?!0\d)\d+(\.[0-9]+)?$") && Regex.IsMatch(TB_b.Text, @"^[+-]?(?!0\d)\d+(\.[0-9]+)?$") && Regex.IsMatch(TB_c.Text, @"^[+-]?(?!0\d)\d+(\.[0-9]+)?$"))
            {
                a = double.Parse(TB_a.Text);
                b = double.Parse(TB_b.Text);
                c = double.Parse(TB_c.Text);
            }
            else
            {
                MessageBox.Show("输入不规范！ 请重新输入！");
                return;
            }
            if (a == 0 && b == 0)
                return;
            if (a == 0)
            {
                label_x1.Text = (-c / b).ToString("F04");
                label_x2.Text = "只有一个解！";
                return;
            }
            if (a != 0)
            {
                det=b*b-4*a*c;
                if (det > 0)
                {
                    label_x1.Text = ((-b + Math.Sqrt(det)) / (2 * a)).ToString("F08");
                    label_x2.Text = ((-b - Math.Sqrt(det)) / (2 * a)).ToString("F08");
                    return;
                }
                if (det < 0)
                {
                    label_x1.Text = (-b / (2 * a)).ToString("F08") + " + " + (Math.Sqrt(-det) / (2 * a)).ToString("F08") + "i";
                    label_x2.Text = (-b / (2 * a)).ToString("F08") + " - " + (Math.Sqrt(-det) / (2 * a)).ToString("F08") + "i";
                    return;
                }
                if (det == 0)
                {
                    label_x1.Text = ((-b + Math.Sqrt(det)) / (2 * a)).ToString("F08");
                    label_x2.Text = "只有一个解！";
                    return;
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            TB_a.Text = "";
            TB_b.Text = "";
            TB_c.Text = "";
            label_x1.Text = "";
            label_x2.Text = "";
        }
    }
}
