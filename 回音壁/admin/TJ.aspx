<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="TJ.aspx.cs" Inherits="admin_TJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 信件统计</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="onecolumn">
        <div class="header"> <span>近期来信及回复情况统计</span>
          <div class="switch" style="width:200px">
            <table width="200px" cellpadding="0" cellspacing="0">
              <tbody>
                <tr>
                  <td><input type="button" id="chart_bar" name="chart_bar" class="left_switch active" value="Bar" style="width:50px"/></td>
                  <td><input type="button" id="chart_area" name="chart_area" class="middle_switch" value="Area" style="width:50px"/></td>
                  <td><input type="button" id="chart_pie" name="chart_pie" class="middle_switch" value="Pie" style="width:50px"/></td>
                  <td><input type="button" id="chart_line" name="chart_line" class="right_switch" value="Line" style="width:50px"/></td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <br class="clear"/>
        <div class="content">
          <div id="chart_wrapper" class="chart_wrapper"></div>
          <br class="clear"/>
          <div class="alert_info">
            <p> <img src="../images/icon_info.png" alt="success" class="mid_align"/> 更多内容统计请在控制面板"统计"栏目中查询。 点击下面表格可对数据进行修改。</p>
          </div>
          <br class="clear"/>
            <table id="graph_data" class="data" rel="bar" cellpadding="0" cellspacing="0" width="100%">
              <caption>
              来信情况统计 (单位：封)
              </caption>
              <thead>
                <tr>
                  <td class="no_input">&nbsp;</td>
                  <th>6天前</th>
                  <th>5天前</th>
                  <th>4天前</th>
                  <th>3天前</th>
                  <th>前天</th>
                  <th>昨天</th>
                  <th>今天</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th>来信数量</th>
                  <td><%=TJCount(1,-6) %></td>
                  <td><%=TJCount(1,-5) %></td>
                  <td><%=TJCount(1,-4) %></td>
                  <td><%=TJCount(1,-3) %></td>
                  <td><%=TJCount(1,-2) %></td>
                  <td><%=TJCount(1,-1) %></td>
                  <td><%=TJCount(1,0) %></td>
                </tr>
                <tr>
                  <th>回复情况</th>
                  <td><%=TJCount(2,-6) %></td>
                  <td><%=TJCount(2,-5) %></td>
                  <td><%=TJCount(2,-4) %></td>
                  <td><%=TJCount(2,-3) %></td>
                  <td><%=TJCount(2,-2) %></td>
                  <td><%=TJCount(2,-1) %></td>
                  <td><%=TJCount(2,0) %></td>
                </tr>
              </tbody>
            </table>
            <!-- End bar chart table-->
        </div>
      </div>
</asp:Content>

