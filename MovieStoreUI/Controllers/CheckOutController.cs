using MovieShopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreUI.Controllers
{
    public class CheckOutController : Controller
    {
        DALFacade facade = new DALFacade();
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = facade.CustomerRepository.Get(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}