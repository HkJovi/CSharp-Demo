using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message_write : System.Web.UI.Page
{
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TB_tm.Text= Session["HFtm"].ToString();
            TB_addtress.Text = Session["HFzh"].ToString();
 
        }
    }
    protected void ImageButton_Send_Click(object sender, ImageClickEventArgs e)
    {
        string tm = TB_tm.Text.Trim();
        string dz = TB_addtress.Text.Trim();
        string nr = Request.Form["txtnr"];
        if (tm == "" || dz == "" || nr == "")
        {
            JScript.MsgBox(this, "请输入完整的信息！");
            return;
        }
        if (dz == Session["uZH"].ToString())
        {
            JScript.MsgBox(this, "不能对自己发信息！");
            return;
        }
        if (Cls.CheckUser(dz)!=-1)   //查询返回为-1
        {
            JScript.MsgBox(this, "发送失败！发送地址错误！");
            return;
        }
        if (Cls.SendMessage(tm, nr, Session["uZH"].ToString(), dz) > 0)
            JScript.MsgBoxAndRedirect("发送成功！", "/Message.aspx");
        else
            JScript.MsgBox(this, "发送失败！请联系管理员！");
    }
}