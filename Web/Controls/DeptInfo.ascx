<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DeptInfo.ascx.cs" Inherits="Powerson.Web.Controls.DeptInfo" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td class="table_body"  align="right">
            部门名称</td>
        <td class="table_none">
            <asp:TextBox ID="_TextBoxDepName" MaxLength="25" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" runat="server" ErrorMessage="*请填写部门名称"
                Display="Dynamic" ControlToValidate="_TextBoxDepName" SetFocusOnError="True"
                ValidationGroup="addDept"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="table_body" align="right">
            上级部门</td>
        <td colspan="1" rowspan="1" class="table_none">
            <asp:DropDownList ID="_DropDownListDep" runat="server">
            </asp:DropDownList></td>
    </tr>
</table>
