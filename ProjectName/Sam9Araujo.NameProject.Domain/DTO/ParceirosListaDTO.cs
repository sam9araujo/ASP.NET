using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class ParceirosListaDTO : BaseDTO 
    {
        private IList<Parceiro> _parceiros;
        private Parceiro _parceiro;

        public IList<Parceiro> Parceiros
        {
            get { return _parceiros; }
            set { _parceiros = value; }
        }
        public Parceiro Parceiro
        {
            get { return _parceiro; }
            set { _parceiro = value; }
        }
    }
}
