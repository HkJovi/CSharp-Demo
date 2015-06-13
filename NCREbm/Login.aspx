<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        姓名：<asp:TextBox ID="xm" runat="server"></asp:TextBox>
        <br />
        身份证号：<asp:TextBox ID="sfzh" runat="server" Width="173px"></asp:TextBox>
        <br />
        验证码：<asp:TextBox ID="yzm" runat="server" Width="54px"></asp:TextBox>
&nbsp;<asp:Image ID="img1" runat="server" ImageUrl="~/GenerateCheckCode.aspx" /> 
        <br />
        <asp:Button ID="OK" runat="server" OnClick="OK_Click" Text="提交" />
    
    </div>
    </form>
</body>
</html>
