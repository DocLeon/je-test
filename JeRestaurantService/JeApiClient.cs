using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace JeRestaurantService
{
    public class JeApiClient
    {
        public JeData GetRestaurantsFor(string se19)
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
}