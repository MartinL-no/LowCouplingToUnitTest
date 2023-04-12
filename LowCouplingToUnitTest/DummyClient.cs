using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest.UnitTest
{
    public class DummyClient : IClient
    {
        private List<string> _jokes;

        public DummyClient(params string[] jokes)
        {
            _jokes = new List<string>();
            foreach (var joke in jokes)
            {
                _jokes.Add(joke);
            }
            
        }
        public Task<List<string>> GetResult(string word)
        {
            return Task.FromResult(_jokes);
        }
    }
}