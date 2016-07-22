using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria, CategoriaDAL, CategoriaRepository>, IRepositoryBase
    {
        public IList<Categoria> ListarPorAmbiente(int idAmbiente)
        {
            string sql = DAL.SqlSELECT + " INNER JOIN AMBIENTE_CATEGORIA ON CATEGORIA.idCategoria = AMBIENTE_CATEGORIA.idCategoria AND CATEGORIA.idParceiro = AMBIENTE_CATEGORIA.idParceiro WHERE idAmbiente = " + idAmbiente;
            return DAL.QueryExecute(sql);
        }

        public IList<Categoria> ListarPorParceiro(int idParceiro)
        {
            string sql = DAL.SqlSELECT + " WHERE idParceiro  = " + idParceiro;
            return DAL.QueryExecute(sql);
        }

        public Categoria Obter(Categoria categoria)
        {
            return DAL.Obter("idCategoria  = " + categoria.IdCategoria + " AND idParceiro  = " + categoria.IdParceiro);
       }
    }
}
