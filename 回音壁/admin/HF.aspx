<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="HF.aspx.cs" Inherits="admin_HF" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 回复信件</title>
<script language="javascript" type="text/javascript">
    var mj_ajax_object = undefined;

    function mj_GetAjaxObject() {
        try {
            return new ActiveXObject('MSXML2.XMLHTTP');
        } catch (e) {
            try {
                return new ActiveXObject('Microsoft.XMLHTTP');
            } catch (e) {
                try {
                    return new XMLHttpRequest();
                } catch (e) {
                    return undefined;
                }
            }
        }
    }

    function mj_KeepConnection() {
        if (mj_ajax_object == undefined) mj_ajax_object = mj_GetAjaxObject();
        if (mj_ajax_object == undefined) return;

        mj_ajax_object.OnReadyStateChange = function () {
            if (mj_ajax_object.ReadyState == 4) {
                if (mj_ajax_object.Status == 200) {
                    //完成
                }
            }
        }

        var s = 'NoThing.aspx?tm=' + Math.random().toString();
        mj_ajax_object.open('get', s);
        mj_ajax_object.send(null);
        setTimeout("mj_KeepConnection();", 120000);
    }

    setTimeout("mj_KeepConnection();", 120000);
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="onecolumn">
        <div class="header"> <span>[<%=GetInfo("lbmc") %>] <%=GetInfo("bt") %></span>
          <div class="right">信件状态：<%=GetInfo("ztmc") %></div>
        </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td colspan="8" class="topic">来信内容</td>
              </tr>
              <tr>
                <td class="topic">信件ID</td>
                <td><%=GetInfo("dm") %></td>
                <td class="topic">信件类型</td>
                <td><%=GetInfo("lxmc") %></td>
                <td class="topic">写信时间</td>
                <td><%=GetInfo("sj") %></td>
                <td colspan="2"> 浏览数<%=GetInfo("hits") %>次 &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink 
                        ID="btDownFJ" runat="server" Text="查看附件" Target="_blank"></asp:HyperLink></td>
              </tr>
              <tr>
                <td class="topic">写信人</td>
                <td><%=GetInfo("dw") %> <%=GetInfo("xm") %></td>
                <td class="topic">IP地址</td>
                <td><%=GetInfo("ip") %></td>
                <td class="topic">电子邮箱</td>
                <td><%=GetInfo("email") %></td>
                <td class="topic"> 联系电话 </td>
                <td><%=GetInfo("dh") %></td>
              </tr>
              <tr>
                <td class="topic" width="10%">信件内容</td>
                <td colspan="7"> <%=g_xj["nr"] %></td>
              </tr>
            </table>
          </div>
<asp:Repeater ID="lstHF" runat="server" DataSourceID="SqlDataSource1">
<ItemTemplate>
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td colspan="4" class="topic">处复情况</td>
              </tr>
              <tr>
                <td class="topic">处复人</td>
                <td><%#Eval("umc") %></td>
                <td class="topic">处复时间</td>
                <td><%#Eval("hfsj") %></td>
              </tr>
              <tr>
                <td class="topic" width="10%">处复内容</td>
                <td colspan="3"> <%#Eval("hfnr") %></td>
              </tr>
            </table>
          </div>
</ItemTemplate>
</asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                SelectCommand="select * from t_hf a inner join t_user b on a.hfr=b.udm where xjid=@xjid order by a.hfsj">
                <SelectParameters>
                    <asp:QueryStringParameter Name="xjid" QueryStringField="xjid" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
      </div>
      <!-- End three column window --> 
      
      <!-- Begin one column wysiwyg window -->
      <div class="onecolumn" <%=btTJ.Visible ? "" : "style='display:none'" %> >
        <div class="header"> <span>信件处复</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td class="topic">修改标题</td>
                <td colspan="3">
                    <asp:TextBox ID="txtbt" runat="server" MaxLength="40" Width="90%"></asp:TextBox>
                  </td>
                <td><asp:CheckBox ID="cbHot" runat="server" Text="设为热点问题" /></td>
              </tr>
              <tr>
                <td width="10%" class="topic">处理方式</td>
                <td>
                    <asp:DropDownList ID="txtzjbz" runat="server">
                        <asp:ListItem Value="1">直接处复</asp:ListItem>
                        <asp:ListItem Value="2">转处复</asp:ListItem>
                    </asp:DropDownList>
                  </td>
                <td> 将此信件转交给<asp:DropDownList ID="txtbm" runat="server" AutoPostBack="True">
                    </asp:DropDownList><asp:DropDownList ID="txtuser" runat="server" 
                        DataSourceID="SqlDataSource4" DataTextField="uxm" DataValueField="udm">
                    </asp:DropDownList>
                    
                  处复</td>
                <td class="topic">插入模版</td>
                <td>&nbsp;<asp:DropDownList ID="txtmb" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="mbmc" DataValueField="mbid">
                    </asp:DropDownList>
                    
                    <asp:Button ID="btmb" runat="server" Text="插入模版" onclick="btmb_Click" />
                  </td>
              </tr>
              <tr>
                <td colspan="5"><div style="width:99%;"><textarea id="wysiwyg" name="txtnr"><%=GetHFNR() %></textarea></div></td>
              </tr>
              <tr>
                <td width="10%" class="topic">选择类型</td>
                <td>
                    <asp:DropDownList ID="txtlb" runat="server" 
                        DataSourceID="SqlDataSource3" DataTextField="lbmc" DataValueField="lbid" 
                        AppendDataBoundItems="True">
                        <asp:ListItem Value="-1">--请选择--</asp:ListItem>
                    </asp:DropDownList>
                    
                  </td>
                <td class="topic">是否公开信件</td>
                <td>
                    <asp:RadioButton ID="rbYes" runat="server" Checked="True" GroupName="gk" 
                        Text="是" />
                    <asp:RadioButton ID="rbNo" runat="server" GroupName="gk" Text="否" />
                  </td>
                <td>
                    <asp:Button ID="btTJ" runat="server" onclick="btTJ_Click" Text="确认提交" 
                        Width="104px" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        SelectCommand="select mbid,mbmc from t_mb where udm=@udm">
                        <SelectParameters>
                            <asp:SessionParameter Name="udm" SessionField="udm" />
                        </SelectParameters>
                    </asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        SelectCommand="select lbid,lbmc from t_lb where plbid&lt;&gt;-1">
                    </asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        
          SelectCommand="select udm,uxm from t_user where jbid=@jbid and uzt='1' order by upx" 
          onselecting="SqlDataSource4_Selecting">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtbm" Name="jbid" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
</asp:Content>

