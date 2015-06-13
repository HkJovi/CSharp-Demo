<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowLB.aspx.cs" Inherits="admin_ShowLB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 分类管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>分类管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="lbid" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="lbid" HeaderText="类别ID" SortExpression="lbid" 
                        InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="lbmc" HeaderText="类别名称" SortExpression="lbmc" />
                    <asp:BoundField DataField="lbbz" HeaderText="类别备注" SortExpression="lbbz" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("lbid") %>' 
                                onclick="btChg_Click">修改</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btDel" runat="server" 
                                CommandArgument='<%# Eval("lbid") %>' onclick="btDel_Click" 
                                onclientclick="return confirm('确定删除此类别吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_lb where plbid&lt;&gt;-1" 
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
            <table class="table" width="100%" border="1">
              <tr>
                <td class="topic">分类名称</td>
                <td>
                    <asp:TextBox ID="txtlbmc" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                  </td>
                <td class="topic" width="10%">分类备注</td>
                <td>
                    <asp:TextBox ID="txtlbbz" runat="server" MaxLength="255" Width="300px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td colspan="3"></td>
                <td>
                    <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click" Text="提交" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>
      <!-- End three column window --> 
</asp:Content>

