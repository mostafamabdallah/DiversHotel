using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class Reservation
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public int  no_adult { get; set; }
        public int no_children { get; set; }
        public int room_type_id { get; set; }
        public int meal_plan_id { get; set; }
        public DateTime checkin_date { get; set; }
        public DateTime checkout_date { get; set; }
    }
}
