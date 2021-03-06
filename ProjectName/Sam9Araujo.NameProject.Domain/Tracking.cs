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
    /// Classe da entidade Tracking
    /// </summary>
    public class Tracking : BaseDomain<int>
    {
        #region Fields

        private int _idPedido;
        private int _idParceiro;
        private int _idTracking;
        private string _status;
        private DateTime _data;
        
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
        /// Grava e recupera o IdTracking
        /// </summary>
        public virtual int IdTracking
        {
            get { return _idTracking; }
            set { _idTracking = value; }
        }

        /// <summary>
        /// Grava e recupera o Status do Pedido
        /// </summary>
        public virtual string Status
        {
            get { return this._status; }
            set { this._status = value; }
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
                    this.IdTracking +
                    this.Status +
                    this.Data).GetHashCode();
        }
        #endregion
    }
}
