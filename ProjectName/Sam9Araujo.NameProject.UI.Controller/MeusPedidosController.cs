using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class MeusPedidosController : BaseController<PedidoDTO>
    {
        public MeusPedidosController()
        {

        }

        public void ConsultarPedido(int idPedido, string cpf)
        {
            View.Pedidos = PedidoRepository.Instance.ConsultarPedido(idPedido, cpf);
        }

        public void ConsultarPedidoData(DateTime dataIni, DateTime dataFin, string cpf)
        {
            View.Pedidos = PedidoRepository.Instance.ConsultarPedidoData(dataIni, dataFin, cpf);
        
        }

        public void CarregarListaPedidos()
        {
            View.Pedidos = PedidoRepository.Instance.Listar();
            //View.Parceiro = ParceiroRepository.Instance.Listar();
        }
    }
}
