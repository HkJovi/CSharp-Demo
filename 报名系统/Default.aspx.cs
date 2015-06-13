using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.imgCheckCode.ImageUrl = "checkCode.aspx";
    }

    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        
    if(Request.Cookies["checkCode"] == null)
   {
    lblMessage.Text = "您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。";
    lblMessage.Visible = true;
    return;
   }
   if(String.Compare(Request.Cookies["checkCode"].Value, txtCheckCode.Text, true) != 0)
   {
    lblMessage.Text = "验证码错误，请输入正确的验证码。";
    lblMessage.Visible = true;
    return;
   }

        string check = "select count(*) from wlbm where ID='" + ID.Text + "'";
        string str = "insert into wlbm values(@pName,@pStuID,@pID,@pProject,@pPhoneNum,@pCumpus)";
        SqlConnection con = new SqlConnection("server=(local);user id=sa;password=123456;initial catalog=wlbm");
        con.Open();
        SqlCommand Check = new SqlCommand(check, con);
        int count = (int)(Check.ExecuteScalar());
        if (count > 0)
        {
            con.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('不能重复报名');", true);
            Response.AddHeader ("Refresh","0");
        }
        else
        {
            SqlCommand cd = new SqlCommand(str, con);
            cd.Parameters.Add(new SqlParameter("pName", Name.Text));
            cd.Parameters.Add(new SqlParameter("pStuID", STUID.Text));
            cd.Parameters.Add(new SqlParameter("pID", ID.Text));
            cd.Parameters.Add(new SqlParameter("pProject", Project.Text));
            cd.Parameters.Add(new SqlParameter("pPhoneNum", PHONENUM.Text));
            cd.Parameters.Add(new SqlParameter("pCumpus", Cumpus.Text));
            cd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('提交成功!');", true);
            Response.AddHeader("Refresh", "0");
        } 
        
    }
    protected void Name_TextChanged(object sender, EventArgs e)
    {

    }
    protected void STUID_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ID_TextChanged(object sender, EventArgs e)
    {

    }
    protected void PHONENUM_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}