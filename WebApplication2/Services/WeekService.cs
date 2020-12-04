using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Dtos;
using YogaStudio.Models;
using YogaStudio.Repositories;

namespace YogaStudio.Services
{
    public class WeekService : IWeekService
    {

        private IRepositoriesManager repositoriesManager;
        private PersonContext personContext;
        private IMapper mapper;

        public WeekService(IRepositoriesManager i_repositoriesManager, PersonContext i_personContext, IMapper i_mapper)
        {
            repositoriesManager = i_repositoriesManager;
            personContext = i_personContext;
            mapper = i_mapper;
        }

   
        public WeekToReturn GetWeekByDates(DateTime startingDate)
        {
            //var weekToReturn = repositoriesManager.GetRepository<Week>().
            //GetBy(w => w.StartingDate.Date.Equals(startingDate.Date)).
            //FirstOrDefault();
            //return MapWeek(weekToReturn);
            return null;
        }

        public WeekToReturn GetWeekById(int weekId)
        {
            return MapWeek(personContext.Weeks.Include(w => w.ClassesInWeek).
                FirstOrDefault(w => w.Id == weekId));
        }

        public List<Week> GetWeeksOfMonth(int monthId)
        {
            var month = personContext.Months.Include(m => m.Weeks).FirstOrDefault(m => m.Id == monthId);
            return month.Weeks.ToList();
        }

        private WeekToReturn MapWeek(Week week)
        {
            var weekToReturn = mapper.Map<Week, WeekToReturn>(week);
            foreach (var yogaClass in week.ClassesInWeek)
            {
                weekToReturn.ClassesByDays[(int)yogaClass.Day].Add(yogaClass);
            }

            return weekToReturn;
        }
    }
         
}
