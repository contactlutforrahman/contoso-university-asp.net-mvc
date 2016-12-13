﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contoso.Core.Domain
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student
        {
            get; set;
        }
    }
}