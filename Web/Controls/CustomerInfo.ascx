<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CustomerInfo.ascx.cs"
    Inherits="Powerson.Web.Controls.CustomerInfo" %>
<table cellspacing="1" cellpadding="1" width="100%" style="vertical-align:middle" border="0">
    <tr>
        <td class="table_body" style="width: 20%">
            ��˾����</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_companyname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_companyName" runat="server"
                ControlToValidate="TextBox_companyname" Display="Dynamic" ErrorMessage="*�����빫˾��"
                SetFocusOnError="True" ValidationGroup="addCustomer"></asp:RequiredFieldValidator></td>
        <td class="table_body" style="width: 20%">
            ��ַ</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_www" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��ϵ��</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_contactman" runat="server"></asp:TextBox>
        </td>
        <td class="table_body" style="width: 20%">
            �绰
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_tel" runat="server"></asp:TextBox>-<asp:TextBox ID="TextBox_extend"
                runat="server" Width="50px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��ϵ��ְλ
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_position" runat="server"></asp:TextBox>
        </td>
        <td class="table_body" style="width: 20%">
            �ֻ�����
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_moblie" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ����
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_fax" runat="server"></asp:TextBox>
        </td>
        <td class="table_body" style="width: 20%">
            Email
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��ҵ����
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_industryType" runat="server" Width="155px" DataTextField="name"
                DataValueField="id" DataSourceID="XmlDataSource_industry">
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_industry" runat="server" DataFile="~/customer_dims.xml"
                XPath="//industry_type"></asp:XmlDataSource>
        </td>
        <td class="table_body" style="width: 20%">
            ��������
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_buyIntent" runat="server" Width="155px" DataSourceID="XmlDataSource_buy" DataTextField="name" DataValueField="id">
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_buy" runat="server" DataFile="~/customer_dims.xml"
                XPath="//buy_intent"></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            �ͻ���Դ</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_visitType" runat="server" Width="155px" DataSourceID="XmlDataSource_source" DataTextField="name" DataValueField="id">
                <asp:ListItem Selected="True" Value="0">&lt;��ѡ��...&gt;</asp:ListItem>
                <asp:ListItem>�ͻ�����</asp:ListItem>
                <asp:ListItem>��������</asp:ListItem>
                <asp:ListItem>������ѯ�ͻ�</asp:ListItem>
                <asp:ListItem>�ٶ�</asp:ListItem>
                <asp:ListItem>�ȸ�</asp:ListItem>
                <asp:ListItem>��ֱַ�ӷ���</asp:ListItem>
                <asp:ListItem>������������</asp:ListItem>
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_source" runat="server" DataFile="~/customer_dims.xml"
                XPath="//source"></asp:XmlDataSource>
        </td>
        <td class="table_body" style="width: 20%">
            �ͻ������
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_customerRank" runat="server" Width="155px" DataSourceID="XmlDataSource_rank" DataTextField="name" DataValueField="id">
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_rank" runat="server" DataFile="~/customer_dims.xml"
                XPath="//rank"></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��Դ��Ϣ.�ؼ���</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_keyword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_keyword" runat="server" ControlToValidate="TextBox_keyword"
                Display="Dynamic" ErrorMessage="*������ؼ���" SetFocusOnError="True" ValidationGroup="addCustomer"></asp:RequiredFieldValidator></td>
        <td class="table_body" style="width: 20%">
            ����ʡ(��)��</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_area" runat="server" Width="155px"
                OnSelectedIndexChanged="DropDownList_area_SelectedIndexChanged" DataSourceID="XmlDataSource_areas" DataTextField="name" DataValueField="id">
            </asp:DropDownList><asp:XmlDataSource ID="XmlDataSource_areas" runat="server" DataFile="~/customer_dims.xml"
                XPath="//area"></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            ��˾�����ַ
        </td>
        <td class="table_none" colspan="3">
            <asp:TextBox ID="TextBox_address" runat="server" Width="62.5%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            �ͻ�����
        </td>
        <td class="table_none" colspan="3">
            <asp:TextBox ID="TextBox_remark" runat="server" Height="80px" TextMode="MultiLine"
                Width="62.5%"></asp:TextBox>
        </td>
    </tr>
</table>
