using NimapInfotech.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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

        // GET: Category/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId, CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
               
                Category existingCategory = db.Categories.Find(category.CategoryId);
                if (existingCategory == null)
                {
                    return HttpNotFound();
                }

             
                existingCategory.CategoryName = category.CategoryName;

               
                db.Entry(existingCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(category);
        }

        // GET: Category/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Category/Index
        public ActionResult Index()
        {
            
            var categories = db.Categories.ToList();
            return View(categories);
        }
    }
}
