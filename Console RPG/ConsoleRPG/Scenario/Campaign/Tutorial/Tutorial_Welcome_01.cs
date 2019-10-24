using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Scenario.Campaign.Tutorial
{
    static public class Tutorial_Welcome_01
    {
        static public void Run()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(
 "   Welcome to Town Attack RPG. Let's get started by going over the controls.\n");
            Console.WriteLine(
 "     (Press any key to continue after a text prompt)");
            Pause();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(
 "   In this tutorial, you control a Knight named Guinevere.\n");
            Pause();
            Console.WriteLine(
@"   Knights are hardy warriors, wielding longswords with both hands and wearing heavy plate armor.
    
     Let's take a look at the combat menu.
");
            Pause();
        }

        static void Pause()
        {
            ConsoleKey key = Console.ReadKey().Key;
        }

    }
}
