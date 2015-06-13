using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// LinkSQL 的摘要说明
/// </summary>
public class DB
{
	   public static SqlConnection CreateConnection()
	{
        string strConnection = "user id=sa;pwd=123456;";
        strConnection += "Server=(local);Initial Catalog=MIS;";
        SqlConnection con = new SqlConnection(strConnection);
        con.Open();
        return con;
	}

       public static int ExecuteSQL(string sSQL, params SqlParameter[] ps)
       {
           SqlConnection conn = CreateConnection();
           try
           {
               SqlCommand cmd = new SqlCommand(sSQL, conn);
               cmd.Parameters.AddRange(ps);
               return cmd.ExecuteNonQuery();
           }
           finally
           {
               conn.Close();
           }
       }

       public static DataTable GetTable(string sSelectSQL, params SqlParameter[] ps)
       {
           SqlConnection conn = CreateConnection();
           try
           {
               SqlCommand cmd = new SqlCommand(sSelectSQL, conn);
               cmd.Parameters.AddRange(ps);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               return dt;
           }
           finally
           {
               conn.Close();
           }
       }

       public static int UpdateTable(string sSelectSQL, DataTable dt)
       {
           SqlConnection conn = CreateConnection();
           try
           {
               SqlCommand cmd = new SqlCommand(sSelectSQL, conn);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               SqlCommandBuilder cb = new SqlCommandBuilder(da);
               return da.Update(dt);
           }
           finally
           {
               conn.Close();
           }
       }

       public static DataRow GetRow(string sSelectSQL, params SqlParameter[] ps)
       {
           DataTable dt = GetTable(sSelectSQL, ps);
           return dt.Rows.Count > 0 ? dt.Rows[0] : null;
       }

       public static object ExecuteScalar(string sSelectSQL, params SqlParameter[] ps)
       {
           SqlConnection conn = CreateConnection();
           try
           {
               SqlCommand cmd = new SqlCommand(sSelectSQL, conn);
               cmd.Parameters.AddRange(ps);
               return cmd.ExecuteScalar();
           }
           finally
           {
               conn.Close();
           }
       }

       public static SqlDataReader GetReader(string sSelectSQL, params SqlParameter[] ps)
       {
           SqlConnection conn = CreateConnection();
           try
           {
               SqlCommand cmd = new SqlCommand(sSelectSQL, conn);
               cmd.Parameters.AddRange(ps);
               return cmd.ExecuteReader();
           }
           finally
           {
           }
       }
       /// <summary>
       /// 根据SQL语言返回指定页的记录阅读器，目前只支持由空格作为分格符的SQL查询语句
       /// 如：select 字段列表/* from ... where (条件) ...
       /// 注意，查询必须要有where子句，条件必须要用括号括起
       /// where以后的地方包含where关键字时请消除where后面的空格
       /// </summary>
       /// <param name="sSelectSQL"></param>
       /// <param name="KeyName"></param>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="ps"></param>
       /// <returns></returns>
       public static SqlDataReader GetPagedReader(string sSelectSQL, string KeyName, int PageIndex, int PageSize, params SqlParameter[] ps)
       {
           if (PageIndex < 0 || PageSize <= 0) return GetReader(sSelectSQL, ps);
           sSelectSQL = sSelectSQL.ToUpper();
           KeyName = KeyName.ToUpper();
           int iSelect = sSelectSQL.IndexOf("SELECT ");
           int ib = sSelectSQL.IndexOf(" FROM ");
           int ie = sSelectSQL.LastIndexOf(" WHERE ");
           string sFieldList = sSelectSQL.Substring(iSelect + 6, ib - iSelect - 5);
           string sFrom = sSelectSQL.Substring(ib, ie - ib + 1);
           string sWhere = sSelectSQL.Substring(ie + 6);
           string s = "(" + KeyName + " NOT IN (SELECT TOP " + (PageIndex * PageSize).ToString() + " " + KeyName + sSelectSQL.Substring(ib) + ")) AND ";
           s = "SELECT TOP " + PageSize.ToString() + " " + sFieldList + " " + sFrom + " WHERE " + s + sWhere;
           return GetReader(s, ps);
       }

