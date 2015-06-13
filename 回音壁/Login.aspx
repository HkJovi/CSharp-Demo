<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd"> 
<html>
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
<title>四川农业大学成都校区 回音壁 - 回复查询</title>
<style type="text/css">
@import url("css/style.css");
 @import url("css/forms.css");
 @import url("css/forms-btn.css");
 @import url("css/menu.css");
 @import url('css/style_text.css');
 @import url("css/datatables.css");
 @import url("css/fullcalendar.css");
 @import url("css/pirebox.css");
 @import url("css/modalwindow.css");
 @import url("css/statics.css");
 @import url("css/tabs-toggle.css");
 @import url("css/system-message.css");
 @import url("css/tooltip.css");
 @import url("css/wizard.css");
 @import url("css/wysiwyg.css");
 @import url("css/wysiwyg.modal.css");
 @import url("css/wysiwyg-editor.css");
</style>

<!--[if lte IE 8]>
		<script type="text/javascript" src="js/excanvas.min.js"></script>
	<![endif]-->

<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery.backgroundPosition.js"></script>
<script type="text/javascript" src="js/jquery.placeholder.min.js"></script>
<script type="text/javascript" src="js/jquery.ui.1.8.17.js"></script>
<script type="text/javascript" src="js/jquery.ui.select.js"></script>
<script type="text/javascript" src="js/jquery.ui.spinner.js"></script>
<script type="text/javascript" src="js/superfish.js"></script>
<script type="text/javascript" src="js/supersubs.js"></script>
<script type="text/javascript" src="js/jquery.datatables.js"></script>
<script type="text/javascript" src="js/fullcalendar.min.js"></script>
<script type="text/javascript" src="js/jquery.smartwizard-2.0.min.js"></script>
<script type="text/javascript" src="js/pirobox.extended.min.js"></script>
<script type="text/javascript" src="js/jquery.tipsy.js"></script>
<script type="text/javascript" src="js/jquery.elastic.source.js"></script>
<script type="text/javascript" src="js/jquery.customInput.js"></script>
<script type="text/javascript" src="js/jquery.validate.min.js"></script>
<script type="text/javascript" src="js/jquery.metadata.js"></script>
<script type="text/javascript" src="js/jquery.filestyle.mini.js"></script>
<script type="text/javascript" src="js/jquery.filter.input.js"></script>
<script type="text/javascript" src="js/jquery.flot.js"></script>
<script type="text/javascript" src="js/jquery.flot.pie.min.js"></script>
<script type="text/javascript" src="js/jquery.flot.resize.min.js"></script>
<script type="text/javascript" src="js/jquery.graphtable-0.2.js"></script>
<script type="text/javascript" src="js/jquery.wysiwyg.js"></script>
<script type="text/javascript" src="js/controls/wysiwyg.image.js"></script>
<script type="text/javascript" src="js/controls/wysiwyg.link.js"></script>
<script type="text/javascript" src="js/controls/wysiwyg.table.js"></script>
<script type="text/javascript" src="js/plugins/wysiwyg.rmFormat.js"></script>
<script type="text/javascript" src="js/costum.js"></script>
</head>

<body>
<div id="wrapper" class="login">
  <div class="box">
    <div class="title"> 回复查询 <span class="hide"></span> </div>
    <div class="content">
      <div class="message inner blue"> <span>如果您不慎遗失此密码，请直接联系我们。</span> </div>
<form id="form2" runat="server">
        <div class="row">
          <label>信件编号</label>
          <div class="right">
<asp:TextBox ID="txtUid" runat="server" ToolTip="这里填入信件编号"></asp:TextBox>
          </div>
        </div>
        <div class="row">
          <label>信件密码</label>
          <div class="right">
<asp:TextBox ID="txtPwd" runat="server" ToolTip="这里填入信件密码" TextMode="Password"></asp:TextBox>
          </div>
        </div>
        <div class="row">
          <div class="right">
<asp:Button ID="dl" runat="server" Text="登陆" onclick="dl_Click" Height="30px" Width="60px" />
          </div>
        </div>
      </form>
    </div>
  </div>
</div>
</body>
</html>
