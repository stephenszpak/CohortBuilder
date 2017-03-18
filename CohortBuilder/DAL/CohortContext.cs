using CohortBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CohortBuilder.DAL
{
    public class CohortContext : DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Cohort> Cohort { get; set; }
    }
}