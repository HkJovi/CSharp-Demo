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
        
    }
    protected void OK_Click(object sender, EventArgs e)
    {
        Session["xsxm"] = xm.Text.Trim();
        Session["sfzh"] = sfzh.Text.Trim();
        string str_con = "server=(local);user id=sa;password=123456;initial catalog=NCREbm";
        SqlConnection con = new SqlConnection(str_con);
        string check = "select count(*) from xsxx where sfzh='" +sfzh.Text + "'and xsxm='"+xm.Text+"'";
        if (this.yzm.Text.Trim() == Session["CheckCode"].ToString() || this.yzm.Text.ToUpper().Trim() == Session["CheckCode"].ToString())
        {
            con.Open();
            SqlCommand Check = new SqlCommand(check, con);
            int count = (int)(Check.ExecuteScalar());
            if (count > 0)
            {
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('登陆成功');", true);
                Response.Redirect("bmxx.aspx");
            }
            else
            {
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无此学生信息！');", true);
            }
        }
        else
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('验证码输入错误');", true);

    }
}