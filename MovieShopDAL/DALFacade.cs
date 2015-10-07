using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class DALFacade
    {
        private IRepository<Customer> customerRepository;
        private IRepository<Movie> movieRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Order> orderRepository;
        private IRepository<OrderContent> orderContentRepository;
        //private IRepository<Shop> shopRepository;


        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return customerRepository == null ? customerRepository =
                    new CustomerRepository() : customerRepository;
            }

        }

        public IRepository<Movie> MovieRepository
        {
            get
            {
                return movieRepository == null ? movieRepository =
                    new MovieRepository() : movieRepository;
            }

        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return categoryRepository == null ? categoryRepository =
                    new CategoryRepository() : categoryRepository;
            }

        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return orderRepository == null ? orderRepository =
                    new OrderRepository() : orderRepository;
            }

        }

        public IRepository<OrderContent> OrderContentRepository
        {
            get
            {
                return orderContentRepository == null ? orderContentRepository =
                    new OrderContentRepository() : orderContentRepository;
            }


        }

    }
}