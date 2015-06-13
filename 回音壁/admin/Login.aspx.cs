using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dl.Style["margin-right"] = "5px";

            HttpCookie ck = Request.Cookies["mm"];
            if (ck == null) return;

            txtUid.Text = ck["udm"];
            //txtPwd.Text = ck["pwd"];
            cbJZMM.Checked = true;
        }

    }

    protected void dl_Click(object sender, EventArgs e)
    {
        string uid = txtUid.Text.Trim();
        string pwd = txtPwd.Text;

        if (pwd == "" && Request.Cookies["mm"]!=null)
        {
            pwd = Request.Cookies["mm"]["pwd"];
        }

        if (uid == "" || pwd == "") return;

        DataRow dr = DB.GetRow("select * from t_user a inner join t_jb b on a.jbid=b.jbid inner join t_qxz c on a.zid=c.zid where udm=@udm and pwd=@pwd and uzt='1'",
            new SqlParameter("udm", uid), new SqlParameter("pwd", pwd));
        if (dr == null)
        {
            JScript.MsgBox(this,"用户名或密码错误！");
            return;
        }

        Session["udm"] = uid;
        Session["jbid"] = (int)dr["jbid"];
        Session["umc"] = dr["umc"].ToString();
        Session["uxm"] = dr["uxm"].ToString();
        Session["zqx"] = dr["zqx"].ToString();
        Session["xrbz"] = dr["xrbz"].ToString();

        if (cbJZMM.Checked)
        {
            HttpCookie ck = new HttpCookie("mm");
            ck["udm"] = uid;
            ck["pwd"] = pwd;
            ck.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(ck);
        }
        else
        {
            HttpCookie ck = Request.Cookies["mm"];
            if (ck != null)
            {
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
        }

        Response.Redirect("Default.aspx", true);
    }

}