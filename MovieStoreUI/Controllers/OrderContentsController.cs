using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDAL;

namespace MovieStoreUI.Controllers
{
    public class OrderContentsController : Controller
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();

        // GET: OrderContents
        public ActionResult Index()
        {
            var orderContents = db.OrderContents.Include(o => o.Movies).Include(o => o.Orders);
            return View(orderContents.ToList());
        }

        // GET: OrderContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderContent orderContent = db.OrderContents.Find(id);
            if (orderContent == null)
            {
                return HttpNotFound();
            }
            return View(orderContent);
        }

        // GET: OrderContents/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: OrderContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentId,OrderId,MovieId")] OrderContent orderContent)
        {
            if (ModelState.IsValid)
            {
                db.OrderContents.Add(orderContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", orderContent.MovieId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderContent.OrderId);
            return View(orderContent);
        }

        // GET: OrderContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderContent orderContent = db.OrderContents.Find(id);
            if (orderContent == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", orderContent.MovieId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderContent.OrderId);
            return View(orderContent);
        }

        // POST: OrderContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentId,OrderId,MovieId")] OrderContent orderContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", orderContent.MovieId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderContent.OrderId);
            return View(orderContent);
        }

        // GET: OrderContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderContent orderContent = db.OrderContents.Find(id);
            if (orderContent == null)
            {
                return HttpNotFound();
            }
            return View(orderContent);
        }

        // POST: OrderContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderContent orderContent = db.OrderContents.Find(id);
            db.OrderContents.Remove(orderContent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
