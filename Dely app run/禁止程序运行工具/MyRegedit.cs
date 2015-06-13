using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;

namespace 禁止程序运行工具
{
    class MyRegedit
    {
        public MyRegedit()  //检查创建相关目录键值
        {
            string[] subkeynames;
            RegistryKey reg = Registry.CurrentUser;
            RegistryKey reg2 = Registry.CurrentUser;
            try
            {
                if(reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer\DisallowRun")== null)
                    reg = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer\DisallowRun");
                reg2 = reg2.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer",true);
                subkeynames = reg2.GetValueNames();
                foreach (string keyname in subkeynames)
                {
                    if (keyname == "DisallowRun")
                        return;
                }
                reg2.SetValue("DisallowRun", 1);
                foreach (Process p in Process.GetProcesses())
                    if (p.ProcessName.ToUpper().Equals("EXPLORER"))
                        p.Kill();
                reg.Close();
                reg2.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("获取注册表信息失败,请重试!"+ex.ToString());
            }
        }
    }

    class MyReg : MyRegedit
    {
        public void Add_DisallowApp(string SafeFilename)  //添加程序
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser;
                reg = reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer\DisallowRun", true);
                reg.SetValue(SafeFilename, SafeFilename, RegistryValueKind.String);
                reg.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("权限不够，请重试！");
            }
        }

        public void Cancel_DisallowApp(string SafeFilename)  //取消程序
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser;
                reg = reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\policies\Explorer\DisallowRun", true);
                reg.DeleteValue(SafeFilename);
                reg.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("权限不够，请重试！");
            }
        }
    }

    class Mytime
    {
        public static string GetTickCount()
        {
            int hm = System.Environment.TickCount;
            double h = hm / 3600000.0;
            double m = double.Parse("0." + h.ToString("F6").Substring(h.ToString().IndexOf(".") + 1)) * 60;
            double s = double.Parse("0." + m.ToString("F6").Substring(m.ToString().IndexOf(".") + 1)) * 60;
            string h1 = ((int)h).ToString();
            string m1 = ((int)m).ToString();
            string s1 = ((int)s).ToString();
            if ((int)h < 10) h1 = "0" + h1;
            if ((int)m < 10) m1 = "0" + m1;
            if ((int)s < 10) s1 = "0" + s1;
            string nowtime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
            string span = h1 + ":" + m1 + ":" + s1+"";
            return span.ToString();
        }

        public static void SetEffict(System.Windows.Forms.TextBox tb, string tip)  //这是tb框的效果
        {
            if (tb.Text ==tip)
                tb.Text = "";
            else
                if(tb.Text=="")
                 tb.Text = tip;
        }

        public static string GetShutdownTime(int H,int M,int S)
        {
            DateTime Nowtime = DateTime.Now;
            H += Nowtime.Hour;
            M += Nowtime.Minute;
            S += Nowtime.Second;
            if (S >= 60)
            {
                S -= 60;
                M += 1;
            }
            if (M >= 60)
            {
                M -= 60;
                H += 1;
            }
            if (H >= 24)
            {
                H -= 24;
                return "关机时间: "+H +":"+ M +":"+ S +" 点击取消";
            }
            else
                return "关机时间：" + H + ":" + M + ":" + S + " 点击取消";
        }

    }
}
