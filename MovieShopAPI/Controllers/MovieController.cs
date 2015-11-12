using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MovieShopDAL;

namespace MovieShopAPI.Controllers
{
    public class MovieController : ApiController
    {
        DALFacade facade = new DALFacade();

        public IEnumerable<Movie> GetMovies()
        {
            try
            {
                return facade.MovieRepository.Get();
            }
            catch 
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        } 


    }
}
