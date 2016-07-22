<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true"
    CodeBehind="Categoria.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.AmbienteAspx" ViewStateMode="Disabled" %>

<%@ Register Src="Controls/NaveguePorTemas.ascx" TagName="NaveguePorTemas" TagPrefix="uc2" %>
<%@ Register Src="Controls/PrateleiraProdutos.ascx" TagName="PrateleiraProdutos"
    TagPrefix="uc3" %>
    <%@ Register Src="Controls/NossosParceiros.ascx" TagName="NossosParceiros" TagPrefix="uc1" %>
<%@ Register src="Controls/AbasMenu.ascx" tagname="AbasMenu" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/sliderCategoria.js"></script>
    <script type="text/javascript" src="js/sliderComum.js"></script>
   <style id="styleDinamicoBannerAmbiente" type="text/css" runat="server">
   </style>
<%
/*
        #slide.loja
        {
          background: #b4390b url("../img/slide/bgloja.png") repeat-x left bottom;
        }
        .classDivAmbiente
        {
            min-height: 167px;
            background: url("../ImagensAmbientes/eletro.jpg") no-repeat left top;
        }
*/
%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="meio">
        <div class="in" id="BannerAmbiente">
            <div id="sidebar">
                <uc4:AbasMenu ID="AbasMenu1" runat="server" /><br />
                <uc1:NossosParceiros ID="NossosParceiros1" runat="server" />
            </div>
            <div id="conteudo">
                <h1>
                    Confira AS NOSSAS OFERTAS</h1>
                <div id="breadcrumb">
                    <span>Você está em:</span> <a href="Default.aspx">Home</a> > <strong id="lblAmbienteAtual"
                        runat="server"></strong>
                </div>
                <uc3:PrateleiraProdutos ID="PrateleiraProdutos1" runat="server" />
                <%--<uc1:SitesParceiros ID="SitesParceiros1" runat="server" />--%>
                <uc2:NaveguePorTemas ID="NaveguePorTemas1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
