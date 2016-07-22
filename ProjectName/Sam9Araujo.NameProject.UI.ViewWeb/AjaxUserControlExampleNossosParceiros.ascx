<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AjaxUserControlExampleNossosParceiros.ascx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.AjaxTestNossosParceiros" %>
<asp:UpdatePanel ID="updatePnlNossosParceiros" runat="server">
    <ContentTemplate>
        <div id="parceiros">
	        <h1>Nossos parceiros</h1>
            <asp:Panel ID="panelListaParceiros" runat="server">
            </asp:Panel>
            <asp:Button ID="btPrevious" runat="server" Text="Anterior" 
                onclick="btPrevious_Click" />
            <asp:Button ID="btNext" runat="server" Text="Próximo" onclick="btNext_Click" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
