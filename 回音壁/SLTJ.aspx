<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SLTJ.aspx.cs" Inherits="SLTJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统 - 数量统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Begin one column wysiwyg window -->
      <div class="onecolumn">
        <div class="header"> <span>数量统计</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">          
            <table class="table" width="100%" border="1">
             <tr>
                <td class="topic">日期</td>
                <td>新信件数量</td>
                <td>回复数量</td>
                <td>转处数量</td>
                <td>浏览总数</td>
              </tr>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
<ItemTemplate>
             <tr>
                <td class="topic"><%#Eval("dt","{0:M月d日}") %></td>
                <td><%#Eval("xjs") %></td>
                <td><%#GetHFCS(Eval("dt")) %></td>
                <td><%#GetZJCS(Eval("dt")) %></td>
                <td><%#Eval("lls") %></td>
              </tr>
</ItemTemplate>
</asp:Repeater>
            </table>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                  SelectCommand="select convert(date,sj) as dt,COUNT(*)as xjs,SUM(hits) as lls from v_xj where sj&gt;=DATEADD(m,-1,getdate()) group by convert(date,sj) order by dt desc"></asp:SqlDataSource>
          </div>
        </div>
      </div>
      <!-- End one column wysiwyg window --> 
</asp:Content>

