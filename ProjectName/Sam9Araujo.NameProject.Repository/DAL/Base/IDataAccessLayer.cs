using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Repository
{
    public interface IDataAccessLayer<T> where T : IDomain
    {
    }
}
