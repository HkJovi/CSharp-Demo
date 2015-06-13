using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ShowXJ : System.Web.UI.Page
{
    public DataRow m_xj = null;
    public bool m_HasPwd = false;

    public string GetInfo(string fn, string sDef, bool bEncode)
    {
        string sRet = bEncode ? BLL.HE(m_xj[fn]) : m_xj[fn].ToString();
        return sRet == "" ? sDef : sRet;
    }

    public string GetInfo(string fn)
    {
        return GetInfo(fn, "&nbsp;", true);
    }

    public string GetInfo(string fn, string sDef)
    {
        return GetInfo(fn, sDef, true);
    }

    public int MyDataBind()
    {
        int xjid = (int)m_xj["xjid"];
        DataTable dt = DB.GetTable("select * from t_hf a inner join t_user b on a.hfr=b.udm where a.xjid=@xjid order by a.hfsj", 
            new SqlParameter("xjid", xjid));
        lsthfList.DataSource = dt;
        lsthfList.DataBind();
        return dt.Rows.Count;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int xjid = QueryParams.GetInt("xjid");
        string xjdm = QueryParams.GetStr("xjdm");
        string ckdm = "";
        string ckpwd = "";
        HttpCookie ck = Request.Cookies["xj"];
        if (ck != null)
        {
            if (!string.IsNullOrEmpty(ck["dm"])) ckdm = ck["dm"];
            if (!string.IsNullOrEmpty(ck["pwd"])) ckpwd = ck["pwd"];
        }

        DataRow dr = DB.GetRow("select xjid,dm,pwd from v_xj where (xjid=@xjid and xdbz='1')or(dm=@xjdm and xdbz='1')or(dm=@ckdm and pwd=@ckpwd)",
            new SqlParameter("xjid", xjid),
            new SqlParameter("xjdm", xjdm),
            new SqlParameter("ckdm", ckdm),
            new SqlParameter("ckpwd", ckpwd));

        if (dr == null) JScript.MsgBoxAndGoBack("该信件未选登，如果要查看，请输入信件编码和密码。");

        m_HasPwd = BLL.SameTextTrim(ckdm, dr["dm"]) && BLL.SameTextTrim(ckpwd, dr["pwd"]);
        m_xj = DB.GetRow(@"
select * from v_xj a 
left join t_lb b on a.lbid=b.lbid
inner join t_zt c on a.ztdm=c.ztdm
inner join t_lx d on a.lxmc=d.lxmc
where a.xjid=@xjid"
            , new SqlParameter("xjid", dr["xjid"]));

        //btYY.Text = string.Format("对我有用({0})", m_xj["yycs"]);

        if (!IsPostBack)
        {
            MyDataBind();
            UserCls.AddHits(xjid);
        }
    }
}