<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Head.aspx.cs" Inherits="Powerson.Web.Head" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="refresh" content="500" />
    <link rel="stylesheet" href="css/main.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; border-bottom: black 1px solid; height: 49px;" cellpadding="0"
                cellspacing="0" border="0">
                <tr>
                    <td class="LabelBlack" style="width: 300px">
                        <b>源易网络CRM客户管理系统</b><br />
                        v2.0.1</td>
                    <td style="width: 320px;">
                        <ComponentArt:Rotator ID="HeadlinesRotator" runat="server" CssClass="Rotator" Width="350"
                            Height="20" RotationType="SmoothScroll" ScrollInterval="10" SlidePause="6000"
                            PauseOnMouseOver="true">
                            <SlideTemplate>
                                <table width="320" cellpadding="0" cellspacing="3" border="0">
                                    <tr>
                                        <td style="width: 30px;" align="center" valign="middle">
                                            <img src="images/spacer.gif" alt="" width="30" height="1" style="border: none; display: block;" /><img
                                                src="images/arrows.gif" alt="" width="16" height="11" style="border: none; display: block;" /></td>
                                        <td class="LabelBlack" onclick="OpenWindowInCenter('<%# DataBinder.Eval(Container.DataItem, "NavUrl") %>','<%# DataBinder.Eval(Container.DataItem, "id") %>');">
                                            <ComponentArt:Ticker id="HeadlinesTicker" text='<%# DataBinder.Eval(Container.DataItem, "Text") %>'
                                                runat="server" /><img src="images/cursor.gif" alt="" width="6" height="7" style="border: none;" /></td>
                                    </tr>
                                </table>
                            </SlideTemplate>
                        </ComponentArt:Rotator>
                    </td>
                    <td style="background-position: right top; background-image: url(images/top-gray.gif);
                        background-repeat: no-repeat">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
