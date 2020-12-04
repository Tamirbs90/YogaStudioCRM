using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public class MonthRepository : IMonthRepository
    {
        private readonly PersonContext personContext;
        private Dictionary<string, List<string>> monthsPerYear;


        public MonthRepository(PersonContext personContext)
        {
            this.personContext = personContext;
            monthsPerYear = new Dictionary<string, List<string>>();
            CreateMonthsPerYearDictionary();
            AddNewMonthIfNessecary();
            AddNewWeekIfNecessary();
        }

        public List<Month> GetAll()
        {
            return personContext.Months.ToList();
        }

        public List<string> GetMonths(string year)
        {
            return monthsPerYear[year];
        }

        public List<string> GetYears()
        {
            var yearsList = monthsPerYear.Keys.ToList();
            yearsList.Sort();
            return yearsList;
        }

        private void CreateMonthsPerYearDictionary()
        {
            var months = personContext.Months.ToList();
            foreach(var month in months)
            {
                if (!monthsPerYear.ContainsKey(month.Year))
                {
                    monthsPerYear.Add(month.Year, new List<string>());
                }

                monthsPerYear[month.Year].Add(month.MonthName);
            }
        }



        private void AddNewMonthIfNessecary()
        {
            var monthToChange = GetCurrentMonth();
            if (monthToChange == null)
            {
                monthToChange = new Month { MonthName = DateTime.Now.ToString("MMMM"), Year = DateTime.Now.Year.ToString() };
                personContext.Months.Add(monthToChange);
                personContext.SaveChanges();
            }

        }

        private void AddNewWeekIfNecessary()
        {

            var startingDate = DateTime.Now;
            while (startingDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startingDate = startingDate.AddDays(-1);
            }

            var startingWeekDateStr = startingDate.ToShortDateString();
            var currentMonth = GetCurrentMonth();

            var relevantWeek = currentMonth.Weeks.
                Where(week => week.StartingDate.ToShortDateString().Equals(startingWeekDateStr)).
                FirstOrDefault();
            if (relevantWeek == null)
            {
                var newWeek = new Week
                {
                    StartingDate = startingDate.Date,
                    EndDate = startingDate.AddDays(6).Date,
                };

                currentMonth.Weeks.Add(newWeek);
                personContext.SaveChanges();

            }
        }

        private Month GetCurrentMonth()
        {
            var currentMonth = DateTime.Now.ToString("MMMM");
            var currentYear = DateTime.Now.Year.ToString();
            var res = personContext.Months.Include(m=>m.Weeks).
                FirstOrDefault(m => m.MonthName.Equals(currentMonth) && m.Year.Equals(currentYear));
            return res;

        }
    }
}
