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
            var currentMonth = DateTime.Now.ToString("MMMM");
            var currentYear = DateTime.Now.Year.ToString();
            var monthToChange = personContext.Months.
                Where(m => m.MonthName.Equals(currentMonth) && m.Year.Equals(currentYear)).
                FirstOrDefault();
            if (monthToChange == null)
            {
                monthToChange = new Month { MonthName = currentMonth, Year = currentYear };
                personContext.Months.Add(monthToChange);
                personContext.SaveChanges();
            }
        }

        
    }
}
