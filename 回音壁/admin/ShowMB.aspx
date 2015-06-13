<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ShowMB.aspx.cs" Inherits="admin_ShowMB" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 回复模版管理</title>
<script language="javascript">
    function InsVar() {
        var i = document.getElementById('wysiwygIFrame');
        var d = i.contentWindow.document;
        i.contentWindow.focus();
        d.selection.createRange().text = document.getElementById('cbvars').value;
        return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>回复模版管理</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="mbid" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="mbmc" HeaderText="模版名称" SortExpression="mbmc" />
                    <asp:BoundField DataField="mbnr" HeaderText="模版内容" SortExpression="mbnr" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
<asp:LinkButton ID="btChg" runat="server" CommandArgument='<%# Eval("mbid") %>' onclick="btChg_Click">修改</asp:LinkButton>&nbsp;
<asp:LinkButton ID="btDel" runat="server" CommandArgument='<%# Eval("mbid") %>' onclick="btDel_Click" onclientclick="return confirm('确定删除此模版吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_mb where udm=@udm" 
                onselecting="SqlDataSource1_Selecting">
                <SelectParameters>
                    <asp:SessionParameter Name="udm" SessionField="udm" />
                </SelectParameters>
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
                <td class="topic">模版标题</td>
                <td colspan="2">
                    <asp:TextBox ID="txtbt" runat="server" MaxLength="20" Width="90%"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td width="10%" class="topic">插入变量</td>
                <td colspan="2">
<select id="cbvars">
	<option value="%xm%">写信人姓名</option>
	<option value="%dw%">写信人所在单位</option>
	<option value="%sj%">写信时间</option>
	<option value="%bt%">信件标题</option>
	<option value="%zjTo%">转交人</option>
</select>
                <input type="button" value="插入变量" onclick="return InsVar();" /></td>
              </tr>
              <tr>
                <td class="topic">模版编辑</td>
                <td colspan="2"><div style="width:99%;">
                  <textarea id="wysiwyg" name="mbnr"><%=BLL.HE(g_mbnr) %></textarea>
                </div></td>
              </tr>
              <tr>
                <td colspan="2">&nbsp;</td>
                <td>
                    <asp:Button ID="btTJ" runat="server" Text="确认提交" onclick="btTJ_Click" />
                  </td>
              </tr>
            </table>          </div>
        </div>
      </div>
      <!-- End three column window --> 
</asp:Content>

