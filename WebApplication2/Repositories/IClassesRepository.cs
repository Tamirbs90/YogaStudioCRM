using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Repositories
{
    public interface IClassesRepository
    {
        Person AddClassToStudent(int studentId, int monthId, ClassParticipated classParticipated);
        Person DeleteClassFromStudent(int classId);

        ClassParticipated UpdateParticipation(ClassParticipated participation);

        List<Person> ShowClassesWithDebts();
    }
}
