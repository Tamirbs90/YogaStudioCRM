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

        public Person AddClassToStudent(int studentId, int monthId, ClassParticipated classParticipated)
        {
            var personToChange = personContext.Persons.FirstOrDefault(p => p.Id == studentId);
            //var currentMonth = DateTime.Now.ToString("MMMM");
            //var currentYear = DateTime.Now.Year.ToString();
            var monthToChange = personContext.Months.FirstOrDefault(m => m.Id == monthId);
            personToChange.StudentClasses.Add(classParticipated);
            monthToChange.ClassesInMonth.Add(classParticipated);
            personToChange.TotalPaid += classParticipated.Paid;
            personToChange.Debt += classParticipated.Debt;
            personContext.SaveChanges();
            return personToChange;
        }

        public ClassParticipated UpdateParticipation(ClassParticipated participation)
        {
            personContext.Entry(participation).State = EntityState.Modified;
            personContext.SaveChanges();
            return participation;
        }

        public Person DeleteClassFromStudent(int classId)
        {
            var classToRemove = personContext.ClassesPartipciations.FirstOrDefault(c => c.Id == classId);
            var personToChange = personContext.Persons.FirstOrDefault(p => p.Id == classToRemove.PersonId);
            personToChange.TotalPaid -= classToRemove.Paid;
            personToChange.Debt -= classToRemove.Debt;
            personContext.ClassesPartipciations.Remove(classToRemove);
            personContext.SaveChanges();
            return personToChange;
        }

        public List<Person> ShowClassesWithDebts()
        {
            if (!personContext.ClassesPartipciations.Any())
                return null;
            var classes = personContext.ClassesPartipciations.ToList();
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

                personList[classPerPerson.PersonId].StudentClasses.Add(classPerPerson);
            }

            var listToReturn = personList.Values.AsQueryable().Include(p => p.StudentClasses).ToList();
            listToReturn.OrderBy(p => p.Id);
            return listToReturn;
        }
    }
}
