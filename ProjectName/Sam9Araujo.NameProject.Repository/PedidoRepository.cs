using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Repository
{
    public class PedidoRepository : BaseRepository<Pedido, PedidoDAL, PedidoRepository>, IRepositoryBase
    {
        private static ItemPedidoDAL ItemPedidoDAL
        {
            get { return Singleton<ItemPedidoDAL>.Instance; }
        }

        public IList<Pedido> ConsultarPedido(int idPedido, string cpf)
        {
            string where = "idPedido = " + idPedido.ToString() + " AND cpfCnpj = " + cpf;
            return this.Listar(where, true);
        }

        public Pedido ObterPedidoPorItemPedido(int idItem, int idParceiro)
        {
            string where = "idPedido = " + ItemPedidoDAL.Obter("where idItem = " + idItem).IdParceiro + " AND idParceiro = " + idParceiro;

            return this.Obter(where, false);
        }

        public IList<Pedido> ConsultarPedidoData(DateTime dataIni, DateTime dataFin, string cpf)
        {
            string where = "data BETWEEN '" + dataIni.ToString("yyyy/MM/dd") + "' AND '" + dataFin.ToString("yyyy/MM/dd") + "' AND cpfCnpj = '" + cpf + "'";
            return this.Listar(where, true);
        }

        public Pedido Obter(string where, bool includeItensPedido = false)
        {
            Pedido pedido = base.Obter(where);

            if(includeItensPedido)
                if (pedido != null)
                {
                    pedido.ItensPedido = ItemPedidoDAL.Listar("idPedido = " + pedido.IdPedido + " AND idParceiro = " + pedido.IdParceiro);
                }
            return pedido;
        }

        public IList<Pedido> Listar(bool includeItensPedido = false)
        {
            return this.Listar("", includeItensPedido);
        }

        public IList<Pedido> Listar(string where, bool includeItensPedido = false)
        {
            IList<Pedido> pedido = base.Listar(where);

            if (includeItensPedido)
                for (int i = 0; i < pedido.Count; i++)
                    pedido[i].ItensPedido = ItemPedidoDAL.Listar("idPedido = " + pedido[i].IdPedido + " AND idParceiro = " + pedido[i].IdParceiro);

            return pedido;
        }

        public override int Update(Pedido pedido)
        {
            int ret = base.Update(pedido);

            if (pedido.ItensPedido != null)
            {
                //DELETE ALL ItensPedido vinculados ao Pedido
                ItemPedidoDAL.Delete("idPedido = " + pedido.IdPedido + " AND idParceiro = " + pedido.IdParceiro);

                for (int i = 0; i < pedido.ItensPedido.Count; i++)
                {
                    ItemPedidoDAL.Insert(pedido.ItensPedido[i]);
                }
            }
            return ret;
        }

        public override int Delete(Pedido pedido)
        {
            //DELETE ALL ItensPedido vinculados ao Pedido
            ItemPedidoDAL.Delete("idPedido = " + pedido.IdPedido + " AND idParceiro = " + pedido.IdParceiro);

            return base.Delete(pedido);
        }

        public override int Insert(Pedido pedido)
        {
            int ret = base.Insert(pedido);

            if (pedido.ItensPedido != null)
            {
                for (int i = 0; i < pedido.ItensPedido.Count; i++)
                {
                    ItemPedidoDAL.Insert(pedido.ItensPedido[i]);
                }
            }
            return ret;
        }

    }
}
