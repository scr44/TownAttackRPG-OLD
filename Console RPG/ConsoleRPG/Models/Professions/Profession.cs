using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Professions
{
    public class Profession
    {
        public Profession()
        {

        }

        public string Title { get; protected set; }
        public string ProfessionSummary { get; protected set; }
        public string Gender { get; protected set; }
        public int BaseHealth { get; protected set; }
        public int BaseStamina { get; protected set; }
        public BaseAttributes StartingAttributes { get; protected set; }
        public BaseTalents StartingTalents { get; protected set; }
        public Inventory StartingInventory { get; protected set; }
        public EquippedItems StartingEquipment { get; protected set; }
    }
}
