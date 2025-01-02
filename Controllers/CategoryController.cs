using NimapInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotech.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Index
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
    }
}