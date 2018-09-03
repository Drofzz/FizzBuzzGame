using System;
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
}
