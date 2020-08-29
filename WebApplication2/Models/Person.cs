using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Models
{
    public class Person
    {
        
        public Person()
        {

        }
        public Person(int id, string name, List<ClassParticipated> classes)
        {
            Id = id;
            Name = name;
            Classes = classes;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        
        public string Birthday { get; set; }
        
        public int TotalPaid { get; set; }
        public int Debt { get; set; }
        public bool IsActive { get; set; }
        public Level Level { get; set; }

        public List<ClassParticipated> Classes { get; set; } = new List<ClassParticipated>();
    }
}
