using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Set : System.Web.UI.Page
{
    public string g_ggnr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("系统设置");
        if (!IsPostBack)
        {
            txtaddress.Text = BLL.GetDBSet("FromAddress");
            txtFromXM.Text = BLL.GetDBSet("FromName");
            txtPwd.Text = BLL.GetDBSet("FromPwd");
            txtSmtp.Text = BLL.GetDBSet("SmtpHost");

            txtggbt.Text = BLL.GetDBSet("ggbt");
            g_ggnr = BLL.GetDBSet("ggInfo");

            txtemailbt.Text = BLL.GetDBSet("EMailSubject");
            txtemailbody.Text = BLL.GetDBSet("EMailBody");
        }
        else
        {
            g_ggnr = Request.Form["ggnr"] ?? "";
        }
    }

    protected void btSmtp_Click(object sender, EventArgs e)
    {
        if (txtaddress.Text.Trim() == "" || txtFromXM.Text.Trim() == "" || txtPwd.Text.Trim() == "" || txtSmtp.Text.Trim() == "")
        {
            JScript.MsgBox(this, "信息不完整，请填写完整后再提交!");
            return;
        }

        BLL.SetDBSet("FromAddress", txtaddress.Text.Trim());
        BLL.SetDBSet("FromName", txtFromXM.Text.Trim());
        BLL.SetDBSet("FromPwd", txtPwd.Text.Trim());
        BLL.SetDBSet("SmtpHost", txtSmtp.Text.Trim());
        JScript.MsgBox(this, "保存SMTP信息成功！");
    }
    protected void btGG_Click(object sender, EventArgs e)
    {
        if (txtggbt.Text.Trim() == "" || g_ggnr.Trim() == "")
        {
            JScript.MsgBox(this, "信息不完整，请填写完整后再提交!");
            return;
        }

        BLL.SetDBSet("ggbt", txtggbt.Text.Trim());
        BLL.SetDBSet("ggInfo", g_ggnr);
        JScript.MsgBox(this, "保存公告信息成功");
    }
    protected void btemail_Click(object sender, EventArgs e)
    {
        if (txtemailbody.Text.Trim() == "" || txtemailbt.Text.Trim() == "")
        {
            JScript.MsgBox(this, "信息不完整，请填写完整后再提交!");
            return;
        }
        BLL.SetDBSet("EMailSubject", txtemailbt.Text.Trim());
        BLL.SetDBSet("EMailBody", txtemailbody.Text.Trim());
        JScript.MsgBox(this, "保存邮件信息成功！");
    }
}