﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Repository
{
    public class AmbienteRepository : BaseRepository<Ambiente, AmbienteDAL, AmbienteRepository>, IRepositoryBase
    {
        public IList<Ambiente> ListarPorOrdem()
        {
            string sql = DAL.SqlSELECT + " WHERE mostra = 1 ORDER BY ordem";
            return DAL.QueryExecute(sql);
        }

        public IList<Ambiente> ListarPorParceiro(int idParceiro)
        {
            string sql = DAL.SqlSELECT + " INNER JOIN AMBIENTE_PARCEIRO ON AMBIENTE.idAMBIENTE = AMBIENTE_PARCEIRO.idAMBIENTE INNER JOIN PARCEIRO ON PARCEIRO.idPARCEIRO = AMBIENTE_PARCEIRO.idPARCEIRO WHERE PARCEIRO.idPARCEIRO = " + idParceiro;
            return DAL.QueryExecute(sql);
        }

        public void InsertAmbienteCategoria(Ambiente ambiente)
        {
            //TODO: insere o ambiente e loop lista de categoria

            
        }
    }
}
