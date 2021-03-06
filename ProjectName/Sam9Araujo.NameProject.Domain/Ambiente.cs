﻿#region Imports
using System;
using System.Collections.Generic;
#endregion

namespace Sam9araujo.NameProject.Domain
{
    public class Ambiente : BaseDomain<int>
    {
        #region Fields

        private int _idAmbiente;
        private string _descricao;
        private DateTime _dataCadastro;
        private bool _mostra;
        private string _imagemGrd;
        private string _imagemPeq;
        private string _cssClassStyle;
        private string _imagemBanner;

        #endregion

        #region References

        private IList<Parceiro> _parceiros;
        private IList<Categoria> _categorias;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera idAmbiente
        /// </summary>
        public virtual int IdAmbiente
        {
            get { return _idAmbiente; }
            set { _idAmbiente = value; }
        }

        /// <summary>
        /// Grava e recupera Descricao
        /// </summary>
        public virtual string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        /// <summary>
        /// Grava e recupera DataCadastro
        /// </summary>
        public virtual DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; }
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
        /// Grava e recupera Lista de Parceiros
        /// </summary>
        public virtual IList<Parceiro> Parceiros
        {
            get { return _parceiros; }
            set { _parceiros = value; }
        }

        /// <summary>
        /// Grava e recupera Lista de Categorias
        /// </summary>
        public virtual IList<Categoria> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        public virtual string ImagemGrd
        {
            get { return _imagemGrd; }
            set { _imagemGrd = value; }
        }

        public virtual string ImagemPeq
        {
            get { return _imagemPeq; }
            set { _imagemPeq = value; }
        }

        public virtual string CssClassStyle
        {
            get { return _cssClassStyle; }
            set { _cssClassStyle = value; }
        }

        public virtual string ImagemBanner
        {
            get { return _imagemBanner; }
            set { _imagemBanner = value; }
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
                    this.IdAmbiente +
                    this.Descricao +
                    this.DataCadastro +
                    this.Mostra).GetHashCode();
        }
        #endregion
    }
}
