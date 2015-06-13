<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <span class="label label-purple">NEW</span>
    <br />
<%
          if ( newmesgcount == 1)
          {
              Response.Write(@"
                     <div class='box box-info'>--------------------您有新的消息---------------------</div>
                    	<div class='box box-info-msg'>
						<ol>
							<li> ");
          }
%>

        <asp:LinkButton ID='LinkButton_new' runat='server' OnClick='LinkButton_new_Click' Visible="False" BorderStyle="None" Font-Bold="True" ForeColor="#FF9900">新消息题目</asp:LinkButton>
<%
    if ( newmesgcount == 1)
          {
              Response.Write(@"
</li>
							<li><a HREF='Message_manage.aspx' style='color:red;border-bottom:none'>更  多  消  息</a></li>
						</ol>
					</div>
     ");
          }        
          else
              Response.Write(@"
                     <div class=""box box-info"">--------------------没有新的消息---------------------</div>
                    	
     ");
%>    
    <span class="label label-blue">WRITE</span>
    <br />
    					<div class="box box-success">
                            
                            <a HREF="/Message_write.aspx" style="border-bottom:none; color:blue" >--------------------发送新的消息---------------------</a>
                            
    					</div> 
    					<span class="label label-green">MANAGE</span>
    <div class="box box-warning">
         <a HREF="/Message_manage.aspx" style="border-bottom:none; color:gray" >--------------------消息管理----------------------------</a>
    </div>


</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <nav id="menu">
        <ul class="sf-menu">
            <li  style="font-family: 宋体, Arial, Helvetica, sans-serif"><a HREF="/Default.aspx" class="auto-style1">控制面板</a></li>
           <li class="current"><a HREF="#" class="auto-style1"  >消息</a>
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
            <li><a HREF="/Setting.aspx" class="auto-style1">个人设置</a></li>
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
                <h1 class="auto-style1">  消息</h1>	
        </asp:Content>



