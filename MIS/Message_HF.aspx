<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message_HF.aspx.cs" Inherits="Message_write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<div class="title">
    <fieldset>
        <legend>Write Message</legend>
        <p>
            <label class="required" for="producttitle">
            Title：</label><br />
            
            <asp:TextBox ID="TB_tm" runat="server" Width="477px" MaxLength="20"></asp:TextBox>
            
        </p>

         <p>
            <label class="required" for="producttitle">
            TO:</label><br />
            
             <asp:TextBox ID="TB_addtress" runat="server" Width="475px" MaxLength="16"></asp:TextBox>
            
        </p>
        <p>
            <label class="required" >
            Details:</label>
        </p>
 
            <textarea id="TextArea_text" name="txtnr" style="background-color:#e6f3f2"></textarea>
        <br />
        <br />
        <p class="box"><asp:ImageButton ID="ImageButton_Send" runat="server" ImageUrl="~/img/Send.png" OnClick="ImageButton_Send_Click"  />&nbsp;or <a href="/Message.aspx" style="color: #99CCFF; border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: medium;">Cancel</a></p>


    </fieldset></div>

</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <nav id="menu">
        <ul class="sf-menu">
            <li  style="font-family: 宋体, Arial, Helvetica, sans-serif"><a HREF="/Default.aspx" class="auto-style1">控制面板</a></li>
            <li class="current"><a HREF="#" class="auto-style1">消息</a>
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
				<h1 class="auto-style1">  写消息</h1>	
        </asp:Content>



