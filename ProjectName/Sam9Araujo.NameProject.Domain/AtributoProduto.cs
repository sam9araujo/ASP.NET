#region Document Header

/******************************************************************************
 * e-Commerce - Versão 2
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
#endregion

namespace Sam9araujo.NameProject.Domain
{
    /// <summary>
    /// Classe da entidade AtributoProduto
    /// </summary>
    public class AtributoProduto : BaseDomain<int>
    {
        #region Fields

        private int _idAtributo;
        private string _atributo;
        private string _descricao;
        private bool _isDisponivel;
        private DateTime _dataCadastro;
        private int _idProduto;
        private int _idParceiro;

        #endregion

        #region References

        private Produto _produto;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o IdAtributo
        /// </summary>
        public virtual int IdAtributo
        {
            get { return _idAtributo; }
            set { _idAtributo = value; }
        }

        /// <summary>
        /// Grava e recupera o Atributo do Produto
        /// </summary>
        public virtual string Atributo
        {
            get { return this._atributo; }
            set { this._atributo = value; }
        }

        /// <summary>
        /// Grava e recupera a Descricao
        /// </summary>
        public virtual string Descricao
        {
            get { return this._descricao; }
            set { this._descricao = value; }
        }

        /// <summary>
        /// Grava e recupera a isDisponivel
        /// </summary>
        public virtual bool IsDisponivel
        {
            get { return this._isDisponivel; }
            set { this._isDisponivel = value; }
        }

        /// <summary>
        /// Grava e recupera a Produto
        /// </summary>
        public virtual Produto Produto
        {
            get { return this._produto; }
            set { this._produto = value; }
        }

        /// <summary>
        /// Grava e recupera a Data de Cadastro
        /// </summary>
        public virtual DateTime DataCadastro
        {
            get { return this._dataCadastro; }
            set { this._dataCadastro = value; }
        }

        /// <summary>
        /// Grava e recupera o IdParceiro
        /// </summary>
        public virtual int IdParceiro
        {
            get { return _idParceiro; }
            set { _idParceiro = value; }
        }

        /// <summary>
        /// Grava e recupera o IdProduto
        /// </summary>
        public virtual int IdProduto
        {
            get { return _idProduto; }
            set { _idProduto = value; }
        }

        #endregion

        #region Override Methods
        /// <summary>
        /// Hash code das informações da entidade
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (this.GetType().FullName +
                    this.IdAtributo  +
                    this.Produto.IdProduto +
                    this.IdParceiro +
                    this.Produto.Parceiro.Nome +
                    this.Atributo +
                    this.DataCadastro).GetHashCode();
        }
        #endregion
    }
}
