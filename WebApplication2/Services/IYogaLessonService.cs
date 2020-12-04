using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Dtos;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public interface IYogaLessonService
    {
       YogaLesson AddStudentToClass(int classId, int studentId, int monthId);
       YogaLesson DeleteStudentFromClass(int classId, int personId);

        YogaLesson AddOrUpdateClass(int weekId, int monthId, YogaLessonDto yogaLessonDto);

       YogaLesson UpdateClass(YogaLesson yogaClass);

       YogaLesson DeleteClass(int classId);

       YogaLesson GetYogaClass(int classId);
    }
}
