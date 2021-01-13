﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class ExerciseEdit
    {
        public int PersonId { get; set; }
        public string Activity { get; set; }
        [Display(Name = "Hours spent on activity:")]
        public double TimeSpentOnActivity { get; set; }
        public DateTime Date { get; set; }
        public int ExerciseId { get; set; }
    }
}
