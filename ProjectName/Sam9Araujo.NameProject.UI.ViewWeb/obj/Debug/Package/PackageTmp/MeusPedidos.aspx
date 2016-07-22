<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true"
    CodeBehind="MeusPedidos.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.MeusPedidos" ViewStateMode="Disabled" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="meio" class="meuspedidos">
        <div class="in">
            <div id="sidebar">
                <span>Número do pedido</span>
                <asp:TextBox ID="txtPedido" runat="server" CssClass="numero text" Width="176px"/>
                <br />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/consultar.png"
                    CssClass="botao" OnClick="ImageButton1_Click" />
                <div></div>
                <span>período</span>
                <asp:TextBox ID="txtDataIni" runat="server" CssClass="datainicial text" Width="176px" />
              
                <asp:TextBox ID="txtDataFin" runat="server" CssClass="datafinal text" Width="176px" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/consultar.png"
                    CssClass="botao" OnClick="ImageButton2_Click"/>
                <br />
                <br />
            </div>
            
            <div id="conteudo">
            <div id="posiH2"> <h2> Consulta de pedidos</h2></div>
              
                <div id="breadcrumb">
                    <span>Você está em: <a href="Default.aspx">Home</a> > <strong> <a href="MeusPedidos.aspx"> Meus Pedidos</a></strong>
                    </span>
                </div>
                
                <%--<asp:Label ID="lblBemVindo" runat="server" Text="Olá BRUNO CAMPOS DALESSIO!"></asp:Label>--%>
                <p runat="server" id="pMsgPedidos">Para consultar seus pedidos, informe o número do pedido ou período desejado ao lado.</p>
                <div class="table" runat="server" id="divTablePedidos" visible="false">
                    <table cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>
                                    Código
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                    Data
                                </th>
                                <th>
                                    Forma de Pagamento
                                </th>
                                <%--<th>Produto</th>--%>
                                <%--<th>Preço unitário</th>--%>
                                <%--<th>Quantidade</th>--%>
                                <th>
                                    Frete
                                </th>
                            </tr>
                        </thead>
                        <tbody id="PedidoContainer" runat="server" style="height: 34px; text-align: left;
                            color: #696969; padding-left: 10px; font: normal 11px/13px Arial, sans-serif;
                            background: url('../img/bgtable.png') repeat-x left top; border-right: 1px solid #fff;
                            border-left: 1px solid #fff; vertical-align: middle;">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
