<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="MapadoSite.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.MapadoSite" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div id="meio">
	<div class="in">
		<div id="contentfull">
			<h2>Mapa do site</h2>
			<ul id="mapa">
				<li>Home
					<ul>
						<li>Categorias
							<ul>
								<li>Informática</li>
								<li>Esportes</li>
								<li>Gastronomia</li>
								<li>Eletro-Eletrônico</li>
								<li>Telefonia</li>
								<li>Diversão e Cultura
									<ul>
										<%--<li>Loren Ipsum</li>--%>
									</ul>
								</li>
							</ul>
						</li>
						<li>Lojas</li>
						<li>Ofertas em geral</li>
						<li>Quiosque</li>
					</ul>
				</li>
			</ul>
		</div>
	</div>
</div>
</asp:Content>
