using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FizzBuzzGame
{
    class Program
    {
        private static readonly Dictionary<int, string> Cheatsheet = File.ReadAllLines("prediction.txt").Select(l =>
        {
            var data = l.Split(':');
            return new KeyValuePair<int, string>(int.Parse(data[0]),data[1]);
        }).ToDictionary(kv => kv.Key, kv => kv.Value.Trim());

        public static bool IsCorrect((int Input,string Output) result)
        {
            if (!Cheatsheet.ContainsKey(result.Input)) return false;
            return string.Equals(result.Output, Cheatsheet[result.Input], StringComparison.CurrentCultureIgnoreCase);
                
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
                //Example of wierd tests:
                //i => i.ToString().Contains("7") ? "Woof":""
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
                Print(results[i].Item2, IsCorrect(results[i]) ? ConsoleColor.Green : ConsoleColor.Red);
            }
        }

        static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
