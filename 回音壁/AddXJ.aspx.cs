using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class AddXJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void bttj_Click(object sender, EventArgs e)
    {
        string xm = txtxm.Text.Trim();
        string dw = txtdw.Text.Trim();
        string dh = txtdh.Text.Trim();
        string dz = "";
        string lx = txtlx.SelectedValue.Trim();
        string bt = txtbt.Text.Trim();
        string nr = Request.Form["txtnr"] ?? "";

        int lb = int.Parse(txtlb.SelectedValue.Trim());

        nr = Regex.Replace(nr, @"<\s*script\s*.*?<\s*/", "<script></", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        string chk = txtchk.Text.Trim().ToUpper();
        string fj = "";
        
        string dm = "";
        string pwd = "";

        txtchk.Text = "";


        string email = txtemail.Text.Trim();
        string gkbz = cbgkbz.Checked ? "1" : "0";
        

        if (xm == "")
        {
            JScript.MsgBox(this, "出错啦！请输入您的姓名或称呼！");
            txtxm.Focus();
            return;
        }

        if (dw == "")
        {
            JScript.MsgBox(this, "出错啦！请输入您所在的单位或专业班级！");
            txtdw.Focus();
            return;
        }

        if (email.IndexOf('@') <= 0 || email.IndexOf('@') >= email.Length)
        {
            JScript.MsgBox(this, "请输入您常用电子邮箱，此邮箱将用于接收信件的编码与密码！");
            txtemail.Focus();
            return;
        }

        if (lx == "")
        {
            JScript.MsgBox(this, "出错啦！还没有选择信件的类型！");
            return;
        }

        if (bt == "")
        {
            JScript.MsgBox(this, "出错啦！信件的标题不能为空！");
            txtbt.Focus();
            return;
        }

        if (nr == "")
        {
            JScript.MsgBox(this, "出错啦！信件内容不能为空！");
            return;            
        }

        if (chk == "")
        {
            JScript.MsgBox(this, "请输入验证码！");
            txtchk.Focus();
            return;
        }

        if (SXMGR.strSession["chkcode"].ToUpper() != chk)
        {
            JScript.MsgBox(this, "验证码输入错误！请重新输入！");
            txtchk.Focus();
            return;
        }

        DataRow dr = DB.GetRow("select xjid from v_xj where bt=@bt and xdbz='1' ", new SqlParameter("bt", bt));
        if( dr!=null )
        {
            JScript.MsgBoxAndRedirect("您好，您提出的问题已经有人提过并已选登，点击“确定”后将自动跳转到该信件！", "ShowXJ.aspx?xjid=" + dr["xjid"].ToString());
            return;
        }

        if (txtfj.HasFile)
        {
            string sAllowExt = BLL.GetDBSet("AllowUploadFileExts");
            string sExt = System.IO.Path.GetExtension(txtfj.FileName).ToLower();
            if (sAllowExt.IndexOf("|" + sExt + "|") == -1)
            {
                JScript.MsgBox(this, "对不起，暂不支持您上传的文件格式！");
                return;
            }

            if (txtfj.PostedFile.ContentLength > int.Parse(BLL.GetDBSet("AllowUploadFileMaxSize")))
            {
                JScript.MsgBox(this, "对不起，上传附件文件太大。");
                return;
            }

            fj = Guid.NewGuid().ToString("N") + sExt;
            try
            {
                txtfj.SaveAs(Server.MapPath("~/UserFiles/") + fj);
            }
            catch
            {
                JScript.MsgBox(this, "附件上传失败，请与管理员联系！");
                return;
            }
        }

        dr = UserCls.AddXJ(xm, dw, dz, dh, bt, nr, fj, lx, lb, gkbz, email, out dm, out pwd);

        HttpCookie ck = new HttpCookie("xj");
        ck["dm"] = dm;
        ck["pwd"] = pwd;
        ck["xm"] = xm;
        ck["email"] = email;
        Response.Cookies.Add(ck);

        string sUrl = BLL.GetSelfMainURL();
        string subject = BLL.ReplaceFromDB(BLL.GetDBSet("EMailSubject"), dr);

        string body = BLL.ReplaceFromDB(BLL.GetDBSet("EMailBody"), dr);
        body = body.Replace("{url}", sUrl);

        BLL.SendMail(email, subject, body);
        
        //成功，跳到另一页读取Cookies显示出代码和密码，提示用户牢记
        Response.Redirect("WriteSuccuess.aspx", true);
    }
}