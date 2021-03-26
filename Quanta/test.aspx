<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Quanta.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server"
        Text="Button" onclick="Button1_Click" />
        <p><asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label></p>


    </div>
    </form>
</body>
</html>
