#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 18/03/2011
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        #region Fields
        private IList<Produto> _produtos;
        private IList<Categoria> _categorias;
        private IList<Parceiro> _parceiros;
        #endregion

        #region Properties
        public IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }

        public IList<Categoria> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        public IList<Parceiro> Parceiros
        {
            get { return _parceiros; }
            set { _parceiros = value; }
        }
        #endregion
    }
}
