using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopDAL;
using System.Net;
using MovieStoreUI.Models;
using System.Data.Entity;

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
            //Customer customer = facade.CustomerRepository.Get(Phone);
            if (customer == null)
            {
                return View(customer);
            }
            return View(customer);
        }


        [HttpPost]
        public ActionResult PlaceOrder(int customerId)
        {
            
            DateTime dt = DateTime.Now;
            Order order = new Order();

            order.CustomerId = customerId;
            order.OrderDate = dt;
            facade.OrderRepository.Add(order);

            Order lo = db.Orders.OrderByDescending(o => o.OrderDate).FirstOrDefault();

            int lastId = lo.Id;

            IList<ShoppingCartItem> lines = Session["cart"] as IList<ShoppingCartItem>;


            foreach (var item in lines)
            {

                OrderContent oc = new OrderContent();
                oc.OrderId = lastId;
                oc.MovieId = item.Id;
                oc.Price = item.UnitPrice;
                oc.Quantity = item.Quantity;
                facade.OrderContentRepository.Add(oc);
                
            }

           

            return RedirectToAction("Index", "Orders");
        }

    }
}