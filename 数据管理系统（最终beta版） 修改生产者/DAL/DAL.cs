using System;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
	public class DAL
	{
		public static SqlConnection CreateConnection()
		{
			string strConnection = "user id=sa;pwd=123456;";
			strConnection += "Server=(local);Initial Catalog=bst;";
			SqlConnection con = new SqlConnection(strConnection);
			con.Open();
			return con;
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

	}
}
