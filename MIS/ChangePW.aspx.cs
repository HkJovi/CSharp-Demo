using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePW : System.Web.UI.Page
{
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
    protected void btTJ_Click(object sender, EventArgs e)
    {
        string OldPwd = txtOldPwd.Text.Trim();
        string NewPwd = txtNewPwd.Text.Trim();
        string NewPwd2 = txtNewPwd2.Text.Trim();

        if (OldPwd == "" || NewPwd == "" || NewPwd != NewPwd2)
        {
            JScript.MsgBox(this, "请输入正确的密码，再提交！");
            return;
        }

        DataRow dr = BLL.GetTableRow("t_User", "uZH", SXMGR.strSession["uZH"]);
        if (dr == null)
        {
            Session.Clear();
            Session.Abandon();
            JScript.MsgBox(this, "当前用户并不存在，请重新登陆！");
            return;
        }

        if (dr["uPW"].ToString() != OldPwd)
        {
            JScript.MsgBox(this, "旧密码不正确！");
            return;
        }

        dr["uPW"] = NewPwd;

        BLL.UpdateSingleRow(dr);

        JScript.MsgBoxAndRedirect("修改密码成功！请牢记您的新密码！", "Default.aspx");
    }
}