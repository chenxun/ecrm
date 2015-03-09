<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Timeout.aspx.cs" Inherits="Powerson.Web.Timeout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>程序过期</title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />

    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>

</head>
<body onload="WindowsMax(null);">
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        对不起，您的登录信息已经过期。为了安全起见，请您重新登录。</td>
                </tr>
                <tr>
                    <td>
                        请点击这里<a href="Default.aspx">返回登录首页</a><br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
