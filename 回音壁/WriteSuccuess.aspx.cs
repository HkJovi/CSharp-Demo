using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WriteSuccuess : System.Web.UI.Page
{
    //接收Cookie[xj]并显示出来

    public string g_xm = "";
    public string g_dm = "";
    public string g_pwd = "";
    public string g_email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie ck = Request.Cookies["xj"];
        if (ck == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        g_xm = BLL.HE(ck["xm"]);
        g_dm = BLL.HE(ck["dm"]);
        g_pwd = BLL.HE(ck["pwd"]);
        g_email = BLL.HE(ck["email"]);
    }
}