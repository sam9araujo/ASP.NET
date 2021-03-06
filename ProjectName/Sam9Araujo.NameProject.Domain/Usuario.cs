#region Document Header

/******************************************************************************
 * e-Commerce - Vers�o 2
 * Copyright (C)2011 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 02/04/2011
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
    /// Classe da entidade Usu�rio
    /// </summary>
    public class Usuario : BaseDomain<int>
    {
        #region Fields

        private int _idUsuario;
        private string _nome;
        private string _email;
        private string _login;
        private string _senha;
        private bool _isAtivo;
        private DateTime? _dataCadastro;
        
        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera o idUsuario
        /// </summary>
        public virtual int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
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
        /// Grava e recupera o e-Mail
        /// </summary>
        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        /// <summary>
        /// Grava e recupera o Login
        /// </summary>
        public virtual string Login
        {
            get { return this._login; }
            set { this._login = value; }
        }

        /// <summary>
        /// Grava e recupera a Senha
        /// </summary>
        public virtual string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        /// <summary>
        /// Grava e recupera o IsAtivo
        /// </summary>
        public virtual bool IsAtivo
        {
            get { return _isAtivo; }
            set { _isAtivo = value; }
        }

        /// <summary>
        /// Grava e recupera a Data de Cadastro
        /// </summary>
        public virtual DateTime? DataCadastro
        {
            get { return this._dataCadastro; }
            set { this._dataCadastro = value; }
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
                    this.IdUsuario +
                    this.Nome).GetHashCode();
        }
        #endregion
    }
}
