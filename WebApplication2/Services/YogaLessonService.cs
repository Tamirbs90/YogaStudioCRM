using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Dtos;
using YogaStudio.Models;
using YogaStudio.Repositories;

namespace YogaStudio.Services
{
    public class YogaLessonService : IYogaLessonService
    {
        private IRepositoriesManager repositoriesManager;
        private PersonContext personContext;
        private IMapper mapper;

        public YogaLessonService(IRepositoriesManager i_repositoriesManager, PersonContext i_personContext, IMapper i_mapper)
        {
            repositoriesManager = i_repositoriesManager;
            personContext = i_personContext;
            mapper = i_mapper;
        }

        public YogaLesson AddStudentToClass(int classId, int studentId, int monthId)
        {
            var yogaClass = repositoriesManager.GetRepository<YogaLesson>().GetById(classId);
            var student = repositoriesManager.GetRepository<Person>().GetById(studentId);
            var month = repositoriesManager.GetRepository<Month>().GetById(monthId);
            var classParticipation = new ClassParticipated
            {
                Date = yogaClass.StartingTime.ToShortDateString(),
                Participated = true
            };

            yogaClass.AddStudentToClass(classParticipation);
            student.StudentClasses.Add(classParticipation);
            month.ClassesInMonth.Add(classParticipation);
            repositoriesManager.Save();
            return yogaClass;
        }

        public YogaLesson UpdateClass(YogaLesson yogaClass)
        {
            return repositoriesManager.GetRepository<YogaLesson>().Update(yogaClass);
        }

        public YogaLesson DeleteClass(int classId)
        {
            return repositoriesManager.GetRepository<YogaLesson>().Delete(classId);
        }

        public YogaLesson DeleteStudentFromClass(int classId, int personId)
        {
            var studentClass = repositoriesManager.GetRepository<YogaLesson>().GetById(classId);
            var participation = repositoriesManager.GetRepository<ClassParticipated>().GetById(personId);
            studentClass.StudentsParticipated.Remove(participation);
            repositoriesManager.Save();
            return studentClass;
        }

        public YogaLesson GetYogaClass(int classId)
        {
            return personContext.YogaLessons.
                Include(l => l.StudentsParticipated).
                ThenInclude(s => s.Person).
                FirstOrDefault(l => l.Id == classId);
        }

        public YogaLesson AddOrUpdateClass(int weekId, int monthId, YogaLessonDto yogaLessonDto)
        {
            var weekToChange = repositoriesManager.GetRepository<Week>().GetById(weekId);
            if (yogaLessonDto.Id > 0)
            {
                return UpdateClass(monthId, yogaLessonDto.Id, yogaLessonDto);

            }

            var newYogaLesson = mapper.Map<YogaLessonDto, YogaLesson>(yogaLessonDto);
            weekToChange.ClassesInWeek.Add(newYogaLesson);
            foreach (var id in yogaLessonDto.studentsIds)
            {
                AddNewParticipation(newYogaLesson, monthId, id, yogaLessonDto.StartingTime);
            }
            repositoriesManager.Save();
            return newYogaLesson;
        }

        private YogaLesson UpdateClass(int monthId, int classId, YogaLessonDto yogaLessonDto)
        {
            var modelClass = mapper.Map<YogaLessonDto, YogaLesson>(yogaLessonDto);
            repositoriesManager.GetRepository<YogaLesson>().Update(modelClass);
            var classToChange = personContext.YogaLessons.Include(lesson => lesson.StudentsParticipated).
                FirstOrDefault(lesson => lesson.Id == classId);
            foreach (var id in yogaLessonDto.studentsIds)
            {
               if(classToChange.StudentsParticipated.FindIndex(p=>p.PersonId==int.Parse(id))==-1)
                {
                    AddNewParticipation(classToChange, monthId, id, yogaLessonDto.StartingTime);
                }
            }
            repositoriesManager.Save();
            return classToChange;
        }

        private void AddNewParticipation(YogaLesson classTochange, int monthId, string studentId, string lessonDate)
        {
            var newClassParticipation = new ClassParticipated
            { Date = lessonDate, Participated = true };
            var student = repositoriesManager.GetRepository<Person>().GetById(int.Parse(studentId));
            var month = repositoriesManager.GetRepository<Month>().GetById(monthId);
            classTochange.StudentsParticipated.Add(newClassParticipation);
            student.StudentClasses.Add(newClassParticipation);
            month.ClassesInMonth.Add(newClassParticipation);
        }


    }
}
