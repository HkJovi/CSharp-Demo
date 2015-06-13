using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CCWin;

namespace 贝斯特产量数据管理系统
{
	public partial class FrmAbout : CCSkinMain
	{
		public FrmAbout()
		{
			InitializeComponent();
		}

		private void skinButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
