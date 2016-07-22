using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laboris.Cosan.Domain;
using System.Data;

namespace Laboris.Cosan.Repository.DAL
{
    public interface IBaseDALTeste<T> where T : IDomain
    {
        T Obter(string where);
        IList<T> Listar();
        IList<T> Listar(string where);
        void Delete();
        void Update();
        void Insert();
        T Factory(IDataReader DataReader);
    }
}
