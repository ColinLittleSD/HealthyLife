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
        [Display(Name ="Hours slept?")]
        public int HoursSlept { get; set; }
        [Required]
        [Display(Name ="What time did you wake up?")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm")]
        public TimeSpan WakeUpTime { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
