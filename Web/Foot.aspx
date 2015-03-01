<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Foot.aspx.cs" Inherits="Powerson.Web.Foot" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />

    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 20px">
                <tr>
                    <td class="down_text">
                        Powered By <a href="http://www.ecomma.net/" target="_blank"><font color="#ffffff">Ecomma.net</font></a>
                        Information Technology Logistics Inc.
                    </td>
                    <td valign="top" align="right" width="240" style="border-left: 1px solid #000000;
                        border-right-width: 1; border-top-width: 1; border-bottom-width: 1; background-color: #D6D6DA;
                        color: #FFFFFF">
                        <button name="xsubmit" class="down_tools_button" onclick="javascript: window.top.location.href = 'Logout.aspx'">
                            <img alt="" border="0" src="images/logout.gif" align="top" />&nbsp;退出系统</button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
