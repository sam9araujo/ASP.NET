<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DePara.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.DePara" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td>
                    Parceiro
                    <br />
                        <asp:DropDownList runat="server" ID="ddlParceiro" AutoPostBack="True" 
                        onselectedindexchanged="ddlParceiro_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvParceiro" runat="server" ControlToValidate="ddlParceiro"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="true" InitialValue="-1" Width="160px"
                                            ErrorMessage="<br> * Este campo é obrigatório" ValidationGroup="Validar" />
                    <br /><br /><br />
                    Categoria
                    <br />
                        <asp:ListBox runat="server" ID="lbxCategoria" SelectionMode="Multiple"></asp:ListBox>
                        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="lbxCategoria" ForeColor="Red"
            ErrorMessage="<br> * Este campo é obrigatório" ValidationGroup="ValidarResultado"></asp:RequiredFieldValidator>
                    <br /><br /><br />
                    Ambiente
                    <br />
                    <asp:ListBox runat="server" ID="lbxAmbiente"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="rfvAmbiente" runat="server" ControlToValidate="lbxAmbiente" ForeColor="Red"
            ErrorMessage="<br> * Este campo é obrigatório" ValidationGroup="ValidarResultado"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="lkOk" Text=">>" onclick="lkOk_Click" ValidationGroup="ValidarResultado" ></asp:LinkButton>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lkRemove" Text="<<" 
                        onclick="lkRemove_Click"></asp:LinkButton>
                </td>
                <td>
                    Resultado
                    <br />
                    <asp:ListBox runat="server" ID="lbxResultado" SelectionMode="Multiple"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="rfvResultado" runat="server" ControlToValidate="lbxResultado" ForeColor="Red"
            ErrorMessage="<br> * Este campo é obrigatório" ValidationGroup="Validar"></asp:RequiredFieldValidator><br />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                <asp:Button runat="server" Text="Voltar" id="btnVoltar" PostBackUrl="~/Default.aspx" />&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Salvar" id="btnSalvar" 
                        onclick="btnSalvar_Click" ValidationGroup="Validar" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
