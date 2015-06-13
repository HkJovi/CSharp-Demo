<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WriteSuccuess.aspx.cs" Inherits="WriteSuccuess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>四川农业大学成都校区 回音壁 - 信件投递成功</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section">
        <div class="box">
          <div class="title"> 信件投递成功 <span class="hide"></span> </div>
          <div class="content">
                <div class="message inner green"> <span>您的信件已发送成功，我们会尽快处理。请牢记您的信件信息，这是您查看信件的唯一凭据。</span>  </div>
                <h2>信件ID : <%=g_dm %></h2><h2>信件密码 : <%=g_pwd %></h2><p>    <%=g_xm %>同学您好，您的信件已发送成功，我们会尽快对您反应的问题进行处理，我们已将您的信件ID和密码发送到您的邮箱：<%=g_email %>，请您查收。感谢您对我们工作的支持。</p><p>
    请各位来信者放心，我们不会公开您的电话、邮箱等联系方式。 如果您不愿意暴露您的身份，我们也不会记录您的IP及一切可能泄露您身份的信息。</p></div>
         
        </div>
      </div>
</asp:Content>

