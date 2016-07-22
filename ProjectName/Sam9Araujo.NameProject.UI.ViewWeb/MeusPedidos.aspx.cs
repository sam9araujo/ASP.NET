using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class MeusPedidos : BaseView<MeusPedidosController>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblBemVindo.Text = "Olá " + Utilidade.GetUsuarioLogado() + "!";

            if(!IsPostBack)
                pMsgPedidos.InnerText = "Para consultar seus pedidos, informe o número do pedido ou período desejado ao lado.";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ConsultarPedidos();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ConsultarPedidos();
        }

        private void ConsultarPedidos()
        {
            string cpf = Page.User.Identity.Name;

            if (txtPedido.Text != "Digite o número do pedido")
            {
                Controller.ConsultarPedido(Int32.Parse(txtPedido.Text), cpf);
                ListarPedidos();
            }
            else if (txtDataIni.Text != "Digite a data inicial" || txtDataFin.Text != "Digite a data final")
            {
                Controller.ConsultarPedidoData(DateTime.Parse(txtDataIni.Text), DateTime.Parse(txtDataFin.Text), cpf);
                ListarPedidos();
            }
        }

        private void ListarPedidos()
        {
            IList<Pedido> pedidos = Controller.View.Pedidos;

            if (pedidos.Count == 0)
            {
                pMsgPedidos.InnerText = "Nenhum pedido encontrado";
                pMsgPedidos.Visible = true;
                PedidoContainer.InnerHtml = "";
                divTablePedidos.Visible = false;
            }
            else
            {
                pMsgPedidos.InnerText = "";
                pMsgPedidos.Visible = false;
                PedidoContainer.InnerHtml = TrPedido(pedidos);
                divTablePedidos.Visible = true;
            }
        }

        private string TrPedido(IList<Pedido> pedidos)
        {
            string htmlPedido = "";

            for (int i = 0; i < pedidos.Count(); i++)
            {
                htmlPedido += "<tr>" +
                                "<th>" + pedidos[i].IdPedido + "</th>" +
                                "<th>" + pedidos[i].Status + "</th>" +
                                "<th>" + pedidos[i].Data.ToString("dd/MM/yyyy") + "</th>" +
                                "<th>" + pedidos[i].FormaPagamento + "</th>" +
                                //"<th>" + pedido.Bairro + "</th>" +
                                //"<th>" + pedido.Nome + "</th>" +
                                //"<th>" + pedido.Endereco + "</th>" +
                                "<th>" + pedidos[i].Frete.ToString("c") + "</th></tr>";
            }
            return htmlPedido;

        }

    }
}