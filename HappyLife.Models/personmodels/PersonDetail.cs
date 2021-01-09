using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class PersonDetail
    {
        
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        [Display(Name = "Health Goals")]
        public string HealthGoals { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        [Display(Name ="List of sleep data ")]
        public List<SleepListItem> Sleeps { get; set; } = new List<SleepListItem>();
        public List<ExerciseListItem> Exercises { get; set; } = new List<ExerciseListItem>();
        public List<DietListItem> Diets { get; set; } = new List<DietListItem>();
    }
}
