﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class LojaDTO : BaseDTO 
    {
        private Ambiente _ambienteAtual;
        private IList<Ambiente> _ambientes;
        private Parceiro _parceiro;
        private IList<Produto> _produtos;

        public Ambiente AmbienteAtual
        {
            get { return _ambienteAtual; }
            set { _ambienteAtual = value; }
        }

        public IList<Ambiente> Ambientes
        {
            get { return _ambientes; }
            set { _ambientes = value; }
        }

        public Parceiro Parceiro
        {
            get { return _parceiro; }
            set { _parceiro = value; }
        }

        public IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }

    }
}
