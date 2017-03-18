﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CohortBuilder.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentFullName { get; set; }

        public virtual Cohort Cohort { get; set; }
    }
}