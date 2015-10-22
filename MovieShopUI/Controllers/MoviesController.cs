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
    public class MoviesController : Controller
    {
        //private MovieStoreDbContext db = new MovieStoreDbContext();

        DALFacade facade = new DALFacade();

        // GET: Movies
        public ActionResult Index()
        {
            return View(facade.MovieRepository.Get());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = facade.MovieRepository.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(facade.CategoryRepository.Get(), "Id", "CategoryName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Price,ImageUrl,TrailerUrl,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                facade.MovieRepository.Add(movie);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(facade.CategoryRepository.Get(), "Id", "CategoryName", movie.CategoryId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = facade.MovieRepository.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", movie.CategoryId);
            var list = facade.CategoryRepository.Get();
            ViewBag.CategoryId = new SelectList(list,"Id","CategoryName", movie.CategoryId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,ImageUrl,TrailerUrl,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(movie).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", movie.CategoryId);
            ViewBag.CategoryId = new SelectList(facade.CategoryRepository.Get(), "Id", "CategoryName", movie.CategoryId);

            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = facade.MovieRepository.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facade.MovieRepository.Remove(id);
            //db.Movies.Remove(movie);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Movies/Details/5
        public ActionResult Trailer(int? id)
        {
            Movie movie = facade.MovieRepository.Get(id.Value);
            return View(movie);
        }

    }
}
