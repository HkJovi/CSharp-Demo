using System.Web;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System;

public static class BLL
{
    public static string HE(object o)
    {
        return HE(o, "");
    }

    public static string HE(object o, string sNull)
    {
        if (o == null) return sNull;
        string s = o.ToString();
        if (s == "") return sNull;
        return HttpContext.Current.Server.HtmlEncode(s);
    }

    public static string HD(object o)
    {
        if (o == null) return "";
        return HttpContext.Current.Server.HtmlDecode(o.ToString());
    }

    public static string UE(object o)
    {
        if (o == null) return "";
        return HttpContext.Current.Server.UrlEncode(o.ToString());
    }

    public static string UD(object o)
    {
        if (o == null) return "";
        return HttpContext.Current.Server.UrlDecode(o.ToString());
    }

    public static void AddCode(string sCode)
    {
/*
        MSScriptControl.ScriptControlClass scc = new MSScriptControl.ScriptControlClass();
        scc.AllowUI = false;
        scc.Language = "VBScript";
        scc.UseSafeSubset = false;
        scc.Timeout = -1;
        scc.AddCode(sCode);
*/
    }

    public static string CutString(object o, int length)
    {
        string str = o == null ? "" : o.ToString().Trim();
        if (str == "")
        {
            str = " ";
        }
        else
        {
            int i = 0, j = 0;
            foreach (char chr in str)
            {
                if ((int)chr > 127)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }
                if (i > length)
                {
                    //str = str.Substring(0, j);
                    str = str.Substring(0, j) + "...";
                    break;
                }
                j++;
            }

        }
        return HE(str);
    }

    public static string GetRealIP()
    {
        HttpRequest request = HttpContext.Current.Request;
        string via = request.ServerVariables["HTTP_VIA"];
        string x = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        string ip =request.UserHostAddress;

        if( !string.IsNullOrEmpty(via) && !string.IsNullOrEmpty(x))
        {
            return x.Split(',')[0].Trim();  //这里的x可能有多个IP由,号分隔，要想获取真正的IP地址，需要依次检查第一个非内网的IP，这里就取第一个IP
        }
        else
        {
            return ip;
        }
    }

    public static bool SameText(object o1, object o2)
    {
        string s1 = o1 == null ? "" : o1.ToString().ToUpper();
        string s2 = o2 == null ? "" : o2.ToString().ToUpper();
        return s1 == s2;
    }

    public static bool SameTextTrim(object o1, object o2)
    {
        string s1 = o1 == null ? "" : o1.ToString().Trim().ToUpper();
        string s2 = o2 == null ? "" : o2.ToString().Trim().ToUpper();
        return s1 == s2;
    }

    public static bool SendMail(string to, string subject, string body)
    {
        try
        {
            string sHost = GetDBSet("SmtpHost");
            int nPort = int.Parse(GetDBSet("SmtpPort"));
            string sFromAddress = GetDBSet("FromAddress");
            string sUserName = sFromAddress;
            string sUserPwd = GetDBSet("FromPwd");
            string sFromName = GetDBSet("FromName");

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(sFromAddress, sFromName);
            msg.To.Add(to);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient();
            sc.Credentials = new NetworkCredential(sUserName, sUserPwd);
            sc.Port = nPort;
            sc.Host = sHost;
            sc.EnableSsl = true;
            //sc.SendAsync(msg, null);
            sc.Send(msg);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static string GetDBSet(string k)
    {
        DataRow dr = DB.GetRow("select * from t_set where k=@k", new SqlParameter("k", k));
        if (dr == null) return "";
        return dr["v"].ToString();
    }

    public static void SetDBSet(string k, string v)
    {
        DataRow dr = GetTableRow("t_set", "k", k);
        if (dr == null) dr = GetTableRow("t_set", "k", null);
        dr["v"] = v;
        UpdateSingleRow(dr);
    }

    //将txt中的   {字段名}    替换为真实的数据信息，注意txt中的字段名必须为小写
    public static string ReplaceFromDB(string txt, DataRow dr)
    {
        foreach (DataColumn c in dr.Table.Columns)
        {
            string s = "{" + c.ColumnName.ToLower() + "}";
            txt = txt.Replace(s, dr[c].ToString());
        }
        return txt;
    }

    public static string GetSelfMainURL()
    {
        string s = HttpContext.Current.Request.Url.ToString();
        int i = s.LastIndexOf("/");
        return s.Substring(0, i+1);
    }

    public static int GetSubControls(Control p, ArrayList ar, bool bHasSub)
    {
        if (p == null) return 0;
        int n = 0;
        foreach (Control c in p.Controls)
        {
            ar.Add(c);
            n++;
            if (bHasSub) n += GetSubControls(c, ar, bHasSub);
        }
        return n;
    }

    public static string MakePager(GridView gv)
    {
        gv.AllowPaging = true;
        gv.PagerStyle.CssClass = "hided";
        gv.PagerSettings.Position = PagerPosition.Bottom;

        if (gv.BottomPagerRow == null) return "";

        int b = int.MaxValue;
        int e = int.MinValue;
        int c = gv.PageIndex + 1;
        ArrayList ar = new ArrayList();
        GetSubControls(gv.BottomPagerRow, ar, true);
        for (int i = 0; i < ar.Count; i++)
        {
            int n = 0;
            if (ar[i] is Label) int.TryParse((ar[i] as Label).Text,out n);
            if (ar[i] is LinkButton) int.TryParse((ar[i] as LinkButton).Text, out n);

            if (n == 0) continue;

            if (b > n) b = n;
            if (e < n) e = n;
        }

        if (e - b == 0) return "";

        string s = "<div class='pagination'>";
        if (b > 1) s += string.Format("<a href=\"javascript:__doPostBack('{0}','Page${1}')\">«</a> ", gv.UniqueID, b - 1);
        for (int i = b; i <= e; i++)
        {
            if (i == c)
                s += string.Format("<a href=\"javascript:void(0)\" class='{0}'>{1}</a> ", "active", i);
            else
                s += string.Format("<a href=\"javascript:__doPostBack('{0}','Page${1}')\">{1}</a> ", gv.UniqueID, i);
        }
        if (gv.PageCount > e) s += string.Format("<a href=\"javascript:__doPostBack('{0}','Page${1}')\">»</a> ", gv.UniqueID, e + 1);
        s += "</div>";

        return s;
    }


    public static string GetSafeStr(object o)
    {
        if (o == null) return "";
        return o.ToString().Replace("'", "''").Replace("\r", "").Replace("\n", "");
    }

    /// <summary>
    /// 获取表中的一行，未指定oKey时为新添行，指定后为指定行，常用于更新和插入，仅用于只有一个主键的表
    /// </summary>
    /// <param name="tbName">表名</param>
    /// <param name="sKeyName">主键</param>
    /// <param name="oKey">值</param>
    /// <returns></returns>
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

    public static DataControlField GetColByName(GridView gv, string sName)
    {
        for (int i = 0; i < gv.Columns.Count; i++)
        {
            if (SameTextTrim(gv.Columns[i].HeaderText, sName))
            {
                return gv.Columns[i];
            }
        }
        return null;
    }

}
