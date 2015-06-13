using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class NCREbm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           string str_con = "server=(local);user id=sa;password=123456;initial catalog=NCREbm";
        SqlConnection con = new SqlConnection(str_con);
        string check = "select count(*) from bmb where sfzh=@p_sfzh";
            con.Open();
          SqlCommand Check = new SqlCommand(check, con);
           Check.Parameters.Add(new SqlParameter("p_sfzh", Session["sfzh"]));
            Check.ExecuteNonQuery();
        int count = (int)(Check.ExecuteScalar());
        if (count > 0)
        {
            this.bmzt.Text = "已经报名";
            this.bmzt.ForeColor = System.Drawing.Color.Green;
            this.Button.Text = "修改报名表";
        }
        else
        {
            this.bmzt.Text = "未报名";
            this.bmzt.ForeColor = System.Drawing.Color.Red;
            this.Button.Text = "填写报名表";
        }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("bmb.aspx");
    }
}