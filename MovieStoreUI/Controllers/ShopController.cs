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
    public class ShopController : Controller
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();
        // GET: Shop
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Category);
            return View(movies.ToList());
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