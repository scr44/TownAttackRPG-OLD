using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;

namespace ConsoleRPG.Models.Professions.DefaultProfessions
{
    public class Constable : Profession
    {
        public Constable(string gender = "M")
        {
            Title = "Constable";
            Gender = GetGender(gender);
            ProfessionSummary = "The town's venerable lawman. Knows his way around locks and is " +
                "well-versed in breaking up brawls. This stiffness of age is beginning to set in.";
            BaseHealth = 20;
            BaseStamina = 20;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 6 },
                { "DEX", 3 },
                { "SKL", 6 },
                { "APT", 4 },
                { "FOR", 5 },
                { "CHA", 5 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Explosives", 0 },
                { "Veterancy", 1 },
                { "Bestiary", 0 },
                { "Engineering", 1 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 1000 },
            };
            StartingEquipmentDict = new Dictionary<string, Items.Equipment.EquipmentItem>()
            {
                { "MainHand", new BareHand() },
                { "OffHand", new BareHand() },
                { "Body", new Naked() },
                { "Charm 1", new Unadorned() },
                { "Charm 2", new Unadorned() }
            };
        }
    }
}
