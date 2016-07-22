using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Laboris.Cosan.Domain;
using Laboris.Cosan.DataAccessLayer;
using System.Configuration;

namespace Laboris.Cosan.Repository.DAL
{
    public abstract class BaseDALTeste<T> : IBaseDALTeste<T> where T : IDomain
    {
        internal string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public abstract string SqlSELECT
        {
            get;
        }

        internal string strSQL = string.Empty;

        public IList<T> Listar()
        {
            return this.Listar(string.Empty);
        }

        public IList<T> Listar(string where)
        {
            string sql;

            if (where != string.Empty)
                sql = SqlSELECT + " where " + where;
            else
                sql = SqlSELECT;

            List<T> listT = new List<T>();

            T t = default(T);

            using (IDBManager dbManager = new DBManager(ConnectionString))
            {
                dbManager.Open();
                {
                    IDataReader dr = dbManager.ExecuteReader(CommandType.Text, sql);
                    {
                        while (dr.Read())
                        {
                            t = this.Factory(dr);
                            listT.Add(t);
                        }
                    }
                    dbManager.CloseReader();

                    if (!dr.IsClosed)
                        dr.Close();
                }
                dbManager.Close();
            }
            return listT;
        }

        public T Obter(string where)
        {
            return default(T);
        }

        public abstract T Factory(IDataReader DataReader);

        public void Delete() { }
        public void Update() { }
        public void Insert() { }

        private abstract void ExecuteIncludes(List<T> lT);

        private void Include() { }
    }
}

