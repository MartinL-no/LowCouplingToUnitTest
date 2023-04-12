using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest
{
    public class JokeGenerator
    {
        private string _word;
        private IClient _client;
        private List<Joke> _jokes;

        public JokeGenerator(IClient client)
        {
            _client = client;
        }

        public async Task<string> GetJoke(string word)
        {
            _word = word;
            _jokes = await _client.GetResult(word);
            var joke = GetJokeWithWordTwoTimes();

            return joke;
        }

        private string GetJokeWithWordTwoTimes()
        {
            foreach (var jokeObj in _jokes)
            {
                var joke = jokeObj.value;
                var firstPosition = joke.IndexOf(_word, StringComparison.OrdinalIgnoreCase);
                if (firstPosition == -1) continue;
                var secondPosition = joke.IndexOf(_word, firstPosition + 1, StringComparison.OrdinalIgnoreCase);
                if (secondPosition != -1) return joke;
            }
            return null;
        }
    }
}