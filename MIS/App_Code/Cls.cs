using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Cls 的摘要说明
/// </summary>
public class Cls
{
	public Cls()
	{
	}

    public static bool HasQX(string sqx)
    {
        string zqx = SXMGR.strSession["uJBZ"];
        if (zqx == "") return false;

        if (string.IsNullOrEmpty(sqx)) return true;  // 怎么理解这个地方

        return (zqx.IndexOf(sqx) != -1) || (zqx.IndexOf("所有权限") != -1);
    }

    public static void CheckQX(string sqx)
    {
        if (HasQX(sqx) == false)
        {
            JScript.MsgBoxAndRedirect("对不起，您还没有登陆，或登陆已经超时！", "Login.aspx");
            return;
        }
    }

    public static void CheckLogin()
    {
        CheckQX("");
    }

    public static int SendMessage(string xjtm, string xjnr, string fszh, string jszh)
    {
        DateTime time = DateTime.Now;
        string xjid = MakeXJID();
        int i=0;

        string sql = "select * from t_xx where 1=0";
        DataTable dt = DB.GetTable(sql);
        DataRow dr = dt.NewRow();

        dr["xjid"] = xjid;
        dr["xjtm"] = xjtm;
        dr["xjnr"] = xjnr;
        dr["time"] = time;

        dt.Rows.Add(dr);
        DB.UpdateTable(sql, dt);

        string sql2 = @"   insert into t_fjx (fszh,xjid) values ( @fszh,@xjid ) 
                        insert into t_sjx (jszh,ydbz,xjid) values ( @jszh,'0',@xjid)";
        i= DB.ExecuteSQL(sql2, new SqlParameter("fszh", fszh), new SqlParameter("jszh", jszh),new SqlParameter("xjid",xjid));
        return i;
    }

    public static int ZhuanSendMessage(int xjid, string jszh)
    {
        int i = 0;
        string sql = "insert into t_sjx (jszh,ydbz,xjid) values ( @jszh,'0',@xjid)";
        i = DB.ExecuteSQL(sql, new SqlParameter("jszh", jszh), new SqlParameter("xjid", xjid));
        return i;
    }

    public static int CheckUser(string jszh)
    {
        string sql = "select * from t_User where uZH=@jszh";
        return  DB.ExecuteSQL(sql, new SqlParameter("jszh", jszh));
    }

    public static string MakeXJID()
    {
        string yy = DateTime.Now.ToString("yy");
        DataRow dr = DB.GetRow("select top 1 xjid from t_xx where xjid like '" + yy + "%' order by xjid desc");
        if (dr == null) return yy + "0001";
        int sn = int.Parse(dr["xjid"].ToString().Substring(2, 4)) + 1;
        return yy + sn.ToString("D4");
    }

    public static int CheckNEW()
    {
        string sql = "select top 1 * from t_sjx a inner join t_xx b on a.xjid=b.xjid and a.ydbz=0 and a.jszh=@jszh order by b.time desc";
        DataRow dr = DB.GetRow(sql, new SqlParameter("jszh", SXMGR.strSession["uZH"]));
        if (dr != null)
            return 1;
        else
            return 0;
    }
    public static string GetTop1MesgName()
    {
        string sql = "select top 1 * from t_sjx a inner join t_xx b on a.xjid=b.xjid and a.ydbz=0 and a.jszh=@jszh order by b.time desc";
        DataRow dr = DB.GetRow(sql, new SqlParameter("jszh", SXMGR.strSession["uZH"]));
            return dr["xjtm"].ToString();
    }
    public static string GetTopMesgID()
    {
        string sql = "select top 1 * from t_sjx a inner join t_xx b on a.xjid=b.xjid and a.ydbz=0 and a.jszh=@jszh order by b.time desc";
        DataRow dr = DB.GetRow(sql, new SqlParameter("jszh", SXMGR.strSession["uZH"]));
        return dr["xjid"].ToString();
    }

    public static int CheckMesg()
    {
        string sql="select top 1 * from t_sjx where jszh=@uZH";
        DataRow dr=DB.GetRow(sql,new SqlParameter("uZH",SXMGR.strSession["uZH"]));
         if (dr != null)
            return 1;
        else
            return 0;
    }

    public static int GetMaxCountsGG()
    {
        string sql = "select top 1 ggid from t_gg order by ggid desc";
        DataRow dr = DB.GetRow(sql);
        if (dr != null)
            return Convert.ToInt32(dr["ggid"]);
        else
            return -1;
    }

    public static string GetGGTime(int ggid)
    {
        string sql = "select time from t_gg where ggid=@ggid";
        DataRow dr = DB.GetRow(sql, new SqlParameter("ggid", ggid));
        if (dr != null)
            return dr["time"].ToString();
        else
            return "";
    }

    public static string GetMesgTime(int xjid)
    {
        string sql = "select time from t_xx where xjid=@xjid";
        DataRow dr = DB.GetRow(sql, new SqlParameter("xjid", xjid));
        if (dr != null)
            return dr["time"].ToString();
        else
            return "";
    }
    public static string GetMesgFSZH(int xjid)
    {
        string sql = "select fszh from t_fjx where xjid=@xjid";
        DataRow dr = DB.GetRow(sql, new SqlParameter("xjid", xjid));
        if (dr != null)
            return dr["fszh"].ToString();
        else
            return "";
    }

    public static string GetHFMessageTm(int xjid)
    {
        string sql = "select xjtm from t_xx where xjid =@xjid";
        DataRow dr = DB.GetRow(sql, new SqlParameter("xjid", xjid));
        if (dr != null)
            return "回复-" + dr["xjtm"].ToString();
        else
            return "";
    }

    public static void Hasread(int xjid,string jszh)
    {
        string sql = "update t_sjx set ydbz='1' where xjid=@xjid and jszh=@jszh";
        DB.ExecuteSQL(sql, new SqlParameter("xjid", xjid), new SqlParameter("jszh", jszh));
    }
}