<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Controls.Pager" %>
<div id="pag">
    <a href="?pagina=" runat="server" id="LinkAnterior" class="prev"><img src="img/pagprev.png" alt="Página anterior" /></a>
    <p>
        <a href="#" id="LinkPaginas" runat="server"></a>
    </p>
    <a href="?pagina=" runat="server" id="LinkProxima" class="next" style="position:static; margin:-25px 0px 0px 185px;">
        <img src="img/pagnext.png" alt="Próxima página" /></a>
</div>
