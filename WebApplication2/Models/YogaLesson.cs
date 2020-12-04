using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class YogaLesson
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime  StartingTime { get; set; }
        public DateTime EndTime { get; set; }
        public Level ClassLevel { get; set; }
        public List<ClassParticipated> StudentsParticipated { get; set; } = new List<ClassParticipated>();

        public void AddStudentToClass(ClassParticipated student)
        {
            StudentsParticipated.Add(student);
        }

        public void RemoveStudentFromClass(int studentId) 
        {
            StudentsParticipated.Remove(StudentsParticipated.Where(s => s.Id == studentId).SingleOrDefault());
        }


    }
}
