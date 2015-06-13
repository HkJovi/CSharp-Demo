using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Net;

/// <summary>
/// BLL 的摘要说明
/// </summary>
public class BLL
{
	public BLL()
	{
	}

    public static DataRow GetTableRow(string tbName, string sKeyName, object oKey)
    {
        DataTable dt = null;
        DataRow dr = null;
        if (oKey == null)
        {
            dt = DB.GetTable("select * from " + tbName + " where 1=0");
            dr = dt.NewRow();
            dt.Rows.Add(dr);
        }
        else
        {
            dt = DB.GetTable("select * from " + tbName + " where " + sKeyName + "=@v", new SqlParameter("v", oKey));
            if (dt.Rows.Count > 0) dr = dt.Rows[0];
        }
        dt.TableName = tbName;
        return dr;
    }

    public static int UpdateSingleRow(DataRow dr)
    {
        if (dr.Table.TableName == "") throw new Exception("UpdateSingleRow函数只能与GetTableRow函数配合使用");
        return DB.UpdateTable("select * from " + dr.Table.TableName + " where 1=0", dr.Table);
    }

    public static string GetRealIP()
    {
        HttpRequest request = HttpContext.Current.Request;
        string via = request.ServerVariables["HTTP_VIA"];
        string x = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        string ip = request.UserHostAddress;

        if (!string.IsNullOrEmpty(via) && !string.IsNullOrEmpty(x))
        {
            return x.Split(',')[0].Trim();  //这里的x可能有多个IP由,号分隔，要想获取真正的IP地址，需要依次检查第一个非内网的IP，这里就取第一个IP
        }
        else
        {
            return ip;
        }
    }

    public static void Login_info(string uZH)
    {
        DateTime DLtime = DateTime.Now;
        string DLIP = BLL.GetRealIP();
        string sql = "insert into t_dlxx values (@uZH,@DLtime,@DLIP)";
        DB.ExecuteSQL(sql, new SqlParameter("uZH", uZH), new SqlParameter("DLtime", DLtime), new SqlParameter("DLIP", DLIP));
    }

    public static string GetLogin_info(string uZH)
    {
        string sql = @"select top 1 * from t_dlxx
where DLtime not in(select top 1 DLtime from t_dlxx where uZH=@uZH order by DLtime desc) and uZH=@uZH
order by DLtime desc";
        DataRow dr=DB.GetRow(sql,new SqlParameter("uZH",uZH));
        if (dr != null)
            return dr["DLtime"].ToString() + " ,IP地址是：" + dr["DLIP"].ToString();
        else
            return "";
    }
}