using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message : System.Web.UI.Page
{
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    public int newmesgcount
    {
        get
        {
            return Cls.CheckNEW();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (newmesgcount == 1)
        {
            this.LinkButton_new.Text = Cls.GetTop1MesgName();
            this.LinkButton_new.Visible = true;
        }
    }



    protected void LinkButton_new_Click(object sender, EventArgs e)
    {
        JScript.Redirect("/Message_text.aspx?xjid=" + Cls.GetTopMesgID());
    }
}