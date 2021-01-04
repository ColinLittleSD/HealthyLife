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
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "How long did you sleep?")]
        public int HoursSlept { get; set; }
        [Required]
        [Display(Name = "Time woken up")]
        public TimeSpan WakeUpTime { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
