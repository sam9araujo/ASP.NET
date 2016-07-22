<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsercaoEmMassa.aspx.cs" Inherits="Laboris.Cosan.UI.ViewAdmin.InsercaoEmMassa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    Digite a quantidade de produtos q você deseja inserir
                    <asp:TextBox runat="server" ID="txtQuantidadeProduto"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnOk" Text="Ok" onclick="btnOk_Click" />
                </td>
            </tr>
            <tr>
                 <td>&nbsp;</td>
                 </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvwProdutos" runat="server" AllowSorting="False" AutoGenerateColumns="false"
                            EnableSortingAndPagingCallbacks="false" OnRowDataBound="gvwProdutos_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Nome" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Título" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Descrição" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Categoria" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbCategoria" runat="server" AppendDataBoundItems="true" Width="160px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="cmbCategoria"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" InitialValue="-1" Width="160px"
                                            ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Parceiro" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbParceiro" runat="server" AppendDataBoundItems="true" Width="160px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvParceiro" runat="server" ControlToValidate="cmbParceiro"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" InitialValue="-1" Width="160px"
                                            ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Link" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLink" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvLink" runat="server" ControlToValidate="txtLink"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Preço Cheio" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPrecoCheio" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvPrecoCheio" runat="server" ControlToValidate="txtPrecoCheio"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Preço" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPreco" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ControlToValidate="txtPreco"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Pontos" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPontos" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvPontos" runat="server" ControlToValidate="txtPontos"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Frete" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFrete" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvFrete" runat="server" ControlToValidate="txtFrete"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Imagem" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtImagem" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvImagem" runat="server" ControlToValidate="txtImagem"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Observação" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtObservacao" runat="server" CssClass="input" Width="160px" />
                                        <asp:RequiredFieldValidator ID="rfvObservacao" runat="server" ControlToValidate="txtObservacao"
                                            Display="Dynamic" ForeColor="Black" SetFocusOnError="true" ErrorMessage="<br> * Este campo é obrigatório" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr align="center">
                        <td>
                           <asp:Button runat="server" Text="Voltar" id="btnVoltar" PostBackUrl="~/Default.aspx" />&nbsp;&nbsp;&nbsp; 
                           <asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" Visible="False" ValidationGroup = "nenhum" />
                        </td>
                    </tr>

      
    </table>
    </form>
</body>
</html>
