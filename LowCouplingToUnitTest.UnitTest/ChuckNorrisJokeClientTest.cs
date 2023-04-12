using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LowCouplingToUnitTest.UnitTest
{
    public class ChuckNorrisJokeClientTest
    {
        [Test]
        public async Task NullTest()
        {
            var chuckNorrisJokeClient = new ChuckNorrisJokeClient();

            AsyncTestDelegate act = () => chuckNorrisJokeClient.GetResult(null);

            Assert.That(act, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public async Task ChuckNorrisJokeClientTestOne()
        {
            var chuckNorrisJokeClient = new ChuckNorrisJokeClient();
            var expectedJoke = "Chuck Norris once whent to pizzahut. He ordered an eggroll with some swiss cheese. A rotten cow corpse.A dead president.And a large box with Hellfire missiles. Pizza hut served it on a big tuna fish pizza. Chuck Norris Roundhousekicked the whole place to oblivion making everyone inside suffer terrible pain for eternity. Chuck Norris did not order any pizza.";

            var jokes = await chuckNorrisJokeClient.GetResult("pizza");
            var includesExpectedJoke = jokes.Exists(j => j == expectedJoke);

            Assert.That(jokes, Is.Not.Null);
            Assert.That(jokes, Is.TypeOf(typeof(List<string>)));
            Assert.That(jokes.Count, Is.GreaterThanOrEqualTo(1));
            Assert.IsTrue(includesExpectedJoke);
        }
    }
}