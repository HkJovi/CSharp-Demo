using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SLTJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetHFCS(object o)
    {
        if (o == null) return "";
        DateTime dt = (DateTime)o;
        return DB.ExecuteScalar("select COUNT(*) from t_hf where zjbz='0' and CONVERT(date,hfsj)=@dt", new SqlParameter("dt", dt)).ToString();
    }

    public string GetZJCS(object o)
    {
        if (o == null) return "";
        DateTime dt = (DateTime)o;
        return DB.ExecuteScalar("select COUNT(*) from t_hf where zjbz<>'0' and CONVERT(date,hfsj)=@dt", new SqlParameter("dt", dt)).ToString();
    }
}