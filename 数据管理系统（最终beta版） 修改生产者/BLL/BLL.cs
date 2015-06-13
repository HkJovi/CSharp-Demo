using System;
using System.Data;
using System.Data.SqlClient;
using Dal;
using CCWin;
using System.Collections.Generic;

namespace Bll
{
	public class BLL
	{
		public static int GetPowerID(string uname, string upwd)  //得到登陆权限ID
		{
			DataRow dr = DAL.GetRow(@"SELECT * FROM t_user where uname = @Uname AND upwd=@Upwd AND uzt=1",
				                              new SqlParameter("Uname",uname), new SqlParameter("Upwd",upwd));
			if (dr == null)
				return -1;  //代表登陆用户或者密码错误
			else
				return (int)dr["uqxz"];
		}

		public static int CheckSQLConnecting()  //检查连接状态 1分钟一次 成功返回1，失败返回0
		{
			try
			{
				SqlConnection sqlcon = DAL.CreateConnection();
				sqlcon.Close();
				return 1;
			}
			catch
			{
				return 0;
			}
			
		}

		public static int XGpwd(string uname, string oldpwd ,string newpwd) //修改密码  修改成功返回1
		{
			return DAL.ExecuteSQL("UPDATE t_user SET upwd= @pwd WHERE uname=@Uname AND upwd=@oldpwd", new SqlParameter("pwd", newpwd),
				new SqlParameter("Uname", uname), new SqlParameter("oldpwd", oldpwd));
		}

		public static DataTable GetsczglListBox()  //获取生产者列表
		{
           return DAL.GetTable(@"SELECT scz FROM t_scz");
		}
		
		public static DataTable GetKeysczglListBox(string keyword)  //关键字查找生产者列表
		{
			string Keyword = "%" + keyword + "%";
			return DAL.GetTable(@"SELECT scz FROM t_scz WHERE scz LIKE @Keyword",new SqlParameter("Keyword",Keyword));
		}

		public static DataTable GetCzListBox()  //获取材质列表
		{
			return DAL.GetTable(@"SELECT czmc FROM t_czb");
		}

		public static DataTable GetGhListBox()  //获取工号列表
		{
			return DAL.GetTable(@"SELECT gh FROM t_ggb");
		}

		public static int SczglXg(string oldname, string newname)  //修改生产者的名称
		{
			return DAL.ExecuteSQL(@"UPDATE t_scz SET scz =@newname WHERE scz=@oldname",
				new SqlParameter("newname",newname),new SqlParameter("oldname",oldname));
		}

		public static int SczglXz(string newscz) //新增生产者
		{
			return DAL.ExecuteSQL(@"INSERT INTO t_scz (scz) VALUES (@Newscz)",
				new SqlParameter("Newscz", newscz));
		}

		public static int CzXg(string oldname, string newname)  //修改材质名称
		{
			return DAL.ExecuteSQL(@"UPDATE t_czb SET czmc =@newname WHERE czmc=@oldname",
				new SqlParameter("newname", newname), new SqlParameter("oldname", oldname));
		}

		public static int CzXz(string newcz) //新增材质
		{
			return DAL.ExecuteSQL(@"INSERT INTO t_czb (czmc) VALUES (@Newcz)",
				new SqlParameter("Newcz", newcz));
		}

		public static DataTable GetghListBox(string keyword)  //获得模糊查询工号的listbox
		{
			string Keyword = "%" + keyword + "%";
			return DAL.GetTable(@"SELECT gh FROM t_ggb WHERE gh LIKE @Keyword", new SqlParameter("Keyword", Keyword));
		}

		public static DataTable GetczListBox(string keyword)  //获得模糊查询材质的listbox
		{
			string Keyword = "%" + keyword + "%";
			return DAL.GetTable(@"SELECT czmc FROM t_czb WHERE czmc LIKE @Keyword", new SqlParameter("Keyword", Keyword));
		}

