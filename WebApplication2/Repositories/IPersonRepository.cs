using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IPersonRepository
    {
        Person AddPerson(Person person);
        Person AddClassToPerson(int id, ClassParticipated classParticipated);
        Person UpdatePerson(Person person);
        object FindStudentsByMonth(string month, string year);
    }
}
