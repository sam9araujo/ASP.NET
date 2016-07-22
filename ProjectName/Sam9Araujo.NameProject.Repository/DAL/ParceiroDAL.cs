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
    public class ParceiroDAL : BaseDAL<Parceiro>
    {
        private AmbienteDAL _ambienteDAL;
        private CategoriaDAL _categoriaDAL;
        private PedidoDAL _pedidoDAL;
        private ProdutoDAL _produtoDAL;

        public AmbienteDAL AmbienteDAL
        {
            get
            {
                if (_ambienteDAL == null)
                    _ambienteDAL = new AmbienteDAL();

                return _ambienteDAL;
            }
        }

        public CategoriaDAL CategoriaDAL
        {
            get
            {
                if (_categoriaDAL == null)
                    _categoriaDAL = new CategoriaDAL();

                return _categoriaDAL;
            }
        }

        public PedidoDAL PedidoDAL
        {
            get
            {
                if (_pedidoDAL == null)
                    _pedidoDAL = new PedidoDAL();

                return _pedidoDAL;
            }
        }

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
            get { return QuerysSQL.selectParceiro; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertParceiro; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateParceiro; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteParceiro; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyParceiro; }
        }

        internal override void ExecuteIncludes(List<Parceiro> parceiro)
        {
            for (int i = 0; i < parceiro.Count; i++)
            {
                if (_ambienteDAL != null)
                    parceiro[i].Ambientes = _ambienteDAL.ListarPorParceiro(parceiro[i].IdParceiro);

                if (_categoriaDAL != null)
                    parceiro[i].Categorias = _categoriaDAL.Listar("idParceiro = " + parceiro[i].IdParceiro);

                if (_pedidoDAL != null)
                    parceiro[i].Pedidos = _pedidoDAL.Listar("idParceiro = " + parceiro[i].IdParceiro);

                if (_produtoDAL != null)
                    parceiro[i].Produtos = _produtoDAL.Listar("idParceiro = " + parceiro[i].IdParceiro);
            }
        }

        internal override IDbDataParameter[] PrepareParametersFactory(Parceiro parceiro, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 8);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 7);

            dataParameters[0].ParameterName = "idParceiro";
            dataParameters[0].DbType        = DbType.Int32;
            dataParameters[0].Value         = parceiro.IdParceiro;

            dataParameters[1].ParameterName = "nome";
            dataParameters[1].DbType        = DbType.String;
            dataParameters[1].Value         = parceiro.Nome;

            dataParameters[2].ParameterName = "dataCadastro";
            dataParameters[2].DbType        = DbType.DateTime;
            dataParameters[2].Value         = parceiro.DataCadastro;

            dataParameters[3].ParameterName = "percentualPreco";
            dataParameters[3].DbType        = DbType.Decimal;
            dataParameters[3].Value         = parceiro.PercentualPreco ;

            dataParameters[4].ParameterName = "percentualPontos";
            dataParameters[4].DbType        = DbType.Decimal;
            dataParameters[4].Value         = parceiro.PercentualPontos;

            dataParameters[5].ParameterName = "imagem";
            dataParameters[5].DbType = DbType.String;
            dataParameters[5].Value = parceiro.Imagem;

            dataParameters[6].ParameterName = "link";
            dataParameters[6].DbType = DbType.String;
            dataParameters[6].Value = parceiro.Link;

            if (includeKeys)
            {
                int i = 7;
                keyMethod(parceiro, dataParameters, i);
            }

            return dataParameters;
        }

        private static void keyMethod(Parceiro parceiro, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idParceiroKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = parceiro.IdParceiro;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(Parceiro parceiro)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 1);

            int i = 0;

            keyMethod(parceiro, dataParameters, i);
            
            return dataParameters;
        }

        public ParceiroDAL()
        {
            
        }

        public override Parceiro Factory(IDataReader DataReader)
        {
            Parceiro parceiro = new Parceiro();
            {
                parceiro.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                parceiro.Nome = DataReader["nome"].ToString();
                parceiro.DataCadastro = DateTime.Parse(DataReader["dataCadastro"].ToString());
                parceiro.PercentualPontos = float.Parse(DataReader["percentualPontos"].ToString());
                parceiro.PercentualPreco = float.Parse(DataReader["percentualPreco"].ToString());
                parceiro.Imagem = DataReader["imagem"].ToString();
                parceiro.Link = DataReader["link"].ToString();
            }
            return parceiro;
        }

        public IList<Parceiro> ListarPorAmbiente(int idAmbiente)
        {
            string sql = this.SqlSELECT + " INNER JOIN AMBIENTE_PARCEIRO ON PARCEIRO.idParceiro = AMBIENTE_PARCEIRO.idParceiro WHERE idAmbiente = " + idAmbiente;
            return this.QueryExecute(sql);
        }
    }
}
