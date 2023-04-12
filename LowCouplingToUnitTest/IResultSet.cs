using System.Collections.Generic;

namespace LowCouplingToUnitTest
{
    public interface IResultSet
    {
        public List<Joke> result { get; set; }
    }
}