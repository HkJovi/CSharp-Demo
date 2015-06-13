using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class LBTJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetXJCount(object o)
    {
        if (o == null) return "";
        int lbid = (int)o;
        return DB.ExecuteScalar("select COUNT(*) from v_xj where lbid=@id", new SqlParameter("id", lbid)).ToString();
    }

    public string GetHFCount(object o)
    {
        if (o == null) return "";
        int lbid = (int)o;
        return DB.ExecuteScalar("select COUNT(*) from t_hf a inner join v_xj b on a.xjid=b.xjid where b.lbid=@id", new SqlParameter("id", lbid)).ToString();
    }
}