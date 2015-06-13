<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bmb.aspx.cs" Inherits="Addbmb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        学号：<asp:Label ID="xh" runat="server" Text="xh"></asp:Label>
        <br />
        姓名：<asp:TextBox ID="xsxm" runat="server"></asp:TextBox>
        <br />
        身份证号：<asp:TextBox ID="sfzh" runat="server" Enabled="False"></asp:TextBox>
        <br />
        性别：<asp:Label ID="xb" runat="server" Text="男"></asp:Label>
        <br />
        移动电话：<asp:TextBox ID="YDDH1" runat="server"></asp:TextBox>
        <br />
        移动电话确认：<asp:TextBox ID="YDDH2" runat="server"></asp:TextBox>
        <br />
        报考语种：<asp:DropDownList ID="bkyz" runat="server" DataSourceID="SqlDataSource1" DataTextField="bmyzmc" DataValueField="bmyzmc">
        </asp:DropDownList>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NCREbmConnectionString %>" SelectCommand="select bmyzmc from yxbmyzb where yzdm in (select yzid from kscjxx where sftg=1 and sfzh=511111199310191014 or yzdm ='any'"></asp:SqlDataSource>
        
        <br />
        民族：<asp:DropDownList ID="mz" runat="server">
            <asp:ListItem>汉族</asp:ListItem>
            <asp:ListItem>彝族</asp:ListItem>
            <asp:ListItem>壮族</asp:ListItem>
            <asp:ListItem>回族</asp:ListItem>
        </asp:DropDownList>
        <br />
        文化程度：<asp:DropDownList ID="whcd" runat="server">
            <asp:ListItem>本科</asp:ListItem>
            <asp:ListItem>硕士</asp:ListItem>
            <asp:ListItem>博士</asp:ListItem>
            <asp:ListItem>大专</asp:ListItem>
            <asp:ListItem>高中</asp:ListItem>
            <asp:ListItem>初中</asp:ListItem>
            <asp:ListItem>小学及以下</asp:ListItem>
        </asp:DropDownList>
        <br />
        职业：<asp:DropDownList ID="zy" runat="server">
            <asp:ListItem>学生</asp:ListItem>
            <asp:ListItem>教师</asp:ListItem>
            <asp:ListItem>公务员</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button" runat="server" Text="提交报名表" OnClick="Button_Click" />
    
    </div>
    </form>
</body>
</html>
