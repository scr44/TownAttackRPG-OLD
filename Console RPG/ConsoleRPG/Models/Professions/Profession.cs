using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Professions
{
    abstract public class Profession
    {
        public Profession()
        {
            
        }

        public string Title { get; protected set; }
        public string Gender { get; protected set; }
        public string GetGender(string gender)
        {
            gender = gender.ToLower();
            if (gender == "male" || gender == "m")
            {
                Gender = "Male";
            }
            else if (gender == "female" || gender == "f")
            {
                Gender = "Female";
            }
            else
            {
                Gender = "Unknown";
            }
            return Gender;
        }
        public string ProfessionSummary { get; protected set; }
        public int BaseHealth { get; protected set; }
        public int BaseStamina { get; protected set; }
        public Dictionary<string, int> StartingAttributesDict { get; protected set; }
        public Dictionary<string, int> StartingTalentsDict { get; protected set; }
        public Dictionary<Item, int> StartingInventoryDict { get; protected set; }
        public Dictionary<string, EquipmentItem> StartingEquipmentDict { get; protected set; }
    }
}
