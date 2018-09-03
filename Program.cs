using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FizzBuzzGame
{
    class Program
    {
        private static readonly string[] Cheatsheet = File.ReadAllLines("prediction.txt");

        public static bool IsCorrect(string result, int number)
        {
            if (!(number < Cheatsheet.Length)) return false; 
            var line = Cheatsheet.GetValue(number).ToString().Split(':');
            return string.Equals(result, line[1].Trim(), StringComparison.CurrentCultureIgnoreCase);
                
        }

        static void Main(string[] args)
        {
            var game1 = new FizzBuzzDynamic(Enumerable.Range(1, 100), new[]
            {
                (3, "Fizz"),
                (5, "Buzz"),
                (7, "Woof")
            });

            var game2 = new FizzBuzzStatic();

            var game3 = new FizzBuzzDynamicUsingDelegates(Enumerable.Range(1,100),
                i => i % 3 == 0 ? "Fizz":"",
                i => i % 5 == 0 ? "Buzz":"",
                i => i % 7 == 0 ? "Woof":""
                );

            PlayFizzBuzz(game1);
            PlayFizzBuzz(game2);
            PlayFizzBuzz(game3);
        }

        public static void PlayFizzBuzz(IFizzBuzzGame game)
        {
            var results = game.GetFizzBuzz().ToList();

            for (var i = 0; i < results.Count; i++)
            {
                Print(results[i], IsCorrect(results[i], i) ? ConsoleColor.Green : ConsoleColor.Red);
            }
        }

        static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }

    interface IFizzBuzzGame
    {
        IEnumerable<string> GetFizzBuzz();
    }

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

    class FizzBuzzDynamic : IFizzBuzzGame
    {
        private readonly IEnumerable<int> _sequence;
        private readonly (int Number, string Word)[] _triggers;
        public FizzBuzzDynamic(IEnumerable<int> sequence, (int,string)[] triggers)
        {
            _sequence = sequence;
            _triggers = triggers;
        }

        public IEnumerable<string> GetFizzBuzz()
        {
            foreach (var i in _sequence)
            {
                var result = _triggers.Where(trigger => i % trigger.Number == 0).Aggregate("", (current, trigger) => current + trigger.Word);

                if (string.IsNullOrEmpty(result)) result = i.ToString();
                yield return result;
            }
        }
    }

    class FizzBuzzDynamicUsingDelegates : IFizzBuzzGame
    {
        private readonly IEnumerable<int> _sequence;
        private readonly Func<int, string>[] _passes;

        public FizzBuzzDynamicUsingDelegates(IEnumerable<int> sequence, params Func<int, string>[] passes)
        {
            _sequence = sequence;
            _passes = passes;
        }

        public IEnumerable<string> GetFizzBuzz()
        {
            foreach (var i in _sequence)
            {
                var result = _passes.Aggregate("", (current, pass) => current + pass.Invoke(i));

                if (string.IsNullOrEmpty(result)) result = i.ToString();
                yield return result;
            }
        }
    }
}
