using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Dtos
{
    public class YogaLessonDto
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string StartingTime { get; set; }
        public string EndTime { get; set; }
        public Level ClassLevel { get; set; }

        public List<string> studentsIds { get; set; } = new List<string>();


    }
}
