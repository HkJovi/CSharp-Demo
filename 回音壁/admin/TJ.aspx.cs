using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_TJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public string TJCount(int lb, int d)
    {
        string dt = DateTime.Now.AddDays(d).ToString("yyyy-MM-dd");
        string sql = "";
        if (lb == 1)
        {
            sql = "select count(*) from t_xj where convert(date,sj)='{0}' ";
        }
        else
        {
            sql = "select count(*) from t_hf where convert(date,hfsj)='{0}' ";
        }
        return DB.ExecuteScalar(string.Format(sql, dt)).ToString();
    }
}