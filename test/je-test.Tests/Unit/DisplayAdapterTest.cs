using System.Collections.Generic;
using JeRestaurantService;
using Moq;
using NUnit.Framework;

namespace je_test.Tests.Unit
{
    public class DisplayAdapterTest
    {
        [Test]
        public void will_display_restaurant_name()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant{Name= "Milliways", CuisineTypes = new List<CuisineType>()}
            };

            var displaySpy = new Mock<IDisplay>();
            var displayAdapter = new DisplayAdapter(displaySpy.Object);
            displayAdapter.Display(restaurants);
            displaySpy.Verify(d => d.Write("Restaurant: Milliways"));
        }

        [Test]
        public void it_will_display_cuisine_types()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    CuisineTypes = new List<CuisineType>()
                    {
                        new CuisineType(){Name = "Gourmet"},
                        new CuisineType(){Name = "Dim Sum"},
                        new CuisineType(){Name = "English Breakfast"}
                    }
                }
            };

            var displaySpy = new Mock<IDisplay>();
            var displayAdapter = new DisplayAdapter(displaySpy.Object);
            displayAdapter.Display(restaurants);
            displaySpy.Verify(d => d.Write("Cuisines: Gourmet, Dim Sum, English Breakfast"));
        }

        [Test]
        public void it_will_display_rating()
        {

        }
    }
}