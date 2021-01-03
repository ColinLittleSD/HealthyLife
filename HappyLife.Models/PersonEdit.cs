using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class PersonEdit
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string HealthGoals { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
