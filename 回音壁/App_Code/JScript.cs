using System.Web;
using System.Web.UI;
using System;

/// <summary>
///JScript 的摘要说明
/// </summary>
public class JScript
{
    public static long g_nScriptID = 0;

    public static string GetRandomDouble()
    {
        Random r = new Random();
        g_nScriptID++;
        return g_nScriptID.ToString() + r.Next().ToString();
    }

    public static string C2J(string s)
    {
        return s.Replace(@"\", @"\\").Replace(@"'", @"\'").Replace("\r", @"\r").Replace("\n", @"\n");
    }

    public static void AddScript(string sScript, bool bEnd)
    {
        HttpContext.Current.Response.Write("<script language='javascript'>" + sScript + "</script>");
        if (bEnd) HttpContext.Current.Response.End();
    }

    public static void AddScript(Page pg, string sScript, bool bEnd)
    {
        if (pg == null) pg = HttpContext.Current.Handler as Page;
        pg.ClientScript.RegisterStartupScript(pg.GetType(), GetRandomDouble(), sScript, true);
        if (bEnd) HttpContext.Current.Response.End();
    }

    public static void MsgBox(Page pg, string sMsg, params object[] os)
    {
        if (os.Length > 0) sMsg = string.Format(sMsg, os);
        AddScript(pg, "alert('" + C2J(sMsg) + "');", false);
    }

    public static void MsgBox(string sMsg, params object[] os)
    {
        if (os.Length > 0) sMsg = string.Format(sMsg, os);
        AddScript("alert('" + C2J(sMsg) + "');", false);
    }

    public static void GoHistory(int i)
    {
        AddScript("history.go(" + i.ToString() + ");", true);
    }

    public static void Redirect(string sUrl)
    {
        string s = C2J(sUrl);
        if (s.LastIndexOf('?') == -1)
        {
            s = s + "?t=" + GetRandomDouble();
        }
        else
        {
            s = s + "&t=" + GetRandomDouble();
        }
        AddScript("window.location.replace('" + s + "');", true);
    }

    public static void CloseWindow()
    {
        AddScript("parent.opener=null;window.close();history.go(-1);", true);
    }

    public static void MsgBoxAndClose(string sMsg)
    {
        MsgBox(sMsg);
        CloseWindow();
    }

    public static void MsgBoxAndGoBack(string sMsg)
    {
        MsgBoxAndGoHistory(sMsg, -1);
    }

    public static void MsgBoxAndGoHistory(string sMsg, int i)
    {
        MsgBox(sMsg);
        GoHistory(i);
    }

    public static void MsgBoxAndRedirect(string sMsg, string sUrl)
    {
        MsgBox(sMsg);
        Redirect(sUrl);
    }
}