using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 自动更新程序
{
    public partial class Form1 : Form
    {
        class MyVersionInfo : IVersionInfo
        {
            private string version;//版本号
            public string LatestVersion
            {
                get { return version; }
            }

            private string downloadUrl;//版本下载地址
            public string LatestDownloadUrl
            {
                get { return downloadUrl; }
            }

            private string dt; //版本时间
            public string LatestDt
            {
                get { return dt; }
            }

            public MyVersionInfo(string version, string downloadUrl, string dt)
            {
                this.version = version;
                this.downloadUrl = downloadUrl;
                this.dt = dt;
            }
        }
        public IVersionInfo GetVersion(string respond)  //进行数据流的处理获取版本信息
        {
            Match temp ;
            try
            {
                temp = (new Regex(@"版本号:\[.*\]").Match(respond));
                string versionid = temp.Groups[0].Value.ToString();
                versionid = versionid.Substring(5, versionid.Length - 6);

                temp = (new Regex(@"下载地址:\[.*\]").Match(respond));
                string downUrl = temp.Groups[0].Value.ToString();
                downUrl = downUrl.Substring(6, downUrl.Length - 7);

                temp = (new Regex(@"更新日期:\[.*\]").Match(respond));
                string dt = temp.Groups[0].Value.ToString();
                dt = dt.Substring(6, dt.Length - 7);

                return new MyVersionInfo(versionid, downUrl, dt);
            }
            catch
            {
                MessageBox.Show("获取服务器信息失败，请检查网络连接！", "检查更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return null;
            } 
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetUpdateInfo info = new GetUpdateInfo("http://blog.sina.com.cn/s/blog_a62456420101vkbb.html", "Get", null, GetVersion); //GetVersion是处理数据返回版本的回调函数
            IVersionInfo versionInfo = info.GetUpdateVersionInfo;  //返回版本信息的方法
            richTextBox1.Text = versionInfo.LatestVersion + versionInfo.LatestDownloadUrl + versionInfo.LatestDt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateSever us = new UpdateSever("http://blog.sina.com.cn/s/blog_a62456420101vkbb.html", "Get", null, GetVersion, "2014年5月12日",true);
            us.Updating();
            MessageBox.Show("欢迎使用！");
        }
    }

}
