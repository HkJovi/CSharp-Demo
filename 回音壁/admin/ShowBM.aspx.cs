using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowBM : System.Web.UI.Page,IQueryJK
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("部门管理");
    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int jbid = int.Parse(lb.CommandArgument);
        DataRow dr = DB.GetRow("select * from t_jb where jbid=@jbid", new SqlParameter("jbid", jbid));
        txtjbmc.Text = dr["jbmc"].ToString();
        txtpjbid.SelectedValue = dr["pjbid"].ToString();
    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int jbid = int.Parse(lb.CommandArgument);
        try
        {
            DB.ExecuteSQL("delete from t_jb where jbid=@jbid", new SqlParameter("jbid", jbid));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败，此部门与用户有关联，无法删除！");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = "select a.*,b.jbmc as pjbmc from t_jb a left join t_jb b on a.pjbid=b.jbid where (a.jbmc like '%{0}%' or b.jbmc like '%{0}%') order by a.pjbid,a.jbid";
        e.Command.CommandText = string.Format(sql, q);

        txtpjbid.Items.Clear();
        txtpjbid.Items.Add(new ListItem("--顶级部门--", "-1"));
        AdminCls.FillTreeList(txtpjbid);
    }
    protected void btTJ_Click1(object sender, EventArgs e)
    {
        string jbmc = txtjbmc.Text.Trim();
        int pjbid = int.Parse(txtpjbid.SelectedValue);

        if (jbmc == "")
        {
            JScript.MsgBox(this, "请输入部门名称！");
            txtjbmc.Focus();
            return;
        }

        DataRow dr = BLL.GetTableRow("t_jb", "jbmc", jbmc);
        bool bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_jb", "jbid", null);

        dr["jbmc"] = jbmc;
        dr["jbqx"] = "";
        dr["pjbid"] = pjbid;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功！");
        else
            JScript.MsgBox(this, "修改成功！");

        txtjbmc.Text = "";
    }
}