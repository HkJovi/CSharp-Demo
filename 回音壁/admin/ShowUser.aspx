<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowUser.aspx.cs" Inherits="admin_ShowUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>投诉建议分级处理系统后台管理 - 用户管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>用户管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="udm,jbid1,zid1" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="udm" HeaderText="登陆名" SortExpression="udm" 
                        ReadOnly="True" />
                    <asp:BoundField DataField="uxm" HeaderText="姓名" SortExpression="uxm" />
                    <asp:BoundField DataField="umc" HeaderText="全称" SortExpression="umc" />
                    <asp:TemplateField HeaderText="用户类别" SortExpression="xrbz">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" 
                                Text='<%# Eval("xrbz").ToString()=="2" ? "超级管理员" : Eval("xrbz").ToString()=="1" ? "受信任的管理员" : "一般管理员" %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("xrbz") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="jbmc" HeaderText="所属部门" SortExpression="jbmc" />
                    <asp:BoundField DataField="zmc" HeaderText="权限组" SortExpression="zmc" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
<asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("udm") %>' onclick="btChg_Click">修改</asp:LinkButton>&nbsp;
<asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("udm") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此用户吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_user a inner join t_jb b on a.jbid=b.jbid inner join t_qxz c on a.zid=c.zid order by a.upx" 
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
                <td class="topic">登录名</td>
                <td>
                    <asp:TextBox ID="txtudm" runat="server" MaxLength="20" Width="120px"></asp:TextBox>
                  </td>
                <td class="topic">登陆密码</td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server" MaxLength="20" Width="120px"></asp:TextBox>
                  </td>
                <td class="topic">姓名</td>
                <td>
                    <asp:TextBox ID="txtxm" runat="server" MaxLength="20" Width="120px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td class="topic">全称</td>
                <td>
                    <asp:TextBox ID="txtumc" runat="server" MaxLength="40" Width="120px"></asp:TextBox>
                  </td>
                <td class="topic">所在部门</td>
                <td>
                    <asp:DropDownList ID="txtjbid" runat="server">
                    </asp:DropDownList>
                  </td>
                <td class="topic">权限组</td>
                <td>
                    <asp:DropDownList ID="txtzid" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="zmc" DataValueField="zid">
                    </asp:DropDownList>
                    
                  </td>
              </tr>
              <tr>
                <td class="topic">排序</td>
                <td>
                    <asp:TextBox ID="txtupx" runat="server" MaxLength="10" Width="120px"></asp:TextBox>
                  </td>
                <td class="topic">状态</td>
                <td>
                    <asp:DropDownList ID="txtuzt" runat="server">
                        <asp:ListItem Value="1">可登陆</asp:ListItem>
                        <asp:ListItem Value="0">禁止登陆</asp:ListItem>
                    </asp:DropDownList>
                  </td>
                
                
                <td class="topic">用户类别</td>
                <td>
                    <asp:DropDownList ID="txtxrbz" runat="server">
                        <asp:ListItem Value="0">一般管理员</asp:ListItem>
                        <asp:ListItem Value="1">信任管理员</asp:ListItem>
                        <asp:ListItem Value="2">超级管理员</asp:ListItem>
                    </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                <td class="topic">备注</td>
                <td colspan="3">
                    <asp:TextBox ID="txtubz" runat="server" MaxLength="255" Width="300px"></asp:TextBox>
                  </td>
                <td colspan="2">
                    <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click1" Text="确认提交" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        SelectCommand="select zid,zmc from t_qxz order by zid"></asp:SqlDataSource>
</asp:Content>

