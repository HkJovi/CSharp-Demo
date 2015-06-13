using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowMB : System.Web.UI.Page,IQueryJK
{
    public string g_mbnr = "";

    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        g_mbnr = Request.Form["mbnr"] ?? "";
    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int mbid = int.Parse(lb.CommandArgument);
        DataRow dr = DB.GetRow("select * from t_mb where mbid=@mbid", new SqlParameter("mbid", mbid));
        txtbt.Text = dr["mbmc"].ToString();
        g_mbnr = dr["mbnr"].ToString();
    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int mbid = int.Parse(lb.CommandArgument);
        try
        {
            DB.ExecuteSQL("delete from t_mb where mbid=@mbid", new SqlParameter("mbid", mbid));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = "select * from t_mb where (udm='{0}')and(mbmc like '%{1}%') order by mbid";
        e.Command.CommandText = string.Format(sql, SXMGR.strSession["udm"], q);
    }

    protected void btTJ_Click(object sender, EventArgs e)
    {
        string mbmc = txtbt.Text.Trim();

        if (mbmc == "")
        {
            JScript.MsgBox(this, "请输入模版的名称！");
            txtbt.Focus();
            return;
        }

        if (g_mbnr.Trim() == "")
        {
            JScript.MsgBox(this, "请输入模版的内容！");
            return;
        }

        DataRow dr = BLL.GetTableRow("t_mb", "mbmc", mbmc);
        bool bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_mb", "mbid", null);

        dr["udm"] = SXMGR.strSession["udm"];
        dr["mbmc"] = mbmc;
        dr["mbnr"] = g_mbnr;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功！");
        else
            JScript.MsgBox(this, "修改成功！");

        txtbt.Text = "";
        g_mbnr = "";
    }
}