using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class admin_HF : System.Web.UI.Page
{
    public DataRow g_xj = null;
    public int g_xjid = 0;
    public string g_hfnr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        g_xjid = QueryParams.GetInt("xjid");
        if (g_xjid == 0) JScript.MsgBoxAndGoBack("错误的参数！");

        g_xj = AdminCls.GetXJAllInfo(g_xjid);
        if (g_xj == null) JScript.MsgBoxAndGoBack("错误的参数！");

        int n = AdminCls.CanHF(g_xj);
        if (n == 0) JScript.MsgBoxAndGoBack("错误的参数！");

        btTJ.Visible = (n == 2);

        g_hfnr = Request.Form["txtnr"];

        if (!IsPostBack)
        {
            txtbt.Text = g_xj["bt"].ToString();
            txtbm.Items.Clear();
            AdminCls.FillTreeList(txtbm);
            if (g_xj["lbid"].ToString() != "") txtlb.SelectedValue = g_xj["lbid"].ToString();
            rbYes.Checked = g_xj["gkbz"].ToString() == "1";
            rbNo.Checked = !rbYes.Checked;
            cbHot.Checked = g_xj["hot"].ToString().Trim() == "1";


            string sfjName = g_xj["fj"].ToString();
            if (sfjName == "")
            {
                btDownFJ.Visible = false;
            }
            else
            {
                btDownFJ.Visible = true;
                btDownFJ.NavigateUrl = "../UserFiles/" + sfjName;
            }
        }
    }

    public string GetHFNR()
    {
        return BLL.HE(g_hfnr);
    }

    public string GetInfo(string fn)
    {
        string s = g_xj[fn].ToString();
        return BLL.HE(s);
    }

    protected void btTJ_Click(object sender, EventArgs e)
    {
        //0直处 1转级别 2转人
        string zjbz = txtzjbz.SelectedValue == "1" ? "0" : (string.IsNullOrEmpty(txtuser.SelectedValue) ? "1" : "2");
        if (zjbz == "0")
        {
            if (string.IsNullOrEmpty(txtlb.SelectedValue))
            {
                JScript.MsgBox(this, "请选择信件的类型，为信件进行分类！");
                return;
            }
        }

        if (string.IsNullOrEmpty(g_hfnr))
        {
            JScript.MsgBox(this, "请输入要回复的内容，您可以直接插入模板快速回复！");
            return;
        }

        string bt = txtbt.Text.Trim();
        int zjhfjb = zjbz == "1" ? int.Parse(txtbm.SelectedValue) : -1;
        string zjhfr = zjbz == "2" ? txtuser.SelectedValue : "";
        int lbid = string.IsNullOrEmpty(txtlb.SelectedValue) ? -1 : int.Parse(txtlb.SelectedValue);
        string gkbz = rbNo.Checked ? "0" : "1";

        DataRow dr = BLL.GetTableRow("t_hf", "hfid", null);
        dr["xjid"] = g_xjid;
        dr["hfr"] = SXMGR.strSession["udm"];
        dr["hfsj"] = DateTime.Now;
        dr["hfnr"] = g_hfnr;
        dr["hfip"] = BLL.GetRealIP();
        dr["zjbz"] = zjbz;
        //dr["hfpj"] = hfpj;
        //dr["hfpf"] = hfpf;
        //dr["pjsj"] = pjsj;
        //dr["pjip"] = pjip;
        //dr["hfbz"] = hfbz;
        dr["zjfrom"] = zjbz == "0" ? "" : SXMGR.strSession["udm"];
        dr["zjhfr"] = zjhfr;
        dr["zjhfjb"] = zjhfjb;
        dr["hftxt"] = g_hfnr;
        BLL.UpdateSingleRow(dr);

        int hfid = Convert.ToInt32(DB.ExecuteScalar("select IDENT_CURRENT('t_hf')"));

        dr = BLL.GetTableRow("t_xj", "xjid", g_xjid);
        if (lbid != -1) dr["lbid"] = lbid;
        dr["bt"] = bt;
        dr["ztdm"] = zjbz == "0" ? "3" : "2";
        dr["xdbz"] = gkbz;
        dr["hfid"] = hfid;
        dr["zjhfr"] = zjhfr;
        dr["zjhfjb"] = zjhfjb;
        //dr["gkbz"] = gkbz;
        dr["hot"] = cbHot.Checked ? "1" : "0";
        BLL.UpdateSingleRow(dr);

        lstHF.DataBind();
        JScript.MsgBox(this, "回复成功！");
    }

    protected void btmb_Click(object sender, EventArgs e)
    {
        if (txtmb.SelectedItem == null)
        {
            JScript.MsgBox(this, "请先选择要插入的模板!");
            return;
        }

        string si = DB.ExecuteScalar("select mbnr from t_mb where mbid=@mbid", new SqlParameter("mbid", txtmb.SelectedValue)).ToString();
        if (string.IsNullOrEmpty(si)) JScript.MsgBoxAndGoBack("请先选择要插入的模板!");

        MatchCollection mc = Regex.Matches(si, "%.+?%", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        foreach (Match m in mc)
        {
            string s = m.Value.Substring(1, m.Value.Length - 2);
            try
            {
                si = si.Replace(m.Value, g_xj[s].ToString());
            }
            catch { }
        }

        if ( txtzjbz.SelectedValue=="2")
        {
            string s = txtbm.SelectedItem.Text;
            if (txtuser.SelectedValue != "") s += txtuser.SelectedItem.Text;
            si = si.Replace("%zjTo%", s);
        }

        g_hfnr = si;
    }
    protected void SqlDataSource4_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        txtuser.Items.Clear();
        txtuser.Items.Add(new ListItem("所有用户", ""));
    }

}