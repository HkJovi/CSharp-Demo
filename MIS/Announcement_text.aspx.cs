using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Announcement_text : System.Web.UI.Page
{
    public static int ggid;
    public static int maxcount;
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
              ggid = Convert.ToInt32(Request["ggid"]);
              maxcount = Cls.GetMaxCountsGG();
              this.Label_time.Text = Cls.GetGGTime(ggid);
        }
    }
    protected void LinkButton_last_Click(object sender, EventArgs e)
    {
        if (ggid > 1)
        {
            SqlDataSource1.SelectCommand = "SELECT top 1 [tm], [gg] FROM [t_gg] WHERE ([ggid] < " + ggid + ") Order by [ggid] desc";
            this.Label_time.Text = Cls.GetGGTime(ggid);
            ggid -=1;          
        }
        else
            JScript.MsgBox(this ,"已经是第一篇了！");
    }
    protected void LinkButton_Next_Click(object sender, EventArgs e)
    {
        if (ggid < maxcount)
        {
            SqlDataSource1.SelectCommand = "SELECT top 1 [tm], [gg] FROM [t_gg] WHERE ([ggid] > " + ggid + ") Order by [ggid] asc";
            this.Label_time.Text = Cls.GetGGTime(ggid);
            ggid += 1;
        }
        else
            JScript.MsgBox(this, "已经是最后一篇了！");
    }
}