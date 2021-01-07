using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class DietCreate
    {
        [Required]
        public string Breakfast { get; set; }
        [Required]
        public string Lunch { get; set; }
        [Required]
        public string Dinner { get; set; }
        [Required]
        public string Snacks { get; set; }
        [Required]
        public string Liquids { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
