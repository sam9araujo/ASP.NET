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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain
{
    public abstract class BaseDomain<T> : IBaseDomain<T>, IDomain
    {
        private T _id;

        /// <summary>
        /// Id da entidade
        /// </summary>
        public T Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
