﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class TesteDTO : BaseDTO 
    {
        private IList<Ambiente> _ambientes;
        private IList<Categoria> _categorias;

        public IList<Ambiente> Ambientes
        {
            get { return _ambientes; }
            set { _ambientes = value; }
        }        
        public IList<Categoria> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }
    }
}
