using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class Week 
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<YogaLesson> ClassesInWeek { get; set; } = new List<YogaLesson>();

        public void AddClass(YogaLesson classToAdd)
        {
            ClassesInWeek.Add(classToAdd);
        }
    }
}
