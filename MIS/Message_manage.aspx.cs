using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Message_manage : System.Web.UI.Page
{
    public int mesgcount
    {
        get
        {
            return Cls.CheckMesg();
        }
    }
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string xjid = lb.CommandArgument;
        try
        {
            DB.ExecuteSQL("delete from t_sjx where xjid=@xjid and jszh=@jszh", new SqlParameter("xjid", xjid), new SqlParameter("jszh", Session["uZH"].ToString()));
            GridView2.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败！");
        }
    }
}