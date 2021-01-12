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
        [Display(Name = "Hours slept?")]
        public int HoursSlept { get; set; }
        [Required]
        [Display(Name = "What time did you wake up?")]
        public TimeSpan WakeUpTime { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
