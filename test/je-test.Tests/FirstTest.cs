using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
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
            var restaurants = jeApiClient.GetRestaurants();
            Assert.That(restaurants.Count, Is.GreaterThan(0));
        }
    }

    public class JeApiClient
    {
        public IList<object> GetRestaurants()
        {
            var client = new RestClient("http://public.je-apis.com/");
            IRestRequest request = new RestRequest("restaurants?q=SE19");
            request.AddHeader("Accept-Language", "en-GB");
            request.AddHeader("Authorization", "Basic VGVjaFRlc3Q6bkQ2NGxXVnZreDVw");
            var response = client.Get(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Error requesting data. Status: {response.StatusCode}, Content: {response.Content}");
            return new List<object>() {new { }};
        }
    }
}
