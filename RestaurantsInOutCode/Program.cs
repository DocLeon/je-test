using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeRestaurantService;

namespace RestaurantsInOutCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var jeApi = new JeApiClient();
            var restaurants = jeApi.GetRestaurantsFor("SE19");
            var displayAdapter = new DisplayAdapter(new ConsoleDisplay());
            displayAdapter.Display(restaurants.Restaurants);
            Console.WriteLine();
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadLine();
        }
    }

    internal class ConsoleDisplay : IDisplay
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
