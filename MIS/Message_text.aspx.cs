using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Message_new : System.Web.UI.Page
{
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    public static int xjid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            xjid = Convert.ToInt32(Request["xjid"]);
            this.Label1.Text = "来自"+Cls.GetMesgFSZH(xjid)+"的消息 |   "+Cls.GetMesgTime(xjid);
            Cls.Hasread(xjid, Session["uZH"].ToString());
        }
    }
    protected void ImageButton_DEL_Click(object sender, ImageClickEventArgs e)
    {
        string sql = "delete from t_sjx where xjid=@xjid and jszh=@jszh";
        try
        {
            DB.ExecuteSQL(sql, new SqlParameter("xjid", xjid), new SqlParameter("jszh", Session["uZH"].ToString()));
            JScript.Redirect("/Message_manage.aspx");
        }
        catch
        {
            JScript.MsgBox(this, "删除失败！");
        }
    }
    protected void ImageButton_HF_Click(object sender, ImageClickEventArgs e)
    {
        Session["HFtm"] = Cls.GetHFMessageTm(xjid);
        Session["HFzh"] = Cls.GetMesgFSZH(xjid);
        JScript.Redirect("/Message_HF.aspx");
    }
    protected void ImageButton_ZF_Click(object sender, ImageClickEventArgs e)
    {
        string sjzh = TB_zf_sjzh.Text.TrimEnd(',');
        if (sjzh == "" )
        {
            JScript.MsgBox(this, "请输入要转发的账号！");
            return;
        }
        if (sjzh == Session["uZH"].ToString())
        {
            JScript.MsgBox(this, "不能对自己发信息！");
            return;
        }
        if (Cls.CheckUser(sjzh) != -1)   //查询返回为-1
        {
            JScript.MsgBox(this, "发送失败！发送地址错误！");
            return;
        }
        if (Cls.ZhuanSendMessage(xjid,sjzh)> 0)
            JScript.MsgBoxAndRedirect("转发成功！", "/Message.aspx");
        else
            JScript.MsgBox(this, "转发失败！请联系管理员！");
    }
}