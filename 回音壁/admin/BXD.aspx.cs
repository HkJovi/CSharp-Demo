using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_BXD : System.Web.UI.Page, IQueryJK
{
    public bool bQX_XD = false;

    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bQX_XD = AdminCls.HasQX("选登信件");

        DataControlField col = BLL.GetColByName(GridView1, "操作");
        if (col != null) col.Visible = bQX_XD;
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        int lb = QueryParams.GetInt("lb");
        int xrbz = SXMGR.intSession["xrbz"];
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        if (q == "信件搜索") q = "";
        string udm = SXMGR.strSession["udm"];
        int jbid = SXMGR.intSession["jbid"];
        string sql = @"
            select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.xm,a.dw,a.sj,d.umc,c.hfsj,a.hits,a.xdbz,e.ztmc from t_xj a 
            left join t_lb b on a.lbid=b.lbid 
            left join t_hf c on a.hfid=c.hfid
            left join t_user d on c.hfr=d.udm
            inner join t_zt e on a.ztdm=e.ztdm
            where (
                a.dm    like '%{0}%' or
                b.lbmc  like '%{0}%' or
                a.bt    like '%{0}%' or
                a.lxmc  like '%{0}%' or
                a.xm    like '%{0}%' or
                a.dw    like '%{0}%' or
                d.umc   like '%{0}%' or
                e.ztmc  like '%{0}%'
            )and(a.xdbz='0')
            order by c.hfsj desc,a.sj desc";

        e.Command.CommandText = string.Format(sql, q);
    }

    protected void btXD_Click(object sender, EventArgs e)
    {
        if (bQX_XD == false) return;
        LinkButton lb = (LinkButton)sender;
        int xjid = int.Parse(lb.CommandArgument);
        DB.ExecuteSQL("update t_xj set xdbz='1' where xjid=@xjid", new SqlParameter("xjid", xjid));
        GridView1.DataBind();
    }
}