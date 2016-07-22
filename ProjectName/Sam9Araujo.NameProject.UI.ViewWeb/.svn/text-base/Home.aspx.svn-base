<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Home" %>

<%@ Register Src="~/Controls/NossosParceiros.ascx" TagName="NossosParceiros" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div id="meio">
	<div class="in">
		<div id="sidebar">
			<span>Navegue por:</span>
			<ul>
				<li class="hover"><a href="#">Categorias</a></li>
				<li><a href="#">Busca<br />Avançada</a></li>
				<li><a href="#">Principais ofertas</a></li>
			</ul>
			<div id="fav">
				<h1>Meus favoritos</h1>
				<p>Arraste  as categorias e monte sua lista favorita.</p>
				<div>0 Itens</div>
			</div>
            <uc1:NossosParceiros ID="NossosParceiros1" runat="server" />
        </div>
		<div id="conteudo">
			<h1>Seja bem-vindo ao Shopping Pontos! Fique a vontade e visite os ambientes abaixo.</h1>
            <div id="divAmbienteEsq" class="ambiente" runat="server">
            </div>
			<div class="ambiente">
				<div id="anuncio">
					<p>Clube de compras</p>
					<div>
						<img src="img/demo/anuncio.jpg" alt="" />
					</div>
				</div>
                <div id="divAmbienteDir" class="ambiente" runat="server">
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
