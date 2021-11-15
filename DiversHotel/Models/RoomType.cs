using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class RoomType
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string roomType { get; set; }
        public int ratePerPreson { get; set; }
    }
}
