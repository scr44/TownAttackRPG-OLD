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
    public class PlagueDoctor : Profession
    {
        public PlagueDoctor(string gender = "F")
        {
            Title = "Plague Doctor";
            Gender = GetGender(gender);
            ProfessionSummary = "This traveling surgeon wears an unsettling beak-shaped mask and " +
                "goggles. Her cures are of dubious merit, but the efficacy of her poisons is inarguable.";
            BaseHealth = 20;
            BaseStamina = 20;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 4 },
                { "DEX", 3 },
                { "SKL", 6 },
                { "APT", 5 },
                { "FOR", 6 },
                { "CHA", 2 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 3 },
                { "Explosives", 0 },
                { "Veterancy", 0 },
                { "Bestiary", 2 },
                { "Engineering", 0 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 900 },
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
