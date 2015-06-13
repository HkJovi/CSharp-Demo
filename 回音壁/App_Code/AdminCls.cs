using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class AdminCls
{
    public static bool HasQX(string sqx)
    {
        string zqx = SXMGR.strSession["zqx"];
        if (zqx == "") return false;

        if (string.IsNullOrEmpty(sqx)) return true;

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

    public static DataRow GetXJAllInfo(int xjid)
    {
        return DB.GetRow(@"
            select * from t_xj a
            inner join t_zt b on a.ztdm=b.ztdm
            left join t_lb c on a.lbid=c.lbid
            where a.xjid=@xjid", new SqlParameter("xjid", xjid));
    }

    /// <summary>
    /// 判断对信件的操作权限：0不能看、1可查看、2可回复
    /// </summary>
    /// <param name="xj">可以使用GetXJAllInfo()获取</param>
    /// <returns>0不能看、1可查看、2可回复</returns>
    public static int CanHF(DataRow xj)
    {
        string xrbz = SXMGR.strSession["xrbz"];
        int jbid = SXMGR.intSession["jbid"];
        string udm = SXMGR.strSession["udm"];

        if (xj["deluser"].ToString() == "")     //不是回收站里的信件
        {
            DataRow dr = DB.GetRow("select 1 from t_hf where xjid=@xjid and hfr=@udm", new SqlParameter("xjid",xj["xjid"]),new SqlParameter("udm",udm));
            if (dr != null)      //有参与回复
            {
                return 2;
            }
            else            //无参与回复
            {
                if (xrbz == "2" || xrbz=="1")
                {
                    return 2;
                }

                if (xj["gkbz"].ToString() == "1")  //公开信
                {
                    if (xj["ztdm"].ToString() == "1")     //新信件
                    {
                        return xrbz != "0" ? 2 : 1;
                    }
                    else
                    {
                        return (jbid == (int)xj["zjhfjb"] || xj["zjhfr"].ToString() == udm) ? 2 : 1;
                    }
                }
                else       //非公开
                {
                    if (xrbz == "2")     //超管
                    {
                        return 2;
                    }
                    else         //其它
                    {
                        return (jbid == (int)xj["zjhfjb"] || xj["zjhfr"].ToString() == udm) ? 2 : 0;
                    }                    
                }
            }
        }
        else       //是回收站里的信件
        {                       
            return HasQX("查看删除信件") ? 1 : 0;
        }
    }

    private static void InnerMakeTreeList(DropDownList lst, DataTable dt, int pid, string bf, string kg, string pidName, string mcName, string idName, string sort)
    {
        DataRow[] rs = dt.Select(pidName + "=" + pid.ToString(), sort);
        for (int i = 0; i < rs.Length; i++)
        {
            DataRow dr = rs[i];
            ListItem item = new ListItem(bf + dr[mcName].ToString(), dr[idName].ToString());
            lst.Items.Add(item);
            InnerMakeTreeList(lst, dt, (int)dr[idName], bf + kg, kg, pidName, mcName, idName, sort);
        }
    }

    public static void FillTreeList(DropDownList lst)
    {
        DataTable dt = DB.GetTable("select * from t_jb");
        InnerMakeTreeList(lst, dt, -1, "", "　", "pjbid", "jbmc", "jbid", "jbid asc");
    }
}