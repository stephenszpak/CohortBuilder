using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohortBuilder.DAL
{
    public interface IRepository
    {
        //Create
        void AddStudent(int StudentId, string StudentFullName);
        void AddCohort(int CohortId);
        void AddInstructor(int InstructorId, string InstructorFullName);

        //Read


        //Update


        //Delete

    }
}
