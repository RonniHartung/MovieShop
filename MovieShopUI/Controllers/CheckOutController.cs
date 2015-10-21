using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopDAL;
using System.Net;

namespace MovieStoreUI.Controllers
{
    public class CheckOutController : Controller
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();
        DALFacade facade = new DALFacade();

        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(int? Phone)
        {
            Customer customer = db.Customers.FirstOrDefault(a => a.Phone == Phone);
            if (customer == null)
            {
                return View(customer);
            }
            return View(customer);
        }
        //[HttpPost]
        //public ActionResult PlaceOrder(int CustomerId)
        //{
        //    facade.OrderRepository.Add(CustomerId);

        //    return View("Index","Orders");
        //}

    }
}