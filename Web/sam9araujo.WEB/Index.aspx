<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="sam9araujo.WEB.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTotMessage" runat="server"></asp:Label>


        <asp:GridView ID="gvTicket" runat="server">
            <Columns>
    <asp:BoundField HeaderText = "From" DataField = "From" />
    <asp:HyperLinkField HeaderText = "Subject" DataNavigateUrlFields = "MessageNumber" DataNavigateUrlFormatString = "~/ShowMessageCS.aspx?MessageNumber={0}" DataTextField = "Subject" />
    <asp:BoundField HeaderText = "Date" DataField = "DateSent" />
</Columns>
        </asp:GridView>

    
    </div>
    </form>
</body>
</html>
