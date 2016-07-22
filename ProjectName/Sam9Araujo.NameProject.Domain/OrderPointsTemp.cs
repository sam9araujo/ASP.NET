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
#endregion

namespace Sam9araujo.NameProject.Domain
{
    /// <summary>
    /// Classe da entidade OrderPointsTemp
    /// </summary>
    public class OrderPointsTemp : BaseDomain<int>
    {
        #region Fields

        private int _idPedido;
        private int _idParceiro;
        private int _idOrder;
        private int _points;
        private DateTime _dataHora;
        
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
        /// Grava e recupera o IdOrder
        /// </summary>
        public virtual int IdOrder
        {
            get { return _idOrder; }
            set { _idOrder = value; }
        }

        /// <summary>
        /// Grava e recupera Points
        /// </summary>
        public virtual int Points
        {
            get { return this._points; }
            set { this._points = value; }
        }

        /// <summary>
        /// Grava e recupera a DataHora
        /// </summary>
        public virtual DateTime DataHora
        {
            get { return this._dataHora; }
            set { this._dataHora = value; }
        }

        /// <summary>
        /// Pedido
        /// </summary>
        public virtual Pedido Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
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
                    this.IdPedido +
                    this.IdParceiro +
                    this.Points +
                    this.DataHora).GetHashCode();
        }
        #endregion
    }
}
