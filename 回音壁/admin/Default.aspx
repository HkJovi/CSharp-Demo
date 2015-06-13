<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 首页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="onecolumn" <%=SXMGR.strSession["xrbz"]=="0" ? "style='display:none'" : "" %> >
        <div class="header"> <span>新信件</span> </div>
        <br class="clear"/>
        <div class="content">
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="xjid" 
                DataSourceID="SqlDataSource3" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="dm" HeaderText="信件ID" SortExpression="dm" />
                    <asp:TemplateField HeaderText="信件标题" SortExpression="bt">
                        <ItemTemplate>
                            <a href="HF.aspx?xjid=<%#Eval("xjid") %>"><strong><%#BLL.HE(Eval("bt")) %></strong></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lxmc" HeaderText="类型" SortExpression="lxmc" />
                    <asp:TemplateField HeaderText="信件来源" SortExpression="dw">
                        <ItemTemplate>
                            <%#BLL.HE(Eval("dw")) %> <%#BLL.HE(Eval("xm")) %> （<%#Eval("sj","{0:d}") %>）
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="hits" HeaderText="点击数" SortExpression="hits" />
                    <asp:TemplateField HeaderText="是否选登" SortExpression="xdbz">
                        <ItemTemplate>
                            <%#Eval("xdbz").ToString()=="1" ? "是" : "否" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from v_xj where ztdm='1' order by sj desc" 
                onselecting="SqlDataSource3_Selecting">
            </asp:SqlDataSource>

            <%=BLL.MakePager(GridView3) %>
          
        </div>
      </div>

      <!-- Begin one column window -->
      <div class="onecolumn">
        <div class="header"> <span>转处给我的信件</span> </div>
        <br class="clear"/>
        <div class="content">

        <%=MakeInfo(1) %>

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
                    <asp:TemplateField HeaderText="最终回复" SortExpression="umc">
                        <ItemTemplate>
                            <%#Eval("umc") %> （<%#Eval("hfsj","{0:d}") %>）
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="hits" HeaderText="点击数" SortExpression="hits" />
                    <asp:TemplateField HeaderText="是否选登" SortExpression="xdbz">
                        <ItemTemplate>
                            <%#Eval("xdbz").ToString()=="1" ? "是" : "否" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" SelectCommand="select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.xm,a.dw,a.sj,d.umc,c.hfsj,a.hits,a.xdbz from v_xj a 
left join t_lb b on a.lbid=b.lbid 
inner join t_hf c on a.hfid=c.hfid
inner join t_user d on c.hfr=d.udm
where a.zjhfjb=@jbid or a.zjhfr=@udm
order by c.hfsj desc">
                <SelectParameters>
                    <asp:SessionParameter Name="jbid" SessionField="jbid" />
                    <asp:SessionParameter Name="udm" SessionField="udm" />
                </SelectParameters>
            </asp:SqlDataSource>

            <%=BLL.MakePager(GridView1) %>
          
        </div>
      </div>
      <!-- End one column window --> 
      
      <!-- Begin one column window -->
      <div class="onecolumn">
        <div class="header"> <span>我转处给别人的信件</span> </div>
        <br class="clear"/>
        <div class="content">
            <%=MakeInfo(2) %>

            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="data" DataKeyNames="xjid" 
                DataSourceID="SqlDataSource2" EnableModelValidation="True" Width="100%">
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
                    <asp:TemplateField HeaderText="最终回复" SortExpression="umc">
                        <ItemTemplate>
                            <%#Eval("umc") %> （<%#Eval("hfsj","{0:d}") %>）
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="hits" HeaderText="点击数" SortExpression="hits" />
                    <asp:TemplateField HeaderText="是否选登" SortExpression="xdbz">
                        <ItemTemplate>
                            <%#Eval("xdbz").ToString()=="1" ? "是" : "否" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="hided" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" SelectCommand="select a.xjid,a.dm,b.lbmc,a.bt,a.lxmc,a.xm,a.dw,a.sj,d.umc,c.hfsj,a.hits,a.xdbz from v_xj a 
left join t_lb b on a.lbid=b.lbid 
inner join t_hf c on a.hfid=c.hfid
inner join t_user d on c.hfr=d.udm
where a.ztdm&lt;&gt;'3' and a.xjid in (select xjid from t_hf where zjfrom=@udm)
order by c.hfsj desc
">
                <SelectParameters>
                    <asp:SessionParameter Name="udm" SessionField="udm" />
                </SelectParameters>
            </asp:SqlDataSource>

            <%=BLL.MakePager(GridView2) %>
          
        </div>
      </div>
      <!-- End one column window --> 
</asp:Content>

