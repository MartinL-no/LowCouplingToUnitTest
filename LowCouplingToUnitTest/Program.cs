using System;
using System.Threading.Tasks;

namespace LowCouplingToUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var generator = new JokeGenerator();
            while (true)
            {
                Console.Write("Hvilken bokstav du at vitsene skal begynne på? ");
                var  word = Console.ReadLine();
                var joke = await generator.GetJokeWithWordTwoTimes(word);
                Console.WriteLine(joke ?? $"Fant ingen vitser med ordet \"{word}\" to ganger.");
            }
        }
    }
}
