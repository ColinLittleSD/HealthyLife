using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class ExerciseCreate
    {
        [Required]
        public string Activity { get; set; }
        [Required]
        [Display(Name = "How many hours did you perform this activity?")]
        public double TimeSpentOnActivity { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Display(Name = "Person Id:")]
        public int PersonId { get; set; }
    }
}

