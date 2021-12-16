using System;
using System.IO;
using System.Collections.Generic;

namespace RockPaperScissorsApp.App
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to RockPaperScissors App");
            var game = new Game();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Play a round? (y/n) ");

                string? input = Console.ReadLine();

                if (input != "y") { break; }

                game.PlayRound();
            }

        }
    }
}
