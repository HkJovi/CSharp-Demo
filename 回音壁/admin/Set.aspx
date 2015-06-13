<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Set.aspx.cs" Inherits="admin_Set" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>投诉建议分级处理系统后台管理 - 系统设置</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="inner">
      <!-- Begin one column wysiwyg window -->
      <div class="onecolumn">
        <div class="header"> <span>信息发送邮箱管理</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td width="10%" class="topic">邮箱地址</td>
                <td>
                    <asp:TextBox ID="txtaddress" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                  </td>
                <td width="10%" class="topic">用户昵称</td>
                <td>
                    <asp:TextBox ID="txtFromXM" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td class="topic"> 邮件服务器(SMTP)： </td>
                <td >
                    <asp:TextBox ID="txtSmtp" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                  </td>
                <td width="10%" class="topic">登录密码</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td colspan="3"></td>
                <td>
                    <asp:Button ID="btSmtp" runat="server" Text="确认保存" onclick="btSmtp_Click" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>
      <!-- End one column wysiwyg window --> 
      
      <!-- Begin one column wysiwyg window -->
      <div class="onecolumn">
        <div class="header"> <span>首页公告</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td width="10%" class="topic">公告标题</td>
                <td colspan="3">
                    <asp:TextBox ID="txtggbt" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                  </td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td colspan="5"><div style="width:99%;">
                    <textarea id="wysiwyg" name="ggnr"><%=BLL.HE(g_ggnr) %></textarea>
                  </div></td>
              </tr>
              <tr>
                <td colspan="4">&nbsp;</td>
                <td>
                    <asp:Button ID="btGG" runat="server" Text="确认保存" onclick="btGG_Click" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>
      <!-- End one column wysiwyg window --> 
      <!-- Begin three column window -->
      <div class="onecolumn">
        <div class="header"> <span>电子邮件编辑</span> </div>
        <br class="clear"/>
        <div class="content">
          <div class="edit">
            <table class="table" width="100%" border="1">
              <tr>
                <td class="topic">邮件标题</td>
                <td colspan="2">
                    <asp:TextBox ID="txtemailbt" runat="server" MaxLength="40" Width="400px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                <td class="topic">信件编辑</td>
                <td colspan="2"><div style="width:99%;">
                  &nbsp;<asp:TextBox ID="txtemailbody" runat="server" TextMode="MultiLine" 
                        Width="100%"></asp:TextBox>
                </div></td>
              </tr>
              <tr>
                <td colspan="2">&nbsp;</td>
                <td>
                    <asp:Button ID="btemail" runat="server" onclick="btemail_Click" Text="确认保存" />
                  </td>
              </tr>
            </table>
          </div>
        </div>
      </div>
      <!-- End three column window --> 
    </div>
</asp:Content>

