using NUnit.Framework;

namespace je_test.Tests
{
    public class FirstTest
    {
        [Test]
        public void add_two_numbers()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }
    }
}
