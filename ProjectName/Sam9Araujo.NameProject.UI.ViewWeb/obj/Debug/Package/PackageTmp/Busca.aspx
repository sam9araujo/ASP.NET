<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true"
    CodeBehind="Busca.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Busca" ViewStateMode="Disabled" %>

<%@ Register Src="Controls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="Controls/AbasMenu.ascx" TagName="AbasMenu" TagPrefix="uc2" %>
<%@ Register Src="Controls/Busca.ascx" TagName="Busca" TagPrefix="uc3" %>
<%@ Register Src="Controls/NaveguePorTemas.ascx" TagName="NaveguePorTemas" TagPrefix="uc4" %>
<%@ Register Src="Controls/NossosParceiros.ascx" TagName="NossosParceiros" TagPrefix="uc5" %>
<%@ Register src="Controls/PrateleiraProdutos.ascx" tagname="PrateleiraProdutos" tagprefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/sliderBusca.js"></script>
    <script type="text/javascript" src="js/sliderComum.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="meio">
        <div class="in">
            <div id="sidebar">
                <uc2:AbasMenu ID="AbasMenu2" runat="server" />
                <div>
                    <asp:Panel ID="PanelBusca" runat="server" DefaultButton="ImageBusca">
                        <asp:TextBox runat="server" class="text TextBoxBusca" ID="TextBoxBusca" />
                        <asp:ImageButton ImageUrl="~/img/submitsidebar.png" runat="server" ID="ImageBusca"
                            OnClick="ImageBusca_Click" /></asp:Panel>
                </div>
                <div id="buscaadv">
                    <h1>
                        Filtrar também por:</h1>
                    <asp:UpdatePanel ID="UpdatePanelUpdateFiltroBusca" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:CheckBox runat="server" ID="CheckBoxponto" AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged" />
                                <asp:Label ID="Label1" AssociatedControlID="CheckBoxponto" runat="server">Pontos</asp:Label>
                            </div>
                            <div id="DivPontos" runat="server" visible="false">
                                <asp:TextBox ID="TextBoxPontoIn" runat="server" CssClass="text TextBoxPontoIn" />
                                até
                                <asp:TextBox ID="TextBoxPontoFin" runat="server" CssClass="text TextBoxPontoFin" />
                            </div>
                            <div>
                                <asp:CheckBox runat="server" ID="CheckBoxpreco" OnCheckedChanged="CheckBox_CheckedChanged"
                                    AutoPostBack="true" />
                                <asp:Label ID="Label2" AssociatedControlID="CheckBoxpreco" oncheckedchanged="CheckBox_CheckedChanged"
                                    runat="server">Preço</asp:Label>
                            </div>
                            <div id="DivPreco" runat="server" visible="false">
                                <asp:TextBox ID="TextBoxprecoInicial" runat="server" CssClass="text TextBoxprecoInicial" />
                                até
                                <asp:TextBox ID="TextBoxPrecoFinal" runat="server" CssClass="text TextBoxPrecoFinal" />
                            </div>
                            <div>
                                <asp:CheckBox runat="server" ID="CheckBoxofertas" CssClass="CheckBoxofertas" 
                                    OnCheckedChanged="CheckBox_CheckedChanged" EnableTheming="False" />
                                <asp:Label ID="Label3" AssociatedControlID="CheckBoxofertas" runat="server">Ofertas</asp:Label>
                            </div>
                            <div>
                                <asp:ImageButton ID="ImageButtonFiltrar" runat="server" ImageUrl="~/img/BtFiltrar.png"
                                    CssClass="filtrar" OnClick="ImageBusca_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <uc5:NossosParceiros ID="NossosParceiros1" runat="server" />
            </div>
            <div id="conteudo">
                <h1 style="text-align: center">
                    &nbsp;</h1>
<%
/*
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id='busca'>
                            <asp:Literal ID="LiteralMensagem" runat="server" />
                            <uc3:Busca ID="Busca1" runat="server" />
                        </div>
                        <uc1:Pager ID="Pager1" runat="server" Visible="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
*/
%>
                <asp:Literal ID="LiteralMensagem" runat="server" />
                <uc6:PrateleiraProdutos ID="PrateleiraProdutos1" runat="server" />
                <asp:Panel ID="PanelNaveguePorTemas" runat="server">
                    <uc4:NaveguePorTemas ID="NaveguePorTemas1" runat="server" />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
