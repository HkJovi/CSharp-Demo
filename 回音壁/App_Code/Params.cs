using System;
using System.Web;
using System.Collections.Specialized;

public class Params
{
    public static NameValueCollection Items
    {
        get
        {
            return HttpContext.Current.Request.Params;
        }
    }

    public static string GetStr(string sName, string sDefValue)
    {
        if (Items[sName] == null) return sDefValue;
        return Items[sName].Replace(@"'", @"''");
    }

    public static string GetStr(string sName)
    {
        return GetStr(sName, "");
    }

    public static int GetInt(string sName, int nDefValue)
    {
        int nRet;
        if (Items[sName] == null) return nDefValue;
        if (int.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static int GetInt(string sName)
    {
        return GetInt(sName, 0);
    }

    public static long GetLong(string sName, long nDefValue)
    {
        long nRet;
        if (Items[sName] == null) return nDefValue;
        if (long.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static long GetLong(string sName)
    {
        return GetLong(sName, 0);
    }

    public static double GetDouble(string sName, double fDefValue)
    {
        double fRet;
        if (Items[sName] == null) return fDefValue;
        if (double.TryParse(Items[sName], out fRet) == false) return fDefValue;
        return fRet;
    }

    public static double GetDouble(string sName)
    {
        return GetDouble(sName, 0.0);
    }

    public static DateTime GetDateTime(string sName, DateTime dtDefValue)
    {
        DateTime dtRet;
        if (Items[sName] == null) return dtDefValue;
        if (DateTime.TryParse(Items[sName], out dtRet) == false) return dtDefValue;
        return dtRet;
    }

    public static DateTime GetDateTime(string sName)
    {
        return GetDateTime(sName, DateTime.Now);
    }

    public static bool GetBool(string sName, bool bDefValue)
    {
        bool bRet;
        if (Items[sName] == null) return bDefValue;
        if (bool.TryParse(Items[sName], out bRet) == false) return bDefValue;
        return bRet;
    }

    public static bool GetBool(string sName)
    {
        return GetBool(sName, false);
    }
}

public class FormParams
{
    public static NameValueCollection Items
    {
        get
        {
            return HttpContext.Current.Request.Form;
        }
    }

    public static string GetStr(string sName, string sDefValue)
    {
        if (Items[sName] == null) return sDefValue;
        return Items[sName].Replace(@"'", @"''");
    }

    public static string GetStr(string sName)
    {
        return GetStr(sName, "");
    }

    public static int GetInt(string sName, int nDefValue)
    {
        int nRet;
        if (Items[sName] == null) return nDefValue;
        if (int.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static int GetInt(string sName)
    {
        return GetInt(sName, 0);
    }

    public static long GetLong(string sName, long nDefValue)
    {
        long nRet;
        if (Items[sName] == null) return nDefValue;
        if (long.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static long GetLong(string sName)
    {
        return GetLong(sName, 0);
    }

    public static double GetDouble(string sName, double fDefValue)
    {
        double fRet;
        if (Items[sName] == null) return fDefValue;
        if (double.TryParse(Items[sName], out fRet) == false) return fDefValue;
        return fRet;
    }

    public static double GetDouble(string sName)
    {
        return GetDouble(sName, 0.0);
    }

    public static DateTime GetDateTime(string sName, DateTime dtDefValue)
    {
        DateTime dtRet;
        if (Items[sName] == null) return dtDefValue;
        if (DateTime.TryParse(Items[sName], out dtRet) == false) return dtDefValue;
        return dtRet;
    }

    public static DateTime GetDateTime(string sName)
    {
        return GetDateTime(sName, DateTime.Now);
    }

    public static bool GetBool(string sName, bool bDefValue)
    {
        bool bRet;
        if (Items[sName] == null) return bDefValue;
        if (bool.TryParse(Items[sName], out bRet) == false) return bDefValue;
        return bRet;
    }

    public static bool GetBool(string sName)
    {
        return GetBool(sName, false);
    }
}

public class QueryParams
{
    public static NameValueCollection Items
    {
        get
        {
            return HttpContext.Current.Request.QueryString;
        }
    }

    public static string GetStr(string sName, string sDefValue)
    {
        if (Items[sName] == null) return sDefValue;
        return Items[sName].Replace(@"'", @"''");
    }

    public static string GetStr(string sName)
    {
        return GetStr(sName, "");
    }

    public static int GetInt(string sName, int nDefValue)
    {
        int nRet;
        if (Items[sName] == null) return nDefValue;
        if (int.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static int GetInt(string sName)
    {
        return GetInt(sName, 0);
    }

    public static long GetLong(string sName, long nDefValue)
    {
        long nRet;
        if (Items[sName] == null) return nDefValue;
        if (long.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static long GetLong(string sName)
    {
        return GetLong(sName, 0);
    }

    public static double GetDouble(string sName, double fDefValue)
    {
        double fRet;
        if (Items[sName] == null) return fDefValue;
        if (double.TryParse(Items[sName], out fRet) == false) return fDefValue;
        return fRet;
    }

    public static double GetDouble(string sName)
    {
        return GetDouble(sName, 0.0);
    }

    public static DateTime GetDateTime(string sName, DateTime dtDefValue)
    {
        DateTime dtRet;
        if (Items[sName] == null) return dtDefValue;
        if (DateTime.TryParse(Items[sName], out dtRet) == false) return dtDefValue;
        return dtRet;
    }

    public static DateTime GetDateTime(string sName)
    {
        return GetDateTime(sName, DateTime.Now);
    }

    public static bool GetBool(string sName, bool bDefValue)
    {
        bool bRet;
        if (Items[sName] == null) return bDefValue;
        if (bool.TryParse(Items[sName], out bRet) == false) return bDefValue;
        return bRet;
    }

    public static bool GetBool(string sName)
    {
        return GetBool(sName, false);
    }
}

public class VariantParams
{
    public static NameValueCollection Items
    {
        get
        {
            return HttpContext.Current.Request.ServerVariables;
        }
    }

    public static string GetStr(string sName, string sDefValue)
    {
        if (Items[sName] == null) return sDefValue;
        return Items[sName].Replace(@"'", @"''");
    }

    public static string GetStr(string sName)
    {
        return GetStr(sName, "");
    }

    public static int GetInt(string sName, int nDefValue)
    {
        int nRet;
        if (Items[sName] == null) return nDefValue;
        if (int.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static int GetInt(string sName)
    {
        return GetInt(sName, 0);
    }

    public static long GetLong(string sName, long nDefValue)
    {
        long nRet;
        if (Items[sName] == null) return nDefValue;
        if (long.TryParse(Items[sName], out nRet) == false) return nDefValue;
        return nRet;
    }

    public static long GetLong(string sName)
    {
        return GetLong(sName, 0);
    }

    public static double GetDouble(string sName, double fDefValue)
    {
        double fRet;
        if (Items[sName] == null) return fDefValue;
        if (double.TryParse(Items[sName], out fRet) == false) return fDefValue;
        return fRet;
    }

    public static double GetDouble(string sName)
    {
        return GetDouble(sName, 0.0);
    }

    public static DateTime GetDateTime(string sName, DateTime dtDefValue)
    {
        DateTime dtRet;
        if (Items[sName] == null) return dtDefValue;
        if (DateTime.TryParse(Items[sName], out dtRet) == false) return dtDefValue;
        return dtRet;
    }

    public static DateTime GetDateTime(string sName)
    {
        return GetDateTime(sName, DateTime.Now);
    }

    public static bool GetBool(string sName, bool bDefValue)
    {
        bool bRet;
        if (Items[sName] == null) return bDefValue;
        if (bool.TryParse(Items[sName], out bRet) == false) return bDefValue;
        return bRet;
    }

    public static bool GetBool(string sName)
    {
        return GetBool(sName, false);
    }
}
