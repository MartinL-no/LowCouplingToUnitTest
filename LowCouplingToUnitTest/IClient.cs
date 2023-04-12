using System;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest
{
    public interface IClient
    {
        public Task<IResultSet> GetResult(string word);
    }
}