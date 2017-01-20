using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<Patient, bool>> criteria);
        T Get(int id);
    }
}
