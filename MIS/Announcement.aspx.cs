﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Announcement : System.Web.UI.Page
{
    public int uJBZ
    {
        get
        {
            return SXMGR.intSession["uJBZ"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

}