using DiversHotel.Data;
using DiversHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Controllers
{
    public class MealController : Controller
    {
        private readonly ApplicationDBContext _db;
        public MealController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MealPlans> objList = _db.MealPlans;
            return View(objList);
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
        public IActionResult Create(MealPlans obj)
        {
            _db.MealPlans.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MealPlans.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Delete
        [HttpPost]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.MealPlans.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.MealPlans.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MealPlans.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Update
        [HttpPost]
        public IActionResult Update(MealPlans obj)
        {
            _db.MealPlans.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string getData()
        {
            var data = _db.MealPlans;
            var jsondata = JsonConvert.SerializeObject(data);
            return jsondata;
        }


    }
}
