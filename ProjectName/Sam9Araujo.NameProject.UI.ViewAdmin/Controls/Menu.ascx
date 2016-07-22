<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.Controls.Menu" %>
<div class="menu">
    <asp:Menu ID="mnuAdministrativo" runat="server" Orientation="Horizontal" MaximumDynamicDisplayLevels="2"
        DisappearAfter="100" StaticEnableDefaultPopOutImage="False" >
        <Items>
            <%-- Home Administrativos --%>
            <asp:MenuItem Text="Home" Value="imnHome" ToolTip="Pagina Incial" NavigateUrl="~/Default.aspx"></asp:MenuItem>
            <%-- Cadastro de Usuários --%>
            <asp:MenuItem Text="Cadastro de Usuários" Value="imnCadastroUsuários" ToolTip="Cadastro de Usuários" NavigateUrl="~/UsuarioDetalhe.aspx">
                <asp:MenuItem Text="Cadastro de Usuários" ToolTip="Cadastro de Usuários" NavigateUrl="~/UsuarioDetalhe.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Lista de Usuários" ToolTip="Lista de Usuários" NavigateUrl="~/UsuarioLista.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <%-- De Para --%>
            <asp:MenuItem Text="De-Para" Value="imnDePara" ToolTip="De-Para" NavigateUrl="~/DePara.aspx" ></asp:MenuItem>
            <%-- Inserção de Produtos em Massa --%>
            <asp:MenuItem Text="Inserção em Massa" Value="imnInsercaoEmMassa" ToolTip="Inserção em Massa" NavigateUrl="~/InsercaoEmMassa.aspx" ></asp:MenuItem>
            <%-- Sair --%>
            <asp:MenuItem ToolTip="Sair" NavigateUrl="~/Logout.aspx" ImageUrl="~/img/logout_icon.gif"></asp:MenuItem>
        </Items>
    </asp:Menu>
</div>

