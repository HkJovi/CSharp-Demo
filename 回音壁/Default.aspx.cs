using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string GetProcingCount()
    {
        return DB.ExecuteScalar("select count(*) from v_xj where hfid is null and xdbz='1'").ToString();
    }

    protected void dsHF_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        int lbid = QueryParams.GetInt("lbid");
        string q = QueryParams.GetStr("q");
        if (BLL.SameText(q, "Search")) q = "";
        string tj = "1=1";
        if (lbid != 0) tj = string.Format("a.lbid in ({0})", UserCls.GetSubLbidList(lbid));

        string sql = string.Format(@"
select top 25 a.xjid,a.dm,a.lbid,b.lbmc,a.bt,a.lxmc,a.dw,a.xm,a.sj,d.uxm,d.umc,c.hfsj,a.hits from v_xj a 
inner join t_lb b on a.lbid=b.lbid
inner join t_hf c on a.hfid=c.hfid
inner join t_user d on c.hfr=d.udm
where (a.xdbz='1')and(
a.dm like   '%{0}%' or
b.lbmc like '%{0}%' or
a.bt like   '%{0}%' or
a.lxmc like '%{0}%' or
a.dw like   '%{0}%' or
a.xm like   '%{0}%' or
d.umc like  '%{0}%'
)and({1})
order by a.dm desc", q, tj);

        e.Command.CommandText = sql;
    }
    protected void dsNew_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string q = QueryParams.GetStr("q");
        if (BLL.SameText(q, "Search")) q = "";
        string sql = string.Format(@"
select xjid,dm,lbid,bt,lxmc,dw,xm,sj,hits from v_xj where (hfid is null)and(xdbz='1')and(
dm like   '%{0}%' or
bt like   '%{0}%' or
lxmc like '%{0}%' or
dw like   '%{0}%' or
xm like   '%{0}%'
)order by dm desc", q);

        e.Command.CommandText = sql;
    }
}