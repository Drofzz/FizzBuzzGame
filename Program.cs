using System;
using System.IO;

namespace FizzBuzzGame
{
    class Program
    {
        static string[] cheatsheet = File.ReadAllLines("prediction.txt");
        static void Main(string[] args)
        {

            for (int i = 1; i <= 100; i++)
            {

                var result = "";

                var fizz = (i % 3 == 0);
                var buzz = (i % 5 == 0);
                var woof = (i % 7 == 0);

                if (fizz || buzz || woof) result
               = (fizz == true ? "Fizz" : "")
               + (buzz ? "Buzz" : "")
               + (woof ? "Woof" : "");
                else result = i.ToString();

                if (!IsCorrect(result, i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result);
                    Console.ResetColor();
                }

            }
        }

        static public bool IsCorrect(string result, int number)
        {
            var line = cheatsheet.GetValue(number).ToString().Split(':');
            return result.ToUpper() == line[1].Trim().ToUpper();
        }

    }
}
