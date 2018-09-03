using System.Collections.Generic;

namespace FizzBuzzGame
{
    class FizzBuzzStatic : IFizzBuzzGame
    {
        public IEnumerable<string> GetFizzBuzz()
        {
            for (var i = 1; i <= 100; i++)
            {

                var result = "";

                var fizz = (i % 3 == 0);
                var buzz = (i % 5 == 0);
                var woof = (i % 7 == 0);

                if (fizz || buzz || woof) result
                    = (fizz ? "Fizz" : "")
                      + (buzz ? "Buzz" : "")
                      + (woof ? "Woof" : "");
                else result = i.ToString();

                yield return result;

            }
        }
    }
}