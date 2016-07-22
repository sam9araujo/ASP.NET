#region Imports
using System;
using System.Collections.Generic;
#endregion

namespace Sam9araujo.NameProject.Domain
{
    public class Newsletter : BaseDomain<int>
    {
        #region Fields

        private int _idNewsletter;
        private string _email;
        private DateTime _data;

        #endregion

        #region Properties

        /// <summary>
        /// Grava e recupera IdNewsletter
        /// </summary>
        public virtual int IdNewsletter
        {
            get { return _idNewsletter; }
            set { _idNewsletter = value; }
        }

        /// <summary>
        /// Grava e recupera Email
        /// </summary>
        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Grava e recupera DataCadastro
        /// </summary>
        public virtual DateTime Data
        {
            get { return _data; }
            set { _data = value; }
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
                    this.IdNewsletter +
                    this.Email +
                    this.Data).GetHashCode();
        }
        #endregion
    }
}
