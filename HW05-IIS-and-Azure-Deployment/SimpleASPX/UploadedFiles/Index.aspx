<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SimpleASPX.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Greetings</title>
</head>
<body>
    <h3>Input your name</h3>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="textBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="button" runat="server" OnClick="On_Click" text="Show my name" />
        <br />
        <asp:Label ID="label" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
