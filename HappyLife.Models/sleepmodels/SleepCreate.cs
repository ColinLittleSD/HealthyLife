using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class SleepCreate
    {
        [Required]
        [Display(Name ="How long did you sleep?")]
        public int HoursSlept { get; set; }
        [Required]
        [Display(Name ="What time did you wake up?")]
        public TimeSpan WakeUpTime { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
