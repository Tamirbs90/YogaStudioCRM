using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly PersonContext personContext;

        public ClassesRepository(PersonContext personContext)
        {
            this.personContext = personContext;
        }

        public Person AddClassToStudent(int id, ClassParticipated classParticipated)
        {
            var personToChange = personContext.Persons.FirstOrDefault(p => p.Id == id);
            var currentMonth = DateTime.Now.ToString("MMMM");
            var currentYear = DateTime.Now.Year.ToString();
            var monthToChange = personContext.Months.
                Where(m => m.MonthName.Equals(currentMonth) && m.Year.Equals(currentYear)).
                FirstOrDefault();
            personToChange.Classes.Add(classParticipated);
            monthToChange.Classes.Add(classParticipated);
            personToChange.TotalPaid += classParticipated.Paid;
            personToChange.Debt += classParticipated.Debt;
            personContext.SaveChanges();
            return personToChange;
        }

        public Person DeleteClassFromStudent(int classId)
        {
            var classToRemove = personContext.Classes.FirstOrDefault(c => c.Id == classId);
            var personToChange = personContext.Persons.FirstOrDefault(p => p.Id == classToRemove.PersonId);
            personToChange.TotalPaid -= classToRemove.Paid;
            personToChange.Debt -= classToRemove.Debt;
            personContext.Classes.Remove(classToRemove);
            personContext.SaveChanges();
            return personToChange;
        }

        public List<Person> ShowClassesWithDebts()
        {
            if (!personContext.Classes.Any())
                return null;
            var classes = personContext.Classes.ToList();
            Dictionary<int, Person> personList = new Dictionary<int, Person>();
            foreach (var classPerPerson in classes)
            {
                if (classPerPerson.Debt == 0)
                    continue;
                if (!personList.ContainsKey(classPerPerson.PersonId))
                {
                    var person = personContext.Persons.FirstOrDefault(p => p.Id == classPerPerson.PersonId);
                    personList.Add(classPerPerson.PersonId, new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        Phone = person.Phone,
                        Debt = person.Debt
                    });
                }

                personList[classPerPerson.PersonId].Classes.Add(classPerPerson);
            }

            var listToReturn = personList.Values.AsQueryable().Include(p => p.Classes).ToList();
            listToReturn.OrderBy(p => p.Id);
            return listToReturn;
        }
    }
}
