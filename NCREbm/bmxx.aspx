<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bmxx.aspx.cs" Inherits="NCREbm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        报名状态：<asp:Label ID="bmzt" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button" runat="server" Text="填写报名表" OnClick="Button_Click" />
    
    </div>
    </form>
</body>
</html>
