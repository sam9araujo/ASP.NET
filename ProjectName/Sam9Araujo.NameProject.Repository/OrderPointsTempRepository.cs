using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository.DAL;

namespace Sam9araujo.NameProject.Repository
{
    public class OrderPointsTempRepository : BaseRepository<OrderPointsTemp, OrderPointsTempDAL, OrderPointsTempRepository>, IRepositoryBase
    {
        private static PedidoRepository PedidoRepository
        {
            get { return Singleton<PedidoRepository>.Instance; }
        }

        public OrderPointsTemp Obter(int idItem, int idParceiro)
        {
            Pedido pedido = PedidoRepository.ObterPedidoPorItemPedido(idItem, idParceiro);

            return base.Obter("where idParceiro = " + idParceiro + " AND idPedido = " + pedido.IdPedido);
        }
    }
}
