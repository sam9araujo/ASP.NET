using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sam9araujo.NameProject.Service.WebService.Contracts;
using Sam9araujo.NameProject.Service.Omnion;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.Service.Omnion.WebService
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Login : System.Web.Services.WebService
    {

        /// <summary>
        /// Recupera os pontos e o status da consulta
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "GetPoints", Description = "Recupera os pontos e o status da consulta")]
        public InterfacePoints GetPoints(string Login, string Token)
        {
            InterfacePoints interfacePoints = null;

            try
            {
                Sam9araujo.NameProject.Service.Omnion.Login usuario = OmnionLoginEngine.Instance.Get(Login, Token);

                if (usuario.CodigoErro == 0)
                {
                    interfacePoints = new InterfacePoints((decimal)usuario.Saldo, GetPointsEnum.CONSULTA_REALIZADA_COM_SUCESSO);
                    Logger.Log(Server.MapPath("~/WS_GetPoints.log"), "CONSULTA_REALIZADA_COM_SUCESSO", true, true);
                }
                else
                {
                    interfacePoints = new InterfacePoints(0, GetPointsEnum.ERRO_NA_CONSULTA);
                    Logger.Log(Server.MapPath("~/WS_GetPoints.log"), "ERRO_NA_CONSULTA", true, true);
                }

            }
            catch (Exception ex)
            {
                interfacePoints = new InterfacePoints(0, GetPointsEnum.ERRO_NA_CONSULTA);
                Logger.WriteLogError("GetPoints", ex);
            }

            return interfacePoints;
        }

        /// <summary>
        /// Recupera os dados do cliente
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <returns>Retorna OmnionLogin com os dados do cliente</returns>
        [WebMethod(MessageName = "GetCustomerData", Description = "Recupera os dados do cliente")]
        public InterfaceCustomer GetCustomerData(string Login, string Token)
        {
            InterfaceCustomer customer;
            try
            {
                Sam9araujo.NameProject.Service.Omnion.Login usuario = OmnionLoginEngine.Instance.Get(Login, Token);

                if (usuario.CodigoErro == 0)
                {
                    customer = new InterfaceCustomer(
                        (int)GetCustomerDataEnum.CONSULTA_REALIZADA_COM_SUCESSO,
                        usuario.CPF,
                        usuario.Nome,
                        string.Empty,
                        usuario.Endereco,
                        usuario.Numero.ToString(),
                        usuario.Complemento,
                        usuario.Bairro,
                        string.Empty,
                        usuario.Cidade,
                        usuario.Estado,
                        usuario.CEP,
                        usuario.Residencial,
                        usuario.DDD_Residencial,
                        usuario.Email);

                    Logger.Log(Server.MapPath("~/WS_GetCustomerData.log"), "CONSULTA_REALIZADA_COM_SUCESSO", true, true);
                }
                else
                {
                    customer = new InterfaceCustomer((int)GetCustomerDataEnum.ERRO_NA_CONSULTA);

                    Logger.Log(Server.MapPath("~/WS_GetCustomerData.log"), "ERRO_NA_CONSULTA", true, true);
                }
            }
            catch (Exception ex)
            {
                customer = new InterfaceCustomer((int)GetCustomerDataEnum.ERRO_NA_CONSULTA);
                Logger.WriteLogError("GetCustomerData", ex);
            }

            return customer;
        }

        /// <summary>
        /// Metodo utilizado para validar o Login e verificar se o usuário terá saldo suficiente para a compra na pagina da Omnion
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="OrderId">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "ValidateOrder", Description = "Valida o Login e verifica se o usuário terá saldo suficiente para a compra")]
        public InterfacePoints ValidateOrder(string Login, string Token, decimal Points, int OrderId)
        {
            return ValidateOrder2(Login, Token, Points, OrderId, 1);

        }

        /// <summary>
        /// Metodo utilizado para validar o Login e verificar se o usuário terá saldo suficiente para a compra na pagina da Omnion
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="OrderId">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "ValidateOrder2", Description = "Valida o Login e verifica se o usuário terá saldo suficiente para a compra")]
        public InterfacePoints ValidateOrder2(string Login, string Token, decimal Points, int OrderId, int Parceiro)
        {
            InterfacePoints interfacePoints;

            try
            {
                Sam9araujo.NameProject.Service.Omnion.UsuarioPedido usuarioPedido = new Sam9araujo.NameProject.Service.Omnion.UsuarioPedido();
                usuarioPedido.Usuario = OmnionLoginEngine.Instance.Get(Login, Token);
                Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "Parceiro: " + Parceiro, true, false);
                Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "OrderID: " + OrderId, false, false);
                Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "Pontos Recebidos: " + Points, false, false);

                if (usuarioPedido.Usuario.CodigoErro == 0)
                {
                    decimal saldoAtual = (decimal)usuarioPedido.Usuario.Saldo;

                    if (saldoAtual >= Points)
                    {
                        OrderPointsTemp orderPointsTemp = OrderPointsTempRepository.Instance.Obter(OrderId, Parceiro);
                        if (orderPointsTemp != null)
                        {
                            orderPointsTemp.Points = (int)Points;

                            OrderPointsTempRepository.Instance.Update(orderPointsTemp);
                        }
                        else
                        {
                            orderPointsTemp = new OrderPointsTemp();
                            {
                                orderPointsTemp.IdOrder = OrderId;
                                orderPointsTemp.Points = (int)Points;
                                orderPointsTemp.IdParceiro = Parceiro;
                            }

                            OrderPointsTempRepository.Instance.Insert(orderPointsTemp);
                        }

                        Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "Qntde de pontos do usuario: " + usuarioPedido.Usuario.Saldo.ToString(), false, false);
                        Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "CPF: " + usuarioPedido.Usuario.CPF, false, false);

                        interfacePoints = new InterfacePoints(saldoAtual, GetPointsEnum.CONSULTA_REALIZADA_COM_SUCESSO);
                    }
                    else
                    {
                        Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "Saldo Insuficiente" + usuarioPedido.Usuario.Saldo.ToString(), false, false);
                        interfacePoints = new InterfacePoints(0, GetPointsEnum.ERRO_NA_CONSULTA);
                    }

                }
                else
                {

                    interfacePoints = new InterfacePoints(0, GetPointsEnum.ERRO_NA_CONSULTA);
                }
            }
            catch (Exception ex)
            {
                interfacePoints = new InterfacePoints(0, GetPointsEnum.ERRO_NA_CONSULTA);
                Logger.Log(Server.MapPath("~/WS_ValidateOrder.log"), "Excessão, consultar LOG: " + DateTime.Now, false, true);
                Logger.WriteLogError("ValidateOrder", ex);
            }

            return interfacePoints;
        }

        /// <summary>
        /// Confirma a compra para o Parceiro e o armazenamento da informação. 
        /// Esse método será chamado na tela de confirmação dos dados do pedido, e confirmará a transação da reserva dos pontos, nele o parceiro deve debitar os pontos do usuário.
        /// Também será utilizado para validar o Login.
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="ped_id">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "FinalizeOrder", Description = "Confirma a compra para o Parceiro e o armazenamento da informação.")]
        public InterfaceStatus FinalizeOrder(string Login, string Token, int OrderId, int Status)
        {
            return FinalizeOrder3(Login, Token, OrderId, Status, 1, null);
        }

        /// <summary>
        /// Confirma a compra para o Parceiro e o armazenamento da informação. 
        /// Esse método será chamado na tela de confirmação dos dados do pedido, e confirmará a transação da reserva dos pontos, nele o parceiro deve debitar os pontos do usuário.
        /// Também será utilizado para validar o Login.
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="ped_id">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "FinalizeOrder2", Description = "Confirma a compra para o Parceiro e o armazenamento da informação.")]
        public InterfaceStatus FinalizeOrder2(string Login, string Token, int OrderId, int Status, int Parceiro)
        {
            return FinalizeOrder3(Login, Token, OrderId, Status, Parceiro, null);
        }

        /// <summary>
        /// Confirma a compra para o Parceiro e o armazenamento da informação. 
        /// Esse método será chamado na tela de confirmação dos dados do pedido, e confirmará a transação da reserva dos pontos, nele o parceiro deve debitar os pontos do usuário.
        /// Também será utilizado para validar o Login.
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="ped_id">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "FinalizeOrder3", Description = "Confirma a compra para o Parceiro e o armazenamento da informação.")]
        public InterfaceStatus FinalizeOrder3(string Login, string Token, int OrderId, int Status, int Parceiro, string XmlTroca)
        {
            /*
                <TROCA>
                <DATA>22/11/2010</DATA>
                <CPF>17263404818</CPF>
                <PONTOS>1</PONTOS>
                <PEDIDO>999</PEDIDO>
                <IDPARCEIRO>3</IDPARCEIRO>
                <PRODUTO>
                <NOME>BOLA QUADRADA</NOME>
                <CODIGO>X</CODIGO>
                <VALOR>30</VALOR>
                <QUANTIDADE>1</QUANTIDADE>
                <CODIGOCATEGORIA>0</CODIGOCATEGORIA>
                <DESCRICAOCATEGORIA>ESPORTIVOS;FUTEBOL;INFANTIL</DESCRICAOCATEGORIA>
                <FRETE>0</FRETE>
                </PRODUTO>
                <PRODUTO>
                <NOME>BOLA TRIANGULAR</NOME>
                <CODIGO>X</CODIGO>
                <VALOR>30</VALOR>
                <QUANTIDADE>1</QUANTIDADE>
                <CODIGOCATEGORIA>0</CODIGOCATEGORIA>
                <DESCRICAOCATEGORIA>ESPORTIVOS;FUTEBOL;INFANTIL</DESCRICAOCATEGORIA>
                <FRETE>0</FRETE>
                </PRODUTO>
                </TROCA>             
             */
            InterfaceStatus InterfaceStatus = null;

            try
            {
                Sam9araujo.NameProject.Service.Omnion.Login omnionLogin = OmnionLoginEngine.Instance.Get(Login, Token);

                if (omnionLogin != null)
                {
                    OrderPointsTemp orderPointsTemp = OrderPointsTempRepository.Instance.Obter(OrderId, Parceiro);

                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Parceiro: " + Parceiro, true, false);
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "OrderID: " + OrderId, false, false);
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Status Parceiro: " + Status, false, false);
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "CPF: " + omnionLogin.CPF, false, false);
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Pontos antes da transação: " + omnionLogin.Saldo, false, false);


                    if (orderPointsTemp != null)
                    {
                        Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Pedido: " + OrderId + " na tabela 'orderPointsTemp' recuperado.", false, false);
                        Omnion.Pedido omnionPedido = Omnion.OmnionPedidoEngine.Instance.Get(orderPointsTemp.IdOrder, orderPointsTemp.Points.ToString(), "0", omnionLogin.CPF, Parceiro, Server.UrlDecode(XmlTroca));



                        Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "omnionPedido.CodigoErro: " + omnionPedido.CodigoErro, false, false);
                        if (omnionPedido.CodigoErro == 0)
                        {
                            Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Pontos antes da transação: " + omnionLogin.Saldo, false, false);

                            if (XmlTroca != null && XmlTroca != string.Empty)
                            {
                                Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), XmlTroca, false, false);

                                Domain.Pedido pedido = new Domain.Pedido();
                                {
                                    //Dados do pedido
                                    pedido.Data = DateTime.Now;
                                    pedido.Nome = omnionLogin.Nome;
                                    pedido.FormaPagamento = "-";

                                    //Dados de Entrega do pedido
                                    pedido.Bairro = "-";
                                    pedido.Cidade = "-";
                                    pedido.UF = "-";
                                    pedido.CPFCNPJ = "-";
                                    pedido.CEP = "-";
                                    pedido.Endereco = "-";

                                    pedido.Frete = 0;
                                    pedido.Status = "OK";
                                    pedido.IdParceiro = Parceiro;

                                    ItemPedido itemPedido = new ItemPedido();
                                    {
                                        itemPedido.IdItem = OrderId;
                                        itemPedido.Quantidade = 1;
                                        itemPedido.ValorRebate = 0;
                                        itemPedido.PrecoUnitario = 0;
                                        itemPedido.Nivel = 0;
                                        //itemPedido.IdProduto = null;
                                        //itemPedido.NomeProduto = null;
                                    }
                                }
                                PedidoRepository.Instance.Insert(pedido);
                            }

                            InterfaceStatus = new InterfaceStatus(FinalizeOrderEnum.TRANSACAO_AUTORIZADA);
                            Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "TRANSACAO_AUTORIZADA", false, false);
                        }
                        else
                        {
                            InterfaceStatus = new InterfaceStatus(FinalizeOrderEnum.FALHA_GERAL);
                        }

                        Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Pontos depois da transação: " + omnionLogin.Saldo, false, false);
                    }
                    else
                    {
                        InterfaceStatus = new InterfaceStatus(FinalizeOrderEnum.FALHA_GERAL);
                        Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Erro ao recuperar o pedido: " + OrderId + " na tabela 'orderPointsTemp'", false, false);
                    }

                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "CodErro Omnion: " + omnionLogin.CodigoErro, false, false);
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Status Omnion: " + omnionLogin.Status, false, true);
                }
                else
                {
                    Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Erro ao tentar logar na Omnion:", false, true);
                }
            }
            catch (Exception ex)
            {
                InterfaceStatus = new InterfaceStatus(FinalizeOrderEnum.FALHA_GERAL);
                Logger.Log(Server.MapPath("~/WS_FinalizeOrder.log"), "Excessão, consultar LOG: " + DateTime.Now, false, true);
                Logger.WriteLogError("ValidateOrder", ex);
            }

            return InterfaceStatus;
        }

        /// <summary>
        /// Estorna os Pontos da Pessoa que foram reservados em uma determinada compra. 
        /// Esse método será chamado na tela de confirmação dos dados do pedido, e voltará a transação da reserva dos pontos, nele o parceiro deve voltar a pontuação anterior a reserva.
        /// Também será utilizado para validar o Login.
        /// </summary>
        /// <param name="Login">Login do usuário</param>
        /// <param name="Token">Token do usuário</param>
        /// <param name="ped_id">Pedido do usuário</param>
        /// <returns>Retorna InterfacePoints com os pontos e o status da consulta</returns>
        [WebMethod(MessageName = "RefundPoints", Description = "Estorna os Pontos da Pessoa que foram reservados em uma determinada compra.")]
        public InterfaceStatus RefundPoints(string Login, string Token, int OrderId)
        {
            return RefundPoints2(Login, Token, OrderId, 1);
        }

        [WebMethod(MessageName = "RefundPoints2", Description = "Estorna os Pontos da Pessoa que foram reservados em uma determinada compra.")]
        public InterfaceStatus RefundPoints2(string Login, string Token, int OrderId, int Parceiro)
        {
            Omnion.Login usuario = OmnionLoginEngine.Instance.Get(Login, Token);

            InterfaceStatus stauts;

            if (usuario.CodigoErro == 0)
            {
                Omnion.Cancelamento cancel = OmnionCancelamentoEngine.Instance.Get(OrderId, Parceiro);

                if (cancel != null)
                    stauts = new InterfaceStatus(RefundPointsEnum.PONTOS_EXTORNADOS_COM_SUCESSO);
                else
                    stauts = new InterfaceStatus(RefundPointsEnum.ERRO_NA_CONSULTA);


            }
            else
            {
                stauts = new InterfaceStatus(RefundPointsEnum.ERRO_NA_CONSULTA);
            }

            return stauts;
        }

    }
}
