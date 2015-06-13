<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>四川农业大学成都校区 回音壁 - 分类查看 <%=GetLbmc() %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section">
    <div class="box">
        <div class="title"> <%=GetLbmc() %> <span class="hide"></span> </div>
        <div class="content">
        <table cellspacing="0" cellpadding="0" border="0" class="sorting">
            <thead>
            <tr>
                <th style="width:40px;">编号</th>
                <th>信件名称</th>
                <th class="all" style="width:70px;">来信时间</th>
                <th style="width:120px;">回复人</th>
                <th style="width:40px;">HITS</th>
            </tr>
            </thead>
            <tbody>
<asp:Repeater ID="Repeater2" runat="server" DataSourceID="dsHF">
<ItemTemplate>
<tr>
<td><%#Eval("dm") %></td>
<td><a href="ShowXJ.aspx?xjid=<%#Eval("xjid") %>"><%#BLL.HE(Eval("bt")) %></a></td>
<td class="all"><%#Eval("sj","{0:M月d日}") %></td>
<td><%#Eval("umc") %></td>
<td><%#Eval("hits") %></td>
</tr>
</ItemTemplate>
</asp:Repeater>
            </tbody>
        </table>
        </div>
    </div>
</div>

    <asp:SqlDataSource ID="dsHF" runat="server" SelectCommand="select * from t_xj"
        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
        onselecting="dsHF_Selecting"></asp:SqlDataSource>

</asp:Content>

