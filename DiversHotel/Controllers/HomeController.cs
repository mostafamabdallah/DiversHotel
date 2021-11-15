using DiversHotel.Data;
using DiversHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult GetReservationTotal(Reservation obj)
        {
            DateTime checkin = obj.checkin_date;
            DateTime checkout = obj.checkout_date;
            int no_of_days = (int)(checkout - checkin).TotalDays;
            int no_persons = obj.no_adult + obj.no_children;
            int meal_id = obj.meal_plan_id;
            int room_id = obj.room_type_id;
            float mealPrice;
            if (checkin.Month > 5 && checkout.Month > 5)
            {
                mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_high_season;
            }
            else if (checkin.Month <= 5 && checkout.Month <= 5)
            {
                mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_low_season;
            }
            else
            {
                mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_high_season;
            }
            float roomPrice = _db.RoomType.Find(room_id).ratePerPreson;
            float singleDayPrice = mealPrice + roomPrice;
            float totalPrice = singleDayPrice * no_of_days * no_persons;
            _db.Reservation.Add(obj);
            _db.SaveChanges();
            return View((object)totalPrice);
        }

    }
}
