using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using ConsoleRPG.Models.Menus.Startup;
using ConsoleRPG.Models.Menus;

namespace ConsoleRPG 
{

    class Program
    {
        static void Main(string[] args)
        {
            new Game().Start();
        }
    }

}
