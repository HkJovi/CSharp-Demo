<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LBTJ.aspx.cs" Inherits="LBTJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统 - 类型统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Begin one column wysiwyg window -->
      <div class="onecolumn">
        <div class="header"> <span>分类统计</span> </div>
        <br class="clear"/>
        <div class="content">
          <div id="chart_wrapper" class="chart_wrapper"></div>
          <br class="clear"/>
          <div class="alert_info">
            <p> <img src="images/icon_info.png" alt="success" class="mid_align"/> 更多内容统计请在控制面板"统计"栏目中查询。 点击下面表格可对数据进行修改。</p>
          </div>
          <br class="clear"/>
          <form id="form_data" name="form_data" action="" method="post">
            <table id="graph_data" class="data" rel="bar" cellpadding="0" cellspacing="0" width="100%">
              <caption>
              来信情况统计 (单位：封)
              </caption>
              <thead>
                <tr>
                  <td class="no_input">&nbsp;</td>
<asp:Repeater ID="lbList" runat="server" DataSourceID="SqlDataSource1">
<ItemTemplate>
                  <th><%#Eval("lbmc") %></th>
</ItemTemplate>
</asp:Repeater>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th>来信数量</th>
<asp:Repeater ID="xjList" runat="server" DataSourceID="SqlDataSource1"><ItemTemplate>
                  <td><%#GetXJCount(Eval("lbid")) %></td>
</ItemTemplate></asp:Repeater>
                </tr>
                <tr>
                  <th>回复情况</th>
<asp:Repeater ID="hfList" runat="server" DataSourceID="SqlDataSource1"><ItemTemplate>
                  <td><%#GetHFCount(Eval("lbid")) %></td>
</ItemTemplate></asp:Repeater>
                </tr>
              </tbody>
            </table>
            <!-- End bar chart table-->
          </form>
        </div>
      </div>
      <!-- End one column wysiwyg window --> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
          ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
          SelectCommand="select lbid,lbmc from t_lb where plbid&lt;&gt;-1 order by lbid"></asp:SqlDataSource>
</asp:Content>

