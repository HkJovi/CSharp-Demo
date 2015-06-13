using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace clock1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm fm = new MainForm();
            fm.WindowState = FormWindowState.Minimized;//设置为最小化
            fm.ShowInTaskbar = false;
            Application.Run(fm);
        }
    }
}