using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Repository;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository.DAL;

namespace Sam9araujo.NameProject.Repository
{
    public static class Utils
    {
        public static void listarParceiro(Produto produto)
        {
           ParceiroDAL parceiro = new ParceiroDAL();
           produto.Parceiro = parceiro.Obter("idParceiro = " + produto.IdParceiro);
        }
    }
}
