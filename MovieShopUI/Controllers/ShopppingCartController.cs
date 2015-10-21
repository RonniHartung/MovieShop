using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MovieShopDAL;
using MovieStoreUI.Models;



namespace MovieStoreUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartModel cartModel;

        public ShoppingCartController()
        {
            IRepository<Movie> repository = new DALFacade().MovieRepository;
            this.cartModel = new ShoppingCartModel(repository);
        }

        // The Initialize() method is invoked just after the constructor. It is
        // used to initialize data that is not available when the constructor is
        // executed.
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["cart"] == null)
                Session["cart"] = new List<ShoppingCartItem>();

            cartModel.Items = (List<ShoppingCartItem>)Session["cart"];
        }

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            return View(cartModel);
        }

        public ActionResult PartIndex()
        {
            return View(cartModel);
        }

        // GET: /ShoppingCart/Add
        public ActionResult Add(int id)
        {
            cartModel.Add(id);
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Clear()
        {
            Session["cart"] = null;
            return RedirectToAction("Index", "Movies");
        }

        // Child action: returns the number of items in the shopping cart
        [ChildActionOnly]
        public ActionResult NoOfItems()
        {
            return Content("[" + cartModel.NoOfItems + "]");
        }
    }
}
