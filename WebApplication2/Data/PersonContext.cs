﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<ClassParticipated> Classes { get; set; }
        public DbSet<Month> Months { get; set; }

    }
}
