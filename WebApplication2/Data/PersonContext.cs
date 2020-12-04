using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) 
            : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ClassParticipated> ClassesPartipciations { get; set; }
        public DbSet<Month> Months { get; set; }

        public DbSet<Week> Weeks { get; set; }

        public DbSet<YogaLesson> YogaLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassParticipated>().HasOne(c => c.Person).WithMany(p => p.StudentClasses).HasForeignKey(c => c.PersonId);
        }

    }
     
   
}
