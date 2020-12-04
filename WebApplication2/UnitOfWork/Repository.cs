using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PersonContext personContext;

        public Repository(PersonContext personContext)
        {
            this.personContext = personContext;
        }

        public T Add(T toAdd)
        {
            personContext.Set<T>().Add(toAdd);
            personContext.SaveChanges();
            return toAdd;
        }

        public T Delete(int id)
        {
            T toDelete = personContext.Set<T>().Find(id);
            if (toDelete==null)
            {
                return null;
            }
            
            personContext.Set<T>().Remove(toDelete);
            personContext.SaveChanges();
            return toDelete;
        }

        public List<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var dbSet = personContext.Set<T>();
            var queryableDbSet = AddIncludes(dbSet,includes);
            return queryableDbSet.ToList();        
        }

        public T GetById(int id)
        {
            T res = personContext.Set<T>().Find(id);
            return res ?? null;
        }

        public List<T> GetBy(Expression<Func<T,bool>> predicate)
        {
            return personContext.Set<T>().Where(predicate).ToList() ?? null;
        }

        public T Update(T toUpdate)
        {
            personContext.Entry(toUpdate).State = EntityState.Modified;
            personContext.SaveChanges();
            return toUpdate;
        }

        private IQueryable<T> AddIncludes(DbSet<T> set, params Expression<Func<T, object>>[] includes)
        {

            var query = set.AsQueryable();
            //query= includes.Aggregate(query, (current,include)=>current.Include(include))
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
