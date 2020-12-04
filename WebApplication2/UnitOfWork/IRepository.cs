using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IRepository<T> 
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includes);
        T GetById(int id);

        List<T> GetBy(Expression<Func<T, bool>> predicate);
        T Add(T toAdd);

        T Update(T toUpdate);

        T Delete(int id);

    }
}