       /// <summary>
       /// 根据SQL语言返回指定页的记录集，目前只支持由空格作为分格符的SQL查询语句
       /// 如：select 字段列表/* from ... where (条件) ...
       /// 注意，查询必须要有where子句，条件必须要用括号括起
       /// where以后的地方包含where关键字时请消除where后面的空格
       /// </summary>
       /// <param name="sSelectSQL"></param>
       /// <param name="KeyName"></param>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="ps"></param>
       /// <returns></returns>
       public static DataTable GetPagedTable(string sSelectSQL, string KeyName, int PageIndex, int PageSize, params SqlParameter[] ps)
       {
           if (PageIndex < 0 || PageSize <= 0) return GetTable(sSelectSQL, ps);
           sSelectSQL = sSelectSQL.ToUpper();
           KeyName = KeyName.ToUpper();
           int iSelect = sSelectSQL.IndexOf("SELECT ");
           int ib = sSelectSQL.IndexOf(" FROM ");
           int ie = sSelectSQL.LastIndexOf(" WHERE ");
           string sFieldList = sSelectSQL.Substring(iSelect + 6, ib - iSelect - 5);
           string sFrom = sSelectSQL.Substring(ib, ie - ib + 1);
           string sWhere = sSelectSQL.Substring(ie + 6);
           string s = "(" + KeyName + " NOT IN (SELECT TOP " + (PageIndex * PageSize).ToString() + " " + KeyName + sSelectSQL.Substring(ib) + ")) AND ";
           s = "SELECT TOP " + PageSize.ToString() + " " + sFieldList + " " + sFrom + " WHERE " + s + sWhere;
           return GetTable(s, ps);
       }
}

public class DBCls
{
    private SqlConnection m_Conn;
    private SqlCommand m_Cmd;
    private SqlDataAdapter m_Da;
   

    private void Init(string sConnString)
    {
        m_Conn = new SqlConnection(sConnString);
        m_Conn.Open();
        m_Cmd = new SqlCommand("", m_Conn);
        m_Da = new SqlDataAdapter(m_Cmd);
    }

    public DBCls()
    {
        string strConnection = "user id=sa;pwd=123456;";
        strConnection += "Server=(local);Initial Catalog=MIS;";
        Init(strConnection);  //连接写在类里面
    }

    //public DBCls(string sConnStrOrConfig, bool bIsConfigName)
    //{
    //    string s = "";
    //    if (bIsConfigName)
    //    {
    //        s = ConfigurationManager.ConnectionStrings[sConnStrOrConfig].ConnectionString;
    //    }
    //    else
    //    {
    //        s = sConnStrOrConfig;
    //    }
    //    Init(s);
    //}

    /*
        //m_Conn可能已经被GC自动回收了。所以不能close。C#析构函数仅用于非托管的回收
        ~DBCls()
        {
            Close();
        }
    */
    public void Close()
    {
        if (m_Conn.State == ConnectionState.Open) m_Conn.Close();
    }

    public DataTable GetTable(string sSelectSQL, params SqlParameter[] ps)
    {
        DataTable dt = new DataTable();
        m_Cmd.Parameters.Clear();
        m_Cmd.CommandText = sSelectSQL;
        m_Cmd.Parameters.AddRange(ps);
        m_Da.Fill(dt);
        return dt;
    }

    public SqlDataReader GetReader(string sSelectSQL, params SqlParameter[] ps)
    {
        m_Cmd.Parameters.Clear();
        m_Cmd.CommandText = sSelectSQL;
        m_Cmd.Parameters.AddRange(ps);
        return m_Cmd.ExecuteReader();
    }

    public SqlDataReader GetNewReader(string sSelectSQL, params SqlParameter[] ps)
    {
        SqlConnection conn = new SqlConnection(m_Conn.ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sSelectSQL, conn);
        cmd.Parameters.AddRange(ps);
        return cmd.ExecuteReader();
    }

    public DataRow GetRow(string sSelectSQL, params SqlParameter[] ps)
    {
        DataTable dt = GetTable(sSelectSQL, ps);
        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
    }

    public object ExecuteScalar(string sSelectSQL, params SqlParameter[] ps)
    {
        m_Cmd.CommandText = sSelectSQL;
        m_Cmd.Parameters.Clear();
        m_Cmd.Parameters.AddRange(ps);
        return m_Cmd.ExecuteScalar();
    }