		public static DataTable GetbelongSczListBox(string keyword)  //获得模糊查询材质的listbox
		{
			string Keyword = "%" + keyword + "%";
			return DAL.GetTable(@"SELECT scz FROM t_scz WHERE scz LIKE @Keyword", new SqlParameter("Keyword", Keyword));
		}

		public static bool CheckSczIsEmpty(string scz) //检查生产者提交表达是否正确  正确返回false
		{
			DataTable dt = new DataTable();
			dt = GetsczglListBox();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (scz.Trim() == dt.Rows[i][0].ToString().Trim())
					return false;
			}
			return true;
		}

		public static bool CheckCzIsEmpty(string cz) //检查材质表达是否正确 正确返回false
		{
			DataTable dt = new DataTable();
			dt = GetCzListBox();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (cz.ToLower().Trim() == dt.Rows[i][0].ToString().ToLower().Trim())
					return false;
			}
			return true;
		}

		public static bool CheckGhIsEmpty(string cz) //检查工号表达是否正确 正确返回false
		{
			DataTable dt = new DataTable();
			dt = GetGhListBox();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (cz.ToLower().Trim() == dt.Rows[i][0].ToString().ToLower().Trim())
					return false;
			}
			return true;
		}

		public static int Addgg(string gh, string mc, string gg, string th, string sbh, string cz, string dz, string sl, string bz, string belongkh) //添加新的规格
		{
			if(bz!="")
			return DAL.ExecuteSQL(@"INSERT INTO t_ggb (gh,mc,gg,th,sbh,cz,dz,sl,bz,belongkh) VALUES (@Gh,@Mc,@Gg,@Th,@Sbh,@Cz,@Dz,@Sl,@Bz,@Belongkh)",
				new SqlParameter("Gh", gh), new SqlParameter("Mc", mc), new SqlParameter("Gg", gg),
				new SqlParameter("Th", th), new SqlParameter("Sbh", sbh), new SqlParameter("Cz", cz),
				new SqlParameter("Dz", dz), new SqlParameter("Sl", sl), new SqlParameter("Bz", bz), new SqlParameter("Belongkh",belongkh));
			else
				return DAL.ExecuteSQL(@"INSERT INTO t_ggb (gh,mc,gg,th,sbh,cz,dz,sl,belongkh) VALUES (@Gh,@Mc,@Gg,@Th,@Sbh,@Cz,@Dz,@Sl,@Belongkh)",
				new SqlParameter("Gh", gh), new SqlParameter("Mc", mc), new SqlParameter("Gg", gg),
				new SqlParameter("Th", th), new SqlParameter("Sbh", sbh), new SqlParameter("Cz", cz),
				new SqlParameter("Dz", dz), new SqlParameter("Sl", sl), new SqlParameter("Belongkh", belongkh));
		}

		public static int Xggg(string gh, string mc, string gg, string th, string sbh, string cz, string dz, string sl, string bz, string belongkh) //修改规格
		{
			if(bz=="")
			return DAL.ExecuteSQL(@"UPDATE t_ggb SET mc=@Mc,gg=@Gg,th=@Th,sbh=@Sbh,cz=@Cz,dz=@Dz,sl=@Sl,bz=Null,belongkh=@Belongkh WHERE gh =@Gh ",
				new SqlParameter("Gh", gh), new SqlParameter("Mc", mc), new SqlParameter("Gg", gg),
				new SqlParameter("Th", th), new SqlParameter("Sbh", sbh), new SqlParameter("Cz", cz),
				new SqlParameter("Dz", dz), new SqlParameter("Sl", sl), new SqlParameter("Bz", bz), new SqlParameter("Belongkh", belongkh));
			else
				return DAL.ExecuteSQL(@"UPDATE t_ggb SET mc=@Mc,gg=@Gg,th=@Th,sbh=@Sbh,cz=@Cz,dz=@Dz,sl=@Sl,bz=@Bz,belongkh=@Belongkh WHERE gh =@Gh ",
				new SqlParameter("Gh", gh), new SqlParameter("Mc", mc), new SqlParameter("Gg", gg),
				new SqlParameter("Th", th), new SqlParameter("Sbh", sbh), new SqlParameter("Cz", cz),
				new SqlParameter("Dz", dz), new SqlParameter("Sl", sl), new SqlParameter("Bz", bz), new SqlParameter("Belongkh", belongkh));
		}

		public static DataSet GetDataGridViewList(string cmdtext,params SqlParameter[] sp)  //datagridview模糊查找
		{
			SqlConnection con = new SqlConnection("user id=sa;pwd=123456;Server=(local);Initial Catalog=bst;");    
			SqlCommand cmd=new SqlCommand ();
			cmd.CommandText = cmdtext;
			cmd.Parameters.AddRange(sp);
			cmd.Connection = con;
			SqlDataAdapter objDataAdapter = new SqlDataAdapter(cmd);
			DataSet objDataSet = new DataSet();
			objDataAdapter.Fill(objDataSet);
			return objDataSet;			
		}

		public static DataSet GetDataGridViewList(string cmdtext)  //datagridview模糊查找
		{
			SqlConnection con = new SqlConnection("user id=sa;pwd=123456;Server=(local);Initial Catalog=bst;");
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = cmdtext;
			cmd.Connection = con;
			SqlDataAdapter objDataAdapter = new SqlDataAdapter(cmd);
			DataSet objDataSet = new DataSet();
			objDataAdapter.Fill(objDataSet);
			return objDataSet;
		}
		
		public static void GetRange(string StrRange,out float low,out float high)  //得到范围表达式
		{
			int i = StrRange.IndexOf("^");
			if (i == -1)
			{
				low = -1;
				high = -1;
				return;
			}
			try
			{
				low = float.Parse(StrRange.Substring(0, i));
				high = float.Parse(StrRange.Trim().Substring(i + 1));
			}
			catch
			{
				low = -1;
				high = -1;
				return;
			}
		}

		public static DataRow GetExpressghxx(string gh)  //根据工号名快速添加生产信息
		{
			try
			{
				return DAL.GetRow(@"SELECT cz,dz,bz from t_ggb WHERE gh =@Gh", new SqlParameter("Gh", gh));
			}
			catch
			{
				return null;
			}
		}

		public static int Addsc(string gh, string cz, string dz, string sl, string producter, string bz,string sj) //添加新的生产
		{
			if (bz != "")
				return DAL.ExecuteSQL(@"INSERT INTO t_scb (gh,cz,dz,sl,producter,bz,sj)  VALUES (@Gh,@Cz,@Dz,@Sl,@Producter,@Bz,@Sj)",
					new SqlParameter("Gh", gh), new SqlParameter("Cz", cz), new SqlParameter("Dz", dz),
					new SqlParameter("Sl", sl), new SqlParameter("Producter", producter), new SqlParameter("Bz", bz),
					new SqlParameter("Sj", sj));
			else
				return DAL.ExecuteSQL(@"INSERT INTO t_scb (gh,cz,dz,sl,producter,bz,sj)  VALUES (@Gh,@Cz,@Dz,@Sl,@Producter,NULL,@Sj)",
					new SqlParameter("Gh", gh), new SqlParameter("Cz", cz), new SqlParameter("Dz", dz),
					new SqlParameter("Sl", sl), new SqlParameter("Producter", producter),
					new SqlParameter("Sj", sj));
		}

		public static int Xgsc(string id, string gh, string cz, string dz, string sl, string producter, string bz, string sj) //修改生产
		{
			if (bz != "")
				return DAL.ExecuteSQL(@"UPDATE t_scb SET  gh=@Gh,cz=@Cz,dz=@Dz,sl=@Sl,producter=@Producter,bz=@Bz,sj=@Sj where id = @Id",
					new SqlParameter("Gh", gh), new SqlParameter("Cz", cz), new SqlParameter("Dz", dz),
					new SqlParameter("Sl", sl), new SqlParameter("Producter", producter), new SqlParameter("Bz", bz),
					new SqlParameter("Sj", sj),new SqlParameter("Id",id));
			else
				return DAL.ExecuteSQL(@"UPDATE t_scb SET  gh=@Gh,cz=@Cz,dz=@Dz,sl=@Sl,producter=@Producter,bz=NULL,sj=@Sj where id = @Id",
					new SqlParameter("Gh", gh), new SqlParameter("Cz", cz), new SqlParameter("Dz", dz),
					new SqlParameter("Sl", sl), new SqlParameter("Producter", producter),
					new SqlParameter("Sj", sj), new SqlParameter("Id", id));
		}

		public static int Scsc(string id) //删除生产
		{			
				return DAL.ExecuteSQL(@"DELETE FROM t_scb WHERE id = @Id",new SqlParameter("Id", id));			
		}

		public static string GetResult(DataTable dt)  //获得统计结果
		{
			List<string> List_ghcz = new List<string>();
			List<float> List_zl=new List<float>();
			float sum=0;
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (!List_ghcz.Contains(dt.Rows[i]["工号"].ToString() + "—" + dt.Rows[i]["材质"].ToString()))
				{
					List_ghcz.Add(dt.Rows[i]["工号"].ToString() + "—" + dt.Rows[i]["材质"].ToString());
					List_zl.Add(0);
				}
			}
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				int index = List_ghcz.IndexOf(dt.Rows[i]["工号"].ToString() + "—" + dt.Rows[i]["材质"].ToString());
				List_zl[index] += float.Parse(dt.Rows[i]["总重"].ToString());
				sum+= float.Parse(dt.Rows[i]["总重"].ToString());
			}
			string result ="";
			for (int i = 0; i < List_ghcz.Count; i++)
			{
				result = result + List_ghcz[i].ToString()+" 总重为： "+List_zl[i].ToString() +"\r\n";
			}
			result = result + "合计： " + sum;
			return result;
		}

		public static int AddLog(string czmc, string czms, string czuser, string czsj)  //添加操作日志
		{
			return DAL.ExecuteSQL("INSERT INTO t_log (czmc,czms,czuser,czsj) VALUES (@Czmc,@Czms,@Czuser,@Czsj)",new SqlParameter("Czmc",czmc),
				new SqlParameter("Czms",czms),new SqlParameter("Czuser",czuser),new SqlParameter("Czsj",czsj));
		}

		public static DataTable GetUserList() //获得用户列表
		{
			return DAL.GetTable("SELECT uname from t_user");
		}

		public static int Scuser(string uname)  //删除用户
		{
			return DAL.ExecuteSQL(@"DELETE FROM t_user WHERE uname =@Uname", new SqlParameter("Uname", uname));
		}

		public static DataRow GetUserInfo(string uname)  //得到用户信息
		{
			return DAL.GetRow("SELECT * FROM t_user WHERE uname =@Uname", new SqlParameter("Uname", uname));
		}

		public static int XgUser(string uname,string uqxz,string uzt) //修改用户信息
		{
			return DAL.ExecuteSQL(@"UPDATE t_user SET uqxz = @Uqxz,uzt=@Uzt WHERE uname=@Uname",new SqlParameter("Uqxz",uqxz),
				new SqlParameter("Uzt",uzt),new SqlParameter("Uname",uname));
		}

		public static int AddUser(string uname, string upwd, string uqxz, string uzt) //添加用户
		{
			return DAL.ExecuteSQL(@"INSERT INTO t_user (uname,upwd,uqxz,uzt) VALUES(@Uname,@Upwd,@Uqxz,@Uzt)", new SqlParameter("Uqxz", uqxz),
				new SqlParameter("Uzt", uzt), new SqlParameter("Uname", uname), new SqlParameter("Upwd", upwd));
		}
	}
}
