using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Professions.Default_Professions;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRPG 
{

    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int>() { 0, 1, 2, 3, 4, 5 };

            IEnumerable<int> selection =
                from values in testList
                where values < 2
                select values;

            

            selection.Select(x => x = 10);

            foreach(int x in selection)
            {
                Console.WriteLine(x);
            }

            Console.ReadLine();
        }
    }

}
