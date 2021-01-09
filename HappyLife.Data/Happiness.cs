using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Data
{
    public class Happiness
    {
        [Key]
        public int HappinessId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Happiness level 1-10")]
        public int HappinessLevel { get; set; }
        [Required]
        [Display(Name = "What emotions/feelings did you have?")]
        public string EmotionNotes { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
