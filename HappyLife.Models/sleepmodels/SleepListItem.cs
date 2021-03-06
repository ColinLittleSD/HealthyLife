﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Models
{
    public class SleepListItem
    {
        
        public int SleepId { get; set; }
       
        [Display(Name = "Hours slept?")]
        public int HoursSlept { get; set; }
        [Display(Name = "What time did you wake up?")]
        public TimeSpan WakeUpTime { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "User name")]
        public string PersonName { get; set; }


    }
}
