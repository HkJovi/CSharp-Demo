using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MD5效验与加密
{
    public partial class Main : Form
    {
        bool uplower = false;   //文件MOD5效验
        bool uplower2 = false;  //字符串加密
        public Main()
        {
			Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private void btn_OpenFile_Click(object sender, EventArgs e)
        {    
            //实例化一个文件打开窗口
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\"; //初始目录
            openFileDialog.Filter = "All files (*.*)|*.*";//设置打开文件类型
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    TB_FilePath.Text = openFileDialog.FileName;//得到文件路径
					this.textBox1.Text = "";
					this.backgroundWorker1.Dispose();
                }
            }
        }

        public  string GetMD5File(string fileName)
        {
                FileStream file = new FileStream(fileName, FileMode.Open,FileAccess.Read,FileShare.Read);
                MD5 md5 = new MD5CryptoServiceProvider();  //实例化
                byte[] Arr_md5 = md5.ComputeHash(file);  //获取byte数据
            //进度条 
                for (int i = 25; i <= 75; i++)
                {
                    toolStripProgressBar.Value = i;
                }
                file.Close();
                
                 //将byte转换成字符串
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < Arr_md5.Length; i++)   
                {
                  sb.Append( Arr_md5[i].ToString("x2")); //ToString("X2") 为C#中的字符串格式控制符  X为十六进制  2为每次都是两位数
                }
                //foreach (byte byt in Arr_md5)
                //{

                //    sb.Append(String.Format("{0:X1}", byt));

                //} 
                //进度条 
                for (int i = 75; i <= 100; i++)
                {
                    toolStripProgressBar.Value = i;
                }

                return sb.ToString();
           
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            //进度条
            for (int i = 0; i <= 25; i++)
            {
                toolStripProgressBar.Value = i;
            }
            if (File.Exists(TB_FilePath.Text))
            {
				//textBox1.Text = GetMD5File(TB_FilePath.Text);
				if (textBox1.Text == "")
				this.backgroundWorker1.RunWorkerAsync();  //后台线程
				if (textBox1.Text != "" && (textBox1.Text == textBox2.Text || textBox1.Text.ToUpper() == textBox2.Text))
				{
					this.pictureBox.Image = Properties.Resources.dabing;
					this.lab_tip.ForeColor = Color.Black;
					this.lab_tip.Text = "一致！够拽！";
				}
				else
				if(textBox1.Text != "")
                {
                    this.pictureBox.Image = Properties.Resources.jingkong;
                    this.lab_tip.ForeColor = Color.Red;
                    this.lab_tip.Text = "不一致！！";
                }
            }
            else
            {
                MessageBox.Show("失败！请正确选择文件！");
                toolStripProgressBar.Value = 0;
            } 
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("复制成功");
            }
            else
                MessageBox.Show("无MD5值,请效验");
        }

        private void bt_strcopy_Click(object sender, EventArgs e)
        {
            if (tb_strMD5.Text != "")
            {
                Clipboard.SetText(tb_strMD5.Text);
                MessageBox.Show("复制成功");
            }
            else
                MessageBox.Show("无MD5值,检查输入");
        }

        private string GetMD5str(string oldStr)
        {
            //将输入转换为ASCII 字符编码
            ASCIIEncoding enc = new ASCIIEncoding();
            //将字符串转换为字节数组
            byte[] buffer = enc.GetBytes(oldStr);
            //创建MD5实例
            MD5 md5 = new MD5CryptoServiceProvider();
            //进行MD5加密
            byte[] hash = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            //拼装加密后的字符
            for (int i = 0; i < hash.Length; i++)
            {
                sb.AppendFormat("{0:x2}", hash[i]);
            }
            //输出加密后的字符串
            return sb.ToString();
        }

        private void bt_coring_Click(object sender, EventArgs e)
        {
            //进度条
            for (int i = 0; i <= 50; i++)
            {
                toolStripProgressBar.Value = i;
            }
            if (Rtb_str.Text != "")
            {
                this.tb_strMD5.Text = GetMD5str(this.Rtb_str.Text);
                for (int i = 50; i <= 100; i++)
                {
                    toolStripProgressBar.Value = i;
                }
            }
            else
            {
                MessageBox.Show("请输入加密内容！");
                toolStripProgressBar.Value = 0;
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (!uplower)
                {
                    uplower = true;
                    textBox1.Text = textBox1.Text.ToUpper();
                    btn_change.Text = "小";
                }
                else
                {
                    uplower = false;
                    textBox1.Text = textBox1.Text.ToLower();
                    btn_change.Text = "大";
                }
            }
        }

        private void btn_change2_Click(object sender, EventArgs e)
        {
            if (tb_strMD5.Text != "")
            {
                if (!uplower2)
                {
                    uplower2 = true;
                    tb_strMD5.Text = tb_strMD5.Text.ToUpper();
                    btn_change2.Text = "小";
                }
                else
                {
                    uplower2 = false;
                    tb_strMD5.Text = tb_strMD5.Text.ToLower();
                    btn_change2.Text = "大";
                }
            }
        }

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			textBox1.Text = GetMD5File(TB_FilePath.Text);
		}
    }
}
