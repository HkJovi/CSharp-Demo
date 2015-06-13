using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /////////////////是否开启注册功能/////////////////////////////////////////
        int flag=0;
        flag = Convert.ToInt32(DB.ExecuteScalar("select zcbz from t_zczt"));
        if(flag ==0)  //标志为0则关闭注册
        JScript.MsgBoxAndRedirect("已经关闭注册,请联系管理员", "/Login.aspx");

    }
    protected void ImageButton_Reg_Click(object sender, ImageClickEventArgs e)
    {
        int flag = 0;   //是否编号和身份匹配的标志
        string BH = TB_BH.Text.Trim();
        string ZH = TB_ZH.Text.Trim();
        string MM = TB_MM.Text;
        if (BH == "" || ZH == "" || MM == "")
        {
            JScript.MsgBox(this, "请输入完整的注册信息");
            return;
        }

        //获取注册许可  验证方式： 编号+身份匹配
        flag = Convert.ToInt32( DB.ExecuteScalar("select COUNT(*) from t_ID where ID=@ID and IDsf=(select sfid from t_sf where sfmc=@sfmc)", new SqlParameter("ID", BH), new SqlParameter("sfmc", Drlt_sf.Text)));  //查询身份和编号是否正确
        if (flag == 0)
            JScript.MsgBox(this, "注册失败！请检查编号和身份是否匹配.");

        //许可允许,转入注册
        else
        {
            //检测是否被注册
            int flag2 ; //是否注册标志
            flag2 = Convert.ToInt32(DB.ExecuteScalar("select COUNT(uID) from t_User where uID=@ID or uZH=@ZH", new SqlParameter("ID", BH),new SqlParameter("ZH",ZH)));

            if (flag2 != 0)
            {
                JScript.MsgBox(this, "编号或者账号已被注册,请重新输入！");
            }
            else  //连接数据库注册
            {
                int i =DB.ExecuteSQL("insert into t_User(uZH,uPW,uID,uJBZ,uSF,uZT) select @ZH,@MM, ID,IDjbz,IDsf,IDzt from t_ID where ID=@BH", new SqlParameter("ZH", ZH), new SqlParameter("MM", MM), new SqlParameter("BH", BH));
                if (i > 0)  //返回影响行数
                    JScript.MsgBoxAndRedirect("注册成功", "/Login.aspx");
                else
                    JScript.MsgBox(this, "注册失败请重试！");
            }

        }
           
    }
}