using ConsoleRPG.Models.Character;
using ConsoleRPG.Models.Character.Professions.Default_Professions;
using System;
using System.Collections.Generic;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Guinevere = new Character("Guinevere", new Mercenary());
            Console.WriteLine($"{Guinevere.Name} is a {Guinevere.Gender.ToLower()} {Guinevere.Profession.Title.ToLower()}: {Guinevere.Profession.ProfessionSummary}");
            Console.WriteLine("\nHer attributes are:");
            foreach(KeyValuePair<string,int> stat in Guinevere.BaseAttributes.Attr)
            {
                Console.WriteLine($"{stat.Key}: {Guinevere.BaseAttributes.Attr[stat.Key]}");
            }

            Console.ReadLine();
        }
    }
}
