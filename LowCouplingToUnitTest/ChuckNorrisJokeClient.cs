using System;
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

        public async Task<IResultSet> GetResult(string word)
        {
            var request = new RestRequest($"/jokes/search?query={word}", DataFormat.Json);
            return await _client.GetAsync<ChuckNorrisJokeSearchResultSet>(request);
        }
    }
}