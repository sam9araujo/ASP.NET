using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class AmbienteDTO : BaseDTO
    {
        private Ambiente _ambiente;
        private IList<Produto> _produtos;

        public Ambiente Ambiente
        {
            get { return _ambiente; }
            set { _ambiente = value; }
        }

        public IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }

    }
}
