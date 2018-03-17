using System.Collections.Generic;
using System.Text;

namespace JeRestaurantService
{
    public class DisplayAdapter
    {
        private readonly IDisplay _display;

        public DisplayAdapter(IDisplay display)
        {
            _display = display;            
        }

        public void Display(IList<Restaurant> restaurants)
        {
            foreach (var restaurant in restaurants)
            { 
                _display.Write($"Restaurant: {restaurant.Name}");
                var cuisineList = new StringBuilder();
                foreach (var cuisine in restaurant.CuisineTypes)
                {
                    cuisineList.Append($"{cuisine.Name}, ");
                }
                _display.Write($"Cuisines: {cuisineList.ToString().TrimEnd(' ', ',')}");
                _display.Write($"Rating: {restaurant.RatingAverage}");
            }
            
        }
    }
}