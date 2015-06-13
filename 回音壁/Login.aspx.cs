using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dl.Style["margin"] = "0 120px";
        }

    }
    protected void dl_Click(object sender, EventArgs e)
    {
        if (txtUid.Text.Trim() != "" && txtPwd.Text.Trim() != "")
        {
            HttpCookie ck = new HttpCookie("xj");

            ck["dm"] = txtUid.Text.Trim();
            ck["pwd"] = txtPwd.Text.Trim();

            Response.Cookies.Add(ck);

            Response.Redirect("ShowXJ.aspx", true);                       
        }
    }
}