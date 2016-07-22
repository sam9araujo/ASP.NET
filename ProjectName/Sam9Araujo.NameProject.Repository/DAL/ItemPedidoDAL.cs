using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.DataAccessLayer;
using System.Configuration;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public class ItemPedidoDAL : BaseDAL<ItemPedido>
    {
        private PedidoDAL _pedidoDAL;

        public PedidoDAL PedidoDAL
        {
            get
            {
                if (_pedidoDAL == null)
                    _pedidoDAL = new PedidoDAL();

                return _pedidoDAL;
            }
        }

        public ItemPedidoDAL()
        {
        
        }

        public override string SqlSELECT
        {
            get { return QuerysSQL.selectItemPedido; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertItemPedido; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateItemPedido; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteItemPedido; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyItemPedido; }
        }

        internal override void ExecuteIncludes(List<ItemPedido> itemPedido)
        {
            if (_pedidoDAL != null)
            {
                for (int i = 0; i < itemPedido.Count; i++)
                    itemPedido[i].Pedido = _pedidoDAL.Obter("idPedido" + itemPedido[i].IdPedido);
            }
        }

        internal override IDbDataParameter[] PrepareParametersFactory(ItemPedido itemPedido, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 12);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 9);
            
            dataParameters[0].ParameterName = "idPedido";
            dataParameters[0].DbType = DbType.Int32;
            dataParameters[0].Value = itemPedido.IdPedido;

            dataParameters[1].ParameterName = "idParceiro";
            dataParameters[1].DbType = DbType.Int32;
            dataParameters[1].Value = itemPedido.IdParceiro;

            dataParameters[2].ParameterName = "idItem";
            dataParameters[2].DbType = DbType.Int32;
            dataParameters[2].Value = itemPedido.IdItem;

            dataParameters[3].ParameterName = "precoUnitario";
            dataParameters[3].DbType = DbType.Decimal;
            dataParameters[3].Value = itemPedido.PrecoUnitario;

            dataParameters[4].ParameterName = "quantidade";
            dataParameters[4].DbType = DbType.Int32;
            dataParameters[4].Value = itemPedido.Quantidade;

            dataParameters[5].ParameterName = "nomeProduto";
            dataParameters[5].DbType = DbType.String;
            dataParameters[5].Value = itemPedido.NomeProduto;

            dataParameters[6].ParameterName = "valorRebate";
            dataParameters[6].DbType = DbType.Decimal;
            dataParameters[6].Value = itemPedido.ValorRebate;

            dataParameters[7].ParameterName = "nivel";
            dataParameters[7].DbType = DbType.Int32;
            dataParameters[7].Value = itemPedido.Nivel;

            dataParameters[8].ParameterName = "pontos";
            dataParameters[8].DbType = DbType.Int32;
            dataParameters[8].Value = itemPedido.Pontos;

            if (includeKeys)
            {
                int i = 9;

                keyMethod(itemPedido, dataParameters, i);
            }
            
            return dataParameters;
        }

        private static void keyMethod(ItemPedido itemPedido, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idPedidoKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = itemPedido.IdPedido;

            i++;

            dataParameters[i].ParameterName = "idParceiroKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = itemPedido.IdParceiro;

            i++;

            dataParameters[i].ParameterName = "idItemKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = itemPedido.IdItem;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(ItemPedido itemPedido)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 2);

            int i = 0;

            keyMethod(itemPedido, dataParameters, i);

            return dataParameters;
        }
        
        public override ItemPedido Factory(IDataReader DataReader)
        {
            ItemPedido ItemPedido = new ItemPedido();
            {
                ItemPedido.IdPedido = int.Parse(DataReader["idPedido"].ToString());
                ItemPedido.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                ItemPedido.IdItem = int.Parse(DataReader["idItem"].ToString());
                ItemPedido.NomeProduto = DataReader["nomeProduto"].ToString();
                ItemPedido.Pontos = int.Parse(DataReader["pontos"].ToString());
                ItemPedido.PrecoUnitario = float.Parse(DataReader["precoUnitario"].ToString());
                ItemPedido.Quantidade = int.Parse(DataReader["quantidade"].ToString());
                ItemPedido.ValorRebate = float.Parse(DataReader["valorRebate"].ToString());
                ItemPedido.Nivel = int.Parse(DataReader["nivel"].ToString());
                ItemPedido.Pontos = int.Parse(DataReader["pontos"].ToString());
            }
            return ItemPedido;
        }

    }
}
