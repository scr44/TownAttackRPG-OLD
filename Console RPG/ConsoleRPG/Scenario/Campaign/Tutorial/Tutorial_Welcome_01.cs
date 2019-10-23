using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Scenario.Campaign.Tutorial
{
    public class Tutorial_Welcome_01
    {
        public void Run()
        {
            Console.WriteLine(
@"   Welcome to Town Attack RPG. Let's get started by going over the controls.");
            rk();

            Console.Clear();
            Console.WriteLine(
@"   In this tutorial, you're controlling a Knight named Guinevere.");
        }

        public ConsoleKey rk()
        {
            var key = Console.ReadKey().Key;
            Console.Clear();
            return key;
        }

    }
}
