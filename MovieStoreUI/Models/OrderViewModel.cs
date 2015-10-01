using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDAL;

namespace MovieStoreUI.Models
{
    public class OrderViewModel
    {
        IRepository<Order> repository = new DALFacade().OrderRepository;
        

        Order order;
        
        public OrderViewModel(int id)
        {
            order = repository.Get(id);
        }

        public Order Order
        {
            get { return order; }
        }

        public List<OrderContent> OrderContent
        {
            get
            {
                return order.OrderContents.ToList();
            }

        }
    }
}