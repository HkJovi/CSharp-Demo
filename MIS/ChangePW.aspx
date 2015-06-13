<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePW.aspx.cs" Inherits="ChangePW" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table border="1" class="stylized" width="100%">
        <tr>
            <td style="background:#206790; color:#fff" >旧密码：</td>
            <td>
                <asp:TextBox ID="txtOldPwd" runat="server" MaxLength="20" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="background:#206790; color:#fff">新密码：</td>
            <td>
                <asp:TextBox ID="txtNewPwd" runat="server" MaxLength="20" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="background:#206790; color:#fff">再输入一次新密码：</td>
            <td>
                <asp:TextBox ID="txtNewPwd2" runat="server" MaxLength="20" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BT_changePW" runat="server" onclick="btTJ_Click" Text="确认修改" />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <nav id="menu">
        <ul class="sf-menu">
            <li  style="font-family: 宋体, Arial, Helvetica, sans-serif"><a HREF="/Default.aspx" class="auto-style1">控制面板</a></li>
            <li><a HREF="#" class="auto-style1">消息</a>
                <ul>
                    <li><a HREF="/Message.aspx" class="auto-style1">消息主页</a> </li>
                    <li><a href="#" class="auto-style1">快捷菜单</a>
                        <ul>
                            <li><a HREF="/Message_write.aspx" class="auto-style1">发送新消息</a></li>
                            <li><a HREF="/Message_manage.aspx" class="auto-style1">消息管理</a></li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li><a HREF="/Announcement.aspx" class="auto-style1">公告</a></li>
            <li class="current"><a HREF="/Setting.aspx" class="auto-style1">个人设置</a></li>
        <%
          if ( uJBZ == 2)
          {
              Response.Write(@"
                    <li><a HREF='Admin_setting.aspx' class='auto-style1'>管理员设置</a></li> 
     ");
          }          
%>
				 </ul>
    </nav>
</asp:Content>


<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder2">
                <h1 class="auto-style1">  修改密码</h1>	
        </asp:Content>



