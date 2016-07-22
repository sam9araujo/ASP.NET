using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using System.Data;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public interface IBaseDAL<T> where T : IDomain
    {
        T Obter(string where);
        IList<T> Listar();
        IList<T> Listar(string where);
        int Insert(T t);
        int Update(T t);
        int Update(string where);
        int Delete(T t);
        int Delete(string where);
        T Factory(IDataReader DataReader);
        IList<T> QueryExecute(string sqlQuery, CommandType cmdType = CommandType.Text, IDbDataParameter[] parameters = null);
        IDbDataParameter[] GetParameters(int paramsCount);
    }
}
