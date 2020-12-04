using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IMonthRepository
    {
        List<string> GetMonths(string year);
        List<string> GetYears();

        List<Month> GetAll();
    }
}
