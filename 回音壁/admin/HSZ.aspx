<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="HSZ.aspx.cs" Inherits="admin_HSZ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>投诉建议分级处理系统后台管理 - 信件回收站</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Begin one column window -->
      <div class="onecolumn">
        <div class="header"> <span>信件回收站</span> </div>
        <br class="clear"/>
        <div class="content">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="xjid" 
                DataSourceID="SqlDataSource1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="dm" HeaderText="信件ID" SortExpression="dm" />
                    <asp:TemplateField HeaderText="信件标题" SortExpression="bt">
                        <ItemTemplate>
                            <a href="HF.aspx?xjid=<%#Eval("xjid") %>">[<%#Eval("lbmc") %>]<strong><%#BLL.HE(Eval("bt")) %></strong></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lxmc" HeaderText="类型" SortExpression="lxmc" />
                    <asp:TemplateField HeaderText="信件来源" SortExpression="dw">
                        <ItemTemplate>
                            <%#BLL.HE(Eval("dw")) %> <%#BLL.HE(Eval("xm")) %> （<%#Eval("sj","{0:d}") %>）
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="umc" HeaderText="删除用户" SortExpression="umc" />
                    <asp:BoundField DataField="hits" HeaderText="点击数" SortExpression="hits" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                                <asp:LinkButton ID="btHF" runat="server" 
                                CommandArgument='<%# Eval("xjid") %>' onclick="btHF_Click">恢复</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btDel" runat="server" 
                                CommandArgument='<%# Eval("xjid") %>' onclick="btDel_Click" 
                                onclientclick="return confirm('确定删除此信件吗？')">永久删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" SelectCommand="select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.xm,a.dw,a.sj,d.umc,c.hfsj,a.hits,a.xdbz from t_xj a 
left join t_lb b on a.lbid=b.lbid 
left join t_hf c on a.hfid=c.hfid
left join t_user d on a.deluser=d.udm
inner join t_zt e on a.ztdm=e.ztdm
where a.deluser&lt;&gt;''
order by c.hfsj desc,a.sj desc" onselecting="SqlDataSource1_Selecting">
            </asp:SqlDataSource>

            <%=BLL.MakePager(GridView1) %>
          
        </div>
      </div>

</asp:Content>

