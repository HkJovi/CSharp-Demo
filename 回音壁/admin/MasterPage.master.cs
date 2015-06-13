using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        AdminCls.CheckLogin();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            q.Attributes["onkeypress"] = "return OnKeyPress(this)";

            plCtrl.Visible = XRBZ != 0;
        }
    }

    public int XRBZ
    {
        get {
            return SXMGR.intSession["xrbz"];
        }
    }

    public string GetMyXJCount()
    {
        string sql = "";

        string xrbz = SXMGR.strSession["xrbz"];
        int jbid = SXMGR.intSession["jbid"];
        string udm = SXMGR.strSession["udm"];

        if (xrbz == "2")    //超管
        {
            sql = "select count(*) from v_xj where zjhfjb=@jbid or zjhfr=@udm or ztdm='1' ";
        }
        else if (xrbz == "1")
        {
            sql = "select count(*) from v_xj where zjhfjb=@jbid or zjhfr=@udm or (ztdm='1' and gkbz='1')";
        }
        else
        {
            sql = "select count(*) from v_xj where zjhfjb=@jbid or zjhfr=@udm";
        }

        return DB.ExecuteScalar(sql, new SqlParameter("jbid", jbid), new SqlParameter("udm", udm)).ToString();
    }
    protected void lbExitLogin_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx", true);
    }

    public string TJCount(int lb)
    {
        string sql = "";

        if (lb == 1)
        {
            sql = "select count(*) from v_xj where hfid is null";
        }
        else if (lb == 2)
        {
            sql = "select count(*) from v_xj where ztdm='2'";
        }
        else if (lb == 3)
        {
            sql = "select COUNT(*) from v_xj a inner join t_hf b on a.hfid=b.hfid where DATEDIFF(d,b.hfsj,getdate())<=5 and a.ztdm='2'";
        }

        return DB.ExecuteScalar(sql).ToString();
    }

    protected void btQ_Click(object sender, EventArgs e)
    {
        string s = q.Text.Trim();
        try
        {
            if (s == "信件搜索") s = "";
            IQueryJK i = (IQueryJK)ContentPlaceHolder1.Page;
            i.QueryTextChange(BLL.GetSafeStr(s));
        }
        catch
        {
            Response.Redirect("Query.aspx?q=" + Server.UrlEncode(s), true);
        }        
    }
}
