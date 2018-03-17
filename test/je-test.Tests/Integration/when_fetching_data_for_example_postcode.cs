using JeRestaurantService;
using NUnit.Framework;

namespace je_test.Tests.Integration
{
    public class when_fetching_data_for_example_postcode
    {        
        private JeData _restaurantData;
        private const string APostCode = "SE19";

        [OneTimeSetUp]
        public void Setup()
        {
            var jeApiClient = new JeApiClient();
            _restaurantData = jeApiClient.GetRestaurantsFor(APostCode);
        }

        [Test]
        public void data_includes_some_restaunts()
        {
            Assert.That(_restaurantData.Restaurants.Count, Is.GreaterThan(0));
        }

        [Test]
        public void data_includes_name_of_a_sample_restaurant()
        {
            Assert.That(_restaurantData.Restaurants[0].Name, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void data_includes_some_cuisine_types_for_the_sample_restaurant()
        {
            Assert.That(_restaurantData.Restaurants[0].CuisineTypes.Count, Is.GreaterThan(0));
        }

        [Test]
        public void data_includes_name_of_a_sample_cuisine_type_for_the_sample_restaurant()
        {
            Assert.That(_restaurantData.Restaurants[0].CuisineTypes[0].Name, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void data_includes_rating_average_of_the_sample_restaurant()
        {
            Assert.That(_restaurantData.Restaurants[0].RatingAverage, Is.Not.Null.Or.Empty);
        }
    }
}