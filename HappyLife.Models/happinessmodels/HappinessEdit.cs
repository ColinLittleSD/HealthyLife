using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models.happinessmodels
{
    public class HappinessEdit
    {
        public int PersonId { get; set; }
        public int HappinessId { get; set; }
        [Display(Name = "Happiness level 1-10")]
        public int HappinessLevel { get; set; }
        [Display(Name = "What emotions/feelings did you have?")]
        public string EmotionNotes { get; set; }
        public DateTime Date { get; set; }
    }
}
