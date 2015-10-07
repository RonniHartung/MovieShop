namespace MovieShopDAL
{
    internal class Shop
    {
        public int Id { get; }
        public string Title { get; }
        public decimal Price { get; }
        public string ImageUrl { get; }
        public string TrailerUrl { get; }

        public int CategoryId { get; }

        public virtual Category Category { get;}
    }
}