<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="_Default" %>



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

</script>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            color: #FF3300;
        }
        .auto-style3 {
            font-size: x-small;
        }
    </style>
</head>
<body>
	<!-- Header -->
	<header id="top">
	  <div class="wrapper-login">
			<!-- Title/Logo - can use text instead of image -->
			<div id="title"><img SRC="img/logo.png" alt="Administry" /><!--<span>Administry</span> demo--></div>
		  <!-- Main navigation -->
			<nav id="menu">
				<ul class="sf-menu">
					<li class="current2" ><a href="/Login.aspx">Login</a></li>
					<li class="current"><a href="/Register.aspx">Register</a></li>
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
					
					<div class="box box-info">请输入注册信息</div>

					<form id="loginform" runat="server">

						<p>
							<font size="+1" face="宋体"><span class="auto-style1">*</span><strong>编号</strong>: </font>
							<br/>
							&nbsp;<asp:TextBox ID="TB_BH" runat="server" Width="339px" MaxLength="15"></asp:TextBox>
						</p>
						
						<p>
							<font size="+1" face="宋体"><span class="auto-style1">*</span><strong>帐号</strong>: </font>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TB_ZH" ErrorMessage="字母和数字，以字母开头且长度大于3" ValidationExpression="^([a-zA-Z])([a-zA-Z0-9_]){2,9}$"></asp:RegularExpressionValidator>
							<br/>
							&nbsp;<asp:TextBox ID="TB_ZH" runat="server" Width="339px" MaxLength="12"></asp:TextBox>
						</p>
						
						<p>
							<font size="+1" face="宋体"><span class="auto-style1">*</span><strong>密码</strong>: </font>
							<br/>
							&nbsp;<asp:TextBox ID="TB_MM" runat="server" MaxLength="16" TextMode="Password" Width="340px"></asp:TextBox>
						</p>
						
						<p>
							<font size="+1" face="宋体"><span class="auto-style1">*</span><strong>再次输入密码</strong>: </font>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_MM" ControlToValidate="TB_MM2" ErrorMessage="两次输入密码不一致"></asp:CompareValidator>
							<br/>
							&nbsp;<asp:TextBox ID="TB_MM2" runat="server" MaxLength="16" TextMode="Password" Width="340px"></asp:TextBox>
						</p>
						
						<p>
                            <br>
							<span class="auto-style2">*</span><strong>您的身份</strong>&nbsp; <asp:DropDownList ID="Drlt_sf" runat="server" DataSourceID="Register" DataTextField="sfmc" DataValueField="sfmc">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Register" runat="server" ConnectionString="<%$ ConnectionStrings:MISConnectionString %>" SelectCommand="SELECT [sfmc] FROM [t_sf] WHERE ([zcbz] = @zcbz)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="zcbz" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
						</p>
						
					  <p>
                          <br />
					    &nbsp;&nbsp;<asp:ImageButton ID="ImageButton_Reg" runat="server" ImageUrl="~/img/Register.png" OnClick="ImageButton_Reg_Click" />
                        </p>
						<div class="clear">&nbsp;</div>

					</form>
					
					<form id="emailform" style="display:none" method="post" action="#">
						<div class="box">
							<p id="emailinput">
								<label for="email">Email:</label><br/>
								<input type="text" id="email" class="full" value="" name="email"/>
							</p>
							<p>
								<input type="submit" class="btn" value="Send"/>
							</p>
						</div>
					</form>
					
				</section>
				<!-- End of login form -->
				
		</div>
		<!-- End of Wrapper -->
	</div>
	<!-- End of Page content -->
	
	<!-- Page footer -->
	<footer id="bottom">
		<div class="wrapper-login">
			<p><span class="auto-style3">Copyright &copy; 2013</span> </p>
		</div>
	</footer>
	<!-- End of Page footer -->

<!-- User interface javascript load -->
<script type="text/javascript" SRC="js/administry.js"></script>
</body>
</html>
