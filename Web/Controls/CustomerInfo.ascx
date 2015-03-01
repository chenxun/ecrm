<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CustomerInfo.ascx.cs"
    Inherits="Powerson.Web.Controls.CustomerInfo" %>
<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
    <tr>
        <td class="table_body" style="width: 20%">
            公司名称</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_companyname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_companyName" runat="server"
                ControlToValidate="TextBox_companyname" Display="Dynamic" ErrorMessage="*请输入公司名"
                SetFocusOnError="True" ValidationGroup="addCustomer"></asp:RequiredFieldValidator></td>
        <td class="table_body" style="width: 20%">
            网址</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_www" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            联系人</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_contactman" runat="server"></asp:TextBox>
        </td>
        <td class="table_body" style="width: 20%">
            电话
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_tel" runat="server"></asp:TextBox>-<asp:TextBox ID="TextBox_extend"
                runat="server" Width="50px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            联系人职位
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_position" runat="server"></asp:TextBox>
        </td>
        <td class="table_body" style="width: 20%">
            手机号码
        </td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_moblie" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            传真
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
            行业类型
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_industryType" runat="server" Width="155px" DataTextField="TypeName"
                DataValueField="Id" DataSourceID="XmlDataSource_in">
            </asp:DropDownList>
            <asp:XmlDataSource ID="XmlDataSource_in" runat="server" DataFile="~/customer_dims.xml"
                XPath="//industry_type"></asp:XmlDataSource>
        </td>
        <td class="table_body" style="width: 20%">
            购买意向
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_buyIntent" runat="server" Width="155px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            拜访类型
        </td>
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
            </asp:DropDownList>
        </td>
        <td class="table_body" style="width: 20%">
            客户成熟度
        </td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_customerRank" runat="server" Width="155px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            来源信息.关键词</td>
        <td class="table_none" style="width: 30%">
            <asp:TextBox ID="TextBox_keyword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_keyword" runat="server" ControlToValidate="TextBox_keyword"
                Display="Dynamic" ErrorMessage="*请输入关键词" SetFocusOnError="True" ValidationGroup="addCustomer"></asp:RequiredFieldValidator></td>
        <td class="table_body" style="width: 20%">
            所属省(市)区</td>
        <td class="table_none" style="width: 30%">
            <asp:DropDownList ID="DropDownList_area" runat="server" Width="155px"
                OnSelectedIndexChanged="DropDownList_area_SelectedIndexChanged" DataSourceID="XmlDataSource_areas" DataTextField="name" DataValueField="id">
            </asp:DropDownList><asp:XmlDataSource ID="XmlDataSource_areas" runat="server" DataFile="~/customer_dims.xml"
                XPath="//area"></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            公司具体地址
        </td>
        <td class="table_none" colspan="3">
            <asp:TextBox ID="TextBox_address" runat="server" Width="62.5%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="table_body" style="width: 20%">
            客户描述
        </td>
        <td class="table_none" colspan="3">
            <asp:TextBox ID="TextBox_remark" runat="server" Height="80px" TextMode="MultiLine"
                Width="62.5%"></asp:TextBox>
        </td>
    </tr>
</table>
