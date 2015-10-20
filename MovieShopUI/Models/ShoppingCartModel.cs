using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDAL;
using MovieStoreUI.BusinessLogic;

namespace MovieStoreUI.Models
{
    public class ShoppingCartModel : IShoppingCartModel
    {
        IRepository<Movie> repository;

        // Constructor parameter enables dependency injection (constructor injection)
        public ShoppingCartModel(IRepository<Movie> repository)
        {
            this.repository = repository;
        }
        // This property enables dependency injection (property injection)
        public IList<ShoppingCartItem> Items { get; set; }

        public void Add(int id)
        {
            ShoppingCartItem cartItem = (from item in Items
                                         where item.Id == id
                                         select item).FirstOrDefault();

            if (cartItem == null)
            {
                Movie movie = repository.Get(id);
                cartItem = new ShoppingCartItem
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    UnitPrice = movie.Price,
                    Quantity = 1
                };
                Items.Add(cartItem);
            }
            else
                cartItem.Quantity++;
        }

        public int NoOfItems
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return AlbumUtil.CalculateTotalPrice(Items);
                //return Items.Sum(item => item.Quantity * item.UnitPrice);
            }
        }
    }
}