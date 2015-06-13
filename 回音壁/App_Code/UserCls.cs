using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public static class UserCls
{
    public static DataRow AddXJ(string xm, string dw, string dz, string dh, string bt, string nr, string fj, string lx, int lbid, string gkbz, string email, out string dm, out string pwd)
    {
        DateTime sj = DateTime.Now;
        string ip = BLL.GetRealIP();
        pwd = MakeXJPwd();
        dm = MakeXJDM();


        string sql = "select * from t_xj where 1=0";
        DataTable dt = DB.GetTable(sql);
        DataRow dr = dt.NewRow();

        dr["dm"] = dm;
        dr["pwd"] = pwd;
        dr["lbid"] = lbid;
        dr["xm"] = xm;
        dr["dw"] = dw;
        dr["sj"] = sj;
        dr["dz"] = dz;
        dr["dh"] = dh;
        dr["bt"] = bt;
        dr["nr"] = nr;
        dr["fj"] = fj;
        dr["ztdm"] = "1";
        dr["xdbz"] = gkbz;  //如果是公开信件则默认选登、如果是非公信件则默认不选登，如果想默认不选登，只需把这里改为"0";
        //dr["hfid"] = hfid;
        dr["lxmc"] = lx;
        dr["ip"] = ip; ;
        dr["zjhfr"] = "";
        dr["zjhfjb"] = -1;
        //dr["pf"] = pf;
        dr["hits"] = 0;
        dr["yycs"] = 0;
        dr["gkbz"] = gkbz;
        dr["email"] = email;
        dr["deluser"] = "";

        dt.Rows.Add(dr);
        DB.UpdateTable(sql, dt);

        return dr;
    }

    public static void AddHits(int xjid)
    {
        DB.ExecuteSQL("update t_xj set hits=isnull(hits,0)+1 where xjid=@xjid", new SqlParameter("xjid", xjid));
    }

    private static void InnerGetSubList(string tbName, string idName, string pidName, int id, ref string sList)
    {
        string sql = string.Format("select {0} from {1} where {2}=@id", idName, tbName, pidName);
        DataTable dt = DB.GetTable(sql, new SqlParameter("id", id));
        foreach (DataRow dr in dt.Rows)
        {
            sList += "," + dr[0].ToString();
            InnerGetSubList(tbName, idName, pidName, (int)dr[0], ref sList);
        }
    }

    public static string GetSubLbidList(int lbid)
    {
        string s = lbid.ToString();
        InnerGetSubList("t_lb", "lbid", "plbid", lbid, ref s);
        return s;
    }

    public static string MakeXJDM()
    {
        string yy = DateTime.Now.ToString("yy");
        DataRow dr = DB.GetRow("select top 1 dm from t_xj where dm like '" + yy + "%' order by dm desc");
        if (dr == null) return yy + "0001";
        int sn = int.Parse(dr["dm"].ToString().Substring(2, 4)) + 1;
        return yy + sn.ToString("D4");
    }
     
    public static string MakeXJPwd()
    {
        Random r = new Random();
        return r.Next(0, 10000).ToString("D4");
    }

}