<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ChgPwd.aspx.cs" Inherits="admin_ChgPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 修改密码</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="onecolumn">
        <div class="header"> <span>修改密码</span> </div>
        <br class="clear"/>
        <div class="content">
        <div class="edit">
<table width="100%" border="1" class="table">
  <tr>
    <td class="topic">旧密码：</td>
    <td>
        <asp:TextBox ID="txtOldPwd" runat="server" MaxLength="20" TextMode="Password" 
            Width="200px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td class="topic">新密码：</td>
    <td>
        <asp:TextBox ID="txtNewPwd" runat="server" MaxLength="20" TextMode="Password" 
            Width="200px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td class="topic">再输入一次新密码：</td>
    <td>
        <asp:TextBox ID="txtNewPwd2" runat="server" MaxLength="20" TextMode="Password" 
            Width="200px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>
        <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click" Text="确认修改" />
      </td>
  </tr>
</table>
</div>
          
        </div>
      </div>
</asp:Content>

