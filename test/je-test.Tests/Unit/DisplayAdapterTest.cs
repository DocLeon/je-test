using System.Collections.Generic;
using JeRestaurantService;
using Moq;
using NUnit.Framework;

namespace je_test.Tests.Unit
{
    public class DisplayAdapterTests
    {
        public class when_displaying_results_for_one_restaurant
        {
            private Mock<IDisplay> _displaySpy;

            [OneTimeSetUp]
            public void SetUp()
            {
                var restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Name = "Milliways",
                    CuisineTypes = new List<CuisineType>()
                    {
                        new CuisineType{Name = "Gourmet"},
                        new CuisineType{Name = "Dim Sum"},
                        new CuisineType{Name = "English Breakfast"}
                    },
                    RatingAverage = "5"
                }
            };
                _displaySpy = new Mock<IDisplay>();
                var displayAdapter = new DisplayAdapter(_displaySpy.Object);
                displayAdapter.Display(restaurants);
            }

            [Test]
            public void it_will_display_restaurant_name()
            {
                _displaySpy.Verify(d => d.Write("Restaurant: Milliways"));
            }

            [Test]
            public void it_will_display_cuisine_types()
            {
                _displaySpy.Verify(d => d.Write("Cuisines: Gourmet, Dim Sum, English Breakfast"));
            }

            [Test]
            public void it_will_display_rating()
            {
                _displaySpy.Verify(d => d.Write("Rating: 5"));
            }
        }
        public class when_dispaying_results_for_mutiple_restaurants
        {
            private Mock<IDisplay> _displaySpy;

            [OneTimeSetUp]
            public void SetUp()
            {
                var restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Name = "Milliways",
                    CuisineTypes = new List<CuisineType>()
                    {
                        new CuisineType{Name = "Gourmet"},
                        new CuisineType{Name = "Dim Sum"},
                        new CuisineType{Name = "English Breakfast"}
                    },
                    RatingAverage = "5"
                },
                new Restaurant
                {
                    Name = "Mancini's",
                    CuisineTypes = new List<CuisineType>()
                    {
                        new CuisineType{Name = "Pick n Mix"},
                        new CuisineType{Name = "Thai"},
                    },
                    RatingAverage = "3"
                }
            };
                _displaySpy = new Mock<IDisplay>();
                var displayAdapter = new DisplayAdapter(_displaySpy.Object);
                displayAdapter.Display(restaurants);
            }

            [Test]
            public void it_will_display_both_restaurant_names()
            {
                _displaySpy.Verify(d => d.Write("Restaurant: Milliways"));
                _displaySpy.Verify(d => d.Write("Restaurant: Mancini's"));
            }

            [Test]
            public void it_will_display_cuisine_types_for_both_restaurants()
            {
                _displaySpy.Verify(d => d.Write("Cuisines: Gourmet, Dim Sum, English Breakfast"));
                _displaySpy.Verify(d => d.Write("Cuisines: Pick n Mix, Thai"));
            }

            [Test]
            public void it_will_display_rating()
            {
                _displaySpy.Verify(d => d.Write("Rating: 5"));
                _displaySpy.Verify(d => d.Write("Rating: 3"));
            }
        }
    }
}