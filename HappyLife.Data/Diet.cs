using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Data
{
    public class Diet
    {
        [Key]
        public int DietId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
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

    }
}
