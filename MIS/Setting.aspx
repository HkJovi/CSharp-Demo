<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <nav id="menu">
        <ul class="sf-menu">
            <li style="font-family: 宋体, Arial, Helvetica, sans-serif"><a HREF="/Default.aspx" class="auto-style1">控制面板</a></li>
            <li ><a HREF="#" class="auto-style1">消息</a>
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


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
				<h1 class="auto-style1">  个人设置</h1>	
        </asp:Content>



