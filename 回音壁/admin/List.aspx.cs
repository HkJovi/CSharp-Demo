using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_List : System.Web.UI.Page, IQueryJK
{
    public bool bQX_Del = false;
    public bool bQX_XD = false;

    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bQX_Del = AdminCls.HasQX("删除信件");
        bQX_XD = AdminCls.HasQX("选登信件");

        if (bQX_XD == false && bQX_Del == false)
        {
            BLL.GetColByName(GridView1, "操作").Visible = false;
        }
    }

    public string GetTitle()
    {
        int lb = QueryParams.GetInt("lb");
        if (lb == 1)
        {
            return "新信件";
        }
        else if (lb == 2)
        {
            return "我转给别人的信件";
        }
        else if (lb == 3)
        {
            return "我处复过的信件";
        }
        else
        {
            return "转处给我的信件";
        }
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
            select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.xm,a.dw,a.sj,d.umc,c.hfsj,a.hits,a.xdbz,e.ztmc from v_xj a 
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
            )and({1})
            order by c.hfsj desc,a.sj desc";

        string tj = "";

        if (lb == 1)        //新信件
        {
            tj = xrbz == 0 ? "1=0" : (xrbz == 1 ? "a.ztdm='1' and gkbz='1'" : "a.ztdm='1'");
        }
        else if (lb == 2)   //转给别人的
        {
            tj = string.Format("c.hfr='{0}' and a.ztdm='2'", udm);
        }
        else if (lb == 3)   //我处复过的
        {
            tj = string.Format("a.xjid in (select xjid from t_hf where hfr='{0}')", udm);
        }
        else                //别人转给我的
        {
            tj = string.Format("a.zjhfjb={0} or a.zjhfr='{1}'", jbid, udm);
        }

        e.Command.CommandText = string.Format(sql, q, tj);
    }

    protected void btXD_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int xjid = int.Parse(lb.CommandArgument);
        DB.ExecuteSQL("update t_xj set xdbz=case when xdbz='1' then '0' else '1' end where xjid=@xjid", new SqlParameter("xjid", xjid));
        GridView1.DataBind();
    }

    protected void btDel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int xjid = int.Parse(lb.CommandArgument);
        string udm = SXMGR.strSession["udm"];
        DB.ExecuteSQL("update t_xj set deluser=@udm where xjid=@xjid", new SqlParameter("xjid", xjid), new SqlParameter("udm", udm));
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        (e.Row.FindControl("btDel") as LinkButton).Visible = bQX_Del;
        (e.Row.FindControl("btXD") as LinkButton).Visible = bQX_XD;
    }
}