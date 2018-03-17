using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;

namespace je_test.Tests
{
    public class JeApiTest
    {
        [Test]
        public void can_get_data_from_just_eat()
        {
            var jeApiClient = new JeApiClient();
            var data = jeApiClient.GetRestaurants();
            Assert.That(data.Restaurants.Count, Is.GreaterThan(0));
            Assert.That(data.Restaurants[0], Is.Not.Null);
            Assert.That(data.Restaurants[0].Name, Is.Not.Null.Or.Empty);
            Assert.That(data.Restaurants[0].CuisineTypes, Is.Not.Null);
            Assert.That(data.Restaurants[0].CuisineTypes[0].Name, Is.Not.Null.Or.Empty);
        }
    }

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
   

    public interface IDisplay
    {
        void Write(string text);
    }

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

    public class JeApiClient
    {
        public JeData GetRestaurants()
        {
            return new JeData{Restaurants = FetchData()};
        }
        private List<Restaurant> FetchData()
        {
            var client = new RestClient("http://public.je-apis.com/");
            IRestRequest request = new RestRequest("restaurants?q=SE19");
            request.AddHeader("Accept-Language", "en-GB");
            request.AddHeader("Authorization", "Basic VGVjaFRlc3Q6bkQ2NGxXVnZreDVw");
            var response = client.Get<JeData>(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Error requesting data. Status: {response.StatusCode}, Content: {response.Content}");
            return response.Data.Restaurants;
        }
    }

    public class JeData
    {
        public List<Restaurant> Restaurants { get; set; }
    }

    public class Restaurant
    {
        public string Name { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
    }

    public class CuisineType
    {
        public string Name { get; set; }
    }
}
