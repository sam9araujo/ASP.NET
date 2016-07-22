﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.DataAccessLayer;
using System.Configuration;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public class AtributoProdutoDAL : BaseDAL<AtributoProduto>
    {
        private ParceiroDAL _parceiroDAL = null;
        private ProdutoDAL _produtoDAL = null;

        public ParceiroDAL ParceiroDAL
        {

            get {
                if (_parceiroDAL == null)
                    _parceiroDAL = new ParceiroDAL();

                return _parceiroDAL;
                }
        }

        public ProdutoDAL ProdutoDAL
        {
            get {
                if (_produtoDAL == null)
                    _produtoDAL = new ProdutoDAL();

                return _produtoDAL;
                }
        
        }


        public override string SqlSELECT
        {
            get { return QuerysSQL.selectAtributo; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertAtributo; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateAtributo; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteAtributo; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyAtributo; }
        }

        internal override void ExecuteIncludes(List<AtributoProduto> atributoProduto)
        {
            
            if (_produtoDAL != null)
            {
                for (int i = 0; i < atributoProduto.Count; i++)
                    atributoProduto[i].Produto = _produtoDAL.Obter("idProduto = " + atributoProduto[i].IdProduto);
            }
        }

       
         internal override IDbDataParameter[] PrepareParametersFactory(AtributoProduto atributoProduto, bool includeKeys = false)
         {
             IDbDataParameter[] dataParameters;

             if (includeKeys)
                 dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 7);
             else
                 dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 6);

             //dataParameters[0].ParameterName = "idAtributo";
             //dataParameters[0].DbType = DbType.Int32;
             //dataParameters[0].Value = atributoProduto.IdAtributo;

             dataParameters[0].ParameterName = "atributo";
             dataParameters[0].DbType = DbType.String;
             dataParameters[0].Value = atributoProduto.Atributo;

             dataParameters[1].ParameterName = "descricao";
             dataParameters[1].DbType = DbType.String;
             dataParameters[1].Value = atributoProduto.Descricao;

             dataParameters[2].ParameterName = "isDisponivel";
             dataParameters[2].DbType = DbType.Boolean;
             dataParameters[2].Value = atributoProduto.IsDisponivel;

             dataParameters[3].ParameterName = "dataCadastro";
             dataParameters[3].DbType = DbType.DateTime;
             dataParameters[3].Value = atributoProduto.DataCadastro;

             dataParameters[4].ParameterName = "idProduto";
             dataParameters[4].DbType = DbType.Int32;
             dataParameters[4].Value = atributoProduto.IdProduto;

             dataParameters[5].ParameterName = "idParceiro";
             dataParameters[5].DbType = DbType.Int32;
             dataParameters[5].Value = atributoProduto.IdParceiro;

             if (includeKeys)
             {
                 int i = 6;

                 keyMethod(atributoProduto, dataParameters, i);
             }
             return dataParameters;
         }



         private static void keyMethod(AtributoProduto atributoProduto, IDbDataParameter[] dataParameters, int i)
         {
             dataParameters[i].ParameterName = "idAtributoKey";
             dataParameters[i].DbType = DbType.Int32;
             dataParameters[i].Value = atributoProduto.IdAtributo;

         }


        internal override IDbDataParameter[] PrepareParametersKeyFactory(AtributoProduto atributoProduto)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 1);

            int i = 0;

            keyMethod(atributoProduto, dataParameters, i);
            
            return dataParameters;
        }

        public AtributoProdutoDAL()
        {
            
        }

        public override AtributoProduto Factory(IDataReader DataReader)
        {
            AtributoProduto AtributoProduto = new AtributoProduto();
            {
               AtributoProduto.IdAtributo = int.Parse(DataReader["idAtributo"].ToString());
                AtributoProduto.IdProduto = int.Parse(DataReader["idProduto"].ToString());
                AtributoProduto.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                AtributoProduto.Atributo = DataReader["atributo"].ToString();
                AtributoProduto.Descricao = DataReader["descricao"].ToString();
                AtributoProduto.IsDisponivel = bool.Parse(DataReader["isDisponivel"].ToString());
                AtributoProduto.DataCadastro = DateTime.Parse(DataReader["dataCadastro"].ToString());
               
            }
            return AtributoProduto;
        }
                    
        
    }
}