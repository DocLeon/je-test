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

        public void Display(IList<Restaurant> restaraunts)
        {
            _display.Write($"Restaurant: {restaraunts[0].Name}");
            var cuisineList = new StringBuilder();
            foreach (var cuisine in restaraunts[0].CuisineTypes)
            {
                cuisineList.Append($"{cuisine.Name}, ");
            }
            
            _display.Write($"Cuisines: {cuisineList.ToString().TrimEnd(' ', ',')}");
        }
    }
}