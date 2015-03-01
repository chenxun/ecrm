<%@ Control Language="C#" AutoEventWireup="true" Codebehind="FindCustomer.ascx.cs"
    Inherits="Powerson.Web.Controls.FindCustomer" %>
<%@ Register Src="PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc1" %>
<link href="../css/calendarStyle.css" rel="stylesheet" type="text/css" />
<table cellpadding="1" cellspacing="1" width="100%" border="0">
    <tr>
        <td class="table_body" style="width: 20%">
            公司名称</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_companyName" runat="server"></asp:TextBox></td>
        <td class="table_body" style="width: 20%">
            联系人</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_contactMan" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            客户来源</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_visitType" runat="server" Width="155px">
                <asp:ListItem Selected="True" Value="0">&lt;请选择...&gt;</asp:ListItem>
                <asp:ListItem>客户介绍</asp:ListItem>
                <asp:ListItem>自主开发</asp:ListItem>
                <asp:ListItem>来电咨询客户</asp:ListItem>
                <asp:ListItem>百度</asp:ListItem>
                <asp:ListItem>谷歌</asp:ListItem>
                <asp:ListItem>网址直接访问</asp:ListItem>
                <asp:ListItem>其他搜索引擎</asp:ListItem>
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            购买意向</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_buyIntent" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            所属省市区</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_area" runat="server" Width="155px">
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            客户成熟度</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_rank" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            多长时间没跟进</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_noVisit" runat="server" Width="155px">
                <asp:ListItem Selected="True" Value="0">&lt;请选择...&gt;</asp:ListItem>
                <asp:ListItem Value="7">一周</asp:ListItem>
                <asp:ListItem Value="14">两周</asp:ListItem>
                <asp:ListItem Value="30">一个月</asp:ListItem>
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            业务员</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_sales" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            添加客户的日期范围</td>
        <td class="table_none" style="width: 30%" colspan="3">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox_addtime_valid" TextAlign="Left" Checked="true" Text="按日期过滤"
                            runat="server" /></td>
                    <td>
                        起始日期</td>
                    <td>
                        <uc1:PickerAndCalendar ID="PickerAndCalendar_begin" runat="server" />
                    </td>
                    <td>
                        结束日期</td>
                    <td>
                        <uc1:PickerAndCalendar ID="PickerAndCalendar_end" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="4" align="right">
            <asp:Button ID="Button_find" runat="server" Width="60px" CssClass="Button" OnClick="Button_find_Click"
                Text="搜 索" /></td>
    </tr>
</table>
