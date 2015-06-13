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
        // 保存个人信息
        Session["Name"] = Name.Text;
        Session["ID"] = ID.Text;
        Session["STUID"] = STUID.Text;
        //以下判断验证码
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
        string str = "insert into wlbm values(@pName,@pStuID,@pID)";
        SqlConnection con = new SqlConnection("server=(local);user id=sa;password=123456;initial catalog=wlbm");
        con.Open();
        SqlCommand Check = new SqlCommand(check, con);
        int count = (int)(Check.ExecuteScalar());
        if (count > 0)
        {
            con.Close();
            Response.Redirect("wlbm.aspx");
        }
        else
        {
            SqlCommand cd = new SqlCommand(str, con);
            cd.Parameters.Add(new SqlParameter("pName", Name.Text));
            cd.Parameters.Add(new SqlParameter("pStuID", STUID.Text));
            cd.Parameters.Add(new SqlParameter("pID", ID.Text));
            cd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("wlbm.aspx");
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
   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}