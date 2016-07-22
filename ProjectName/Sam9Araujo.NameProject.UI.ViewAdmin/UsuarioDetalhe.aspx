<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioDetalhe.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.UsuarioDetalhe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID=  "pnlCadastro" runat="server">
                <table>
                <tr>
                    <td><asp:Label runat="server" Text="Nome: " ID="lblNome"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtNome"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="valNome" runat="server" ValidationGroup="gravar"
                        ControlToValidate="txtNome" ErrorMessage="O campo 'Nome' é de preenchimento obrigatório"
                        Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="E-mail: " ID="lblEmail"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtEmail"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ValidationGroup="gravar"
                        ControlToValidate="txtEmail" ErrorMessage="O campo 'E-mail' é de preenchimento obrigatório"
                        Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valEmailFormat" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="O e-mail está em um formato inválido" 
                            ValidationExpression="^ *\w+(\.\w+)*@\w+(\.\w+)+ *$" Display="Dynamic" ValidationGroup="gravar"
                            SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Login: " ID="lblLogin"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtLogin"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="rfvLogin" runat="server" ValidationGroup="gravar"
                        ControlToValidate="txtLogin" ErrorMessage="O campo 'Login' é de preenchimento obrigatório"
                        Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Senha: " ID="lblSenha"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtSenha" TextMode="Password"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="rfvSenha" runat="server" ValidationGroup="gravar"
                        ControlToValidate="txtSenha" ErrorMessage="O campo 'Senha' é de preenchimento obrigatório"
                        Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td><asp:Label runat="server" Text="Confirmar senha:: " ID="lblConfirmaSenha"></asp:Label> </td>
                <td><asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password"></asp:TextBox></td>
                <td><asp:CompareValidator ID="cvCompararSenha" runat="server" 
                        ValidationGroup="gravar" ControlToValidate="txtConfirmaSenha" 
                        ErrorMessage="As senhas não conferem!" ControlToCompare="txtSenha" 
                        Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Ativo: " ID="lblAtivo"></asp:Label> </td>
                    <td><asp:CheckBox runat="server" ID="chkAtivo" Checked="true"></asp:CheckBox> </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="btnVoltar" PostBackUrl="~/Default.aspx" 
                            Text="Voltar"/>&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" onclick="btnSalvar_Click" ValidationGroup="gravar" />  </td>
                    <td></td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                <asp:Label ID="lblResultadoInsercacao" runat="server"></asp:Label>
                <br /><br />
                <asp:Button ID="btnVoltar2" runat="server" CausesValidation="false" PostBackUrl="UsuarioLista.aspx" Text="Voltar"></asp:Button>
            </asp:Panel>
    </div>
    </form>
</body>
</html>
