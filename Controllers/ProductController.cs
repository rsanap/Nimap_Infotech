using NimapInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NimapInfotech.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product/Create
        public ActionResult Create()
        {
           
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName, CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
               
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public ActionResult Index(int page = 1)
        {
            const int pageSize = 10;

            var totalProducts = db.Products.Count();

            var products = db.Products.Include(p => p.Category)
                                      .OrderBy(p => p.ProductId)
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            ViewBag.TotalProducts = totalProducts;  

            return View(products);
        }
    }
}