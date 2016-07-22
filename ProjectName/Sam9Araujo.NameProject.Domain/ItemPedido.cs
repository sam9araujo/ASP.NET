#region Document Header

/******************************************************************************
 * e-Commerce - Versão 2
 * Copyright (C)2011 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 27/08/2010
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
    /// Classe da entidade ItemPedido
    /// </summary>
    public class ItemPedido : BaseDomain<int>
    {
        #region Fields

        private int _idPedido;
        private int _idParceiro;
        private int _idItem;
        private int _idProduto;
        private double _precoUnitario;
        private int _quantidade;
        private string _nomeProduto;
        private float _valorRebate;
        private int _nivel;
        private int _pontos;

        #endregion

        #region References

        private Pedido _pedido;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o IdPedido
        /// </summary>
        public virtual int IdPedido
        {
            get { return this._idPedido; }
            set { this._idPedido = value; }
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
        /// Grava e recupera o IdItem
        /// </summary>
        public virtual int IdItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }

        /// <summary>
        /// Preço unitário do produto
        /// </summary>
        public virtual double PrecoUnitario
        {
            get { return _precoUnitario; }
            set { _precoUnitario = value; }
        }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public virtual int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        /// <summary>
        /// NomeProduto
        /// </summary>
        public virtual string NomeProduto
        {
            get { return _nomeProduto; }
            set { _nomeProduto = value; }
        }

        /// <summary>
        /// ValorRebate do produto
        /// </summary>
        public virtual float ValorRebate
        {
            get { return _valorRebate; }
            set { _valorRebate = value; }
        }

        /// <summary>
        /// Nivel
        /// </summary>
        public virtual int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        /// <summary>
        /// Pontos
        /// </summary>
        public virtual int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }

        /// <summary>
        /// Pedido
        /// </summary>
        public virtual Pedido Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }


        public int IdProduto
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
                    this.IdPedido +
                    this.IdParceiro +
                    this.IdItem +
                    this.PrecoUnitario +
                    this.Quantidade +
                    this.NomeProduto +
                    this.ValorRebate +
                    this.Nivel +
                    this.Pontos).GetHashCode();
        }
        #endregion
    }
}
