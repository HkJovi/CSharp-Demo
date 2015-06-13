<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en">
<head>
<meta charset="utf-8" />
<title>MIS信息管理系统</title>
<meta name="description" content="Administry - Admin Template by www.mianfeimoban.com" />
<meta name="keywords" content="Admin,Template" />
<!-- Favicons --> 
<link rel="shortcut icon" type="image/png" HREF="img/favicons/favicon.png"/>
<link rel="icon" type="image/png" HREF="img/favicons/favicon.png"/>
<link rel="apple-touch-icon" HREF="img/favicons/apple.png" />
<!-- Main Stylesheet --> 
<link rel="stylesheet" href="css/style.css" type="text/css" />
<!-- Colour Schemes
Default colour scheme is blue. Uncomment prefered stylesheet to use it.
<link rel="stylesheet" href="css/brown.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/gray.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/green.css" type="text/css" media="screen" />
<link rel="stylesheet" href="css/pink.css" type="text/css" media="screen" />  
<link rel="stylesheet" href="css/red.css" type="text/css" media="screen" />
-->
<!-- Your Custom Stylesheet --> 
<link rel="stylesheet" href="css/custom.css" type="text/css" />
<!--swfobject - needed only if you require <video> tag support for older browsers -->
<script type="text/javascript" SRC="js/swfobject.js"></script>
<!-- jQuery with plugins -->
<script type="text/javascript" SRC="js/jquery-1.4.2.min.js"></script>
<!-- Could be loaded remotely from Google CDN : <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script> -->
<script type="text/javascript" SRC="js/jquery.ui.core.min.js"></script>
<script type="text/javascript" SRC="js/jquery.ui.widget.min.js"></script>
<script type="text/javascript" SRC="js/jquery.ui.tabs.min.js"></script>
<!-- jQuery tooltips -->
<script type="text/javascript" SRC="js/jquery.tipTip.min.js"></script>
<!-- Superfish navigation -->
<script type="text/javascript" SRC="js/jquery.superfish.min.js"></script>
<script type="text/javascript" SRC="js/jquery.supersubs.min.js"></script>
<!-- jQuery form validation -->
<script type="text/javascript" SRC="js/jquery.validate_pack.js"></script>
<!-- jQuery popup box -->
<script type="text/javascript" SRC="js/jquery.nyroModal.pack.js"></script>
<!-- Internet Explorer Fixes --> 
<!--[if IE]>
<link rel="stylesheet" type="text/css" media="all" href="css/ie.css"/>
<script src="js/html5.js"></script>
<![endif]-->
<!--Upgrade MSIE5.5-7 to be compatible with MSIE8: http://ie7-js.googlecode.com/svn/version/2.1(beta3)/IE8.js -->
<!--[if lt IE 8]>
<script src="js/IE8.js"></script>
<![endif]-->
<script type="text/javascript">

    $(document).ready(function () {

        /* setup navigation, content boxes, etc... */
        Administry.setup();

        // validate signup form on keyup and submit
        var validator = $("#loginform").validate({
            rules: {
                username: "required",
                password: "required"
            },
            messages: {
                username: "Enter your username",
                password: "Provide your password"
            },
            // the errorPlacement has to take the layout into account
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent().find('label:first'));
            },
            // set new class to error-labels to indicate valid fields
            success: function (label) {
                // set &nbsp; as text for IE
                label.html("&nbsp;").addClass("ok");
            }
        });

    });
</script>
    <style type="text/css">
        .auto-style1 {
            font-size: x-small;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
	<!-- Header -->
	<header id="top">
	  <div class="wrapper-login">
			<!-- Title/Logo - can use text instead of image -->
			<div id="title"><img SRC="img/logo.png" alt="Administry" /><!--<span>Administry</span> demo--></div>
		  <!-- Main navigation -->
			<nav id="menu">
				<ul class="sf-menu">
					<li class="current"><a href="/Login.aspx">Login</a></li>
					<li><a href="/Register.aspx">Register</a></li>
				</ul>
			</nav>
		  <!-- End of Main navigation -->
		  <!-- Aside links --><!-- End of Aside links -->
		</div>
	</header>
	<!-- End of Header -->
	<!-- Page title -->
	<div id="pagetitle">
		<div class="wrapper-login"></div>
	</div>

	<!-- End of Page title -->
	
	<!-- Page content -->
	<div id="page">
		<!-- Wrapper -->
		<div class="wrapper-login">
				<!-- Login form -->
				<section class="full">					
					
					<h3>&nbsp;</h3>
					
					<div class="box box-info">请输入登陆信息</div>

						<p>
							<font size="+1" face="宋体"><strong>账号</strong>: </font>
							<br/>
							<asp:TextBox ID="TB_ZH" runat="server" Width="348px"></asp:TextBox>
&nbsp;</p>
						
						<p>
							<font size="+1"><strong>密码</strong>:&nbsp; </font><br/>
							<asp:TextBox ID="TB_MM" runat="server" Width="343px" TextMode="Password"></asp:TextBox>
						</p>
						
						<p>
                            <br>
							&nbsp;<asp:CheckBox ID="CB_JZMM" runat="server" Font-Size="Medium" Text="  记 住 我" />
							</p>
						
					  <p>
						&nbsp;&nbsp;<asp:ImageButton ID="ImageButton_log" runat="server" ImageUrl="~/img/Login.png" OnClick="ImageButton_log_Click" />
                    </p>
						<div class="clear">&nbsp;</div>

				</section>
				<!-- End of login form -->
				
		</div>
		<!-- End of Wrapper -->
	</div>
	<!-- End of Page content -->
	
	<!-- Page footer -->
	<footer id="bottom">
		<div class="wrapper-login">
			<p ><span class="auto-style1">Copyright &copy; 2013</span> </p>
		</div>
	</footer>
	<!-- End of Page footer -->

<!-- User interface javascript load -->
<script type="text/javascript" SRC="js/administry.js"></script>
    </form>
</body>
</html>
