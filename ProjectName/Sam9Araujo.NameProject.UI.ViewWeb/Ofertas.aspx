<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Ofertas.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Ofertas" ViewStateMode="Disabled"%>
<%@ Register Src="Controls/NossosParceiros.ascx" TagName="NossosParceiros" TagPrefix="uc1" %>
<%@ Register Src="Controls/NaveguePorTemas.ascx" tagname="NaveguePorTemas" tagprefix="uc2" %>

<%@ Register src="Controls/Busca.ascx" tagname="Busca" tagprefix="uc3" %>

<%@ Register src="Controls/AbasMenu.ascx" tagname="AbasMenu" tagprefix="uc4" %>

<%@ Register src="Controls/Pager.ascx" tagname="Pager" tagprefix="uc5" %>

<%@ Register src="Controls/OrdenacaoProdutos.ascx" tagname="OrdenacaoProdutos" tagprefix="uc6" %>

<%@ Register src="Controls/PrateleiraProdutos.ascx" tagname="PrateleiraProdutos" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/sliderOfertas.js"></script>
    <script type="text/javascript" src="js/sliderComum.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div id="meio">
	<div class="in">
		<div id="sidebar">
		    <uc4:AbasMenu ID="AbasMenu1" runat="server" />
            <uc1:NossosParceiros ID="NossosParceiros1" runat="server" />
		</div>
		<div id="conteudo">
			<h1>CONFIRA AS NOSSAS PRINCIPAIS OFERTAS</h1>
    	    <uc6:OrdenacaoProdutos ID="OrdenacaoProdutos1" runat="server" />
<%
/*
			<div id="busca">
			    <uc3:Busca ID="Busca1" runat="server" />
			</div>
            <uc5:Pager ID="Pager1" runat="server" />
*/
%>
		    <uc7:PrateleiraProdutos ID="PrateleiraProdutos1" runat="server" />
            <uc2:NaveguePorTemas ID="NaveguePorTemas1" runat="server" />
		</div>
	</div>
</div>
</asp:Content>
