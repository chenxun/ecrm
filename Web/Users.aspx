<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Users.aspx.cs" Inherits="Powerson.Web.Users" %>

<%@ Register Src="Controls/DeptInfo.ascx" TagName="DeptInfo" TagPrefix="uc2" %>
<%@ Register Src="Controls/UserInfo.ascx" TagName="UserInfo" TagPrefix="uc1" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />
    <link rel="Stylesheet" type="text/css" href="css/tabStyle.css" />
    <link rel="Stylesheet" type="text/css" href="css/treeStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 98%;" cellpadding="0" cellspacing="0" border="0" align="center">
                <tr>
                    <td class="menubar_title" style="height: 38px">
                        <img src="images/default.gif" alt="" />&nbsp;管理登录用户</td>
                </tr>
                <tr>
                    <td class="menubar_function_text" style="height: 27px">
                        管理用户和部门信息</td>
                </tr>
                <tr>
                    <td>
                        <ComponentArt:TabStrip ID="TabStrip_user" runat="server" ImagesBaseUrl="images/"
                            Width="100%" MultiPageId="MultiPage_users" ScrollDownLookId="TopLevelTabLook"
                            TopGroupTabSpacing="0px" TopGroupCssClass="TopGroup" Templates="(Collection)"
                            ScrollRightLookId="TopLevelTabLook" ScrollLeftLookId="TopLevelTabLook" ScrollUpLookId="TopLevelTabLook"
                            DefaultGroupCssClass="TopGroup" DefaultItemLookId="TopLevelTabLook" DefaultSelectedItemLookId="SelectedTopLevelTabLook"
                            DefaultChildSelectedItemLookId="SelectedTopLevelTabLook" DefaultGroupTabSpacing="0px">
                            <ItemLooks>
                                <ComponentArt:ItemLook HoverCssClass="TopLevelTabHover" LabelPaddingTop="4px" CssClass="TopLevelTab"
                                    LabelPaddingRight="15px" LabelPaddingBottom="4px" LeftIconVisibility="Always"
                                    LabelPaddingLeft="15px" RightIconVisibility="Always" LookId="TopLevelTabLook"></ComponentArt:ItemLook>
                                <ComponentArt:ItemLook LabelPaddingTop="4px" CssClass="SelectedTopLevelTab" LabelPaddingRight="15px"
                                    LabelPaddingBottom="4px" LeftIconVisibility="Always" LabelPaddingLeft="15px"
                                    RightIconVisibility="Always" LookId="SelectedTopLevelTabLook"></ComponentArt:ItemLook>
                                <ComponentArt:ItemLook HoverCssClass="Level2TabHover" LabelPaddingTop="4px" CssClass="Level2Tab"
                                    LabelPaddingRight="15px" LabelPaddingBottom="4px" LeftIconVisibility="Always"
                                    LabelPaddingLeft="15px" RightIconVisibility="Always" LookId="Level2TabLook"></ComponentArt:ItemLook>
                                <ComponentArt:ItemLook LabelPaddingTop="4px" CssClass="SelectedLevel2Tab" LabelPaddingRight="15px"
                                    LabelPaddingBottom="4px" LeftIconVisibility="Always" LabelPaddingLeft="15px"
                                    RightIconVisibility="Always" LookId="SelectedLevel2TabLook"></ComponentArt:ItemLook>
                            </ItemLooks>
                            <Tabs>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="用户列表" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="新增用户" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="新增部门" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                            </Tabs>
                        </ComponentArt:TabStrip>
                        <ComponentArt:MultiPage ID="MultiPage_users" runat="server" Width="100%">
                            <ComponentArt:PageView ID="Pageview_users">
                                <table id="Table1" cellspacing="1" cellpadding="1" border="0" width="100%">
                                    <tr>
                                        <td valign="top" style="width: 50%" colspan="1" rowspan="1" align="left">
                                            <ComponentArt:TreeView ID="_TreeViewUser" runat="server" CssClass="TreeView" ShowLines="True"
                                                AutoPostBackOnSelect="True" EnableViewState="true" ImagesBaseUrl="images/" Height="450px"
                                                LineImagesFolderUrl="images/lines/" NodeLabelPadding="3" ItemSpacing="0" DefaultImageHeight="16"
                                                DefaultImageWidth="16" LineImageHeight="20" LineImageWidth="19" NodeEditCssClass="NodeEdit"
                                                HoverNodeCssClass="HoverTreeNode" SelectedNodeCssClass="SelectedTreeNode" NodeCssClass="TreeNode"
                                                AutoPostBackOnNodeMove="True" Width="400px" CausesValidation="False" OnNodeSelected="TreeViewUser_NodeSelected"
                                                OnNodeMoved="TreeViewUser_NodeMoved">
                                            </ComponentArt:TreeView></td>
                                        <td valign="top" style="width: 50%" colspan="1" rowspan="1">
                                            <table id="tUserInfo" cellspacing="1" cellpadding="1" width="100%" border="0" runat="server">
                                                <tr>
                                                    <td align="left">
                                                        <uc1:UserInfo ID="_UserInfo" runat="server"></uc1:UserInfo>
                                                        <br />
                                                        <asp:Button ID="_ButtonSaveUser" CssClass="Button" runat="server" Width="60px" Text="保存"
                                                            OnClick="ButtonSaveUser_Click"></asp:Button>
                                                        <asp:Button ID="_ButtonInitPass" CssClass="Button" runat="server" Width="60px" Text="初始化密码"
                                                            CausesValidation="False" OnClick="ButtonInitPass_Click"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tDepInfo" cellspacing="1" cellpadding="1" width="100%" border="0" runat="server">
                                                <tr>
                                                    <td align="left">
                                                        <uc2:DeptInfo id="_DeptInfo" runat="server">
                                                        </uc2:DeptInfo><br />
                                                        <asp:Button ID="_ButtonSaveDep" runat="server" CssClass="Button" Width="60px" Text="保存"
                                                            OnClick="ButtonSaveDep_Click"></asp:Button>
                                                        <asp:Button ID="_ButtonDelDep" runat="server" CssClass="Button" Width="60px" Text="删除部门"
                                                            CausesValidation="False" OnClick="ButtonDelDep_Click"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                            <ComponentArt:PageView ID="Pageview_adduser">
                                <table id="TableAddUser" cellspacing="1" cellpadding="1" width="100%" border="0"
                                    align="center">
                                    <tr>
                                        <td colspan="2">
                                            <uc1:UserInfo ID="UserInfo_add" runat="server"></uc1:UserInfo>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="Button_addUser" CssClass="Button" ValidationGroup="addUser" runat="server"
                                                Width="60px" Text="添加用户" OnClick="Button_addUser_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                            <ComponentArt:PageView ID="Pageview_adddept">
                                <table id="Table_newDept" cellspacing="1" cellpadding="1" width="100%" border="0"
                                    align="center">
                                    <tr>
                                        <td colspan="2">
                                            <uc2:DeptInfo id="DeptInfo_add" runat="server">
                                            </uc2:DeptInfo>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="Button_addDept" CssClass="Button" runat="server" Width="60px" ValidationGroup="addDept"
                                                Text="添加部门" OnClick="Button_addDept_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                        </ComponentArt:MultiPage>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
