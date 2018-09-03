using System.Collections.Generic;

namespace FizzBuzzGame
{
    interface IFizzBuzzGame
    {
        IEnumerable<(int,string)> GetFizzBuzz();
    }
}