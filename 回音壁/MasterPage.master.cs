using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int nAllCount, nTodayCount;
        DateTime tm;
        nAllCount = int.Parse(BLL.GetDBSet("LLS"));
        nTodayCount = int.Parse(BLL.GetDBSet("TodayLLS"));
        tm = DateTime.Parse(BLL.GetDBSet("Now"));

        if (DateTime.Now.Date > tm.Date)
        {
            nTodayCount = 1;
            BLL.SetDBSet("Now", DateTime.Now.Date.ToString());
        }
        else
        {
            nTodayCount++;
        }
        nAllCount++;

        BLL.SetDBSet("TodayLLS", nTodayCount.ToString());
        BLL.SetDBSet("LLS", nAllCount.ToString());
    }

    public string GetTodayLLS()
    {
        return BLL.GetDBSet("TodayLLS");
    }

    public string GetTodayXJS()
    {
        return DB.ExecuteScalar("select count(*) from v_xj where sj>=@sj", new SqlParameter("sj", DateTime.Now.Date)).ToString();
    }

    public string GetTodayHFS()
    {
        return DB.ExecuteScalar("select count(*) from t_hf where hfsj>=@sj", new SqlParameter("sj", DateTime.Now.Date)).ToString();
    }

    public string GetAllInfoCount()
    {
        return BLL.GetDBSet("lls");
    }
}
