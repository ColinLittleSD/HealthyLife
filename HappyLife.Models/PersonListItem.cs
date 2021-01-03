using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class PersonListItem
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        [Display(Name="Health Goals")]
        public string HealthGoals { get; set; }
        [Display(Name ="Date")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }
    }
}
