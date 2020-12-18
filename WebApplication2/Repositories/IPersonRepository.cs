using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        Person AddPerson(Person person);
        Person AddClassToPerson(int studentId, int monthId, ClassParticipated classParticipated);
        Person UpdatePerson(Person person);
        object FindStudentsByMonth(string month, string year);
    }
}
