<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>四川农业大学成都校区 回音壁 - 首页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--热点问题---------------------->
<div class="section">
    <div class="box">
        <div class="title"> 热点问题选登 <span class="hide"></span> </div>
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
<asp:Repeater ID="Repeater2" runat="server" DataSourceID="dsHotList">
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

    <asp:SqlDataSource ID="dsHotList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" SelectCommand="select top 5 a.xjid,a.dm,a.lbid,b.lbmc,a.bt,a.lxmc,a.dw,a.xm,a.sj,d.uxm,d.umc,c.hfsj,a.hits from v_xj a 
inner join t_lb b on a.lbid=b.lbid
inner join t_hf c on a.hfid=c.hfid
inner join t_user d on c.hfr=d.udm
where a.xdbz='1' and a.hot='1'
order by a.dm desc"></asp:SqlDataSource>

<!--已回复的信件-------------------------------->
<div class="section">
        <div class="box">
          <div class="title"> 已回复信件 <span class="hide"></span> </div>
          <div class="content">
            <table cellspacing="0" cellpadding="0" border="0" class="all">
              <thead>
                <tr>
                  <th style="width:40px;">编号</th>
                  <th>信件名称</th>
                  <th style="width:70px;">来信时间</th>
                  <th style="width:120px;">回复人</th>
                  <th style="width:40px;">HITS</th>
                </tr>
              </thead>
              <tbody>
              <asp:Repeater runat="server" ID="lstHF" DataSourceID="dsHF">
              <ItemTemplate>
<tr>
<td><%#Eval("dm") %></td>
<td><a href="ShowXJ.aspx?xjid=<%#Eval("xjid") %>"><%#BLL.HE(Eval("bt")) %></a></td>
<td class="all"><%#Eval("sj", "{0:M月d日}")%></td>
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
    <asp:SqlDataSource ID="dsHF" runat="server" SelectCommand="select * from t_xj order by dm desc"
        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
        onselecting="dsHF_Selecting"></asp:SqlDataSource>

<!--最新信件-------------------------->
<div class="section">
        <div class="box">
          <div class="title"> 最新信件 <span class="hide"></span> </div>
          <div class="content">
            <table cellspacing="0" cellpadding="0" border="0">
              <thead>
                <tr>
                  <th style="width:40px;">编号</th>
                  <th>信件名称</th>
                  <th style="width:60px;">来信时间</th>
                  <th style="width:120px;">写信人</th>
                  <th style="width:40px;">HITS</th>
                </tr>
              </thead>
              <tbody>
<asp:Repeater runat="server" ID="lstNew" DataSourceID="dsNew">
<ItemTemplate>
<tr>
<td><%#Eval("dm") %></td>
<td><a href="ShowXJ.aspx?xjid=<%#Eval("xjid") %>"><%#BLL.HE(Eval("bt")) %></a></td>
<td class="all"><%#Eval("sj", "{0:M月d日}")%></td>
<td><%#BLL.HE(Eval("dw"))+" "+BLL.HE(Eval("xm")) %></td>
<td><%#Eval("hits") %></td>
</tr>
</ItemTemplate>
</asp:Repeater>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    <asp:SqlDataSource ID="dsNew" runat="server" SelectCommand="select * from t_xj order by dm desc"
        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
        onselecting="dsNew_Selecting"></asp:SqlDataSource>

<!-- 下面这段用于版本控制，请不要修改，此版本号应该与数据库一致 -->
<!--    v1.9 --->
</asp:Content>

