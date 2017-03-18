using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CohortBuilder.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        public string InstructorFullName { get; set; }

        public virtual Cohort Cohort { get; set; }

    }
}