    public int ExecuteSQL(string sSQL, params SqlParameter[] ps)
    {
        m_Cmd.CommandText = sSQL;
        m_Cmd.Parameters.Clear();
        m_Cmd.Parameters.AddRange(ps);
        return m_Cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// 根据SQL语言返回指定页的记录阅读器，目前只支持由空格作为分格符的SQL查询语句
    /// 如：select 字段列表/* from ... where (条件) ...
    /// 注意，查询必须要有where子句，条件必须要用括号括起
    /// where以后的地方包含where关键字时请消除where后面的空格
    /// </summary>
    /// <param name="sSelectSQL"></param>
    /// <param name="KeyName"></param>
    /// <param name="PageIndex"></param>
    /// <param name="PageSize"></param>
    /// <param name="ps"></param>
    /// <returns></returns>
    public SqlDataReader GetPagedReader(string sSelectSQL, string KeyName, int PageIndex, int PageSize, params SqlParameter[] ps)
    {
        if (PageIndex < 0 || PageSize <= 0) return GetReader(sSelectSQL, ps);
        sSelectSQL = sSelectSQL.ToUpper();
        KeyName = KeyName.ToUpper();
        int iSelect = sSelectSQL.IndexOf("SELECT ");
        int ib = sSelectSQL.IndexOf(" FROM ");
        int ie = sSelectSQL.LastIndexOf(" WHERE ");
        string sFieldList = sSelectSQL.Substring(iSelect + 6, ib - iSelect - 5);
        string sFrom = sSelectSQL.Substring(ib, ie - ib + 1);
        string sWhere = sSelectSQL.Substring(ie + 6);
        string s = "(" + KeyName + " NOT IN (SELECT TOP " + (PageIndex * PageSize).ToString() + " " + KeyName + sSelectSQL.Substring(ib) + ")) AND ";
        s = "SELECT TOP " + PageSize.ToString() + " " + sFieldList + " " + sFrom + " WHERE " + s + sWhere;
        return GetReader(s, ps);
    }

    /// <summary>
    /// 根据SQL语言返回指定页的记录阅读器，目前只支持由空格作为分格符的SQL查询语句
    /// 如：select 字段列表/* from ... where (条件) ...
    /// 注意，查询必须要有where子句，条件必须要用括号括起
    /// where以后的地方包含where关键字时请消除where后面的空格
    /// </summary>
    /// <param name="sSelectSQL"></param>
    /// <param name="KeyName"></param>
    /// <param name="PageIndex"></param>
    /// <param name="PageSize"></param>
    /// <param name="ps"></param>
    /// <returns></returns>
    public SqlDataReader GetPagedNewReader(string sSelectSQL, string KeyName, int PageIndex, int PageSize, params SqlParameter[] ps)
    {
        if (PageIndex < 0 || PageSize <= 0) return GetNewReader(sSelectSQL, ps);
        sSelectSQL = sSelectSQL.ToUpper();
        KeyName = KeyName.ToUpper();
        int iSelect = sSelectSQL.IndexOf("SELECT ");
        int ib = sSelectSQL.IndexOf(" FROM ");
        int ie = sSelectSQL.LastIndexOf(" WHERE ");
        string sFieldList = sSelectSQL.Substring(iSelect + 6, ib - iSelect - 5);
        string sFrom = sSelectSQL.Substring(ib, ie - ib + 1);
        string sWhere = sSelectSQL.Substring(ie + 6);
        string s = "(" + KeyName + " NOT IN (SELECT TOP " + (PageIndex * PageSize).ToString() + " " + KeyName + sSelectSQL.Substring(ib) + ")) AND ";
        s = "SELECT TOP " + PageSize.ToString() + " " + sFieldList + " " + sFrom + " WHERE " + s + sWhere;
        return GetNewReader(s, ps);
    }


    /// <summary>
    /// 根据SQL语言返回指定页的记录集，目前只支持由空格作为分格符的SQL查询语句
    /// 如：select 字段列表/* from ... where (条件) ...
    /// 注意，查询必须要有where子句，条件必须要用括号括起
    /// where以后的地方包含where关键字时请消除where后面的空格
    /// </summary>
    /// <param name="sSelectSQL"></param>
    /// <param name="KeyName"></param>
    /// <param name="PageIndex"></param>
    /// <param name="PageSize"></param>
    /// <param name="ps"></param>
    /// <returns></returns>
    public DataTable GetPagedTable(string sSelectSQL, string KeyName, int PageIndex, int PageSize, params SqlParameter[] ps)
    {
        if (PageIndex < 0 || PageSize <= 0) return GetTable(sSelectSQL, ps);
        sSelectSQL = sSelectSQL.ToUpper();
        KeyName = KeyName.ToUpper();
        int iSelect = sSelectSQL.IndexOf("SELECT ");
        int ib = sSelectSQL.IndexOf(" FROM ");
        int ie = sSelectSQL.LastIndexOf(" WHERE ");
        string sFieldList = sSelectSQL.Substring(iSelect + 6, ib - iSelect - 5);
        string sFrom = sSelectSQL.Substring(ib, ie - ib + 1);
        string sWhere = sSelectSQL.Substring(ie + 6);
        string s = "(" + KeyName + " NOT IN (SELECT TOP " + (PageIndex * PageSize).ToString() + " " + KeyName + sSelectSQL.Substring(ib) + ")) AND ";
        s = "SELECT TOP " + PageSize.ToString() + " " + sFieldList + " " + sFrom + " WHERE " + s + sWhere;
        return GetTable(s, ps);
    }

}