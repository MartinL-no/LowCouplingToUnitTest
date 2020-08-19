using System;
using System.Collections.Generic;
using System.Text;

namespace LowCouplingToUnitTest
{
    public class ChuckNorrisJokeSearchResultSet
    {
        public List<Joke> result { get; set; }
    }

    public class Joke
    {
        public string value { get; set; }
    }

}
