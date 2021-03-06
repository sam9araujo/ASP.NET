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
    public class ProdutoDAL : BaseDAL<Produto>
    {
        private AtributoProdutoDAL _atributos;
        private ImagemProdutoDAL _imagens;
        private ParceiroDAL _parceiro;
        private RebateDAL _rebate;
        private CategoriaDAL _categoriaDAL = null;

        public CategoriaDAL CategoriaDAL
        {
            get 
            {
                if (_categoriaDAL == null)
                    _categoriaDAL = new CategoriaDAL();
                
                return _categoriaDAL; 
            }
        }

        public override string SqlSELECT
        {
            get { return QuerysSQL.selectProduto; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertProduto; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateProduto; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteProduto; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyProduto; }
        }

        internal override void ExecuteIncludes(List<Produto> produtos)
        {
            if (_categoriaDAL != null)
            {
                for (int i = 0; i < produtos.Count; i++)
                    produtos[i].Categoria = _categoriaDAL.Obter("idCategoria = " + produtos[i].IdCategoria + " AND idParceiro = " + produtos[i].IdParceiro);
            }
        }

        internal override IDbDataParameter[] PrepareParametersFactory(Produto produto, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 23);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 21);
            
            dataParameters[0].ParameterName = "idProduto";
            dataParameters[0].DbType = DbType.String;
            dataParameters[0].Value = produto.IdProduto;

            dataParameters[1].ParameterName = "idParceiro";
            dataParameters[1].DbType = DbType.Int32;
            dataParameters[1].Value = produto.IdParceiro;

            dataParameters[2].ParameterName = "link";
            dataParameters[2].DbType = DbType.String;
            dataParameters[2].Value = produto.Link;

            dataParameters[3].ParameterName = "precoCheio";
            dataParameters[3].DbType = DbType.Decimal;
            dataParameters[3].Value = produto.PrecoCheio;

            dataParameters[4].ParameterName = "preco";
            dataParameters[4].DbType = DbType.Decimal;
            dataParameters[4].Value = produto.Preco;

            dataParameters[5].ParameterName = "imagem";
            dataParameters[5].DbType = DbType.String;
            dataParameters[5].Value = produto.ImagemThumbnail;

            dataParameters[6].ParameterName = "pontos";
            dataParameters[6].DbType = DbType.Int32;
            dataParameters[6].Value = produto.Pontos;

            dataParameters[7].ParameterName = "isDisponivel";
            dataParameters[7].DbType = DbType.Boolean;
            dataParameters[7].Value = produto.IsDisponivel;

            dataParameters[8].ParameterName = "IsAtivo";
            dataParameters[8].DbType = DbType.Boolean;
            dataParameters[8].Value = produto.IsAtivo;

            dataParameters[9].ParameterName = "dataCadastro";
            dataParameters[9].DbType = DbType.DateTime;
            dataParameters[9].Value = produto.DataCadastro;

            dataParameters[10].ParameterName = "dataAlteracao";
            dataParameters[10].DbType = DbType.DateTime;
            dataParameters[10].Value = produto.DataAlteracao;

            dataParameters[11].ParameterName = "usuario";
            dataParameters[11].DbType = DbType.String;
            dataParameters[11].Value = produto.Usuario;

            dataParameters[12].ParameterName = "nome";
            dataParameters[12].DbType = DbType.String;
            dataParameters[12].Value = produto.Nome;

            dataParameters[13].ParameterName = "nivel";
            dataParameters[13].DbType = DbType.Int32;
            dataParameters[13].Value = produto.Nivel;

            dataParameters[14].ParameterName = "ordemDestaque";
            dataParameters[14].DbType = DbType.Int32;
            dataParameters[14].Value = produto.OrdemDestaque;

            dataParameters[15].ParameterName = "titulo";
            dataParameters[15].DbType = DbType.String;
            dataParameters[15].Value = produto.Titulo;

            dataParameters[16].ParameterName = "descricao";
            dataParameters[16].DbType = DbType.String;
            dataParameters[16].Value = produto.Descricao;

            dataParameters[17].ParameterName = "observacao";
            dataParameters[17].DbType = DbType.String;
            dataParameters[17].Value = produto.Observacao;

            dataParameters[18].ParameterName = "frete";
            dataParameters[18].DbType = DbType.Decimal;
            dataParameters[18].Value = produto.Frete;

            dataParameters[19].ParameterName = "idCategoria";
            dataParameters[19].DbType = DbType.Int32;
            dataParameters[19].Value = produto.IdCategoria;

            dataParameters[20].ParameterName = "totalUpdate";
            dataParameters[20].DbType = DbType.Int32;
            dataParameters[20].Value = produto.TotalUpdate;

            if (includeKeys)
            {
                int i = 21;
                keyMethod(produto, dataParameters, i);
            }
            
            return dataParameters;
        }

        private static void keyMethod(Produto produto, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idProdutoKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = produto.IdProduto;

            i++;

            dataParameters[i].ParameterName = "idParceiroKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = produto.IdParceiro;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(Produto produto)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 2);

            int i = 0;

            keyMethod(produto, dataParameters, i);
            
            return dataParameters;
        }

        public ProdutoDAL()
        {
            
        }

        public override Produto Factory(IDataReader DataReader)
        {
            Produto produto = new Produto();
            {
                produto.IdProduto = DataReader["idProduto"].ToString();
                produto.IdParceiro = int.Parse(DataReader["idParceiro"].ToString());
                produto.Link = DataReader["link"].ToString();
                produto.PrecoCheio = float.Parse(DataReader["precoCheio"].ToString());
                produto.Preco = float.Parse(DataReader["preco"].ToString());
                produto.ImagemThumbnail = DataReader["imagem"].ToString();
                produto.Pontos = int.Parse(DataReader["pontos"].ToString());
                produto.IsDisponivel = bool.Parse(DataReader["isDisponivel"].ToString());
                produto.IsAtivo = bool.Parse(DataReader["isAtivo"].ToString());
                produto.DataCadastro = DateTime.Parse(DataReader["dataCadastro"].ToString());
                produto.DataAlteracao = DateTime.Parse(DataReader["dataAlteracao"].ToString());
                produto.Usuario = DataReader["usuario"].ToString();
                produto.Nome = DataReader["nome"].ToString();
                produto.Nivel = int.Parse(DataReader["nivel"].ToString());
                produto.OrdemDestaque = int.Parse(DataReader["ordemDestaque"].ToString());
                produto.Titulo = DataReader["titulo"].ToString();
                produto.Descricao = DataReader["descricao"].ToString();
                produto.Observacao = DataReader["observacao"].ToString();
                produto.Frete = float.Parse(DataReader["frete"].ToString());
                produto.IdCategoria = int.Parse(DataReader["idCategoria"].ToString());
            }
            return produto;
        }

    }
}

