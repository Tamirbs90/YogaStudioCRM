using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class Month
    {
        public int Id { get; set; }
        public string MonthName { get; set; }
        public string Year { get; set; }
        public List<ClassParticipated> Classes { get; set; } = new List<ClassParticipated>();
    }
}
