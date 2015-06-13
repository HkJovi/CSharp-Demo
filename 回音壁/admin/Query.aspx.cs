using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Query : System.Web.UI.Page,IQueryJK 
{
    public void QueryTextChange(string txt)
    {
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetTitle()
    {
        int lb = QueryParams.GetInt("lb");
        if (lb == 1) return "所有新信件";
        else if (lb == 2) return "所有转处中的信件";
        else if (lb == 3) return "所有已处的信件";
        else return "所有信件";
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        int lb = QueryParams.GetInt("lb");
        string q = BLL.GetSafeStr((Master.FindControl("q") as TextBox).Text.Trim());
        string udm = SXMGR.strSession["udm"];
        int xrbz = SXMGR.intSession["xrbz"];
        if (q == "") q = QueryParams.GetStr("q");
        if (q == "信件搜索") q = "";

        string sql = @"
            select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.dw,a.xm,a.sj,d.umc,c.hfsj,a.hits,a.xdbz,e.ztmc from v_xj a 
            left join t_lb b on a.lbid=b.lbid
            left join t_hf c on a.hfid=c.hfid
            left join t_user d on c.hfr=d.udm
            left join t_zt e on a.ztdm=e.ztdm
            where (
            a.dm like '%{0}%' or
            b.lbmc like '%{0}%' or
            a.bt like '%{0}%' or
            a.lxmc like '%{0}%' or
            a.dw like '%{0}%' or
            a.xm like '%{0}%' or
            d.umc like '%{0}%' or
            e.ztmc like '%{0}%'
            )and({1})
            order by c.hfsj desc,a.sj desc";

        string tj = xrbz == 2 ? "1=1 " : "a.gkbz='1' ";


        if (lb == 1)        //所有新信件
        {
            tj += "and a.ztdm='1' ";
        }
        else if (lb == 2)   //所有转处中的信件
        {
            tj += "and a.ztdm='2' ";
        }
        else if (lb == 3)   //所有已处理信件
        {
            tj += "and a.ztdm='3' ";
        }

        e.Command.CommandText = string.Format(sql, q, tj);
    }
}