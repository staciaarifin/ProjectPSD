﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePaymentType.aspx.cs" Inherits="ProjectPSD.View.UpdatePaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Payment Type: <asp:Label ID="labType" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Payment Type
            <br />
            <asp:TextBox ID="txtPaymentType" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdatePaymentType" runat="server" OnClick="btnUpdatePaymentType_Click" Text="Update Payment Type" />
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Payment Type" />
            < br />
            < br />
            < asp:Button ID = "btnHome" runat = "server" OnClick = "BtnHome_Click" Text = "Back to Home" />
        </div>
    </form>
</body>
</html>
