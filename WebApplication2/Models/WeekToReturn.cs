using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class WeekToReturn
    {

        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<List<YogaLesson>> ClassesByDays { get; set; } = new List<List<YogaLesson>>();

        public WeekToReturn()
        {
            for (int i = 0; i < 6; i++)
            {
                ClassesByDays.Add(new List<YogaLesson>());
            }
        }


    }
}
