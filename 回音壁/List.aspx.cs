using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class List : System.Web.UI.Page
{
    int g_lbid;

    protected void Page_Load(object sender, EventArgs e)
    {
        g_lbid = QueryParams.GetInt("lbid");
        if (g_lbid == 0) g_lbid = 1;            //未指定类别的话就转到所有类别中
    }

    public string GetLbmc()
    {
        return DB.ExecuteScalar("select lbmc from t_lb where lbid=@lbid", new SqlParameter("lbid", g_lbid)).ToString();        
    }

    protected void dsHF_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        int lbid = g_lbid;
        string q = QueryParams.GetStr("q");
        if (BLL.SameText(q, "Search")) q = "";
        string tj = "1=1";
        if (lbid != 0) tj = string.Format("a.lbid in ({0})", UserCls.GetSubLbidList(lbid));

        string sql = string.Format(@"
select top 50 a.xjid,a.dm,a.lbid,b.lbmc,a.bt,a.lxmc,a.dw,a.xm,a.sj,d.uxm,d.umc,c.hfsj,a.hits from v_xj a 
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
order by c.hfsj desc", q, tj);

        e.Command.CommandText = sql;
    }
}