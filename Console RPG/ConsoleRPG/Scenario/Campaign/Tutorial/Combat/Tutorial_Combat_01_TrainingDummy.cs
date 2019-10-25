using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Enemies;
using ConsoleRPG.Models.Actors.Enemies.Unaffiliated;
using ConsoleRPG.Models.Party;

namespace ConsoleRPG.Scenario.Campaign.Tutorial.Combat
{
    public class Tutorial_Combat_01_TrainingDummy : CombatEvent
    {
        public Tutorial_Combat_01_TrainingDummy(Party playerParty) : base(playerParty)
        {
            EnemyParty = new List<Actor>()
            {
                new TrainingDummy(100, 0, 0),

                new TrainingDummy(100, 0, 0),

                new TrainingDummy(100, 0, 0),
            };
            CombatUI.SetTargetList(EnemyParty);
        }

        override public void Run()
        {
            CombatUI.Display();
            Say("This is the combat menu.");
            Pause();
            Say("Attack!", EnemyParty[0]);
            Pause();
            Say("You'll need to defend yourself. Try using your first skill, Double Strike,");
            Say("by pressing the appropriate button.");
            Pause();
        }
    }
}
