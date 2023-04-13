using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace LowCouplingToUnitTest.UnitTest
{
    public class JokeGeneratorTest
    {
        [Test]
        public void NullConstructorTest()
        {
            var jokeGenerator = new JokeGenerator(null);

            AsyncTestDelegate act = () => jokeGenerator.GetJoke(null);

            Assert.That(act, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public async Task JokeGeneratorTestWithOneJoke()
        {
            var word = "pizza";
            var expectedJoke = "Chuck Norris once whent to pizzahut. He ordered an eggroll with some swiss cheese. A rotten cow corpse.A dead president.And a large box with Hellfire missiles. Pizza hut served it on a big tuna fish pizza. Chuck Norris Roundhousekicked the whole place to oblivion making everyone inside suffer terrible pain for eternity. Chuck Norris did not order any pizza.";
            var dummyClient = new DummyClient(expectedJoke);
            var jokeGenerator = new JokeGenerator(dummyClient);

            var joke = await jokeGenerator.GetJoke(word);

            Assert.That(joke, Is.Not.Null);
            Assert.That(joke, Is.TypeOf(typeof(string)));
            Assert.That(joke, Is.EqualTo(expectedJoke));
        }

        [Test]
        public async Task JokeGeneratorTestWithTwoJokes()
        {
            var word = "pizza";
            var expectedJoke = "Chuck Norris once whent to pizzahut. He ordered an eggroll with some swiss cheese. A rotten cow corpse.A dead president.And a large box with Hellfire missiles. Pizza hut served it on a big tuna fish pizza. Chuck Norris Roundhousekicked the whole place to oblivion making everyone inside suffer terrible pain for eternity. Chuck Norris did not order any pizza.";
            var wrongJoke = $"Joke where {word} is used once";
            var dummyClient = new DummyClient(expectedJoke, wrongJoke);
            var jokeGenerator = new JokeGenerator(dummyClient);

            var joke = await jokeGenerator.GetJoke(word);

            Assert.That(joke, Is.EqualTo(expectedJoke));
            Assert.That(joke, Is.Not.EqualTo(wrongJoke));
        }

        [Test]
        public async Task JokeGeneratorTestOneJokeWithMoq()
        {
            var word = "pizza";
            var expectedJoke = "Chuck Norris once whent to pizzahut. He ordered an eggroll with some swiss cheese. A rotten cow corpse.A dead president.And a large box with Hellfire missiles. Pizza hut served it on a big tuna fish pizza. Chuck Norris Roundhousekicked the whole place to oblivion making everyone inside suffer terrible pain for eternity. Chuck Norris did not order any pizza.";
            var expectedListReturned = new List<string>
            {
                expectedJoke
            };
            var clientMock = new Mock<IClient>();
            clientMock
                .Setup(c => c.GetResult(It.IsAny<string>()))
                .ReturnsAsync(expectedListReturned);
            var jokeGenerator = new JokeGenerator(clientMock.Object);

            var joke = await jokeGenerator.GetJoke(word);

            Assert.That(joke, Is.Not.Null);
            Assert.That(joke, Is.TypeOf(typeof(string)));
            Assert.That(joke, Is.EqualTo(expectedJoke));
        }

        [Test]
        public async Task JokeGeneratorTestTwoJokesWithMoq()
        {
            var word = "pizza";
            var expectedJoke = "Chuck Norris once whent to pizzahut. He ordered an eggroll with some swiss cheese. A rotten cow corpse.A dead president.And a large box with Hellfire missiles. Pizza hut served it on a big tuna fish pizza. Chuck Norris Roundhousekicked the whole place to oblivion making everyone inside suffer terrible pain for eternity. Chuck Norris did not order any pizza.";
            var wrongJoke = $"Joke where {word} is used once";
            var expectedListReturned = new List<string>
            {
                expectedJoke,
                wrongJoke
            };
            var clientMock = new Mock<IClient>();
            clientMock
                .Setup(c => c.GetResult(It.IsAny<string>()))
                .ReturnsAsync(expectedListReturned);
            var jokeGenerator = new JokeGenerator(clientMock.Object);

            var joke = await jokeGenerator.GetJoke(word);

            Assert.That(joke, Is.EqualTo(expectedJoke));
            Assert.That(joke, Is.Not.EqualTo(wrongJoke));
        }
    }
}