using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public int newmesgcount
    {
        get
        {
            return Cls.CheckNEW();
        }
    }
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Cls.CheckLogin();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label_zh1.Text = Session["uZH"].ToString();
            Label_zh2.Text = Session["uZH"].ToString();
        }
    }

    protected void LinkButton_out_Click(object sender, EventArgs e)
    {
        
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx", true);
    }
    protected void LinkButton_ChangePW_Click(object sender, EventArgs e)
    {
        JScript.Redirect("ChangePW.aspx");
    }
}
