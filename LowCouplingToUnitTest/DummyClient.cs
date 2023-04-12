using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest.UnitTest
{
    public class DummyClient : IClient
    {
        private List<Joke> _jokes;

        public DummyClient(params string[] jokeStrings)
        {
            _jokes = new List<Joke>();
            foreach (var jokeString in jokeStrings)
            {
                var joke = new Joke()
                {
                    value = jokeString
                };
                _jokes.Add(joke);
            }
            
        }
        public Task<List<Joke>> GetResult(string word)
        {
            return Task.FromResult(_jokes);
        }
    }
}