<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioLista.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.UsuarioLista" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Panel ID="pnlPesquisa" runat="server">
                <table>
                <tr>
                    <td><asp:Label runat="server" Text="Nome: " ID="lblNome"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtNome"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="E-mail: " ID="lblEmail"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtEmail"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Login: " ID="lblLogin"></asp:Label> </td>
                    <td><asp:TextBox runat="server" ID="txtLogin"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Ativo: " ID="lblAtivo"></asp:Label> </td>
                    <td><asp:CheckBox runat="server" ID="chkAtivo" ></asp:CheckBox> </td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" ID="btnVoltar" Text="Voltar" PostBackUrl="~/Default.aspx" /></td>
                    <td><asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" 
                            onclick="btnPesquisar_Click"/></td>
                    <td><asp:Button runat="server" ID="btnNovo" Text="Novo" PostBackUrl="~/UsuarioDetalhe.aspx"/></td>
                </tr>
            </table>
            </asp:Panel>

           <asp:Label ID="lblQuantidadeEncontrada" runat="server"></asp:Label><br />
           <asp:Label ID="lblPeriodo" runat="server"></asp:Label><br />
        <br />
        <asp:GridView ID="gvwUsuarios" runat="server" OnPageIndexChanging="gvwUsuarios_PageIndexChanging" 
            PagerSettings-Mode="NumericFirstLast" AutoGenerateColumns="False" AllowSorting="True"
            AllowPaging="True">
            <Columns>
                <asp:BoundField HeaderText="Data de Cadastro" SortExpression="DataCadastro" DataField="DataCadastro"
                    DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="115px"
                    HeaderStyle-Width="115px" />
                <asp:BoundField HeaderText="Nome" SortExpression="Nome" DataField="Nome" ItemStyle-Width="250px"
                    HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="E-Mail" SortExpression="Email" DataField="Email" ItemStyle-Width="250px"
                    HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="Login" SortExpression="Login" DataField="Login" ItemStyle-Width="250px"
                    HeaderStyle-HorizontalAlign="Left" />
                
                <asp:TemplateField HeaderText="Ativo" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px"
                    ControlStyle-Width="80px" HeaderStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblAtivo" runat="server" Text='<%# ((bool)Eval("IsAtivo")) ? "Sim" : "Não" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visualizar Detalhes" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnModify" runat="server" PostBackUrl='<%# "UsuarioDetalhe.aspx?u=" + Eval("IdUsuario") %>'
                            ImageUrl="~/img/icon_edit.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <asp:Label ID="lblResultado" runat="server" CssClass="resultado"></asp:Label>
    </div>
    </form>
</body>
</html>
