using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ShowUser : System.Web.UI.Page,IQueryJK
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCls.CheckQX("用户管理");
        if (!IsPostBack)
        {
            txtjbid.Items.Clear();
            AdminCls.FillTreeList(txtjbid);
        }

    }
    protected void btChg_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string udm = lb.CommandArgument;
        DataRow dr = DB.GetRow("select * from t_user where udm=@udm", new SqlParameter("udm", udm));
        txtudm.Text = dr["udm"].ToString();
        txtxm.Text = dr["uxm"].ToString();
        txtumc.Text = dr["umc"].ToString();
        txtjbid.SelectedValue = dr["jbid"].ToString();
        txtzid.SelectedValue = dr["zid"].ToString();
        txtupx.Text = dr["upx"].ToString();
        txtuzt.SelectedValue = dr["uzt"].ToString();
        txtxrbz.SelectedValue = dr["xrbz"].ToString();
        txtubz.Text = dr["ubz"].ToString();

    }
    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string udm = lb.CommandArgument;
        try
        {
            DB.ExecuteSQL("delete from t_user where udm=@udm", new SqlParameter("udm", udm));
            GridView1.DataBind();
        }
        catch
        {
            JScript.MsgBox(this, "删除失败，此用户与信件有关联，无法删除！");
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string sql = @"select * from t_user a inner join t_jb b on a.jbid=b.jbid inner join t_qxz c on a.zid=c.zid where (
a.udm like '%{0}%' or
b.jbmc like '%{0}%' or
a.uxm like '%{0}%' or
a.umc like '%{0}%' or
c.zmc like '%{0}%'
) order by a.upx";
        e.Command.CommandText = string.Format(sql, q);
    }
    protected void btTJ_Click1(object sender, EventArgs e)
    {
        string udm = txtudm.Text.Trim();
        string uxm = txtxm.Text.Trim();
        string pwd = txtpwd.Text.Trim();
        string umc = txtumc.Text.Trim();
        string ubz = txtubz.Text.Trim();
        string uzt = txtuzt.SelectedValue ?? "";
        string xrbz = txtxrbz.SelectedValue ?? "";

        int jbid = 0;
        int zid = 0;
        int upx = 0;

        if (udm == "" || uxm == "" || umc == "" || uzt == "" || xrbz == "")
        {
            JScript.MsgBox(this, "信息输入不完整，请重新输入。");
            return;
        }

        if (int.TryParse(txtjbid.SelectedValue, out jbid) == false)
        {
            JScript.MsgBox(this, "请选择用户所在的部门！");
            return;
        }
        if (int.TryParse(txtzid.SelectedValue, out zid) == false)
        {
            JScript.MsgBox(this, "请选择用户所在的权限组！");
            return;
        }
        if (int.TryParse(txtupx.Text.Trim(), out upx) == false)
        {
            JScript.MsgBox(this, "请输入用户的排序号！");
            return;
        }

        DataRow dr = BLL.GetTableRow("t_user", "udm", udm);
        bool bAdd = dr == null;
        if (bAdd) dr = BLL.GetTableRow("t_user", "udm", null);

        if (bAdd && pwd == "")
        {
            JScript.MsgBox(this, "请输入用户的登陆密码！");
            return;
        }

        dr["udm"] = udm;
        dr["jbid"] = jbid;
        if (pwd != "") dr["pwd"] = pwd;
        dr["uxm"] = uxm;
        dr["umc"] = umc;
        dr["upx"] = upx;
        dr["uzt"] = uzt;
        dr["ubz"] = ubz;
        dr["xrbz"] = xrbz;
        dr["zid"] = zid;

        BLL.UpdateSingleRow(dr);
        GridView1.DataBind();

        if (bAdd)
            JScript.MsgBox(this, "添加成功！");
        else
            JScript.MsgBox(this, "修改成功！");

        txtudm.Text = "";
        txtxm.Text = "";
        txtpwd.Text = "";
        txtumc.Text = "";
        txtupx.Text = "";
        txtubz.Text = "";
    }
}