<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowLX.aspx.cs" Inherits="admin_ShowLX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 信件类型管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>信件类型管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="lxmc" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="lxmc" HeaderText="类型名称" SortExpression="lxmc" 
                        ReadOnly="True" />
                    <asp:TemplateField HeaderText="类型图片" SortExpression="lximg">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("lximg") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("lximg") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lxpx" HeaderText="排序" SortExpression="lxpx" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
<asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("lxmc") %>' onclick="btChg_Click">修改</asp:LinkButton>&nbsp;
<asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("lxmc") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此类型吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_lx order by lxpx" 
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
                <td class="topic">类型名称</td>
                <td>
                    <asp:TextBox ID="txtlxmc" runat="server" MaxLength="20"></asp:TextBox>
                  </td>
                <td class="topic" width="10%">类型图片</td>
                <td>
                    <asp:TextBox ID="txtlximg" runat="server" MaxLength="255"></asp:TextBox>
                  </td>
                <td class="topic">排序</td>
                <td>
                    <asp:TextBox ID="txtlxpx" runat="server" MaxLength="10"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td colspan="5"></td>
                <td>
                    <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click1" Text="提交" />
                  </td>
              </tr>
            </table>          </div>
        </div>
      </div>
      <!-- End three column window --> 
</asp:Content>

