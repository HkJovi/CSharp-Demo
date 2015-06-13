<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Announcement_text.aspx.cs" Inherits="Announcement_text" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box box-success" style="margin-top:0px;">
        <asp:Label ID="Label_time" runat="server" Text=" 时间"></asp:Label>
    </div>
    <div style="margin-top:0px">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="738px">
        <ItemTemplate>
            <div class="ta-center">
                &nbsp;<asp:Label ID="tmLabel" runat="server" Font-Size="XX-Large" Text='<%# Eval("tm") %>' />
                <br />
                </div>
            <div class="align-left">
                <asp:Label ID="ggLabel" runat="server" Text='<%# Eval("gg") %>' />
                <br />
                <br />
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MISConnectionString %>" SelectCommand="SELECT [tm], [gg] FROM [t_gg] WHERE ([ggid] = @ggid)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="ggid" QueryStringField="ggid" Type="Int32" />
        </SelectParameters>
</asp:SqlDataSource>
        </div>
       <div class="box box-info-msg" style="background:#EAF7D9">
           &nbsp;&nbsp;-----<asp:LinkButton ID="LinkButton_last" runat="server" OnClick="LinkButton_last_Click">上一篇</asp:LinkButton>
           -----&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -----<asp:LinkButton ID="LinkButton_Next" runat="server" OnClick="LinkButton_Next_Click">下一篇</asp:LinkButton>
           -----</div>                             
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
            <li class="current"><a HREF="/Announcement.aspx" class="auto-style1">公告</a></li>
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


