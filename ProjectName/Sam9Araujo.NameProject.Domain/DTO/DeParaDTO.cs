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
    public class DeParaDTO : BaseDTO
    {
        #region Fields
        private Ambiente _ambiente;
        private Parceiro _parceiro;
        private Categoria _categoria;
        private IList<Ambiente> _ambientes;
        private IList<Parceiro> _parceiros;
        private IList<Categoria> _categorias;
        #endregion

        #region Properties
        public IList<Ambiente> Ambientes
        {
            get { return _ambientes; }
            set { _ambientes = value; }
        }
        public IList<Parceiro> Parceiros
        {
            get { return _parceiros; }
            set { _parceiros = value; }
        }
        public IList<Categoria> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }
        public Ambiente Ambiente
        {
            get { return _ambiente; }
            set { _ambiente = value; }
        }
        public Parceiro Parceiro
        {
            get { return _parceiro; }
            set { _parceiro = value; }
        }
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        #endregion
    }
}
