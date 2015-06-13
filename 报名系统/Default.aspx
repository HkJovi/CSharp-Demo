<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>国家计算机等级考试报名</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .list {
            position :absolute;
            top :62px;
            right: 195px;
            width : 751px;
            height: 352px;
            margin-bottom: 0px;
            
        }
        .auto-style2 {
            color: #FF3300;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class ="test"> 
      <div class="auto-style1"> 国家计算机等级考试报名  </div>
        <div class="list">&nbsp;&nbsp;&nbsp; 姓名：&nbsp;&nbsp; 
            <asp:TextBox ID="Name" runat="server" Height="19px" Width="146px" OnTextChanged="Name_TextChanged"></asp:TextBox>
&nbsp;<span aria-multiline="True" class="auto-style2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name" ErrorMessage="请输入姓名"></asp:RequiredFieldValidator>
            
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Name" ErrorMessage="请输入正确的姓名" ValidationExpression="[\u4E00-\u9FA5]{2,5}(?:·[\u4E00-\u9FA5]{2,5})*"></asp:RegularExpressionValidator>
            
            <br />
            <br />
            &nbsp;&nbsp;&nbsp; 学号：&nbsp;&nbsp; <asp:TextBox ID="STUID" runat="server" Height="18px" Width="148px" OnTextChanged="STUID_TextChanged"></asp:TextBox>
            <span class="auto-style2">&nbsp;*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="STUID" ErrorMessage="请输入学号"></asp:RequiredFieldValidator>
            <span aria-multiline="True" class="auto-style2">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="STUID" ErrorMessage="请输入正确的学号" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </span>
            <br />
            <br />
            &nbsp;身份证号：&nbsp; <asp:TextBox ID="ID" runat="server" Height="21px" Width="201px" OnTextChanged="ID_TextChanged"></asp:TextBox>
&nbsp;<span class="auto-style2">*<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ID" ErrorMessage="请输入身份证号"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ID" ErrorMessage="请输入正确的身份证号码" ValidationExpression="[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}"></asp:RegularExpressionValidator>
            </span><br />
            <br />
            &nbsp;报考科目：&nbsp; 
            <asp:DropDownList ID="Project" runat="server">
                <asp:ListItem>全国二级C</asp:ListItem>
                <asp:ListItem>全国二级C++</asp:ListItem>
                <asp:ListItem>全国二级VF</asp:ListItem>
                <asp:ListItem>全国二级VB</asp:ListItem>
            </asp:DropDownList>
&nbsp;<span class="auto-style2">*</span><br />
            <br />
            &nbsp;联系电话：&nbsp; 
            <asp:TextBox ID="PHONENUM" runat="server" Height="18px" Width="195px" OnTextChanged="PHONENUM_TextChanged"></asp:TextBox>
&nbsp;<span class="auto-style2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PHONENUM" ErrorMessage="务必正确填写手机号码"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入正确的手机号" ValidationExpression="\d{11}" ControlToValidate="PHONENUM"></asp:RegularExpressionValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp; 校区：&nbsp; &nbsp;<asp:DropDownList ID="Cumpus" runat="server">
                <asp:ListItem>雅安校区</asp:ListItem>
                <asp:ListItem>温江校区</asp:ListItem>
                <asp:ListItem>都江堰校区</asp:ListItem>
            </asp:DropDownList>
            <span class ="auto-style2"> &nbsp;*&nbsp;</span>
            <br />
            <br />
            <br />
            请输入验证码：&nbsp;&nbsp; 
            <asp:TextBox ID="txtCheckCode" runat="server" Height="25px" Width="102px"></asp:TextBox>
&nbsp;
            <asp:Image ID="imgCheckCode" runat="server" />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonOK" runat="server" Height="38px" style="margin-top: 0px" Text="确认报名" Width="150px" OnClick="ButtonOK_Click" />
        </div>
        
    </div>
    </form>
</body>
</html>
