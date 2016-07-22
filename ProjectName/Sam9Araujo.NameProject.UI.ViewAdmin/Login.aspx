<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnEntrar" Width="50%" >
            <br />
            <h3>
                Bem-Vindo ao Gerenciador de Conteúdo do Shopping Pontos
            </h3>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblLogin" runat="server" Text="Login: " 
                            AssociatedControlID="txtLogin" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSenha" runat="server" Text="Senha: " AssociatedControlID="txtSenha" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnEntrar" runat="server" onclick="btnEntrar_Click" 
                            Text="Entrar" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblResultado" runat="server" ForeColor="Red" Text="Usuário ou Senha inválidos"
                            Visible="false" />
                    </td>
                    <td>
                    </td>
                    <td></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
