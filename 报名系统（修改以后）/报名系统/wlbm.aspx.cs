using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class wlbm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.imgCheckCode.ImageUrl = "checkCode.aspx";
        string check = "select count(*) from bmxx where ID='" + Session["ID"] + "'";
        SqlConnection con = new SqlConnection("server=(local);user id=sa;password=123456;initial catalog=wlbm");
        con.Open();
        SqlCommand Check = new SqlCommand(check, con);
        int count = (int)(Check.ExecuteScalar());
        if (count > 0)
        {
            //显示报名信息
            string sql = "select * from bmxx";
            SqlCommand comm = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                this.Imformation.Text = "姓名： " + dr.GetString(dr.GetOrdinal("Name")) + "<br>" + "  学生学号：  " + dr.GetString(dr.GetOrdinal("STUID")) + "<br>" + "  身份证号：  " + dr.GetString(dr.GetOrdinal("ID")) + "<br>" + "  报考科目：  " + dr.GetString(dr.GetOrdinal("Project")) + "<br>" + "  手机号码：  " + dr.GetString(dr.GetOrdinal("PhoneNum"));
            }
            dr.Close(); 
            con.Close();
            Button1.Enabled = false;
        }
        else
        {
            con.Close();
            Button2.Enabled = false;
        }
        
    }
    
    protected void PHONENUM_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //   以下提交数据
        string str = "insert into bmxx values(@pName,@pStuID,@pID,@pProject,@pPhoneNum,@pCumpus)";
        SqlConnection con = new SqlConnection("server=(local);user id=sa;password=123456;initial catalog=wlbm");
        con.Open();

            SqlCommand cd = new SqlCommand(str, con);
            cd.Parameters.Add(new SqlParameter("pName", Session["Name"]));
            cd.Parameters.Add(new SqlParameter("pStuID", Session["STUID"]));
            cd.Parameters.Add(new SqlParameter("pID", Session["ID"]));
            cd.Parameters.Add(new SqlParameter("pProject", Project.Text));
            cd.Parameters.Add(new SqlParameter("pPhoneNum", PHONENUM.Text));
            cd.Parameters.Add(new SqlParameter("pCumpus", Cumpus.Text));
            cd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('报名成功!');", true);
            Response.AddHeader("Refresh", "0");
        }
    protected void Button2_Click(object sender, EventArgs e)
{
     //   以下修改数据
    string str = "update bmxx set Project=@pProject,PhoneNum=@pPhoneNum,Cumpus=@pCumpus where ID =@pID ";
    SqlConnection con = new SqlConnection("server=(local);user id=sa;password=123456;initial catalog=wlbm");
    con.Open();
    SqlCommand cd = new SqlCommand(str, con);
    cd.Parameters.Add(new SqlParameter("pID", Session["ID"]));
    cd.Parameters.Add(new SqlParameter("pProject", Project.Text));
    cd.Parameters.Add(new SqlParameter("pPhoneNum", PHONENUM.Text));
    cd.Parameters.Add(new SqlParameter("pCumpus", Cumpus.Text));
    cd.ExecuteNonQuery();
    con.Close();
    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!');", true);
    Response.AddHeader("Refresh", "0");
}
}
