using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace je_test.Tests
{
    public class JeApiTest
    {
        [Test]
        public void can_get_data_from_just_eat()
        {
            var jeApiClient = new JeApiClient();
            var restaurants = jeApiClient.GetRestaurants();
            Assert.That(restaurants, Is.Not.Null);
        }
    }

    public class JeApiClient
    {
        public object GetRestaurants()
        {
            return new { };
        }
    }
}
