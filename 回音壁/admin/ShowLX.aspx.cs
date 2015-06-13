using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowLX : System.Web.UI.Page,IQueryJK
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("类型管理");
    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string lxmc = lb.CommandArgument;
        DataRow dr = DB.GetRow("select * from t_lx where lxmc=@lxmc", new SqlParameter("lxmc", lxmc));
        txtlxmc.Text = dr["lxmc"].ToString();
        txtlximg.Text = dr["lximg"].ToString();
        txtlxpx.Text = dr["lxpx"].ToString();
    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string lxmc = lb.CommandArgument;
        try
        {
            DB.ExecuteSQL("delete from t_lx where lxmc=@lxmc", new SqlParameter("lxmc", lxmc));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败，此类型与信件有关联，无法删除！");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = "select * from t_lx where (lxmc like '%{0}%' or lximg like '%{0}%') order by lxpx";
        e.Command.CommandText = string.Format(sql, q);
    }
    protected void btTJ_Click1(object sender, EventArgs e)
    {
        string lxmc = txtlxmc.Text.Trim();
        string lximg = txtlximg.Text.Trim();
        int lxpx = 0;

        if (int.TryParse(txtlxpx.Text.Trim(), out lxpx) == false)
        {
            JScript.MsgBox(this, "排序只能是数字！");
            txtlxpx.Focus();
            return;
        }

        if (lxmc == "")
        {
            JScript.MsgBox(this, "类型名称不能为空！");
            txtlxmc.Focus();
            return;
        }

        DataRow dr = BLL.GetTableRow("t_lx", "lxmc", lxmc);
        bool bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_lx", "lxmc", null);

        if (bAdd) dr["lxmc"] = lxmc;
        dr["lximg"] = lximg;
        dr["lxpx"] = lxpx;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功!");
        else
            JScript.MsgBox(this, "修改成功！");

        txtlxmc.Text = "";
        txtlximg.Text = "";
        txtlxpx.Text = "";
    }
}