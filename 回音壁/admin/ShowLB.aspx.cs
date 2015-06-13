using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowLB : System.Web.UI.Page,IQueryJK
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("类别管理");

    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int lbid = int.Parse(lb.CommandArgument);
        DataRow dr = DB.GetRow("select * from t_lb where lbid=@lbid", new SqlParameter("lbid", lbid));
        txtlbmc.Text = dr["lbmc"].ToString();
        txtlbbz.Text = dr["lbbz"].ToString();
    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int lbid = int.Parse(lb.CommandArgument);
        try
        {
            DB.ExecuteSQL("delete from t_lb where lbid=@lbid", new SqlParameter("lbid", lbid));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败，此类别与信件有关联，无法删除！");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = "select * from t_lb where plbid<>-1 and (lbmc like '%{0}%' or lbbz like '%{0}%') order by lbid";
        e.Command.CommandText = string.Format(sql, q);
    }
    protected void btTJ_Click(object sender, EventArgs e)
    {
        string lbmc = txtlbmc.Text.Trim();
        string lbbz = txtlbbz.Text.Trim();
        bool bAdd = false;

        if (lbmc == "")
        {
            JScript.MsgBox(this, "请输入类别名称！");
            txtlbmc.Focus();
            return;
        }

        DataRow dr = BLL.GetTableRow("t_lb", "lbmc", lbmc);
        bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_lb", "lbid", null);

        dr["lbmc"] = lbmc;
        dr["lbbz"] = lbbz;
        dr["plbid"] = 1;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功！");
        else
            JScript.MsgBox(this, "修改成功！");

        txtlbmc.Text = "";
        txtlbbz.Text = "";
    }
}