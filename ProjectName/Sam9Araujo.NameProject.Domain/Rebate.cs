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
    /// Classe da entidade Rebate
    /// </summary>
    public class Rebate : BaseDomain<int>
    {
        #region Fields

        private int _idProduto;
        private int _idParceiro;
        private DateTime _data;
        private float _valor;
        private int _idImagem;

        #endregion

        #region References

        private Produto _produto;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o IdImagem
        /// </summary>
        public virtual int IdImagem
        {
            get { return _idImagem; }
            set { _idImagem = value; }
        }

        /// <summary>
        /// Grava e recupera o Valor
        /// </summary>
        public virtual float Valor
        {
            get { return this._valor; }
            set { this._valor = value; }
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
        /// Grava e recupera a Data
        /// </summary>
        public virtual DateTime Data
        {
            get { return this._data; }
            set { this._data = value; }
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
                    this.IdProduto +
                    this.IdParceiro +
                    this.Data +
                    this.Valor).GetHashCode();
        }
        #endregion
    }
}
