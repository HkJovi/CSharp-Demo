<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Announcement.aspx.cs" Inherits="Announcement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="title">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="736px" AllowPaging="True" CssClass="stylized" ShowHeader="False">
                <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ggid", "Announcement_text.aspx?ggid={0}") %>' Text='<%# Eval("tm") %>' BorderColor="White"></asp:HyperLink>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("time") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                          
                </Columns>
            </asp:GridView>
            <strong><br />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MISConnectionString %>" SelectCommand="SELECT [tm], [time], [ggid] FROM [t_gg]"></asp:SqlDataSource>

            </strong>
        </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <h1 class="auto-style1" style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: large">  公告</h1>	
        </asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
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



