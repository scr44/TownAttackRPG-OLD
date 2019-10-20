using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Actors.SkillCollections;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Skills;
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

        #region Tags
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
        #endregion

        #region Profession Stats
        public string ProfessionSummary { get; protected set; }
        public int BaseHealth { get; protected set; }
        public int BaseStamina { get; protected set; }
        public double BaseStaminaRegen { get; protected set; }
        #endregion

        #region Initalizers
        public Dictionary<string, int> StartingAttributesDict { get; protected set; } =
            new Dictionary<string, int>()
            {
                { "STR", 5 },
                { "DEX", 5 },
                { "SKL", 5 },
                { "APT", 5 },
                { "FOR", 5 },
                { "CHA", 5 }
            };
        public Dictionary<string, int> StartingTalentsDict { get; protected set; } =
        new Dictionary<string, int>()
        {
            { "Medicine", 0 },
            { "Explosives", 0 },
            { "Veterancy", 0 },
            { "Bestiary", 0 },
            { "Engineering", 0 },
            { "History", 0 }
        };
        public Dictionary<Item, int> StartingInventoryDict { get; protected set; } =
            new Dictionary<Item, int>()
            {

            };
        public Dictionary<string, EquipmentItem> StartingEquipmentDict { get; protected set; } =
            new Dictionary<string, EquipmentItem>()
            {
                { "MainHand", new BareHand() },
                { "OffHand", new TwoHanding() },
                { "Body", new Naked() },
                { "Charm 1", new Unadorned() },
                { "Charm 2", new Unadorned() }
            };
        public List<Skill> StartingSkills = new List<Skill>(6) { null, null, null, null, null, null };
        #endregion
    }
}
