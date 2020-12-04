using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IRepositoriesManager
    {
        Repository<T> GetRepository<T>() where T:class;

        void Save();

        void Dispose();


    }
}
