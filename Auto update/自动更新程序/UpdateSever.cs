using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;


/*Demo*/
 //UpdateSever us = new UpdateSever("http://blog.sina.com.cn/s/blog_a62456420101vkbb.html", "Get", null, GetVersion, "2014年5月12日");
 //           us.Updating();
//Updating()更新检测 CanUseOld决定能否不更新使用

namespace 自动更新程序
{
    class UpdateSever:GetUpdateInfo
    {
        private string oldDt;
        IVersionInfo version;
        bool needUpdate ; //更新标志
        bool CanUseOld; //不更新能否使用

        public bool NeedUpdate
        {
            get { return needUpdate; }
        }

        public UpdateSever(string Url,string Method,string PostData,MyDeleGetInfo Callback,string OldDt,bool Canuseold):base(Url,Method,PostData,Callback)
        {
            oldDt = OldDt;
            CanUseOld = Canuseold;
            version = base.GetUpdateVersionInfo;
            TimeSpan ts=new TimeSpan (DateTime.Parse(version.LatestDt).Ticks-DateTime.Parse(oldDt).Ticks);
            if (ts.Ticks > 0)
                needUpdate = true;
            else
                needUpdate = false;
        }
        public void Updating()  //发现新版本进行更新,不更新可以选择是否不能使用
        {
            if (!needUpdate)
                return ;
            DialogResult result = MessageBox.Show("版本号：" + version.LatestVersion + "\n更新时间：" + version.LatestDt + "\n是否更新？", "发现新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start("IEXPLORE.EXE", version.LatestDownloadUrl);
                Process.GetCurrentProcess().Kill();
            }
            if (!CanUseOld)
            {
                MessageBox.Show("不更新不能使用！","请更新", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

    }
}
