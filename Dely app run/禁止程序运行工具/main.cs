using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace 禁止程序运行工具
{
    public partial class main : Form
    {
        MyReg myregedits =new MyReg();

        public void GetChoosedApp()
        {
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer\DisallowRun");
            if(reg!=null)
            foreach (string item in reg.GetValueNames())
            {
                for (int i = 0; i < listBox_app.Items.Count; i++)
                    if (item == listBox_app.Items[i].ToString())
                        listBox_app.Items.Remove(item);
                listBox_choosedapp.Items.Add(item);
            }
        }

        public main()
        {
            login lg = new login();
            lg.ShowDialog();
            InitializeComponent();
            this.Opacity = 0.9;
            timer1.Start();
            GetChoosedApp();
        }

        private void btn_choosefile_Click(object sender, EventArgs e)  //选择程序
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "可执行文件|*.exe";
            ofd.InitialDirectory = @"\.";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TB_FilePosation.Text = ofd.FileName;
                TB_FileName.Text = ofd.SafeFileName;
                this.btn_AddApp.PerformClick();
            }
        }

        private void btn_AddApp_Click(object sender, EventArgs e)  //添加程序
        {
            if (TB_FileName.Text == "")
                return;
            for (int i = 0; i < listBox_app.Items.Count; i++)
            {
                if (listBox_app.Items[i].ToString().ToLower() == TB_FileName.Text.ToLower())
                {
                    this.listBox_app.SetSelected(i, true);
                    return;
                }
                else
                {
                    for (int n = 0; i < listBox_choosedapp.Items.Count; i++)
                        if (listBox_choosedapp.Items[n].ToString().ToLower() == TB_FileName.Text.ToLower())
                        {
                            this.listBox_choosedapp.SetSelected(i, true);
                            return;
                        }
                }
            }
            this.listBox_app.Items.Add(TB_FileName.Text);
        }

        private void btn_add_one_Click(object sender, EventArgs e) //单个添加
        {
            if (listBox_app.SelectedIndex != -1)
            {
                for(int i=0;i<listBox_choosedapp.Items.Count;i++)
                    if (this.listBox_app.SelectedItem.ToString().ToLower() == this.listBox_choosedapp.Items[i].ToString().ToLower())
                    { 
                        myregedits.Add_DisallowApp(listBox_app.SelectedItem.ToString());
                        this.listBox_app.Items.Remove(this.listBox_app.SelectedItem);
                        this.listBox_choosedapp.SetSelected(i, true);
                        return;
                    }
                this.listBox_choosedapp.Items.Add(this.listBox_app.SelectedItem.ToString());
                myregedits.Add_DisallowApp(listBox_app.SelectedItem.ToString());
                this.listBox_app.Items.Remove(this.listBox_app.SelectedItem);
            }
        }

        private void btn_cut_one_Click(object sender, EventArgs e)  //单个取消
        {
            if (listBox_choosedapp.SelectedIndex != -1)
            {
                for (int i = 0; i < listBox_app.Items.Count; i++)
                    if (this.listBox_choosedapp.SelectedItem.ToString().ToLower() == this.listBox_app.Items[i].ToString().ToLower())
                    {
                        myregedits.Cancel_DisallowApp(this.listBox_choosedapp.SelectedItem.ToString());
                        this.listBox_choosedapp.Items.Remove(this.listBox_choosedapp.SelectedItem);
                        this.listBox_app.SetSelected(i, true);
                        return;
                    }
                this.listBox_app.Items.Add(this.listBox_choosedapp.SelectedItem.ToString());
                myregedits.Cancel_DisallowApp(this.listBox_choosedapp.SelectedItem.ToString());
                this.listBox_choosedapp.Items.Remove(this.listBox_choosedapp.SelectedItem);
            }
        }

        private void btn_add_all_Click(object sender, EventArgs e)  //全部添加
        {
            int n;
            for (int i = 0; i < listBox_app.Items.Count;i++ )
            {
                this.listBox_app.SelectedIndex = i;
                for ( n = 0; n < listBox_choosedapp.Items.Count; n++)
                    if (this.listBox_app.SelectedItem.ToString().ToLower() == this.listBox_choosedapp.Items[n].ToString().ToLower())
                    {
                        break;
                    }
                if (n == listBox_choosedapp.Items.Count)
                {
                    this.listBox_choosedapp.Items.Add(this.listBox_app.SelectedItem.ToString());
                    myregedits.Add_DisallowApp(listBox_app.SelectedItem.ToString());
                }
            }
            listBox_app.Items.Clear();
        }

        private void btn_cut_all_Click(object sender, EventArgs e)  //全部取消
        {
            for (int i = 0; i < listBox_choosedapp.Items.Count; i++)
            {
                int n;
                this.listBox_choosedapp.SelectedIndex = i;
                for (n = 0; n < listBox_app.Items.Count; n++)
                    if (this.listBox_choosedapp.SelectedItem.ToString().ToLower() == this.listBox_app.Items[n].ToString().ToLower())
                        break;
                if (n == listBox_app.Items.Count)
                {
                    this.listBox_app.Items.Add(this.listBox_choosedapp.SelectedItem.ToString());
                    myregedits.Cancel_DisallowApp(this.listBox_choosedapp.SelectedItem.ToString());
                }
            }
            listBox_choosedapp.Items.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)  //获取启动时间
        {
            toolStripStatusLabel2.Text = Mytime.GetTickCount();
        }

        private void 定时关机ToolStripMenuItem_Click(object sender, EventArgs e)  //定时关机菜单
        {
            shutdown std = new shutdown();
            std.Owner = this;
            std.ShowDialog();
        }

        private void toolStripStatusLabel3_DoubleClick(object sender, EventArgs e)  //点击label取消关机
        {
            if (this.toolStripStatusLabel3.Text != "定时关机未启用！")
            {
                System.Diagnostics.Process.Start("cmd.exe", "/cshutdown -a");
                this.toolStripStatusLabel3.Text = "定时关机未启用！";
            }
            else
                return;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.ShowDialog();
        }

    }
}
