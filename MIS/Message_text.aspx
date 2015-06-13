<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message_text.aspx.cs" Inherits="Message_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <p class="box" style="height:23px; margin-top:0px;"> 
        <input type="reset" class="btn" value="返回" onclick="location = 'Message_manage.aspx'"/> |<asp:ImageButton ID="ImageButton_HF" runat="server" ImageUrl="~/img/huifu.png" OnClick="ImageButton_HF_Click" />
        <input name="Input" class="btn"  id="test3" value="转发" type="button" onclick="openLayer('test3', 'test_con3')" />
        <asp:ImageButton ID="ImageButton_DEL" runat="server" ImageUrl="~/img/shanchu.png" OnClick="ImageButton_DEL_Click" onclientclick="return confirm('确定删除此消息吗？')" />
        </p>
<div id="test_con3" style="display:none" title="包含弹出层的内容的容器">
<div id="tab3" style="width:300px;height:180px;background:#eeedea">
<div id="tabtop3">
<div id="tabtop-L3" onMousedown="StartDrag(this)" onMouseup="StopDrag(this)" onMousemove="Drag(this)"></div>
<div id="tabtop-R3" onclick="closeLayer()"><strong>点我关闭</strong></div>
</div>
        <br />
<div id="tabcontent3">
    <strong style="color:red;font-size:20px">TO：</strong>
    <asp:TextBox ID="TB_zf_sjzh" runat="server"></asp:TextBox>
    <asp:ImageButton ID="ImageButton_ZF" runat="server" ImageUrl="~/img/zhuanfa.png" OnClick="ImageButton_ZF_Click" />
    <br />
    <br />
    <br />
    <strong>温馨提示：<br />     <br />请输入要转发的账号.</strong>
</div>
</div>
</div>       

    <div class="box box-success" style="margin-top:-6px;">
        <asp:Label ID="Label1" runat="server" Text="来自 XXX 的消息  | 时间" ForeColor="#3333FF"></asp:Label>
    </div>
    <div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="738px">
        <ItemTemplate>
            <div class="ta-center">
                &nbsp;<asp:Label ID="tmLabel" runat="server" Font-Size="XX-Large" Text='<%# Eval("xjtm") %>' />
                <br />
                </div>
            <div class="align-left">
                <asp:Label ID="ggLabel" runat="server" Text='<%# Eval("xjnr") %>' />
                <br />
                <br />
            </div>
        </ItemTemplate>
    </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MISConnectionString %>" SelectCommand="select xjtm,xjnr from t_xx a inner join t_sjx b on a.xjid=b.xjid where b.xjid=@xjid and b.jszh=@uZH">
            <SelectParameters>
                <asp:QueryStringParameter Name="xjid" QueryStringField="xjid" />
                <asp:SessionParameter Name="uZH" SessionField="uZH" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
   <div class="box box-info-msg" style="background:#EAF7D9">
       &nbsp;&nbsp;-----上一篇 -------下一篇----怎么做？</div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <nav id="menu">
        <ul class="sf-menu">
            <li  style="font-family: 宋体, Arial, Helvetica, sans-serif"><a HREF="/Default.aspx" class="auto-style1">控制面板</a></li>
            <li class="current"><a HREF="#" class="auto-style1">消息</a>
                        <ul>
                            <li><a HREF="/Message.aspx" class="auto-style1">消息主页</a> </li>
                            <li><a href="#" class="auto-style1">快捷菜单</a>
                                <ul>
                                    <li><a HREF="/Message_write.aspx" class="auto-style1">发送新消息</a></li>
                                    <li><a HREF="/Message_manage.aspx" class="auto-style1">消息管理</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
            <li><a HREF="/Announcement.aspx" class="auto-style1">公告</a></li>
            <li><a HREF="/Setting.aspx" class="auto-style1">个人设置</a></li>
<%
          if ( uJBZ == 2)
          {
              Response.Write(@"
                    <li><a HREF='Admin_setting.aspx' class='auto-style1'>管理员设置</a></li> 
     ");
          }          
%>
        </ul>
    </nav>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
                <h1 class="auto-style1">  消息查看</h1>	
        </asp:Content>



