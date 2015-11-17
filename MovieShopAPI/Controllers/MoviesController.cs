using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MovieShopDAL;

namespace MovieShopAPI.Controllers
{
    public class MovieController : ApiController
    {

        //IMovieRepository repository = new IMovieRepository();
        DALFacade facade = new DALFacade();

        // GET /api/movies
        // The method name starts with "Get", so by convention it maps to GET requests.
        // Also, because the method has no parameters, it maps to a URI that does not 
        // contain an "id" segment in the path.

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns>Array of movies</returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            // This method implementation demonstrates proper exception handling. A
            // real world web api should have similar exception handling in all
            // controller actions.
            return facade.MovieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            Movie item = facade.MovieRepository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
    }
}
