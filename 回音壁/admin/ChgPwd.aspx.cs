using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ChgPwd : System.Web.UI.Page
{
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

        DataRow dr = BLL.GetTableRow("t_user", "udm", SXMGR.strSession["udm"]);
        if (dr == null)
        {
            Session.Clear();
            Session.Abandon();
            JScript.MsgBox(this, "当前用户并不存在，请重新登陆！");
            return;
        }

        if (dr["pwd"].ToString() != OldPwd)
        {
            JScript.MsgBox(this, "旧密码不正确！");
            return;
        }

        dr["pwd"] = NewPwd;

        BLL.UpdateSingleRow(dr);

        JScript.MsgBoxAndRedirect("修改密码成功！请牢记您的新密码！", "Default.aspx");
    }
}