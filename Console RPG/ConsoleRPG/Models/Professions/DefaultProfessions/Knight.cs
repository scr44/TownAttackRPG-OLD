using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Professions.DefaultProfessions
{
    public class Knight : Profession
    {
        public Knight(string gender="M")
        {
            Title = "Knight";
            Gender = GetGender(gender);
            ProfessionSummary = "Knights are masters of the longsword clad in sturdy plate armor; but " +
                "they often neglect their academic studies in favor of drinking and skirt-chasing.";
            BaseHealth = 20;
            BaseStamina = 20;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 6 },
                { "DEX", 6 },
                { "SKL", 6 },
                { "APT", 2 },
                { "FOR", 5 },
                { "CHA", 4 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Herbalism", 0 },
                { "Explosives", 0 },
                { "Veterancy", 2 },
                { "Bestiary", 0 },
                { "Engineering", 0 },
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 800 },
                { new Memento(), 1 }
            };
            StartingEquipmentDict = new Dictionary<string, Items.Equipment.EquipmentItem>()
            {
                { "MainHand", new Longsword() },
                { "OffHand", new TwoHanding() },
                { "Body", new PlateArmor() },
                { "Charm 1", new LoversLocket() },
                { "Charm 2", new Unadorned() }
            };
        }
    }
}
