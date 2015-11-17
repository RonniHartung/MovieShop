using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShopDAL
{
    internal class MovieRepository : IRepository<Movie>
    {
        System.Data.Entity.SqlServer.SqlProviderServices ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public void Add(Movie entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Movies.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Movie entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Movie Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Movies.Include(c => c.Category).FirstOrDefault(m => m.Id==id);
            }
        }

        public IEnumerable<Movie> Get()
        {

            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Movies.Include(c=> c.Category).ToList();
            }
        }

        public void Remove(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var movies = db.Movies.Find(id);
                db.Movies.Remove(movies);
                db.SaveChanges();
            }
        }

        public bool Update(Movie entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }
    }
}