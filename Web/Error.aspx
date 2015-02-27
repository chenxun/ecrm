<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Powerson.Web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="css/main.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 100%" cellpadding="0" cellspacing="0" border="0" class="LableBlack">
    	<tr>
    		<td>对不起，程序在运行中出现了一些问题。<br/>
    		我们已经把错误信息记录下来，请联系管理员，告诉他错误的代号是:<br />
                <asp:Label ID="Label_errorCode" runat="server" ></asp:Label>
    		</td>
    	</tr>
    </table>
    </div>
    </form>
</body>
</html>
