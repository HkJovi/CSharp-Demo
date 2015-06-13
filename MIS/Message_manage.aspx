<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message_manage.aspx.cs" Inherits="Message_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <%
          if ( mesgcount == 1)
          {
              Response.Write(@"
                     <span class='label label-purple'>NEWS</span>
                       <br/>
                     <div class='box box-info'>--------------------您的消息如下---------------------</div>
               ");
          }
          else
          {
              Response.Write(@"
                         <br/>
                     <span class='label label-purple'>NEWS</span>
                           <br/>
                     <div class='box box-info'>--------------------您没有任何消息---------------------</div>
                            <br />
                     <span class='label label-blue'>WRITE</span>
                       <br />
    					<div class='box box-success'>
                            
                            <a HREF='/Message_write.aspx' style='border-bottom:none; color:blue' >------------------您可以发送新的消息------------------</a>
                            
    					</div> 

               ");
          }
%>
    <div style="margin-top:-6px;" >
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="736px" AllowPaging="True" CssClass="stylized" ShowHeader="False">
                <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("xjid", "Message_text.aspx?xjid={0}") %>' Text='<%# Eval("xjtm") %>' BorderColor="White"></asp:HyperLink>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                         </ItemTemplate>
                         </asp:TemplateField>
                    <asp:TemplateField>
                         <ItemTemplate>
                         <asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("xjid") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此消息吗？')">删除</asp:LinkButton>
                            </ItemTemplate>
                           </asp:TemplateField>
                          
                </Columns>
            </asp:GridView>
        </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MISConnectionString %>" SelectCommand="select a.xjid,xjtm,time from t_xx a inner join t_sjx b on a.xjid=b.xjid where jszh=@jszh order by time desc">
                <SelectParameters>
                    <asp:SessionParameter Name="jszh" SessionField="uZH" />
                </SelectParameters>
    </asp:SqlDataSource>
    </div>
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
				<h1 class="auto-style1">  消息管理</h1>	
        </asp:Content>



