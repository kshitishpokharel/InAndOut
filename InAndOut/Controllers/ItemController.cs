using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET Create Action
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item Obj)
        {
            _db.Items.Add(Obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Update Action
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.Items.Find(id);
            return View(obj);
        }

        //POST Update Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            _db.Items.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Delete Action
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.Items.Find(id);
            return View(obj);
        }

        //POST Update Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
