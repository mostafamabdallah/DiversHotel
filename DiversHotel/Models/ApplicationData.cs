using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class ApplicationData
    {
        public IEnumerable<DiversHotel.Models.MealPlans> MealPlans { get; set; }
        public IEnumerable<DiversHotel.Models.RoomType> RoomType { get; set; }
        public DiversHotel.Models.Reservation Reservation { get; set; }
    }
}
