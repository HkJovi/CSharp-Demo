<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wlbm.aspx.cs" Inherits="wlbm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            color: #FF3300;
        }
       
        .auto-style3 {
            color: #000000;
        }
    </style>
</head>
<body style="height: 244px; width: 1273px">
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Literal ID="Imformation" runat="server" Text="暂无报名信息"></asp:Literal>
        <br />
        <br />
        <br />
    
        报考科目：&nbsp; 
            <asp:DropDownList ID="Project" runat="server">
                <asp:ListItem>全国二级C</asp:ListItem>
                <asp:ListItem>全国二级C++</asp:ListItem>
                <asp:ListItem>全国二级VF</asp:ListItem>
                <asp:ListItem>全国二级VB</asp:ListItem>
            </asp:DropDownList>
&nbsp;<span class="auto-style2">*<br />
        </span><span class="auto-style3">&nbsp;&nbsp; 校区：</span><span class="auto-style2">&nbsp; &nbsp;<asp:DropDownList ID="Cumpus" runat="server">
                <asp:ListItem>雅安校区</asp:ListItem>
                <asp:ListItem>温江校区</asp:ListItem>
                <asp:ListItem>都江堰校区</asp:ListItem>
            </asp:DropDownList>
            &nbsp;*<br />
        </span><span class="auto-style3">联系电话：</span><span class="auto-style2">&nbsp;&nbsp; 
            <asp:TextBox ID="PHONENUM" runat="server" Height="18px" Width="195px" OnTextChanged="PHONENUM_TextChanged"></asp:TextBox>
&nbsp;*<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PHONENUM" ErrorMessage="务必正确填写手机号码"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入正确的手机号" ValidationExpression="\d{11}" ControlToValidate="PHONENUM"></asp:RegularExpressionValidator>
            <br />
        </span><span class="auto-style3">请输入验证码：</span><span class="auto-style2">&nbsp;&nbsp; 
            <asp:TextBox ID="txtCheckCode" runat="server" Height="25px" Width="102px"></asp:TextBox>
&nbsp;
            <asp:Image ID="imgCheckCode" runat="server" />
            <asp:Label ID="lblMessage" runat="server" style="color: #000000"></asp:Label>
            </span>
    
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="34px" Text="确认报名" Width="131px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="32px" style="margin-top: 0px" Text="修改报名" Width="154px" OnClick="Button2_Click" />
    </form>
</body>
</html>
