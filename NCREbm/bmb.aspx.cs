using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Addbmb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //禁止dropdownlist重复加载
        if(!IsPostBack)
{


            string str_con = "server=(local);user id=sa;password=123456;initial catalog=NCREbm";
            SqlConnection con = new SqlConnection(str_con);
            //查看是否有报名信息

            string check = "select count(*) from bmb where sfzh=@p_sfzh";
            con.Open();
            SqlCommand Check = new SqlCommand(check, con);
            Check.Parameters.Add(new SqlParameter("p_sfzh", Session["sfzh"]));
            Check.ExecuteNonQuery();
            int count = (int)(Check.ExecuteScalar());
            if (count > 0)
            {
                string sql = "select * from bmb";
                SqlCommand comm = new SqlCommand(sql, con);
                DataSet ds = new DataSet();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    this.xh.Text = dr.GetString(dr.GetOrdinal("xsxh"));
                    this.xsxm.Text = dr.GetString(dr.GetOrdinal("xsxm"));
                    this.sfzh.Text = dr.GetString(dr.GetOrdinal("sfzh"));
                    this.xb.Text = dr.GetString(dr.GetOrdinal("xsxb"));
                    this.YDDH1.Text = dr.GetString(dr.GetOrdinal("xsdh"));
                    this.YDDH2.Text = dr.GetString(dr.GetOrdinal("xsdh"));
                    this.bkyz.Text = dr.GetString(dr.GetOrdinal("bkyz"));
                    this.mz.Text = dr.GetString(dr.GetOrdinal("mz"));
                    this.whcd.Text = dr.GetString(dr.GetOrdinal("whcd"));
                    this.zy.Text = dr.GetString(dr.GetOrdinal("zy"));
                    this.Button.Text = "保存修改";
                    SqlDataSource1.SelectCommand = @"select bmyzmc from yxbmyzb where yzdm in (select yzid from kscjxx where sftg=1 and sfzh=" + this.sfzh.Text + ") or yzdm ='any'";
                }
                dr.Close();
                con.Close();
            }
            else
            {
                string sql = "select * from xsxx";
                SqlCommand comm = new SqlCommand(sql, con);
                DataSet ds = new DataSet();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    this.xh.Text = dr.GetString(dr.GetOrdinal("xsxh"));
                    this.xsxm.Text = dr.GetString(dr.GetOrdinal("xsxm"));
                    this.sfzh.Text = dr.GetString(dr.GetOrdinal("sfzh"));
                    this.xb.Text = dr.GetString(dr.GetOrdinal("xsxb"));
                }
                SqlDataSource1.SelectCommand = @"select bmyzmc from yxbmyzb where yzdm in (select yzid from kscjxx where sftg=1 and sfzh=" + this.sfzh.Text + ") or yzdm ='any'";
                con.Close();
            }
        }
    }
    protected void Button_Click(object sender, EventArgs e)
    {

        string str1 = "insert into bmb values(@Pxsxm,@Psfzh,@Pxsxb,@Pxsdh,@Pbkyz,@Pmz,@Pwhcd,@Pzy,@Pxsxh)";
        string str2 = "update bmb set xsxm=@Pxsxm,xsdh=@Pxsdh,bkyz=@Pbkyz,mz=@Pmz,whcd=@Pwhcd,zy=@Pzy";
        string str_con = "server=(local);user id=sa;password=123456;initial catalog=NCREbm";
        SqlConnection con = new SqlConnection(str_con);
        if ((YDDH1.Text == YDDH2.Text) && (YDDH1.Text.Length == 11))
        {
            con.Open();

                SqlCommand cd1 = new SqlCommand(str1, con);
                SqlCommand cd2 = new SqlCommand(str2, con);
                //   提交报名表
                if (this.Button.Text != "保存修改")
                {
                    cd1.Parameters.Add(new SqlParameter("Pxsxm", this.xsxm.Text));
                    cd1.Parameters.Add(new SqlParameter("Psfzh", this.sfzh.Text));
                    cd1.Parameters.Add(new SqlParameter("Pxsxb", this.xb.Text));
                    cd1.Parameters.Add(new SqlParameter("Pxsdh", this.YDDH1.Text));
                    cd1.Parameters.Add(new SqlParameter("Pbkyz", this.bkyz.SelectedValue));
                    cd1.Parameters.Add(new SqlParameter("Pmz", this.mz.Text));
                    cd1.Parameters.Add(new SqlParameter("Pwhcd", this.whcd.Text));
                    cd1.Parameters.Add(new SqlParameter("Pzy", this.zy.Text));
                    cd1.Parameters.Add(new SqlParameter("Pxsxh", this.xh.Text));
                    cd1.ExecuteNonQuery();
                    con.Close();
                    JScript.MsgBox("报名成功！");
                    JScript.Redirect("bmxx.aspx");
                }

                //  以下修改报名表
                else
                {
                    cd2.Parameters.Add(new SqlParameter("Pxsxm", this.xsxm.Text));
                    cd2.Parameters.Add(new SqlParameter("Pxsdh", this.YDDH1.Text));
                    cd2.Parameters.Add(new SqlParameter("Pbkyz", this.bkyz.SelectedValue));
                    cd2.Parameters.Add(new SqlParameter("Pmz", this.mz.Text));
                    cd2.Parameters.Add(new SqlParameter("Pwhcd", this.whcd.Text));
                    cd2.Parameters.Add(new SqlParameter("Pzy", this.zy.Text));
                    cd2.ExecuteNonQuery();
                    con.Close();
                    JScript.MsgBox("修改成功！");
                    JScript.Redirect("bmxx.aspx");
                }
            }
        }
    }
