using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext personContext;
        public SortedDictionary<int, Person> StudentsPerMonth { get; set; }

        public PersonRepository(PersonContext personContext)
        {
            this.personContext = personContext;
            StudentsPerMonth = new SortedDictionary<int, Person>();
        }

        public Person AddPerson(Person person)
        {
            personContext.Persons.Add(person);
            personContext.SaveChanges();
            return person;
        }

        public Person AddClassToPerson(int id, ClassParticipated classParticipated)
        {
            var personToChange = personContext.Persons.FirstOrDefault(p => p.Id == id);
            var currentMonth = DateTime.Now.ToString("MMMM");
            var currentYear = DateTime.Now.Year.ToString();
            var monthToChange = personContext.Months.
                Where(m => m.MonthName.Equals(currentMonth) && m.Year.Equals(currentYear)).
                FirstOrDefault();
            personToChange.Classes.Add(classParticipated);
            monthToChange.Classes.Add(classParticipated);
            personContext.SaveChanges();
            return personToChange;
        }

        public Person UpdatePerson(Person person)
        {
            personContext.Entry(person).State = EntityState.Modified;
            personContext.SaveChanges();
            return person;
        }

        public List<Person> FindPersonByName(string name)
        {
            return personContext.Persons.Where(p => p.Name.Equals(name)).Include(p => p.Classes).ToList();
        }

        public object FindStudentsByMonth(string month, string year)
        {
            StudentsPerMonth.Clear();
            int totalPaid = 0, totalDebt = 0;
            var selectedMonth = personContext.Months.
                Where(m => m.MonthName.Equals(month) && m.Year.Equals(year)).
                Include(m => m.Classes).FirstOrDefault();
            if (selectedMonth != null && selectedMonth.Classes.Any())
            {
                var classes = selectedMonth.Classes.ToList();
                foreach (var classPerPerson in classes)
                {
                    if (!StudentsPerMonth.ContainsKey(classPerPerson.PersonId))
                    {
                        var person = personContext.Persons.FirstOrDefault(p => p.Id == classPerPerson.PersonId);
                        StudentsPerMonth.Add(classPerPerson.PersonId, new Person
                        {
                            Id = person.Id,
                            Name = person.Name,
                            Phone = person.Phone,
                            Birthday = person.Birthday,
                            IsActive = person.IsActive
                        });
                    }

                    StudentsPerMonth[classPerPerson.PersonId].Classes.Add(classPerPerson);
                    StudentsPerMonth[classPerPerson.PersonId].TotalPaid += classPerPerson.Paid;
                    StudentsPerMonth[classPerPerson.PersonId].Debt += classPerPerson.Debt;
                    totalPaid += classPerPerson.Paid;
                    totalDebt += classPerPerson.Debt;
                }
            }

            foreach (var person in personContext.Persons.ToList())
            {
                if (person.IsActive && !StudentsPerMonth.ContainsKey(person.Id))
                    StudentsPerMonth.Add(person.Id, new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        Phone = person.Phone,
                        Birthday = person.Birthday,
                        TotalPaid = 0,
                        Debt = 0,
                        IsActive = person.IsActive
                    });
            }

            var totalStudentsList = StudentsPerMonth.Values.AsQueryable().Include(p => p.Classes).ToList();
            return new { StudentsList = totalStudentsList, TotalPaid = totalPaid, TotalDebt = totalDebt };
        }
    }
}
