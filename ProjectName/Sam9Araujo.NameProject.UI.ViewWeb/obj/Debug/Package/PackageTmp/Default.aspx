<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Default" ViewStateMode="Disabled" %>

<%@ Register Src="Controls/NossosParceiros.ascx" TagName="NossosParceiros" TagPrefix="uc1" %>
<%@ Register Src="Controls/AbasMenu.ascx" TagName="AbasMenu" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript" src="js/in/slider.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="meio">
                <div class="in">
                    <div id="sidebar">
                        <uc2:AbasMenu ID="AbasMenu2" runat="server" />
                        <div id="fav">
                            <h1>
                                Meus favoritos</h1>
                            <p>
                                Arraste as categorias e monte sua lista favorita.</p>
                            <div id="divFavItensAmbiente"><br /></div>
                        </div>
                        <uc1:NossosParceiros ID="NossosParceiros1" runat="server" />
                    </div>
                    <div id="conteudo">
                        <%--<h1>
                            Seja bem-vindo ao Shopping Pontos! Fique a vontade e visite os ambientes abaixo.</h1>--%>
                        <div id="divAmbienteEsq" class="ambiente" runat="server">
                        </div>
                        <div class="ambiente">
                            <div id="anuncio">
                                <p>
                                    Clube de compras</p>
                                <div>
                                    <%--<img src="img/demo/anuncio.jpg" alt="" />--%>

                                    <iframe src="http://ads.imperdivel.com.br/widget/geoip/cosan/" width="300px" frameborder="0" scrolling="no" height="280px"></iframe>

                                </div>
                            </div>
                            <div id="divAmbienteDir" class="ambiente" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
