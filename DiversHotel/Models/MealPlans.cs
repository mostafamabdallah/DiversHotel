using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class MealPlans
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string mealPlans { get; set; }
        public int ratePerPerson_low_season { get; set; }
        public int ratePerPerson_high_season { get; set; }
    }
}
