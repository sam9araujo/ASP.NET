<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.Controls.Login" %>
<div id="login">
    <asp:Panel ID="PanelNotLoged" runat="server">
		<p>Área restrita</p>
		<div>
			<asp:TextBox ID="txtCpf" runat="server" CssClass="cpf" />
			<asp:TextBox ID="txtSenha" runat="server" CssClass="senha" 
                TextMode="Password" />
			<asp:ImageButton ID="btLogin" ImageUrl="~/img/ok.png" runat="server" 
                onclick="btLogin_Click" />
		</div>
		<div><asp:ImageButton ID="ImageButton1" ImageUrl="~/img/cadastrese.png" runat="server" /></div>
    </asp:Panel>
    <asp:Panel ID="PanelLoged" runat="server" Visible="False">
        <br />  
        <p runat="server" id="msgLogin"></p>
        <p><asp:LinkButton ID="linkLogout" runat="server" onclick="linkLogout_Click">Sair</asp:LinkButton></p>
    </asp:Panel>
</div>
