using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public int TJCount(int lb)
    {
        int jbid = SXMGR.intSession["jbid"];
        string udm = SXMGR.strSession["udm"];
        string sql = "select count(*) from v_xj where (zjhfjb=@jbid or zjhfr=@udm)";
        if (lb == 1) sql += "and DATEDIFF(d,sj,getDate())>=3";
        return Convert.ToInt32(DB.ExecuteScalar(sql, new SqlParameter("jbid", jbid), new SqlParameter("udm", udm)));
    }

    public int TJCount2(int lb)
    {
        string udm = SXMGR.strSession["udm"];
        string sql = "";
        if (lb == 1)
        {
            sql = "select count(*) from v_xj a inner join t_hf b on a.hfid=b.hfid where b.zjfrom=@udm and DATEDIFF(d,b.hfsj,getDate())>=3";
        }
        else
        {
            sql = "select COUNT(*) from v_xj where ztdm<>'3' and xjid in (select xjid from t_hf where zjfrom=@udm)";
        }
        return Convert.ToInt32(DB.ExecuteScalar(sql, new SqlParameter("udm", udm)));
    }

    public string MakeInfo(int lb)
    {
        if (lb == 1)
        {
            int n = TJCount(1);
            int m = TJCount(2);
            if (n > 0)
            {
                return string.Format(@"
                <div class='alert_error'>
                <p> <img src='../images/icon_error.png' alt='delete' class='mid_align'/>有{0}封转处给您的信件您已经超过三天没有进行回复，请尽快回复。</p>
                </div>", n);
            }
            else if (m > 0)
            {
                return string.Format(@"
                <div class='alert_warning' style='margin-top:0;'>
                <p> <img src='../images/icon_warning.png' alt='success' class='mid_align'/> 您有{0}封由上级转处给您需要您及时处理的信件。请认真对待每一位来信的人。</p>
                </div>", m);
            }
            else
            {
                return @"
                <div class='alert_success'>
                <p> <img src='../images/icon_accept.png' alt='success' class='mid_align'/> 暂时没有转处给您的信件</p>
                </div>";
            }
        }
        else
        {
            int n = TJCount2(1);
            int m = TJCount2(2);
            if (n > 0)
            {
                return string.Format(@"
                  <div class='alert_error'>
                    <p> <img src='../images/icon_error.png' alt='delete' class='mid_align'/>有{0}封您转处给别人的信件已经超过三天没有进行回复，请尽快联系该工作人员。</p>
                  </div>", n);
            }
            else if (m > 0)
            {
                return string.Format(@"
                  <div class='alert_warning' style='margin-top:0'>
                    <p> <img src='../images/icon_warning.png' alt='success' class='mid_align'/> 有{0}封您转处给别人的信件正在处理中。</p>
                  </div>", m);
            }
            else
            {
                return @"
                  <div class='alert_success'>
                    <p> <img src='../images/icon_accept.png' alt='success' class='mid_align'/> 您转处给别人的信件已全部处复完毕。</p>
                  </div>";
            }
        }
    }
    protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string xrbz = SXMGR.strSession["xrbz"];
        if (xrbz == "2")
        {
            e.Command.CommandText = "select xjid,dm,bt,lxmc,xm,dw,sj,hits,xdbz from v_xj where ztdm='1' order by sj desc";
        }
        else if (xrbz == "1")
        {
            e.Command.CommandText = "select xjid,dm,bt,lxmc,xm,dw,sj,hits,xdbz from v_xj where ztdm='1' and gkbz='1' order by sj desc";
        }
        else
        {
            e.Command.CommandText = "select xjid,dm,bt,lxmc,xm,dw,sj,hits,xdbz from v_xj where ztdm='1' and 1=0 order by sj desc";
        }
    }
}