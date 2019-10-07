using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Elixir;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;

namespace ConsoleRPG.Models.Professions.DefaultProfessions
{
    public class SecretProfession : Profession
    {
        public SecretProfession(string gender="F")
        {
            Title = "Pony";
            Gender = GetGender(gender);
            ProfessionSummary = "You've had about enough of these bandits and their horsing around.";
            BaseHealth = 100;
            BaseStamina = 40;
            BaseStaminaRegen = 20.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 8 },
                { "DEX", 8 },
                { "SKL", 1 },
                { "APT", 5 },
                { "FOR", 5 },
                { "CHA", 9 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Explosives", 0 },
                { "Veterancy", 1 },
                { "Bestiary", 3 },
                { "Engineering", 0 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 500 },
                // singed portrait
            };
            StartingEquipmentDict = new Dictionary<string, Items.Equipment.EquipmentItem>()
            {
                { "MainHand", new BareHand() }, // Hoof
                { "OffHand", new BareHand() }, // Hoof
                { "Body", new Naked() }, // Shiny Fur Coat
                { "Charm 1", new Unadorned() }, // Flower Ornament
                { "Charm 2", new Unadorned() } // Tail Bow
            };
        }
    }
}
