<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowXJ.aspx.cs" Inherits="ShowXJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>四川农业大学成都校区 回音壁 - 信件浏览</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-------信件信息-------->
<div class="section">
        <div class="box">
          <div class="title"> 信件信息 <span class="hide"></span> </div>
          <div class="content">
            <table cellspacing="0" cellpadding="0" border="0">
              <thead>
                <tr>
                  <th>编号</th>
                  <th>信件分类</th>
                  <th>信件类型</th>
                  <th style="width:70px;">来信时间</th>
                  <th style="width:120px;">来信人</th>
                  <th>HITS</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td><%=GetInfo("dm") %></td>
                  <td><strong><%=GetInfo("lbmc","尚未分类") %></strong></td>
                  <td> <%=GetInfo("lxmc") %> </td>
                  <td><%=GetInfo("sj") %></td>
                  <td> <%=GetInfo("dw") %> <%=GetInfo("xm") %> </td>
                  <td><%=GetInfo("hits") %></td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
<!------信件内容------------->
<div class="section">
        <div class="box">
          <div class="title"> 信件内容<span class="hide"></span> </div>
          <div class="content" style="background :url(gfx/pattern/flower-swirl9.png) #fffbcc;font-size:14px;">
            <h2><%=GetInfo("bt") %></h2>
            <p><%=GetInfo("nr","",false) %></p>
          </div>
        </div>
      </div>
<!------回复---------------------->
<asp:Repeater ID="lsthfList" runat="server">
<ItemTemplate>

<div class="section">
    <div class="box">
        <div class="title"> 第<%#Container.ItemIndex+1%>次处复 <span class="hide"></span> </div>
        <div class="content" style="background :url(gfx/pattern/flower-swirl9.png) #fffbcc;font-size:14px;">
        <p><%#Eval("hfnr") %></p>
        <blockquote> <%#Eval("umc") %> | 回复时间：<%#Eval("hfsj") %></blockquote>
        </div>
    </div>
</div>

</ItemTemplate>
</asp:Repeater>

</asp:Content>

