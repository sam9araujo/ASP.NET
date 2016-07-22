<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Redirect" %>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body runat="server" id="Body">
<%--<script>
    document.write = "Estamos redirecionando...";
    window.setTimeout("location.href='http://www.site.com'", 3000)
</script>--%>
    <form id="form1" runat="server">
    <div id="redirect_body">
        <p><strong>Aguarde</strong>. Você está sendo redirecionado...</p><br />
        <br />
        <br />
        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/logotopo.png" />
        <br />
        <br />
        <br />
        <br />
        Você está comprando no parceiro:<br />
        <br />
        <asp:Label ID="Label1" runat="server" />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
