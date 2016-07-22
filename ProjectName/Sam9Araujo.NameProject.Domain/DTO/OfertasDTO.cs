using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class OfertasDTO : BaseDTO
    {
        private IList<Produto> _produtos;

        public IList<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; }
        }
    }
}
