using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class SleepListItem
    {
        [Key]
        public int SleepId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "How long did you sleep?")]
        public int HoursSlept { get; set; }
        [Display(Name = "Time woken up")]
        public TimeSpan WakeUpTime { get; set; }
        public DateTime Date { get; set; }
    }
}
