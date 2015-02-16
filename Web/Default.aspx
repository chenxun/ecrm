<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Powerson.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>源易网络CRM客户管理系统</title>
    <link rel="Stylesheet" type="text/css" href="css/main.css" />
    <script type="text/javascript" language="javascript" src="JavaScript/Windows.js"></script>
</head>
<body style="margin: 0px; height: 100%; " >
    <form id="form1" runat="server">
    <div>
    <table  cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%; ">
    	<tr>
    		<td style="width: 100%; height: 50px;" valign="top">
    		    <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
    		    	<tr>
    		    		<td class="LabelBlack" style="background-image: url(images/top-gray.gif); width: 100%; height: 50px; background-repeat: no-repeat; background-position: right top; border-bottom: black 1px solid;">
    		    		    <b>源易网络CRM客户管理系统</b><div style="font-size: small; font-family: Verdana, Arial">v2.0.1</div>
    		    		</td>
    		    	</tr>
    		    </table>
    		</td>
    	</tr>
    	<tr valign="middle" > <td align="center" valign="middle" >
    	    <table cellpadding="0" cellspacing="0" border="0" style="width: 431px; ">
    	    	<tr>
    	    		<td style="background-image: url(images/logon/Logon_1.gif); height: 125px;" colspan="2"></td>
    	    	</tr>
    	    	<tr><td colspan="2" style="background-image: url(images/logon/Logon_2.gif); height: 30px">
    	    	</td></tr>
                <tr>
                    <td style="background-image: url(images/logon/Logon_3.gif); width: 194px; height: 28px">
                    </td>
                    <td style="background-image: url(images/logon/Logon_4.gif)" align="left">
                        <asp:TextBox ID="TextBox_name" runat="server" Width="138px" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" runat="server" ControlToValidate="TextBox_name"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="login"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/logon/Logon_5.gif); height: 24px;">
                    </td>
                    <td style="background-image: url(images/logon/Logon_6.gif)" align="left">
                        <asp:TextBox ID="TextBox_password" runat="server" TextMode="Password" Width="138px" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_pass" runat="server" ControlToValidate="TextBox_password"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="login"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/logon/Logon_7.gif); height: 25px">
                    </td>
                    <td style="background-image: url(images/logon/Logon_8.gif)" align="left" class="LabelBlack">
                        <asp:TextBox ID="TextBox_code" runat="server" Columns="4" MaxLength="4" CssClass="TextBox"></asp:TextBox>请输入<img alt="ImageCheck" src="ValidateCode.aspx" height="20" width="45" /> </td>
                </tr>
                <tr>
                    <td style="background-image: url(images/logon/Logon_9.gif); height: 40px">
                    </td>
                    <td style="background-image: url(images/logon/Logon_10.gif)" align="left">
                        <asp:Button ID="Button_login" runat="server" Text="登录" CssClass="Button" OnClick="Button_login_Click" ValidationGroup="login" />
                        </td>
                </tr>
                <tr>
                    <td style="background-image: url(images/logon/Logon_11.gif); height: 39px" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" class="LabelBlack" >提醒：请使用IE6以上版本，并开启javascript
                    </td>
                </tr>
    	    </table>
    	</td> </tr>
    	<tr><td style="width: 100%; height: 20px" valign="bottom">
    	    <table  cellpadding="0" cellspacing="0" border="0" style="height: 20px">
    	    	<tr>
    	    		<td  class="down_text">
    	    		    Powered By <a href="http://www.ecomma.net/" target="_blank"><font color="#ffffff">Ecomma.net</font></a> Information Technology Logistics Inc.
    	    		</td>
    	    	</tr>
    	    </table>
    	</td></tr>
    </table></div>
    </form>
</body>
</html>
