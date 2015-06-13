<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
            <div class="colgroup leading" style="margin-top:-10px">
                <div class="column width3 first">
                    <h3 style="background:#206790; color:#fff ;border:solid 3px #206790 ">Welcome!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎回来！</h3>
                    <p style="border:solid 1px #206790;margin-top:-9px">
                        &nbsp;&nbsp;&nbsp; ——<a href="Message.aspx" style="color:#20a1eb;border-bottom:none">点我----查看消息</a> ——
                    <br />
                    &nbsp;&nbsp;&nbsp; ——<a href="Announcement.aspx" style="color:#20a1eb;border-bottom:none">点我----查看公告</a> ——</p>
                </div>
                <div class="column width3">
                    <h3 style="background:#206790; color:#fff ;border:solid 3px #206790 ">您上一次的登陆信息:</h3>
                    <p style="border:solid 1px #206790;margin-top:-9px">
                        您上一次登陆的 时间是：<asp:Label ID="Label_time_IP" runat="server" Text="label"></asp:Label>
&nbsp;<span style="color: #FF0000">非本人登陆？点击链接：</span>  <a href="ChangePW.aspx" style="color:#20a1eb;border-bottom:none">修改密码</a> </p>
                </div>
            </div>
					
					<div class="colgroup leading">
						<div class="column width3 first">
							<h4>&nbsp;</h4>
							<hr/>
							<table class="no-style full">
								<tbody>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
								</tbody>
							</table>
						</div>
						<div class="column width3">
							<h4>&nbsp;</h4>
							<hr/>
							<table class="no-style full">
								<tbody>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right"></td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right"></td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
										<td class="ta-right">&nbsp;</td>
									</tr>
								</tbody>
							</table>
						</div>
					</div>
				
        </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
				<h1 class="auto-style1">  控制面板</h1>	
        </asp:Content>




