<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head>

<!-- Website Title --> 
<title>投诉建议分级处理系统 - 管理员登陆</title>

<!-- Meta data for SEO -->
<meta name="description" content="">
<meta name="keywords" content="">

<!-- Template stylesheet -->
<link href="../css/green/screen.css" rel="stylesheet" type="text/css" media="all">
<link href="../css/green/datepicker.css" rel="stylesheet" type="text/css" media="all">
<link href="../js/visualize/visualize.css" rel="stylesheet" type="text/css" media="all">
<link href="../js/jwysiwyg/jquery.wysiwyg.css" rel="stylesheet" type="text/css" media="all">
<link href="../js/fancybox/jquery.fancybox-1.3.0.css" rel="stylesheet" type="text/css" media="all">

<!--[if IE]>
	<link href="../css/ie.css" rel="stylesheet" type="text/css" media="all">
	<meta http-equiv="X-UA-Compatible" content="IE=7" />
<![endif]-->

<!-- Jquery and plugins -->
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>
<script type="text/javascript" src="../js/jquery.img.preload.js"></script>
<script type="text/javascript" src="../js/hint.js"></script>
<script type="text/javascript" src="../js/visualize/jquery.visualize.js"></script>
<script type="text/javascript" src="../js/jwysiwyg/jquery.wysiwyg.js"></script>
<script type="text/javascript" src="../js/fancybox/jquery.fancybox-1.3.0.js"></script>
<script type="text/javascript" charset="utf-8">
    $(function () {
        // find all the input elements with title attributes
        $('input[title!=""]').hint();
        $('#login_info').click(function () {
            $(this).fadeOut('fast');
        });
    });
</script>
</head>
<body class="login">
<form id="form1" runat="server">
	<!-- Begin login window -->
	<div id="login_wrapper">
		<div id="login_info" class="alert_warning noshadow" style="width:350px;margin:auto;padding:auto;">
			<p><img src="../images/icon_info.png" alt="success" class="mid_align"/>请各位管理员在公共计算机使用本系统时不使用记住密码，并在使用完本系统后点击“退出”注销登陆。</p>
			<p>请各位管理员认真回复来信。</p>
		</div>
		<br class="clear"/>
		<div id="login_top_window">
			<img src="../images/blue/top_login_window.png" alt="top window"/>
		</div>
		
		<!-- Begin content -->
		<div id="login_body_window">
			<div class="inner">
				<img src="../images/login_logo.png" alt="logo"/>
					<p>
						<asp:TextBox ID="txtUid" runat="server" ToolTip="这里填入您的用户名" Width="285px"></asp:TextBox>
					</p>
					<p>
						<asp:TextBox ID="txtPwd" runat="server" ToolTip="这里填入您的密码" TextMode="Password" Width="285px"></asp:TextBox>
					</p>
					<p style="margin-top:50px">
                        <asp:Button ID="dl" runat="server" Text="登陆" CssClass="login" onclick="dl_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="cbJZMM" runat="server" Text="记住密码（下次不用在输入）" />
                    </p>
			</div>
		</div>
		<!-- End content -->
		
		<div id="login_footer_window">
			<img src="../images/blue/footer_login_window.png" alt="footer window"/>
		</div>
		<div id="login_reflect">
			<img src="../images/blue/reflect.png" alt="window reflect"/>
		</div>
	</div>
	<!-- End login window -->
</form>	
</body>
</html>
