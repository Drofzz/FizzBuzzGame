using System.Collections.Generic;

namespace FizzBuzzGame
{
    interface IFizzBuzzGame
    {
        IEnumerable<string> GetFizzBuzz();
    }
}