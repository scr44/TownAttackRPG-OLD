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
    public class Alchemist : Profession
    {
        public Alchemist(string gender="M")
        {
            Title = "Alchemist";
            Gender = GetGender(gender);
            ProfessionSummary = "Recently expelled from the university for burning down the " +
                "research hall, this pyromaniac may be more dangerous to their teammates than their enemies.";
            BaseHealth = 40;
            BaseStamina = 20;
            BaseStaminaRegen = 15.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 2 },
                { "DEX", 2 },
                { "SKL", 6 },
                { "APT", 7 },
                { "FOR", 3 },
                { "CHA", 1 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Explosives", 3 },
                { "Veterancy", 0 },
                { "Bestiary", 0 },
                { "Engineering", 2 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 500 },
                // singed portrait
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
