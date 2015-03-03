<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Customer_info.aspx.cs"
    Inherits="Powerson.Web.Customer_info" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Register TagPrefix="uc1" TagName="CustomerInfo" Src="Controls/CustomerInfo.ascx" %>
<%@ Register Src="Controls/VisitRecordInfo.ascx" TagName="VisitRecordInfo" TagPrefix="uc3" %>
<%@ Register Src="Controls/PickerAndCalendar.ascx" TagName="PickerAndCalendar" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="thistitle"></title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />
    <link rel="Stylesheet" type="text/css" href="css/tabStyle.css" />
    <link rel="Stylesheet" type="text/css" href="css/gridStyle.css" />

    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>

    <script type="text/javascript" language="javascript">
		function Grid_onItemDoubleClick(sender, eventArgs)
		{
		    var c_id = eventArgs.get_item().getMemberAt(0).get_value();
		    //Dialog_editVisitRecord.set_modal(true);
		    Dialog_editVisitRecord.Show();
		    ViewVisit(c_id);
		}
		function ViewVisit(param)
        {
          Callback_visit.callback(param);
        }
        function Grid_itemSelect(sender, eventArgs)
        {
            if (Dialog_editVisitRecord.get_isShowing())
            {
                var c_id = eventArgs.get_item().getMemberAt(0).get_value();
                ViewVisit(c_id);
            }
        }
    </script>

    <link href="css/calendarStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 98%;" cellpadding="0" align="center" cellspacing="0" border="0">
                <tr>
                    <td class="menubar_title" style="height: 38px">
                        <img alt="" src="images/default.gif" />&nbsp;客户信息
                    </td>
                </tr>
                <tr>
                    <td class="menubar_function_text" style="height: 27px">
                        客户信息</td>
                </tr>
                <tr>
                    <td>
                        <ComponentArt:TabStrip ID="TabStrip_person" runat="server" MultiPageId="MultiPage_person"
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
                                    DefaultSubGroupCssClass="TopGroup" Text="客户信息" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="客户信息变更历史" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="已经签订的订单" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                                <ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always"
                                    DefaultSubGroupCssClass="TopGroup" Text="正在跟进的新项目意向" DefaultSubGroupTabSpacing="0px"
                                    SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always" SelectedLook-RightIconVisibility="Always"
                                    DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
                                    SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always">
                                </ComponentArt:TabStripTab>
                            </Tabs>
                        </ComponentArt:TabStrip>
                        <ComponentArt:MultiPage ID="MultiPage_person" runat="server" Width="100%">
                            <ComponentArt:PageView ID="Pageview_grid">
                                <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <uc1:CustomerInfo ID="CustomerInfo_edit" runat="server" CtrlAction="EDIT"></uc1:CustomerInfo>
                                            <asp:Button ID="Button_saveCustomer" runat="server" CssClass="Button" Width="60px"
                                                ValidationGroup="edit" OnClick="Button_saveCustomer_Click" Text="保存" Visible="false">
                                            </asp:Button>
                                            <input id="Button_shift" type="button" value="转移" onclick="Dialog_shift.Show();"
                                                class="Button" runat="server" visible="false" />
                                            <input id="Button_close" type="button" value="关闭" onclick="window.close();" class="Button" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Button_opensea" type="button" value="踢入公海" onclick="Dialog_opensea.Show();"
                                                class="Button" runat="server" visible="false" />
                                            <asp:Button ID="Button_apply" runat="server" CssClass="Button" Width="60px" ValidationGroup="edit"
                                                OnClick="Button_apply_Click" Text="认领" Visible="false"></asp:Button>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Button_newproj" type="button" value="新意向" onclick="Dialog_newproject.Show();"
                                                class="Button" runat="server" visible="false" />
                                            <input id="Button_newOrder" type="button" value="新建订单" onclick="Dialog_order.Show();Callback_neworder.callback();"
                                                class="Button" runat="server" visible="false" />
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="BackColorBlue">
                                            <asp:Label ID="Label_visitPlan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            跟进记录列表
                                            <input id="Button_add_rec" type="button" value="添加记录" onclick="Dialog_addVisitRecord.Show();"
                                                class="Button" visible="false" runat="server" />
                                            <ComponentArt:Grid ID="Grid_visitRecord" runat="server" Width="100%" CssClass="Grid"
                                                Height="180" LoadingPanelPosition="MiddleCenter" LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                                GroupBySortImageHeight="10" GroupBySortImageWidth="10" GroupBySortDescendingImageUrl="group_desc.gif"
                                                GroupBySortAscendingImageUrl="group_asc.gif" GroupingNotificationTextCssClass="GridHeaderText"
                                                IndentCellWidth="22" TreeLineImageHeight="19" TreeLineImageWidth="22" TreeLineImagesFolderUrl="images/lines/"
                                                PagerImagesFolderUrl="images/pager/" ImagesBaseUrl="images/" PreExpandOnGroup="true"
                                                GroupingPageSize="5" SliderPopupOffsetX="20" SliderGripWidth="9" SliderWidth="150"
                                                SliderHeight="20" PagerButtonHeight="22" PagerButtonWidth="41" PagerTextCssClass="GridFooterText"
                                                GroupByTextCssClass="GroupByText" GroupByCssClass="GroupByCell" FooterCssClass="GridFooter"
                                                HeaderCssClass="GridHeader" SearchTextCssClass="GridHeaderText" ShowHeader="false"
                                                EditOnClickSelectedItem="False">
                                                <Levels>
                                                    <ComponentArt:GridLevel DataKeyField="Id" SelectedRowCssClass="SelectedRow" DataCellCssClass="DataCell"
                                                        HeadingTextCssClass="HeadingCellText" SortAscendingImageUrl="asc.gif" HeadingCellCssClass="HeadingCell"
                                                        ColumnReorderIndicatorImageUrl="reorder.gif" GroupHeadingCssClass="GroupHeading"
                                                        HeadingCellHoverCssClass="HeadingCellHover" SortImageWidth="10" SortDescendingImageUrl="desc.gif"
                                                        HeadingRowCssClass="HeadingRow" SortImageHeight="19" RowCssClass="Row" HeadingCellActiveCssClass="HeadingCellActive">
                                                        <Columns>
                                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="ID"
                                                                Width="10" DataField="Id" Visible="False"></ComponentArt:GridColumn>
                                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="拜访人"
                                                                DataField="Name" Width="100"></ComponentArt:GridColumn>
                                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="拜访类型"
                                                                DataField="Title" Width="100"></ComponentArt:GridColumn>
                                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="详细内容"
                                                                DataField="Remark"></ComponentArt:GridColumn>
                                                            <ComponentArt:GridColumn SortedDataCellCssClass="SortedDataCell" HeadingText="拜访日期"
                                                                FormatString="yyyy-MM-dd" Width="80" DataField="VisitDate"></ComponentArt:GridColumn>
                                                        </Columns>
                                                    </ComponentArt:GridLevel>
                                                </Levels>
                                                <ClientEvents>
                                                    <ItemDoubleClick EventHandler="Grid_onItemDoubleClick" />
                                                    <ItemSelect EventHandler="Grid_itemSelect" />
                                                </ClientEvents>
                                            </ComponentArt:Grid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                            <ComponentArt:PageView ID="Pageview_edit">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="Grid_history" GridLines="Horizontal" BorderWidth="2px" BorderColor="LightGray"
                                                CssClass="DataGrid" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <HeaderStyle Wrap="False" CssClass="Header" HorizontalAlign="Left"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="Alternating" />
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                                    <asp:BoundField DataField="ColumnName" HeaderText="变更项" />
                                                    <asp:BoundField DataField="OldValue" HeaderText="旧值" />
                                                    <asp:BoundField DataField="NewValue" HeaderText="新值" />
                                                    <asp:BoundField DataField="personname" HeaderText="操作人" />
                                                    <asp:BoundField DataField="ChangeDate" HeaderText="变更日期" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                            <ComponentArt:PageView ID="Pageview_add">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView_order" GridLines="Horizontal" BorderWidth="2px" BorderColor="LightGray"
                                                CssClass="DataGrid" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <HeaderStyle Wrap="False" CssClass="Header" HorizontalAlign="Left"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="Alternating" />
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                                    <asp:BoundField DataField="serial" HeaderText="订单编号" />
                                                    <asp:BoundField DataField="signMoney" HeaderText="金额" />
                                                    <asp:BoundField DataField="name" HeaderText="负责人" />
                                                    <asp:BoundField DataField="signDate" HeaderText="签单日期" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                            <ComponentArt:PageView ID="Pageview_new_proj">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView_newproj" GridLines="Horizontal" Width="100%" BorderWidth="2px"
                                                BorderColor="LightGray" CssClass="DataGrid" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle Wrap="False" CssClass="Header" HorizontalAlign="Left"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="Alternating" />
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                                    <asp:BoundField DataField="Remark" HeaderText="项目信息" />
                                                    <asp:BoundField DataField="name" HeaderText="跟进人" />
                                                    <asp:BoundField DataField="planstatus" HeaderText="状态" />
                                                    <asp:BoundField DataField="VisitPlanDate" HeaderText="日期" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ComponentArt:PageView>
                        </ComponentArt:MultiPage>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_addVisitRecord"
                            runat="server" Width="470" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            添加跟进记录</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_addVisitRecord.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <table cellpadding="0" cellspacing="0" width="450px">
                                    <tr>
                                        <td>
                                            <uc3:VisitRecordInfo ID="VisitRecordInfo_addVisit" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellspacing="1" cellpadding="1" width="100%" border="0">
                                                <tr>
                                                    <td class="table_body" style="width: 30%">
                                                        计划下次跟进时间</td>
                                                    <td class="table_none" style="width: 70%">
                                                        <uc4:PickerAndCalendar ID="PickerAndCalendar_addVisitRecord_nextVisit" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_body" style="width: 30%">
                                                        跟进时的注意事项</td>
                                                    <td class="table_none" style="width: 70%">
                                                        <asp:TextBox ID="TextBox_addVisit_nextVisit" runat="server" Height="80px" TextMode="MultiLine"
                                                            Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_addVisit_nextVisit" runat="server"
                                                            ErrorMessage="请填写下次跟进的注意事项" Display="Dynamic" ControlToValidate="TextBox_addVisit_nextVisit"
                                                            ValidationGroup="addVisit"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button_addRecord" runat="server" OnClick="Button_addRecord_Click"
                                                CssClass="Button" Width="60px" Text="添加记录" ValidationGroup="addVisit"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </Content>
                        </ComponentArt:Dialog>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_editVisitRecord"
                            runat="server" Width="458" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            跟进记录详细说明</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_editVisitRecord.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <ComponentArt:CallBack ID="Callback_visit" runat="server" OnCallback="Callback_visit_Callback">
                                    <Content>
                                        <uc3:VisitRecordInfo ID="VisitRecordInfo_editVisitRecord" runat="server" />
                                    </Content>
                                    <LoadingPanelClientTemplate>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td style="font-size: 10px;">
                                                    Loading...&nbsp;</td>
                                                <td>
                                                    <img alt="" src="images/spinner.gif" width="16" height="16" border="0" /></td>
                                            </tr>
                                        </table>
                                    </LoadingPanelClientTemplate>
                                </ComponentArt:CallBack>
                                <asp:Button ID="Button_saveRecord" Visible="false" runat="server" Width="60px" CssClass="Button"
                                    OnClick="Button_saveRecord_Click" Text="保存"></asp:Button>
                            </Content>
                        </ComponentArt:Dialog>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_opensea"
                            runat="server" Width="458" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            扔此客户入公海</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_opensea.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <table cellspacing="1" cellpadding="1" width="100%" border="0">
                                    <tr>
                                        <td class="table_body" style="width: 30%">
                                            请说明为什么把这个客户扔了</td>
                                        <td class="table_none" style="width: 70%">
                                            <asp:TextBox ID="TextBox_opensea_reason" runat="server" Height="80px" TextMode="MultiLine"
                                                Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_opensea_reason" runat="server"
                                                ErrorMessage="请输入具体原因" ControlToValidate="TextBox_opensea_reason" Display="Dynamic"
                                                ValidationGroup="opensea_reason"></asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button_confirm_opensea" runat="server" CssClass="Button" Width="60px"
                                    OnClick="Button_confirm_opensea_Click" Text="确定" ValidationGroup="opensea_reason">
                                </asp:Button>
                            </Content>
                        </ComponentArt:Dialog>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_newproject"
                            runat="server" Width="458" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            添加新项目意向</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_newproject.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <table cellspacing="1" cellpadding="1" width="100%" border="0">
                                    <tr>
                                        <td class="table_body" style="width: 30%">
                                            新项目日期</td>
                                        <td class="table_none" style="width: 70%">
                                            <uc4:PickerAndCalendar ID="PickerAndCalendar_newproject" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table_body" style="width: 30%">
                                            新项目意向说明</td>
                                        <td class="table_none" style="width: 70%">
                                            <asp:TextBox ID="TextBox_newproject" runat="server" Height="80px" TextMode="MultiLine"
                                                Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_newproj" runat="server" ErrorMessage="请输入项目意向说明"
                                                ControlToValidate="TextBox_newproject" Display="Dynamic" ValidationGroup="newproj"></asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button_addNewProject" runat="server" CssClass="Button" Width="60px"
                                    OnClick="Button_addNewProject_Click" Text="新建" ValidationGroup="newproj"></asp:Button>
                            </Content>
                            <Footer>
                            </Footer>
                        </ComponentArt:Dialog>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_order"
                            runat="server" Width="458" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            添加订单</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_order.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <ComponentArt:CallBack ID="Callback_neworder" runat="server" OnCallback="Callback_neworder_Callback">
                                    <Content>
                                    </Content>
                                    <LoadingPanelClientTemplate>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td style="font-size: 10px;">
                                                    Loading...&nbsp;</td>
                                                <td>
                                                    <img alt="" src="images/spinner.gif" width="16" height="16" border="0" /></td>
                                            </tr>
                                        </table>
                                    </LoadingPanelClientTemplate>
                                </ComponentArt:CallBack>
                                <asp:Button ID="Button_createOrder" ValidationGroup="order" runat="server" Text="创建"
                                    CssClass="Button" Width="60px" OnClick="Button_createOrder_Click" />
                            </Content>
                            <Footer>
                            </Footer>
                        </ComponentArt:Dialog>
                        <ComponentArt:Dialog AllowDrag="False" Alignment="MiddleCentre" ID="Dialog_shift"
                            runat="server" Width="458" RenderOverWindowedObjects="true">
                            <ClientEvents>
                            </ClientEvents>
                            <Header>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 50%">
                                            转移客户给另一个销售</td>
                                        <td align="right">
                                            <img alt="" src="images/close.gif" onclick="Dialog_shift.Close();" /></td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                <table cellspacing="1" cellpadding="1" width="100%" border="0">
                                    <tr>
                                        <td class="table_body" style="width: 30%">
                                            请选择将客户转移给谁</td>
                                        <td class="table_none" style="width: 70%">
                                            </td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button_confirm_shift" runat="server" CssClass="Button" Width="60px"
                                    OnClick="Button_confirm_shift_Click" Text="确定"></asp:Button>
                            </Content>
                            <Footer>
                            </Footer>
                        </ComponentArt:Dialog>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
