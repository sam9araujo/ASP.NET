using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class HomeDTO : BaseDTO 
    {
        private Ambiente _ambiente;
        private Parceiro _parceiro;
        private IList<Ambiente> _ambientes;
        private IList<Parceiro> _parceiros;

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
    }
}
