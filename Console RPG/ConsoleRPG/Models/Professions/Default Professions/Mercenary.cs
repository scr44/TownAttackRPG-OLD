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

namespace ConsoleRPG.Models.Professions.Default_Professions
{
    public class Mercenary : Profession
    {
        public Mercenary(string gender="F")
        {
            Title = "Mercenary";
            Gender = GetGender(gender);
            ProfessionSummary = "Mercenaries are masters of the longsword; but constant concussions and old wounds have damaged their senses, and their social graces are lacking.";
            BaseHealth = 20;
            BaseStamina = 20;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 6 },
                { "DEX", 6 },
                { "SKL", 7 },
                { "APT", 4 },
                { "FOR", 2 },
                { "CHA", 3 }
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
                { "Body", new HalfPlate() },
                { "Charm 1", new LoversLocket() },
                { "Charm 2", new Unadorned() }
            };
        }
    }
}
