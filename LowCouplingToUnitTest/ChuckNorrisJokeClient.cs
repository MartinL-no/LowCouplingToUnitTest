using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace LowCouplingToUnitTest
{
    public class ChuckNorrisJokeClient : IClient
    {
        private readonly RestClient _client;

        public ChuckNorrisJokeClient()
        {
            _client = new RestClient("https://api.chucknorris.io");
        }

        public async Task<List<string>> GetResult(string word)
        {
            if (word == null)
            {
                throw new NullReferenceException();
            }

            var request = new RestRequest($"/jokes/search?query={word}", DataFormat.Json);
            var result = await _client.GetAsync<ChuckNorrisJokeSearchResultSet>(request);
            return result.result.Select(j => j.value).ToList();
        }
    }
}