using System.Collections.Generic;

namespace JeRestaurantService
{
    public class Restaurant
    {
        public string RatingAverage { get; set; }
        public string Name { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
    }
}