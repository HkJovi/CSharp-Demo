<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowBM.aspx.cs" Inherits="admin_ShowBM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 部门管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>部门管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="jbid" HeaderText="部门ID" SortExpression="jbid" 
                        InsertVisible="False" />
                    <asp:BoundField DataField="jbmc" HeaderText="部门名称" SortExpression="jbmc" />
                    <asp:BoundField DataField="pjbmc" HeaderText="上级部门" SortExpression="pjbmc" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
<asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("jbid") %>' onclick="btChg_Click">修改</asp:LinkButton>&nbsp;
<asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("jbid") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此部门吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select a.*,b.jbmc as pjbmc from t_jb a inner join t_jb b on a.pjbid=b.jbid where a.pjbid&lt;&gt;-1 order by a.jbid" 
                onselecting="SqlDataSource1_Selecting">
            </asp:SqlDataSource>

          <%--  <%=BLL.MakePager(GridView1) %>--%>
         
        </div>
      </div>
      <!-- End one column window --> 
      
      <asp:GridView ID="GridView2" runat="server">
      </asp:GridView>
      
      <br class="clear"/>
      <!-- Begin three column window -->
      <div class="onecolumn">
        <div class="header"> <span>编辑</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
<table class="table" width="100%" border="1">
              <tr>
                <td class="topic">部门名称</td>
                <td>
                    <asp:TextBox ID="txtjbmc" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                  </td>
                <td class="topic" width="10%">上级部门</td>
                <td colspan="2">
                    <asp:DropDownList ID="txtpjbid" runat="server">
                    </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                <td colspan="3"></td>
                <td>
                    <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click1" Text="提交" />
                  </td>
              </tr>
            </table>          </div>
        </div>
      </div>
      <!-- End three column window --> 
</asp:Content>

