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
    /// Classe da entidade Pedido
    /// </summary>
    public class Pedido : BaseDomain<int>
    {
        #region Fields

        private int _idPedido;
        private int _idParceiro;
        private DateTime _data;
        private string _status;
        private string _nome;
        private string _formaPagamento;
        private string _endereco;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _cep;
        private string _cpfCnpj;
        private float _frete;

        #endregion

        #region References

        private IList<ItemPedido> _itensPedido;
        private IList<OrderPointsTemp> _orderPointsTemp;
        private IList<Tracking> _tracking;
        private Parceiro _parceiro;

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
        /// Grava e recupera o idParceiro
        /// </summary>
        public virtual int IdParceiro
        {
            get { return _idParceiro; }
            set { _idParceiro = value; }
        }

        /// <summary>
        /// Data em que o pedido foi feito
        /// </summary>
        public virtual DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// Status do pedido
        /// </summary>
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Nome do cliente que fez o pedido
        /// </summary>
        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        /// <summary>
        /// Forma de pagamento do pedido
        /// </summary>
        public virtual string FormaPagamento
        {
            get { return _formaPagamento; }
            set { _formaPagamento = value; }
        }

        /// <summary>
        /// Endereço de entrega do pedido
        /// </summary>
        public virtual string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        /// <summary>
        /// Bairro de entrega do pedido
        /// </summary>
        public virtual string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        /// <summary>
        /// Cidade de entrega do pedido
        /// </summary>
        public virtual string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        /// <summary>
        /// UF de entrega do pedido
        /// </summary>
        public virtual string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }

        /// <summary>
        /// CEP de entrega do pedido
        /// </summary>
        public virtual string CEP
        {
            get { return _cep; }
            set { _cep = value; }
        }

        /// <summary>
        /// CPF/CNPJ do usuário que fez o pedido
        /// </summary>
        public virtual string CPFCNPJ
        {
            get { return _cpfCnpj; }
            set { _cpfCnpj = value; }
        }

        /// <summary>
        /// Frete
        /// </summary>
        public virtual float Frete
        {
            get { return _frete; }
            set { _frete = value; }
        }

        /// <summary>
        /// Lista ItensPedido
        /// </summary>
        public virtual IList<ItemPedido> ItensPedido
        {
            get { return _itensPedido; }
            set { _itensPedido = value; }
        }

        /// <summary>
        /// Lista OrderPointsTemp
        /// </summary>
        public virtual IList<OrderPointsTemp> OrderPointsTemp
        {
            get { return _orderPointsTemp; }
            set { _orderPointsTemp = value; }
        }

        /// <summary>
        /// Lista Tracking
        /// </summary>
        public virtual IList<Tracking> Tracking
        {
            get { return _tracking; }
            set { _tracking = value; }
        }

        /// <summary>
        /// Parceiro
        /// </summary>
        public virtual Parceiro Parceiro
        {
            get { return _parceiro; }
            set { _parceiro = value; }
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
                    this.Data +
                    this.Status +
                    this.Nome +
                    this.FormaPagamento +
                    this.Endereco +
                    this.Bairro +
                    this.Cidade +
                    this.UF +
                    this.CEP +
                    this.CPFCNPJ).GetHashCode();
        }
        #endregion

        public void Add(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
