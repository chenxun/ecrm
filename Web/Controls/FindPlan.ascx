<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FindPlan.ascx.cs" Inherits="Powerson.Web.Controls.FindPlan" %>
<%@ Register Src="PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc1" %>
<link href="../css/calendarStyle.css" rel="stylesheet" type="text/css" />
<table cellpadding="1" cellspacing="1" width="100%" border="0">
    <tr>
        <td class="table_body" style="width: 20%">
            公司名称</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_companyName" runat="server"></asp:TextBox></td>
        <td class="table_body" style="width: 20%">
            客户成熟度</td>
        <td class="table_none" style="width: 30%"><asp:DropDownList ID="DropDownList_rank" runat="server" Width="155px">
        </asp:DropDownList></td>
    </tr>
    
    <tr>
        <td class="table_body" style="width: 20%">
            所属省市区</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_area" runat="server" Width="155px">
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            业务员</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_sales" runat="server" Width="155px">
            </asp:DropDownList></td>
        
    </tr>
        <tr>
        <td class="table_body" style="width: 20%">
            计划跟进日期</td>
        <td class="table_none" style="width: 30%" colspan="3">
            
            <table><tr>
            <td><asp:CheckBox ID="CheckBox_plandate" TextAlign="Left" Checked="true" Text="显示这一天之前的计划" runat="server" /></td><td></td><td><uc1:PickerAndCalendar ID="PickerAndCalendar_begin" runat="server" /></td>
            </tr></table>
            
        </td>
        
    </tr>

    <tr>
        <td colspan="4" align="right">
            <asp:Button ID="Button_find" runat="server" Width="60px" CssClass="Button" OnClick="Button_find_Click" Text="搜 索" /></td>
    </tr>
</table>