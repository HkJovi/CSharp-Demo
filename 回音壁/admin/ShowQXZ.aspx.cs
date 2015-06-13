using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowQXZ : System.Web.UI.Page,IQueryJK
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("权限组管理");
        if (!IsPostBack)
        {
            txtzqx.Items.Clear();
            DataTable dt = DB.GetTable("select * from t_qx order by qxpx");
            foreach (DataRow dr in dt.Rows)
            {
                string qx = dr["qxmc"].ToString().Trim();
                txtzqx.Items.Add(new ListItem(qx, qx));
            }
        }

    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int zid = int.Parse(lb.CommandArgument);
        DataRow dr = DB.GetRow("select * from t_qxz where zid=@zid", new SqlParameter("zid", zid));
        txtzmc.Text = dr["zmc"].ToString();

        string qx = dr["zqx"].ToString().Trim();
        for (int i = 0; i < txtzqx.Items.Count; i++)
        {
            if (qx.IndexOf(txtzqx.Items[i].Value) != -1) txtzqx.Items[i].Selected = true;
        }
    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int zid = int.Parse(lb.CommandArgument);
        try
        {
            DB.ExecuteSQL("delete from t_qxz where zid=@zid", new SqlParameter("zid", zid));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败，此权限组与用户有关联，无法删除！");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = "select * from t_qxz where zmc like '%{0}%' order by zid";
        e.Command.CommandText = string.Format(sql, q);
    }

    protected void btTJ_Click1(object sender, EventArgs e)
    {
        string zmc = txtzmc.Text.Trim();
        string zqx = ",";

        for (int i = 0; i < txtzqx.Items.Count; i++)
        {
            if (txtzqx.Items[i].Selected) zqx += txtzqx.Items[i].Value + ",";
        }

        if (zmc == "")
        {
            JScript.MsgBox(this, "请输入权限组名称！");
            return;
        }

        DataRow dr = BLL.GetTableRow("t_qxz", "zmc", zmc);
        bool bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_qxz", "zid", null);

        dr["zmc"] = zmc;
        dr["zqx"] = zqx;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功！");
        else
            JScript.MsgBox(this, "修改成功！");

        txtzmc.Text = "";
    }
}