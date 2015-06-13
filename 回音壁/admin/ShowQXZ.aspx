<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowQXZ.aspx.cs" Inherits="admin_ShowQXZ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 权限组管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>权限组管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="zid" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="zmc" HeaderText="权限组名称" SortExpression="zmc" />
                    <asp:BoundField DataField="zqx" HeaderText="权限列表" SortExpression="zqx" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
<asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("zid") %>' onclick="btChg_Click">修改</asp:LinkButton>&nbsp;
<asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("zid") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此权限组吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_qxz order by zid" 
                onselecting="SqlDataSource1_Selecting">
            </asp:SqlDataSource>

            <%=BLL.MakePager(GridView1) %>
         
        </div>
      </div>
      <!-- End one column window --> 
      
      <br class="clear"/>
      <!-- Begin three column window -->
      <div class="onecolumn">
        <div class="header"> <span>编辑</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
<table width="100%" border="1" class="table">
  <tr>
    <td class="topic">组名称：</td>
    <td>
        <asp:TextBox ID="txtzmc" runat="server" MaxLength="20" Width="150px"></asp:TextBox>    </td>
  </tr>
  
  <tr>
    <td class="topic">组权限：</td>
    <td>
        <asp:CheckBoxList ID="txtzqx" runat="server" BorderStyle="Solid" 
            BorderWidth="1px" RepeatColumns="2" RepeatDirection="Horizontal" 
            Width="100%"></asp:CheckBoxList>    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right">
        <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click1" Text="确认提交" />
      </td>
  </tr>
</table>
          </div>
        </div>
      </div>
      <!-- End three column window --> 
</asp:Content>

