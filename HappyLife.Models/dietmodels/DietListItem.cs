using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class DietListItem
    {
        public int DietId { get; set; }
        [Display(Name = "User name")]
        public string PersonName { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Snacks { get; set; }
        public string Liquids { get; set; }
        public DateTime Date { get; set; }
    }
}
