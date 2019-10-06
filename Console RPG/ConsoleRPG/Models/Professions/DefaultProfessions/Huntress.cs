using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Elixir;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;

namespace ConsoleRPG.Models.Professions.DefaultProfessions
{
    public class Huntress : Profession
    {
        public Huntress(string gender="F")
        {
            Title = "Huntress";
            Gender = GetGender(gender);
            if (gender == "Male")
            {
                Title = "Hunter";
            }
            ProfessionSummary = $"A dangerous {(gender == "female" ? "huntress" : "hunter")} from the wildling " +
                $"tribes. Knows how to hunt nearly any creature, but has no social graces.";
            BaseHealth = 20;
            BaseStamina = 20;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 4 },
                { "DEX", 8 },
                { "SKL", 7 },
                { "APT", 5 },
                { "FOR", 4 },
                { "CHA", 1 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Explosives", 0 },
                { "Veterancy", 0 },
                { "Bestiary", 3 },
                { "Engineering", 0 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {

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
