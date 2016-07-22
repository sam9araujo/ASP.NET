<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NaveguePorTemas.ascx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Controls.NaveguePorTemas" %>
<div id="geralTemas">
<h2>Navegue por Categorias:</h2>
<div id="temas">
	<img src="img/loja/topo.png" alt="" />
	<div>
		<a href="#" class="prev"><img src="img/loja/prevorange.png" alt="Veja os temas anteriores" /></a>
		<div>
			<ul id="TemasContainer" runat="server">
			</ul>
		</div>
		<a href="#" class="next"><img src="img/loja/nextorange.png" alt="Veja os próximos temas" /></a>
	</div>
	<img src="img/loja/baixo.png" alt="" />
</div>
</div>