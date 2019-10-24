using ConsoleRPG.Menus.Combat;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Party;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Scenario.Campaign.Tutorial
{
    public class Tutorial
    {
        public Tutorial()
        {
            PC = new Character("Guinevere", new Knight("F"));
            Party.AddPartyMember((Actor)PC);
            CombatUI = new CombatUI(PC);
        }
        Character PC { get; }
        Party Party { get; set; } = new Party();
        CombatUI CombatUI { get; set; } = null;

        public void RunScenario()
        {
            string Module = "Welcome_01";
            while (true)
            {
                switch(Module)
                {
                    case "Welcome_01":
                        Tutorial_Welcome_01.Run();
                        Module = "Combat_01_TrainingDummy";
                        break;
                    case "Combat_01_TrainingDummy":
                        CombatUI.Display();
                        Console.ReadKey();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
