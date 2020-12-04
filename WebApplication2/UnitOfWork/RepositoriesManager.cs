using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public class RepositoriesManager : IRepositoriesManager
    {
        private PersonContext personContext;
        private Hashtable repositories;

        public RepositoriesManager(PersonContext _personContext)
        {
            personContext = _personContext;
            repositories = new Hashtable();
        }

        public Repository<T> GetRepository<T>() where T:class
        {
            if (!repositories.ContainsKey(typeof(T).Name))
            {
                repositories.Add(typeof(T).Name, new Repository<T>(personContext));
            }

            //if (!repositories.ContainsKey(typeof(T).Name))
            //{
            //    var repositoryType = typeof(Repository<>);
            //    var repositroyInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), personContext);
            //    repositories.Add(typeof(T).Name, repositroyInstance);
               
            //}

            return (Repository<T>)repositories[typeof(T).Name];
        }

        public void Save()
        {
            personContext.SaveChanges();
        }

        public void Dispose()
        {
            personContext.Dispose();
        }


    }
}
