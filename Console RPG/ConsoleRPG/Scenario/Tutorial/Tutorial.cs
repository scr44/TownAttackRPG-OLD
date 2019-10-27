using ConsoleRPG.Menus.Combat;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Party;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using ConsoleRPG.Scenario.Tutorial.Combat;
using ConsoleRPG.Scenario.Tutorial.Dialogue;
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
            Tutorial_Combat_01_TrainingDummy = new Tutorial_Combat_01_TrainingDummy(Party);
        }
        Character PC { get; }
        Party Party { get; set; } = new Party();
        CombatUI CombatUI { get; set; } = null;

        #region Modules
        Tutorial_Welcome_01 Tutorial_Welcome_01 { get; set; } = new Tutorial_Welcome_01();
        Tutorial_Combat_01_TrainingDummy Tutorial_Combat_01_TrainingDummy { get; set; } 
        #endregion

        public void RunScenario()
        {
            string Module = "Tutorial_Welcome_01";
            while (true)
            {
                switch(Module)
                {
                    case "Tutorial_Welcome_01":
                        Tutorial_Welcome_01.Run();
                        Module = "Tutorial_Combat_01_TrainingDummy";
                        break;
                    case "Tutorial_Combat_01_TrainingDummy":
                        Tutorial_Combat_01_TrainingDummy.Run();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
