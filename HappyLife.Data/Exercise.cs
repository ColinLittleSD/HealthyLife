using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Data
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public double TimeSpentOnActivity { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
