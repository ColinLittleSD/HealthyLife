using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Data
{
    public class Sleep
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

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}
