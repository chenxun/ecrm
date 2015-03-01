<%@ Control Language="C#" AutoEventWireup="true" Codebehind="FindCustomer.ascx.cs"
    Inherits="Powerson.Web.Controls.FindCustomer" %>
<%@ Register Src="PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc1" %>
<link href="../css/calendarStyle.css" rel="stylesheet" type="text/css" />
<table cellpadding="1" cellspacing="1" width="100%" border="0">
    <tr>
        <td class="table_body" style="width: 20%">
            ��˾����</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_companyName" runat="server"></asp:TextBox></td>
        <td class="table_body" style="width: 20%">
            ��ϵ��</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_contactMan" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            �ͻ���Դ</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_visitType" runat="server" Width="155px">
                <asp:ListItem Selected="True" Value="0">&lt;��ѡ��...&gt;</asp:ListItem>
                <asp:ListItem>�ͻ�����</asp:ListItem>
                <asp:ListItem>��������</asp:ListItem>
                <asp:ListItem>������ѯ�ͻ�</asp:ListItem>
                <asp:ListItem>�ٶ�</asp:ListItem>
                <asp:ListItem>�ȸ�</asp:ListItem>
                <asp:ListItem>��ֱַ�ӷ���</asp:ListItem>
                <asp:ListItem>������������</asp:ListItem>
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            ��������</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_buyIntent" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ����ʡ����</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_area" runat="server" Width="155px">
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            �ͻ������</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_rank" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            �೤ʱ��û����</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_noVisit" runat="server" Width="155px">
                <asp:ListItem Selected="True" Value="0">&lt;��ѡ��...&gt;</asp:ListItem>
                <asp:ListItem Value="7">һ��</asp:ListItem>
                <asp:ListItem Value="14">����</asp:ListItem>
                <asp:ListItem Value="30">һ����</asp:ListItem>
            </asp:DropDownList></td>
        <td class="table_body" style="width: 20%">
            ҵ��Ա</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_sales" runat="server" Width="155px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��ӿͻ������ڷ�Χ</td>
        <td class="table_none" style="width: 30%" colspan="3">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox_addtime_valid" TextAlign="Left" Checked="true" Text="�����ڹ���"
                            runat="server" /></td>
                    <td>
                        ��ʼ����</td>
                    <td>
                        <uc1:PickerAndCalendar ID="PickerAndCalendar_begin" runat="server" />
                    </td>
                    <td>
                        ��������</td>
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
                Text="�� ��" /></td>
    </tr>
</table>
