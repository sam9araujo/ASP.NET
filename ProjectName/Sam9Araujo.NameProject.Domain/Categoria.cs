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
    /// Classe da entidade Categoria
    /// </summary>
    public class Categoria : BaseDomain<int>
    {
        #region Fields
        private int _idCategoria;
        private int _idParceiro;
        private string _descricao;
        private DateTime _dataCadastro;
        private bool _mostra;
        private int _idPaiCategoria;

        #endregion

        #region References

        private IList<Ambiente> _ambientes;
        private IList<Produto> _produtos;
        private IList<Categoria> _categoriasFilhos;
        private Parceiro _parceiro;
        private Categoria _categoriaPai;

        #endregion

        #region Properties
        /// <summary>
        /// Grava e recupera o IdCategoria
        /// </summary>
        public virtual int IdCategoria
        {
            get { return this._idCategoria; }
            set { this._idCategoria = value; }
        }

        /// <summary>
        /// Grava e recupera o IdParceiro
        /// </summary>
        public virtual int IdParceiro
        {
            get { return this._idParceiro; }
            set { this._idParceiro = value; }
        }

        /// <summary>
        /// Grava e recupera a Descri��o
        /// </summary>
        public virtual string Descricao
        {
            get { return this._descricao; }
            set { this._descricao = value; }
        }

        /// <summary>
        /// Grava e recupera o Data de Cadastro
        /// </summary>
        public virtual DateTime DataCadastro
        {
            get { return this._dataCadastro; }
            set { this._dataCadastro = value; }
        }

        /// <summary>
        /// Grava e recupera Mostra
        /// </summary>
        public virtual bool Mostra
        {
            get { return _mostra; }
            set { _mostra = value; }
        }

        /// <summary>
        /// Grava e recupera o Parent
        /// </summary>
        public virtual int IdPaiCategoria
        {
            get { return this._idPaiCategoria; }
            set { this._idPaiCategoria = value; }
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
        /// Grava e recupera o Parceiro
        /// </summary>
        public virtual Parceiro Parceiro
        {
            get { return this._parceiro; }
            set { this._parceiro = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Produtos
        /// </summary>
        public virtual IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Categorias filhas
        /// </summary>
        public virtual IList<Categoria> CategoriasFilhos
        {
            get { return _categoriasFilhos; }
            set { _categoriasFilhos = value; }
        }

        /// <summary>
        /// Grava e recupera Categoria pai
        /// </summary>
        public virtual Categoria CategoriaPai
        {
            get { return _categoriaPai; }
            set { _categoriaPai = value; }
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
                    this.IdCategoria +
                    this.IdParceiro +
                    this.Descricao +
                    this.DataCadastro +
                    this.Mostra +
                    this.IdPaiCategoria).GetHashCode();
        }
        #endregion
    }
}
