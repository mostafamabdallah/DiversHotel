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
    public class RoomController : Controller
    {
        private readonly ApplicationDBContext _db;
        public RoomController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<RoomType> objList = _db.RoomType;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST  Create
        [HttpPost]
        public IActionResult Create(RoomType obj)
        {
            _db.RoomType.Add(obj);
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
            var obj = _db.RoomType.Find(id);
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
            var obj = _db.RoomType.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.RoomType.Remove(obj);
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
            var obj = _db.RoomType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Update
        [HttpPost]
        public IActionResult Update(RoomType obj)
        {
            _db.RoomType.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string getData()
        {
            var data = _db.RoomType;
            var jsondata = JsonConvert.SerializeObject(data);
            return jsondata;
        }
    }
}
