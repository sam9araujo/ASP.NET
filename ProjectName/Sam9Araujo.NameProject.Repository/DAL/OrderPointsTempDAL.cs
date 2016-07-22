using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using System.Data;
using Sam9araujo.NameProject.DataAccessLayer;

namespace Sam9araujo.NameProject.Repository.DAL 
{
    public class OrderPointsTempDAL : BaseDAL<OrderPointsTemp>
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

        public override string SqlSELECT
        {
            get { return QuerysSQL.selectOrderPointsTemp; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertOrderPointsTemp; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateOrderPointsTemp; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteOrderPointsTemp; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyOrderPointsTemp; }
        }

        internal override void ExecuteIncludes(List<OrderPointsTemp> orders)
        {
            if (_pedidoDAL != null)
            {
                for (int i = 0; i < orders.Count; i++)
                    orders[i].Pedido = _pedidoDAL.Obter("idPedido" + orders[i].IdPedido);
            }
        }
        internal override IDbDataParameter[] PrepareParametersFactory(OrderPointsTemp order, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 6);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 5);

            dataParameters[0].ParameterName = "idPedido";
            dataParameters[0].DbType = DbType.Int32;
            dataParameters[0].Value = order.IdPedido;

            dataParameters[1].ParameterName = "idParceiro";
            dataParameters[1].DbType = DbType.Int32;
            dataParameters[1].Value = order.IdParceiro;

            dataParameters[2].ParameterName = "idOrder";
            dataParameters[2].DbType = DbType.Int32;
            dataParameters[2].Value = order.IdOrder;

            dataParameters[3].ParameterName = "points";
            dataParameters[3].DbType = DbType.Int32;
            dataParameters[3].Value = order.Points;

            dataParameters[4].ParameterName = "dataHora";
            dataParameters[4].DbType = DbType.DateTime;
            dataParameters[4].Value = order.DataHora;

            if (includeKeys)
            {
                keyMethod(order, dataParameters, 5);
            }

            return dataParameters;
        }

        private static void keyMethod(OrderPointsTemp order, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idPedidoKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = order.IdPedido;

            i++;

            dataParameters[i].ParameterName = "idParceiroKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = order.IdParceiro;

            i++;
            
            dataParameters[i].ParameterName = "idOrderKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = order.IdOrder;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(OrderPointsTemp order)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 2);

            keyMethod(order, dataParameters, 0);

            return dataParameters;
        }

        public OrderPointsTempDAL()
        {
        }

        public override OrderPointsTemp Factory(IDataReader DataReader)
        {
            OrderPointsTemp order = new OrderPointsTemp();
            {
                order.IdPedido = int.Parse(DataReader["idPedido"].ToString());
                order.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                order.IdOrder = int.Parse(DataReader["idOrder"].ToString());
                order.Points = int.Parse(DataReader["points"].ToString());
                order.DataHora = DateTime.Parse(DataReader["dataHora"].ToString());
            }
            return order;
        }
    }
}
