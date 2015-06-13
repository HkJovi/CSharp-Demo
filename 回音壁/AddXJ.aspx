<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddXJ.aspx.cs" Inherits="AddXJ" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>四川农业大学成都校区 回音壁 - 我要写信</title>
<script language="javascript">
    function tjing(e) {
        e.style.display = "none";
        document.getElementById("info").innerHTML = "<font color=red>正在提交，请稍候</font>";
        return true;        
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!----------------------------------------->
<div class="section">
        <div class="box">
          <div class="title"> 信件内容 <span class="hide"></span> </div>
          <div class="content">
              <div class="row">
                <label>信件标题*</label>
                <div class="right">
<asp:TextBox ID="txtbt" runat="server" MaxLength="40" Width="80%"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <label>信件类型*</label>
                <div class="right">
<asp:DropDownList ID="txtlx" runat="server" DataSourceID="SqlDataSource1" DataTextField="lxmc" DataValueField="lxmc"></asp:DropDownList>
                </div>
              </div>
              <div class="row">
                <label>信件分类*</label>
                <div class="right">
<asp:DropDownList ID="txtlb" runat="server" DataSourceID="SqlDataSource2" DataTextField="lbmc" DataValueField="lbid"></asp:DropDownList>
                    
                </div>
              </div>
              <div class="row">
                <label>信件内容*</label>
                <div class="right">
<textarea name="txtnr" id="wysiwyg" style="height:100px;"><%=BLL.HE(Request.Form["txtnr"]) %></textarea>
                </div>
              </div>
              
          </div>
        </div>
      </div>
<!----------------------------------------->
<div class="section">
        <div class="box">
          <div class="title">您的信息<span class="hide"></span> </div>
          <div class="content">
              <div class="row">
                <label>您所在的学院或部门*</label>
                <div class="right">
<asp:TextBox ID="txtdw" runat="server" MaxLength="40"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <label>您的姓名*</label>
                <div class="right">
<asp:TextBox ID="txtxm" runat="server" MaxLength="20"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <label>Email*</label>
                <div class="right">
<asp:TextBox ID="txtemail" runat="server" MaxLength="40"></asp:TextBox>
                </div>
              </div>
          </div>
        </div>
      </div>
<!----------------------------------------->
<div class="section">
        <div class="box">
          <div class="title">自愿填写<span class="hide"></span> </div>
          <div class="content">
              <div class="row">
                <label>您的电话</label>
                <div class="right">
<asp:TextBox ID="txtdh" runat="server" MaxLength="20" CssClass="onlynum"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <label>附件</label>
                <div class="right">
<asp:FileUpload ID="txtfj" runat="server" />
                </div>
              </div>

          </div>
        </div>
      </div>
<!----------------------------------------->
<div class="section">
        <div class="box">
          <div class="title"> 确认发送<span class="hide"></span> </div>
          <div class="content">
              <div class="row">
                <label>是否公开</label>
                <div class="right">
<asp:CheckBox ID="cbgkbz" runat="server" Checked="true" />
<label for="<%=cbgkbz.ClientID %>">这是一封公开信件，信件内容不需要保密。</label>
                </div>
              </div><div class="row">
                <label>验证码</label>
                <div class="right">
<asp:TextBox ID="txtchk" runat="server" MaxLength="10" Width="100px" CssClass="onlynum"></asp:TextBox>
<img src="GetChkCode.aspx?a" alt="看不清楚？点击更换一张" onclick="this.src=this.src+'a'" />
                </div>
              </div>
              <div class="row">
                <label>发送</label>
                <div class="right">
<asp:Button ID="bttj" runat="server" Text="提交" onclick="bttj_Click" OnClientClick="return tjing(this);" Height="30px" />
                </div>
              </div>

          </div>
        </div>
      </div>
<!----------------------------------------->

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        SelectCommand="select lxmc from t_lx order by lxpx"></asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:zrxxConnectionString %>" 
                        SelectCommand="select lbid,lbmc from t_lb where plbid&lt;&gt;-1">
                    </asp:SqlDataSource>
</asp:Content>

