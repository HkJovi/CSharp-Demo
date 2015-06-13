using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie ck = Request.Cookies["mm"];  // 检查cookie里的 mm  是否有存储
            if (ck == null) return;

            TB_ZH.Text = ck["uzh"];
            //TB_MM.Text = ck["pwd"];
            CB_JZMM.Checked = true;
        }
    }
    protected void ImageButton_log_Click(object sender, ImageClickEventArgs e)
    {
        string ZH = TB_ZH.Text.Trim();
        string MM = TB_MM.Text;

        if (MM == "" && Request.Cookies["mm"] != null)   //空则调用Cookies
        {
            MM = Request.Cookies["mm"]["pwd"];
        }

        if (ZH == "" || MM == "")
        {
            JScript.MsgBox(this, "请输入账号密码！");
            return;
        }
       
        DataRow dr = DB.GetRow("select * from t_User where uZH=@ZH and uPW=@MM and uzt='1'",new SqlParameter("ZH", ZH), new SqlParameter("MM", MM));
        if (dr == null)
        {
            JScript.MsgBox(this, "用户名或密码错误！");
            return;
        }

        Session["uZH"] = ZH;
        Session["uJBZ"] = (int)dr["uJBZ"]; //保存权限代码
        Session["uID"] = dr["uID"].ToString();
        Session["usf"] = dr["usf"].ToString();
        BLL.Login_info(ZH);

        if (CB_JZMM.Checked)
        {
            HttpCookie ck = new HttpCookie("mm");
            ck["uzh"] = ZH;
            ck["mm"] = MM;
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