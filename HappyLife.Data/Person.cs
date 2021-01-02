using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        [Display(Name="Health Goals")]
        public string HealthGoals { get; set; }
        [Required]
        [Display(Name="Date")]
        public DateTime DateStarted { get; set; }
    }
}
