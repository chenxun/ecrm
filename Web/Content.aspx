<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="Powerson.Web.Content" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="refresh" content="500" />
    <link rel="stylesheet" href="css/main.css" type="text/css"/>
    <link rel="stylesheet" href="css/navStyle.css" type="text/css"/>
    <link rel="Stylesheet" type="text/css" href="css/tabStyle.css" />
    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>
</head>
<body style="background-color: #9aadcd">
    <form id="form1" runat="server">
    <table style="width: 219px" cellpadding="0" cellspacing="0" border="0">
    	<tr>
    		<td align="center">
                <asp:Label ID="Label_user" runat="server"></asp:Label><br /></td>
    	</tr>
        <tr>
            <td align="center" valign="top">
                <ComponentArt:NavBar ID="_NavBarContent" runat="server" Width="200px" CssClass="NavBar" DefaultItemLookId="TopItemLook" DefaultItemSpacing="10" ExpandTransition="Fade" ExpandDuration="200" CollapseTransition="Fade" CollapseDuration="200" ImagesBaseUrl="images/">
                <ItemLooks>
      <ComponentArt:ItemLook LookID="TopItemLook" CssClass="TopItem" HoverCssClass="TopItemHover" />
      <ComponentArt:ItemLook LookID="Level2ItemLook" LabelPaddingLeft="10" CssClass="Level2Item" HoverCssClass="Level2ItemHover" LeftIconWidth="16" LeftIconHeight="16" />
      <ComponentArt:ItemLook LookID="EmptyLook" CssClass="Empty"/>
    </ItemLooks>
                </ComponentArt:NavBar>
                
            </td>
        </tr>
        <tr>
        <td  align="center"><br/>
        <ComponentArt:TabStrip ID="TabStrip_person" runat="server" Width="200px"  MultiPageId="MultiPage_person" ScrollDownLookId="TopLevelTabLook"
								TopGroupTabSpacing="0px" TopGroupCssClass="TopGroup" Templates="(Collection)" ScrollRightLookId="TopLevelTabLook" ScrollLeftLookId="TopLevelTabLook"
								ScrollUpLookId="TopLevelTabLook" DefaultGroupCssClass="TopGroup" DefaultItemLookId="TopLevelTabLook" DefaultSelectedItemLookId="SelectedTopLevelTabLook"
								DefaultChildSelectedItemLookId="SelectedTopLevelTabLook" DefaultGroupTabSpacing="0px"  ImagesBaseUrl="images/" >
            <ItemLooks>
									<ComponentArt:ItemLook HoverCssClass="TopLevelTabHover" LabelPaddingTop="4px" CssClass="TopLevelTab" LabelPaddingRight="15px"
										LabelPaddingBottom="4px" LeftIconVisibility="Always" LabelPaddingLeft="15px" RightIconVisibility="Always"
										LookId="TopLevelTabLook"></ComponentArt:ItemLook>
									<ComponentArt:ItemLook LabelPaddingTop="4px" CssClass="SelectedTopLevelTab" LabelPaddingRight="15px" LabelPaddingBottom="4px"
										LeftIconVisibility="Always" LabelPaddingLeft="15px" RightIconVisibility="Always" LookId="SelectedTopLevelTabLook"></ComponentArt:ItemLook>
									<ComponentArt:ItemLook HoverCssClass="Level2TabHover" LabelPaddingTop="4px" CssClass="Level2Tab" LabelPaddingRight="15px"
										LabelPaddingBottom="4px" LeftIconVisibility="Always" LabelPaddingLeft="15px" RightIconVisibility="Always"
										LookId="Level2TabLook"></ComponentArt:ItemLook>
									<ComponentArt:ItemLook LabelPaddingTop="4px" CssClass="SelectedLevel2Tab" LabelPaddingRight="15px" LabelPaddingBottom="4px"
										LeftIconVisibility="Always" LabelPaddingLeft="15px" RightIconVisibility="Always" LookId="SelectedLevel2TabLook"></ComponentArt:ItemLook>
								</ItemLooks>
								<Tabs>
									<ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always" DefaultSubGroupCssClass="TopGroup"
										Text="今日计划" DefaultSubGroupTabSpacing="0px" SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always"
										SelectedLook-RightIconVisibility="Always" DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
										SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always" runat="server"></ComponentArt:TabStripTab>
									<ComponentArt:TabStripTab Look-LeftIconVisibility="Always" Look-RightIconVisibility="Always" DefaultSubGroupCssClass="TopGroup"
										Text="即将入海" DefaultSubGroupTabSpacing="0px" SubGroupCssClass="TopGroup" SelectedLook-LeftIconVisibility="Always"
										SelectedLook-RightIconVisibility="Always" DisabledLook-LeftIconVisibility="Always" DisabledLook-RightIconVisibility="Always"
										SubGroupTabSpacing="0px" ChildSelectedLook-LeftIconVisibility="Always" ChildSelectedLook-RightIconVisibility="Always" runat="server"></ComponentArt:TabStripTab>
									
								</Tabs>
            </ComponentArt:TabStrip>
            <ComponentArt:MultiPage ID="MultiPage_person" runat="server"  Width="200px" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                <PageViews>
            <ComponentArt:PageView ID="Pageview_grid" runat="server">
            <table style="width: 98%;" cellpadding="3" cellspacing="3" border="0">
            <tr>
            <td>
            <asp:Label ID="Label_today" runat="server" CssClass="LabelBlack"></asp:Label>
            </td>
            </tr>
            </table>
                
            </ComponentArt:PageView>
            <ComponentArt:PageView ID="Pageview1" runat="server">
            </ComponentArt:PageView>
                </PageViews>
            </ComponentArt:MultiPage>
        </td>
        </tr>
    </table>
       
    </form>
</body>
</html>
