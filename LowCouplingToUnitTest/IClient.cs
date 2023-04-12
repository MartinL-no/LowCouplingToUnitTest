using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest
{
    public interface IClient
    {
        public Task<List<string>> GetResult(string word);
    }
}