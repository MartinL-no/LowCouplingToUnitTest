using System.Collections.Generic;

namespace LowCouplingToUnitTest.UnitTest
{
    internal class DummyResultSet : IResultSet
    {
        public List<Joke> result { get; set; }

        public DummyResultSet()
        {
            result = new List<Joke>();
        }
    }
}