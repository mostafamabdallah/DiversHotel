using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Controllers
{
    public class ReservationTotalController : Controller
    {
        [HttpPost]
        public string GetReservationTotal(string name)
        {
            string name1 = name;
            return "s";
        }
    }
}
