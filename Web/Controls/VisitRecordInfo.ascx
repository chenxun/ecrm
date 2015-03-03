<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VisitRecordInfo.ascx.cs"
    Inherits="Powerson.Web.Controls.VisitRecordInfo" %>
<%@ Register Src="PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc1" %>
<table cellspacing="1" cellpadding="1" width="100%"  border="0">
    <tr>
        <td class="table_body" style="width: 30%">
            ��������</td>
        <td class="table_none" style="width: 70%">
            <asp:DropDownList ID="DropDownList_type" runat="server" Width="155" DataSourceID="XmlDataSource_type" DataTextField="name" DataValueField="id">
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_type" runat="server" ></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 30%">
            ��������
        </td>
        <td class="table_none" style="width: 70%">
            <uc1:PickerAndCalendar ID="PickerAndCalendar_visitDate" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 30%">
            ��ϸ����</td>
        <td class="table_none" style="width: 70%">
            <asp:TextBox ID="TextBox_remark" runat="server" Height="80px" TextMode="MultiLine"
                Width="100%"></asp:TextBox>
        </td>
    </tr>
</table>
