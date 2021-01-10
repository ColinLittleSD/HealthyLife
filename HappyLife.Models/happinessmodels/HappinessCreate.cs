using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models.happinessmodels
{
    public class HappinessCreate
    {
        [Required]
        public int HappinessLevel { get; set; }
        [Required]
        [Display(Name = "What emotions/feelings did you have?")]
        public string EmotionNotes { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Display(Name = "Person Id")]
        public int PersonId { get; set; }
    }
}
