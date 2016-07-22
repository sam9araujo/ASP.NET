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
using System.Collections.Generic;
#endregion

namespace Sam9araujo.NameProject.Domain
{
    /// <summary>
    /// Classe da entidade Produto
    /// </summary>
    public class Produto : BaseDomain<int>
    {
        #region Fields

        private string _idProduto;
        private int _idParceiro;
        private string _link;
        private float _precoCheio;
        private float _preco;
        private string _imagemThumbnail;
        private IList<string> _imagem;
        private int _pontos;
        private bool _isDisponivel;
        private bool _isAtivo;
        private DateTime? _dataCadastro;
        private DateTime? _dataAlteracao;
        private string _usuario;
        private string _nome;
        private int _nivel;
        private int _ordemDestaque;
        private string _titulo;
        private string _descricao;
        private string _observacao;
        private float _frete;
        private int _idCategoria;
        private int _totalUpdate;

        #endregion

        #region References

        private IList<AtributoProduto> _atributos;
        private IList<ImagemProduto> _imagens;
        private Parceiro _parceiro;
        private Categoria _categoria;
        private Rebate _rebate;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o IdProduto
        /// </summary>
        public virtual string IdProduto
        {
            get { return this._idProduto; }
            set { this._idProduto = value; }
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
        /// Grava e recupera o Nome
        /// </summary>
        public virtual string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        /// <summary>
        /// Grava e recupera o Nivel
        /// </summary>
        public virtual int Nivel
        {
            get { return this._nivel; }
            set { this._nivel = value; }
        }

        /// <summary>
        /// Grave e recupera a Link (URL)
        /// </summary>
        public virtual string Link
        {
            get { return this._link; }
            set { this._link = value; }
        }

        /// <summary>
        /// Grava e recupera o Preço Cheio
        /// </summary>
        public virtual float PrecoCheio
        {
            get { return this._precoCheio; }
            set { this._precoCheio = value; }
        }

        /// <summary>
        /// Grava e recupera a Preço
        /// </summary>
        public virtual float Preco
        {
            get { return this._preco; }
            set { this._preco = value; }
        }

        /// <summary>
        /// Grava e recupera os Pontos
        /// </summary>
        public virtual int Pontos
        {
            get { return this._pontos; }
            set { this._pontos = value; }
        }

        /// <summary>
        /// Grava e recupera o IsAtivo
        /// </summary>
        public virtual bool IsAtivo
        {
            get { return this._isAtivo; }
            set { this._isAtivo = value; }
        }

        /// <summary>
        /// Grava e recupera o IsDisponivel
        /// </summary>
        public virtual bool IsDisponivel
        {
            get { return this._isDisponivel; }
            set { this._isDisponivel = value; }
        }
        
        /// <summary>
        /// Grava e recupera a data do cadastro
        /// </summary>
        public virtual DateTime? DataCadastro
        {
            get { return this._dataCadastro; }
            set { this._dataCadastro = value; }
        }

        /// <summary>
        /// Grava e recupera a data da alteração
        /// </summary>
        public virtual DateTime? DataAlteracao
        {
            get { return this._dataAlteracao; }
            set { this._dataAlteracao = value; }
        }

        /// <summary>
        /// Grava e recupera o Usuário
        /// </summary>
        public virtual string Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }

        /// <summary>
        /// Grava e recupera a Categoria
        /// </summary>
        public virtual Categoria Categoria
        {
            get { return this._categoria; }
            set { this._categoria = value; }
        }

        /// <summary>
        /// Grava e recupera a Rebate
        /// </summary>
        public virtual Rebate Rebate
        {
            get { return this._rebate; }
            set { this._rebate = value; }
        }

        /// <summary>
        /// Grava e recupera a IdCategoria
        /// </summary>
        public virtual int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        /// <summary>
        /// Grava e recupera o OrdemDestaque
        /// </summary>
        public virtual int OrdemDestaque
        {
            get { return this._ordemDestaque; }
            set { this._ordemDestaque = value; }
        }

        /// <summary>
        /// Grava e recupera a Descricao
        /// </summary>
        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        /// <summary>
        /// Grava e recupera o Frete
        /// </summary>
        public virtual float Frete
        {
            get { return _frete; }
            set { _frete = value; }
        }

        /// <summary>
        /// Grava e recupera a ImagemThumbnail
        /// </summary>
        public virtual string ImagemThumbnail
        {
            get { return _imagemThumbnail; }
            set { _imagemThumbnail = value; }
        }

        /// <summary>
        /// Grava e recupera o Titulo
        /// </summary>
        public virtual string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        /// <summary>
        /// Grava e recupera a Observacao
        /// </summary>
        public virtual string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
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
        /// Grava e recupera lista de Imagens
        /// </summary>
        public virtual IList<ImagemProduto> Imagens
        {
            get { return _imagens; }
            set { _imagens = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Atributos
        /// </summary>
        public virtual IList<AtributoProduto> Atributos
        {
            get { return _atributos; }
            set { _atributos = value; }
        }

        /// <summary>
        /// Grava e recupera lista de Atributos
        /// </summary>
        public virtual IList<string> Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }

        /// <summary>
        /// Grava e recupera o TotalUpdate
        /// </summary>
        public int TotalUpdate
        {
            get { return _totalUpdate; }
            set { _totalUpdate = value; }
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
                    this.Link +
                    this.Nome +
                    this.PrecoCheio +
                    this.Preco +
                    this.Imagem +
                    this.Pontos +
                    this.IsDisponivel +
                    this.IsAtivo +
                    this.DataCadastro +
                    this.DataAlteracao).GetHashCode();
        }
        #endregion
    }
}

