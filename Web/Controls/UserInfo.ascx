<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="Powerson.Web.Controls.UserInfo" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
		<tr>
			<td style="width:30%" class="table_body" colspan="1" rowspan="1">用户登录名</td>
			<td style="width:70%" class="table_none">
				<asp:TextBox id="_TextBoxUserName" MaxLength="25" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator_userName" runat="server" ErrorMessage="*请填写用户登录名" Display="Dynamic"
					ControlToValidate="_TextBoxUserName" SetFocusOnError="True" ValidationGroup="addUser"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="table_body">真实姓名</td>
			<td class="table_none">
				<asp:TextBox id="_TextBoxRealName" MaxLength="25" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="table_body" colspan="1" rowspan="1">用户角色</td>
			<td class="table_none">
				<asp:CheckBoxList id="_CheckBoxListRole" runat="server" DataTextField="name" DataValueField="key"></asp:CheckBoxList></td>
		</tr>
		<tr>
			<td class="table_body" >对应员工</td>
			<td class="table_none" >
				<asp:DropDownList id="DropDownList_person" runat="server"></asp:DropDownList>
				<asp:RequiredFieldValidator id="RequiredFieldValidator_person" runat="server" ErrorMessage="*请选择对应的员工" Display="Dynamic"
					ControlToValidate="DropDownList_person" ValidationGroup="addUser"></asp:RequiredFieldValidator></td>
		</tr>
	</table>