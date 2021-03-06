#region Document Header

/******************************************************************************
 * e-Commerce - Vers�o 2
 * Copyright (C)2011 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Bruno D'Alessio - 01/02/2011
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
#endregion

namespace Sam9araujo.NameProject.Domain
{
    /// <summary>
    /// Classe da entidade Parceiro
    /// </summary>
    public class Parceiro : BaseDomain<int>
    {
        #region Fields

        private int _idParceiro;
        private string _nome;
        private DateTime? _dataCadastro;
        private float _percentualPreco;
        private float _percentualPontos;
        private string _imagem;
        private string _link;

        #endregion

        #region References

        private IList<Ambiente> _ambientes;
        private IList<Categoria> _categorias;
        private IList<Pedido> _pedidos;
        private IList<Produto> _produtos;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o idParceiro
        /// </summary>
        public virtual int IdParceiro
        {
            get { return _idParceiro; }
            set { _idParceiro = value; }
        }

        /// <summary>
        /// Grava e recupera o nome
        /// </summary>
        public virtual string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        /// <summary>
        /// Grava e recupera o Percentual de Pontos
        /// </summary>
        public virtual float PercentualPontos
        {
            get { return this._percentualPontos; }
            set { this._percentualPontos = value; }
        }

        /// <summary>
        /// Grava e recupera o Percentual de Pre�o
        /// </summary>
        public virtual float PercentualPreco
        {
            get { return this._percentualPreco; }
            set { this._percentualPreco = value; }
        }

        /// <summary>
        /// Grava e recupera a Data de Cadastro
        /// </summary>
        public virtual DateTime? DataCadastro
        {
            get { return this._dataCadastro; }
            set { this._dataCadastro = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Ambientes
        /// </summary>
        public virtual IList<Ambiente> Ambientes
        {
            get { return _ambientes; }
            set { _ambientes = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Categorias
        /// </summary>
        public virtual IList<Categoria> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Pedidos
        /// </summary>
        public virtual IList<Pedido> Pedidos
        {
            get { return _pedidos; }
            set { _pedidos = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Produtos
        /// </summary>
        public virtual IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }

        public virtual string Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }

        public virtual string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        #endregion

        #region Override Methods
        /// <summary>
        /// Hash code das informa��es da entidade
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (this.GetType().FullName +
                    this.IdParceiro +
                    this.Nome).GetHashCode();
        }
        #endregion
    }
}
