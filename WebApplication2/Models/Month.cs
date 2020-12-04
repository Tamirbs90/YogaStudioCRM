using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class Month 
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MonthName { get; set; }
        public string Year { get; set; }
        public List<ClassParticipated> ClassesInMonth { get; set; } = new List<ClassParticipated>();
        public List<Week> Weeks { get; set; } = new List<Week>();
    }
}
