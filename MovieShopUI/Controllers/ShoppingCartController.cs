using System.Collections.Generic;
using System.Web.Mvc;
using MusicStoreDAL;
using MusicStoreUI.Models;
using System.Web.Routing;

namespace MusicStoreUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartModel cartModel;

        public ShoppingCartController()
        {
            IRepository<Album> repository = new DALFacade().AlbumRepository;
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

        // GET: /ShoppingCart/Add
        public ActionResult Add(int id)
        {
            cartModel.Add(id);
            return RedirectToAction("Index", "Albums");
        }

        public ActionResult Clear()
        {
            Session["cart"] = null;
            return RedirectToAction("Index", "Albums");
        }

        // Child action: returns the number of items in the shopping cart
        [ChildActionOnly]
        public ActionResult NoOfItems()
        {
            return Content("[" + cartModel.NoOfItems + "]");
        }
    }
}