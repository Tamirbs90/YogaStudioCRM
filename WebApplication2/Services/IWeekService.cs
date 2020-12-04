using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Dtos;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public interface IWeekService
    {

        WeekToReturn GetWeekById(int weekId);

        WeekToReturn GetWeekByDates(DateTime startingDate);

        List<Week> GetWeeksOfMonth(int monthId);

    }
}
