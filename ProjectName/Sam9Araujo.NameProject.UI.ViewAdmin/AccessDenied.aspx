<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.AccessDenied" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="header" style="padding-left:100px;">
    	    &nbsp;</div>

    	<div class="conteudomeio">

        <h2>Acesso Negado</h2>       
        
        Você não tem permissão para acessar essa área
        
        <br /><br /><br />
        
        <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" /></div>
    </div>
    </form>
</body>
</html>
