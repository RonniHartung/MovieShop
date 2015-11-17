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

        // GET /api/movie
        // The method name starts with "Get", so by convention it maps to GET requests.
        // Also, because the method has no parameters, it maps to a URI that does not 
        // contain an "id" segment in the path.

        /// <summary>
        /// Returns all movie
        /// </summary>
        /// <returns>Array of movie</returns>
        public IEnumerable<Movie> GetAll()
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

        // GET /api/movie/id
        // This method name also starts with "Get", but the method has a parameter named id.
        // This parameter is mapped to the "id" segment of the URI path. The ASP.NET Web API
        // framework automatically converts the ID to the correct data type for the parameter. 

        /// <summary>
        /// Finds a movie by Id
        /// </summary>
        /// <param name="id">movie Id</param>
        /// <returns>Product</returns>
        public Movie GetMovie(int id)
        {
            Movie item = facade.MovieRepository.Get(id);
            if (item == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;

        }

        // DELETE /api/movie/id
        // In this case, the DeleteMovie method has a void return type, so ASP.NET Web API
        // automatically translates this into status code 204 (No Content).

        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <param name="id">Movie Id of the product that sould be deleted</param>

        public void DeleteMovie(int id)
        {
            Movie item = GetMovie(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.MovieRepository.Remove(id);
        }

        // PUT /api/products/id
        // The id parameter is taken from the URI path, and the product parameter is deserialized
        // from the request body. By default, the ASP.NET Web API framework takes simple parameter
        // types from the route and complex types from the request body.

        /// <summary>
        /// Replaces a product with a new product
        /// </summary>
        /// <param name="id">Product Id of the product to replace</param>
        /// <param name="movie">The new product</param>
        public void PutProduct(int id, Movie movie)
        {
            movie.Id = id;
            if (!facade.MovieRepository.Update(movie))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage PostMovie(Movie entity)
        {
            entity = facade.MovieRepository.Add(entity);
            var response = Request.CreateResponse<Movie>(HttpStatusCode.Created, entity);

            string uri = Url.Link("DefaultApi", new { id = entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
