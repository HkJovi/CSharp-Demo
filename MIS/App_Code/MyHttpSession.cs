using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;

public class MyHttpSession<T>
{
    private bool m_TryConvert = false;

    public MyHttpSession()
    {
    }

    public MyHttpSession(bool bTryConvert)
    {
        m_TryConvert = bTryConvert;
    }

    public T this[string fn, T DefVal]
    {
        get
        {
            object v = HttpContext.Current.Session[fn];
            if (v == null) return DefVal;

            Type ct = typeof(T);
            if (v.GetType() == ct) return (T)v;
            if (ct == typeof(string)) return (T)(object)v.ToString();
            if (m_TryConvert == false) return (T)v;

            //尝试转换
            try
            {
                MethodInfo mi = ct.GetMethod("Parse", new Type[] { typeof(string) });
                return (T)mi.Invoke(null, new object[] { v.ToString() });
            }
            catch
            {
                return (T)v;
            }
        }
        set
        {
            HttpContext.Current.Session[fn] = value;
        }
    }

    public T this[string fn]
    {
        get
        {
            if (typeof(T) == typeof(string)) return this[fn, (T)(object)string.Empty];
            //添加其它类型默认值在这里
            return this[fn, default(T)];
        }
        set
        {
            HttpContext.Current.Session[fn] = value;
        }
    }
}

public static class SXMGR
{
    public static MyHttpSession<string> strSession
    {
        get { return new MyHttpSession<string>(true); }
    }

    public static MyHttpSession<char> chrSession
    {
        get { return new MyHttpSession<char>(true); }
    }

    public static MyHttpSession<int> intSession
    {
        get { return new MyHttpSession<int>(true); }
    }

    public static MyHttpSession<long> lngSession
    {
        get { return new MyHttpSession<long>(true); }
    }

    public static MyHttpSession<float> fltSession
    {
        get { return new MyHttpSession<float>(true); }
    }

    public static MyHttpSession<double> dblSession
    {
        get { return new MyHttpSession<double>(true); }
    }

    public static MyHttpSession<decimal> decSession
    {
        get { return new MyHttpSession<decimal>(true); }
    }

    public static MyHttpSession<DateTime> dtSession
    {
        get { return new MyHttpSession<DateTime>(true); }
    }

    public static MyHttpSession<object> objSession
    {
        get { return new MyHttpSession<object>(true); }
    }

    //在这里添加其它类型的Session
}