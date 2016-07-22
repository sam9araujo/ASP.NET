<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrdenacaoProdutos.ascx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Controls.OrdenacaoProdutos" %>
<div class="ordenaProdutos">
Ordenar produtos por:
<asp:DropDownList ID="ddlOrdem" CssClass="ordemCombo" runat="server" 
        AutoPostBack="True" ViewStateMode="Enabled" 
        onselectedindexchanged="ddlOrdem_SelectedIndexChanged"></asp:DropDownList>
</div>