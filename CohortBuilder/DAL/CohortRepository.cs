using CohortBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CohortBuilder.DAL
{
    public class CohortRepository : IRepository
    {
        public CohortContext Context { get; set; }

        public CohortRepository()
        {
            Context = new CohortContext();
        }

        public CohortRepository(CohortContext context)
        {
            this.Context = context;
        }

    
        public void AddCohort(int CohortId)
        {
            Cohort cohort = new Cohort { CohortId = 2};
            Context.Cohort.Add(cohort);
            Context.SaveChanges();
        }

        public void AddInstructor(int InstructorId, string InstructorFullName)
        {
            Instructor instructor = new Instructor { InstructorId = 2, InstructorFullName = "butts magee" };
            Context.Instructor.Add(instructor);
            Context.SaveChanges();
        }

        public void AddStudent(int StudentId, string StudentFullName)
        {
            Student student = new Student { StudentId = 2, StudentFullName = "butts magee" };
            Context.Student.Add(student);
            Context.SaveChanges();
        }
    }
}