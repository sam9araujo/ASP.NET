using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class PedidoDTO : BaseDTO
    {
        private Pedido _pedido;
        private Parceiro _parceiro;

        private IList<Pedido> _pedidos;
        //private IList<Parceiro> _parceiros;
        
        public IList<Pedido> Pedidos
        {

            get { return _pedidos; }
            set { _pedidos = value; }

        }

        public Pedido Pedido
        {

            get { return _pedido; }
            set { _pedido = value; }
        
        }

        public Parceiro Parceiro
        {
            get { return _parceiro; }
            set { _parceiro = value; }
        }
    }

   
}
