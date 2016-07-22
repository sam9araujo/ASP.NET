using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class ucNaveguePorTemasDTO : BaseDTO
    {
        private IList<Ambiente> _ambientes;

        public IList<Ambiente> Ambientes
        {
            get { return _ambientes; }
            set { _ambientes = value; }
        }
    }
}
