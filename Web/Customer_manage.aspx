<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Customer_manage.aspx.cs"
    Inherits="Powerson.Web.Customer_manage" %>

<%@ Register Src="Controls/FindPlan.ascx" TagName="FindPlan" TagPrefix="uc5" %>
<%@ Register Src="Controls/PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc4" %>
<%@ Register Src="Controls/VisitRecordInfo.ascx" TagName="VisitRecordInfo" TagPrefix="uc3" %>
<%@ Register Src="Controls/FindCustomer.ascx" TagName="FindCustomer" TagPrefix="uc2" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Register TagPrefix="uc1" TagName="CustomerInfo" Src="Controls/CustomerInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />
    <link rel="Stylesheet" type="text/css" href="css/tabStyle.css" />
    <link rel="Stylesheet" type="text/css" href="css/gridStyle.css" />
    <link rel="Stylesheet" type="text/css" href="css/dialog.css" />

    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>

    <script type="text/javascript" language="javascript">
		function Grid_onItemDoubleClick(sender, eventArgs)
		{
		    var c_id = eventArgs.get_item().getMemberAt(0).get_value();
			//Callback_edit.callback(eventArgs.get_item().getMemberAt(0).get_value());
			OpenWindowInCenter("customer_info.aspx?id="+c_id, c_id);
			//TabStrip_customer.get_tabs().getTab(1).set_visible(true); 
			//TabStrip_customer.get_tabs().getTab(1).select();
		}
    </script>

    <link href="css/calendarStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 98%;" cellpadding="0" align="center" cellspacing="0" border="0">
            <tr>
                <td class="menubar_title" style="height: 38px">
                    <img alt="" src="images/default.gif" />&nbsp;管理客户</td>
            </tr>
            <tr>
                <td class="menubar_function_text" style="height: 27px">
                    管理客户信息</td>
            </tr>
            <tr>
                <td>
                    <ComponentArt:TabStrip ID="TabStrip_customer" runat="server" MultiPageId="MultiPage_customer"
                        ScrollDownLookId="TopLevelTabLook" TopGroupTabSpacing="0px" TopGroupCssClass="TopGroup"
                        Templates="(Collection)" ScrollRightLookId="TopLevelTabLook" ScrollLeftLookId="TopLevelTabLook"
                        ScrollUpLookId="TopLevelTabLook" DefaultGroupCssClass="TopGroup" DefaultItemLookId="TopLevelTabLook"
                        DefaultSelectedItemLookId="SelectedTopLevelTabLook" DefaultChildSelectedItemLookId="SelectedTopLevelTabLook"
                        DefaultGroupTabSpacing="0px" Width="100%" ImagesBaseUrl="images/">
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
                                DefaultSubGroupCssClass="TopGroup" Text="修改客户" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always"
                                Visible="False">
                            </ComponentArt:TabStripTab>
                            <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                DefaultSubGroupCssClass="TopGroup" Text="客户列表" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                            </ComponentArt:TabStripTab>
                            <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                DefaultSubGroupCssClass="TopGroup" Text="跟进客户计划" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                            </ComponentArt:TabStripTab>
                            <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                DefaultSubGroupCssClass="TopGroup" Text="续费客户" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                            </ComponentArt:TabStripTab>
                            <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                DefaultSubGroupCssClass="TopGroup" Text="老客户新项目" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                            </ComponentArt:TabStripTab>
                            <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                DefaultSubGroupCssClass="TopGroup" Text="新增客户" DefaultSubGroupTabSpacing="0px"
                                SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                            </ComponentArt:TabStripTab>
                        </Tabs>
                    </ComponentArt:TabStrip>
                    <ComponentArt:MultiPage ID="MultiPage_customer" runat="server" Width="100%" SelectedIndex="1">
                        <ComponentArt:PageView ID="Pageview_edit">
                        </ComponentArt:PageView>
                        <ComponentArt:PageView ID="Pageview_grid">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <uc2:FindCustomer ID="FindCustomer_manage" runat="server" OnFindCustomerButtonClick="FindCustomer_manage_FindCustomerButtonClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ComponentArt:Grid ID="Grid_customer" runat="server" Width="100%" CssClass="Grid"
                                            LoadingPanelPosition="MiddleCenter" LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                            GroupBySortImageHeight="10" GroupBySortImageWidth="10" GroupBySortDescendingImageUrl="group_desc.gif"
                                            GroupBySortAscendingImageUrl="group_asc.gif" GroupingNotificationTextCssClass="GridHeaderText"
                                            IndentCellWidth="22" TreeLineImageHeight="19" TreeLineImageWidth="22" TreeLineImagesFolderUrl="images/lines/"
                                            PagerImagesFolderUrl="images/pager/" ImagesBaseUrl="images/" PreExpandOnGroup="true"
                                            GroupingPageSize="5" SliderPopupOffsetX="20" SliderGripWidth="9" SliderWidth="150"
                                            SliderHeight="20" PagerButtonHeight="22" PagerButtonWidth="41" PagerTextCssClass="GridFooterText"
                                            PageSize="20" GroupByTextCssClass="GroupByText" GroupByCssClass="GroupByCell"
                                            FooterCssClass="GridFooter" HeaderCssClass="GridHeader" SearchTextCssClass="GridHeaderText"
                                            ShowHeader="false" EditOnClickSelectedItem="False">
                                            <Levels>
                                                <ComponentArt:GridLevel DataKeyField="Id" SelectedRowCssClass="SelectedRow" DataCellCssClass="DataCell"
                                                    HeadingTextCssClass="HeadingCellText" SortAscendingImageUrl="asc.gif" HeadingCellCssClass="HeadingCell"
                                                    ColumnReorderIndicatorImageUrl="reorder.gif" GroupHeadingCssClass="GroupHeading"
                                                    HeadingCellHoverCssClass="HeadingCellHover" SortImageWidth="10" SortDescendingImageUrl="desc.gif"
                                                    HeadingRowCssClass="HeadingRow" SortImageHeight="19" RowCssClass="Row" HeadingCellActiveCssClass="HeadingCellActive">
                                                    <Columns>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="ID"
                                                            Width="20" DataField="Id" Visible="False"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="客户名称"
                                                            DataField="companyname" Width="200"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="成熟度"
                                                            DataField="RankName" Width="150"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="负责人"
                                                            DataField="PersonName" Width="100"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="录入日期"
                                                            FormatString="yyyy-MM-dd" Width="80" DataField="addtime"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="最近跟进日期"
                                                            FormatString="yyyy-MM-dd" Width="80" DataField="lastvisitDate"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="跟进信息"
                                                            DataField="LastVisitInfo" Width="300"></ComponentArt:GridColumn>
                                                    </Columns>
                                                </ComponentArt:GridLevel>
                                            </Levels>
                                            <ClientEvents>
                                                <ItemDoubleClick EventHandler="Grid_onItemDoubleClick" />
                                            </ClientEvents>
                                        </ComponentArt:Grid>
                                    </td>
                                </tr>
                            </table>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView ID="PageView_visitPlan">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <uc5:FindPlan ID="FindPlan_visit" runat="server" OnFindCustomerButtonClick="FindCustomer_visitPlan_FindCustomerButtonClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ComponentArt:Grid ID="Grid_visitPlan" runat="server" Width="100%" CssClass="Grid"
                                            LoadingPanelPosition="MiddleCenter" LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                            GroupBySortImageHeight="10" GroupBySortImageWidth="10" GroupBySortDescendingImageUrl="group_desc.gif"
                                            GroupBySortAscendingImageUrl="group_asc.gif" GroupingNotificationTextCssClass="GridHeaderText"
                                            IndentCellWidth="22" TreeLineImageHeight="19" TreeLineImageWidth="22" TreeLineImagesFolderUrl="images/lines/"
                                            PagerImagesFolderUrl="images/pager/" ImagesBaseUrl="images/" PreExpandOnGroup="true"
                                            GroupingPageSize="5" SliderPopupOffsetX="20" SliderGripWidth="9" SliderWidth="150"
                                            SliderHeight="20" PagerButtonHeight="22" PagerButtonWidth="41" PagerTextCssClass="GridFooterText"
                                            PageSize="20" GroupByTextCssClass="GroupByText" GroupByCssClass="GroupByCell"
                                            FooterCssClass="GridFooter" HeaderCssClass="GridHeader" SearchTextCssClass="GridHeaderText"
                                            ShowHeader="false" EditOnClickSelectedItem="False">
                                            <Levels>
                                                <ComponentArt:GridLevel DataKeyField="Id" SelectedRowCssClass="SelectedRow" DataCellCssClass="DataCell"
                                                    HeadingTextCssClass="HeadingCellText" SortAscendingImageUrl="asc.gif" HeadingCellCssClass="HeadingCell"
                                                    ColumnReorderIndicatorImageUrl="reorder.gif" GroupHeadingCssClass="GroupHeading"
                                                    HeadingCellHoverCssClass="HeadingCellHover" SortImageWidth="10" SortDescendingImageUrl="desc.gif"
                                                    HeadingRowCssClass="HeadingRow" SortImageHeight="19" RowCssClass="Row" HeadingCellActiveCssClass="HeadingCellActive">
                                                    <Columns>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="ID"
                                                            Width="20" DataField="Id" Visible="false"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="公司名称"
                                                            DataField="CompanyName" Width="150"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="成熟度"
                                                            DataField="RankName" Width="150"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="拜访人"
                                                            DataField="PersonName" Width="150"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="下次跟进日期"
                                                            FormatString="yyyy-MM-dd" Width="100" DataField="VisitPlanDate"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="上次跟进日期"
                                                            FormatString="yyyy-MM-dd" Width="80" DataField="lastvisitDate"></ComponentArt:GridColumn>
                                                        <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="上次跟进信息"
                                                            DataField="LastVisitInfo" Width="300"></ComponentArt:GridColumn>
                                                    </Columns>
                                                </ComponentArt:GridLevel>
                                            </Levels>
                                            <ClientEvents>
                                                <ItemDoubleClick EventHandler="Grid_onItemDoubleClick" />
                                            </ClientEvents>
                                        </ComponentArt:Grid>
                                    </td>
                                </tr>
                            </table>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView ID="PageView_continuePay">
                        </ComponentArt:PageView>
                        <ComponentArt:PageView ID="PageView_newProject">
                            <ComponentArt:Grid ID="Grid_newproject" runat="server" Width="100%" CssClass="Grid"
                                LoadingPanelPosition="MiddleCenter" LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                GroupBySortImageHeight="10" GroupBySortImageWidth="10" GroupBySortDescendingImageUrl="group_desc.gif"
                                GroupBySortAscendingImageUrl="group_asc.gif" GroupingNotificationTextCssClass="GridHeaderText"
                                IndentCellWidth="22" TreeLineImageHeight="19" TreeLineImageWidth="22" TreeLineImagesFolderUrl="images/lines/"
                                PagerImagesFolderUrl="images/pager/" ImagesBaseUrl="images/" PreExpandOnGroup="true"
                                GroupingPageSize="5" SliderPopupOffsetX="20" SliderGripWidth="9" SliderWidth="150"
                                SliderHeight="20" PagerButtonHeight="22" PagerButtonWidth="41" PagerTextCssClass="GridFooterText"
                                PageSize="20" GroupByTextCssClass="GroupByText" GroupByCssClass="GroupByCell"
                                FooterCssClass="GridFooter" HeaderCssClass="GridHeader" SearchTextCssClass="GridHeaderText"
                                ShowHeader="false" EditOnClickSelectedItem="False">
                                <Levels>
                                    <ComponentArt:GridLevel DataKeyField="Id" SelectedRowCssClass="SelectedRow" DataCellCssClass="DataCell"
                                        HeadingTextCssClass="HeadingCellText" SortAscendingImageUrl="asc.gif" HeadingCellCssClass="HeadingCell"
                                        ColumnReorderIndicatorImageUrl="reorder.gif" GroupHeadingCssClass="GroupHeading"
                                        HeadingCellHoverCssClass="HeadingCellHover" SortImageWidth="10" SortDescendingImageUrl="desc.gif"
                                        HeadingRowCssClass="HeadingRow" SortImageHeight="19" RowCssClass="Row" HeadingCellActiveCssClass="HeadingCellActive">
                                        <Columns>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="ID"
                                                Width="20" DataField="Id" Visible="false"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="客户名称"
                                                DataField="companyname" Width="200"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="成熟度"
                                                DataField="RankName" Width="150"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="负责人"
                                                DataField="PersonName" Width="100"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="录入日期"
                                                FormatString="yyyy-MM-dd" Width="80" DataField="addtime"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="最近跟进日期"
                                                FormatString="yyyy-MM-dd" Width="80" DataField="lastvisitDate"></ComponentArt:GridColumn>
                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="新项目信息"
                                                DataField="Remark" Width="300"></ComponentArt:GridColumn>
                                        </Columns>
                                    </ComponentArt:GridLevel>
                                </Levels>
                                <ClientEvents>
                                    <ItemDoubleClick EventHandler="Grid_onItemDoubleClick" />
                                </ClientEvents>
                            </ComponentArt:Grid>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView ID="Pageview_add">
                            客户基本信息：
                            <uc1:CustomerInfo ID="CustomerInfo_add" runat="server" CtrlAction="NEW"></uc1:CustomerInfo>
                            初次跟进记录：
                            <uc3:VisitRecordInfo ID="VisitRecordInfo_firstVisit" runat="server" />
                            <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                <tr>
                                    <td class="table_body" style="width: 30%">
                                        计划下次跟进时间</td>
                                    <td class="table_none" style="width: 70%">
                                        <uc4:PickerAndCalendar ID="PickerAndCalendar_nextVisit" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_body" style="width: 30%">
                                        跟进时的注意事项</td>
                                    <td class="table_none" style="width: 70%">
                                        <asp:TextBox ID="TextBox_addCustomer_nextVisit" runat="server" Height="80px" TextMode="MultiLine"
                                            Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_addCustomer_nextVisit" runat="server"
                                            ErrorMessage="请填写下次跟进的注意事项" ValidationGroup="new" Display="Dynamic" ControlToValidate="TextBox_addCustomer_nextVisit"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                            <asp:Button ID="Button_addCustomer" runat="server" CssClass="Button" ValidationGroup="new"
                                Width="60px" OnClick="Button_addCustomer_Click" Text="新增客户"></asp:Button>
                        </ComponentArt:PageView>
                    </ComponentArt:MultiPage>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
