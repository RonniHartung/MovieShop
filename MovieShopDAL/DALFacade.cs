using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDAL.Repository;

namespace MovieShopDAL
{
    public class DALFacade
    {
        private IRepository<Customer> customerRepository;
        private IRepository<Movie> movieRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Order> orderRepository;
        private IRepository<OrderContent> orderContentRepository;


        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return customerRepository == null ? customerRepository =
                    new CustomerRepository() : customerRepository;
            }

        }

        public IRepository<Movie> MovieRepository => movieRepository ?? (movieRepository =
            new MovieRepository());

        public IRepository<Category> CategoryRepository => categoryRepository ?? (categoryRepository =
            new CategoryRepository());

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