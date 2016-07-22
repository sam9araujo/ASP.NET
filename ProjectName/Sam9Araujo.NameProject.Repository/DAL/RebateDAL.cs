using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.DataAccessLayer;
using System.Configuration;
using System.Data;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public class RebateDAL : BaseDAL<Rebate>
    {
        private ProdutoDAL _produtoDAL = null;

        public ProdutoDAL ProdutoDAL
        {
            get
            {
                if (_produtoDAL == null)
                    _produtoDAL = new ProdutoDAL();

                return _produtoDAL;
            }
        }

        public override string SqlSELECT
        {
            get { return QuerysSQL.selectRebate; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertRebate; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateRebate; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteRebate ; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyRebate; }
        }

        internal override void ExecuteIncludes(List<Rebate> rebates)
        {   
            if (_produtoDAL != null)
            {
                for (int i = 0; i < rebates.Count; i++)
                    rebates[i].Produto = _produtoDAL.Obter("idProduto = " + rebates[i].IdProduto + " AND idParceiro = " + rebates[i].IdParceiro);
            }
        }

        internal override IDbDataParameter[] PrepareParametersFactory(Rebate rebate, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 6);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 4);
         
            dataParameters[0].ParameterName = "idProduto";
            dataParameters[0].DbType = DbType.Int32;
            dataParameters[0].Value = rebate.IdProduto;

            dataParameters[1].ParameterName = "idParceiro";
            dataParameters[1].DbType = DbType.Int32;
            dataParameters[1].Value = rebate.IdParceiro;

            dataParameters[2].ParameterName = "data";
            dataParameters[2].DbType = DbType.DateTime;
            dataParameters[2].Value = rebate.Data;

            dataParameters[3].ParameterName = "valor";
            dataParameters[3].DbType = DbType.Decimal;
            dataParameters[3].Value = rebate.Valor;


            if (includeKeys)
            {
                int i = 4;

                keyMethod(rebate, dataParameters, i);
            }
            return dataParameters;
        }

        private static void keyMethod(Rebate rebate, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idProdutoKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = rebate.IdProduto;

            i++;

            dataParameters[i].ParameterName = "idParceiroKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = rebate.IdParceiro;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(Rebate rebate)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 2);

            int i = 0;

            keyMethod(rebate, dataParameters, i);
           
            return dataParameters;
        }

        public RebateDAL()
        {

        }

        public override Rebate Factory(IDataReader DataReader)
        {
            Rebate rebate = new Rebate();
            {
                rebate.IdProduto = int.Parse(DataReader["idProduto"].ToString());
                rebate.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                rebate.Data = DateTime.Parse(DataReader["data"].ToString());
                rebate.Valor = float.Parse(DataReader["valor"].ToString());
            }
            return rebate;
        }
    }
}
