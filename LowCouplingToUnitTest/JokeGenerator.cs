using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace LowCouplingToUnitTest
{
    class JokeGenerator
    {
        public async Task<string> GetJokeWithWordTwoTimes(string word)
        {
            var client = new RestClient("https://api.chucknorris.io");
            var request = new RestRequest($"/jokes/search?query={word}", DataFormat.Json);
            var result = await client.GetAsync<ChuckNorrisJokeSearchResultSet>(request);

            foreach (var jokeObj in result.result)
            {
                var joke= jokeObj.value;
                var firstPosition = joke.IndexOf(word, StringComparison.OrdinalIgnoreCase);
                if (firstPosition == -1) continue;
                var secondPosition = joke.IndexOf(word, firstPosition + 1, StringComparison.OrdinalIgnoreCase);
                if (secondPosition != -1) return joke;
            }

            return null;
        }
    }
}
