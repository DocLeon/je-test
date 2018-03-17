using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeRestaurantService;

namespace RestaurantsInOutCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string outCode = "SE19";
            if (0 < args.Length) outCode = args[0];
            if (string.IsNullOrEmpty(outCode)) outCode = "SE19"; 
            var jeApi = new JeApiClient();
            var restaurants = jeApi.GetRestaurantsFor(outCode);
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
