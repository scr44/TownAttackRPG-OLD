using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Characters.Stats;
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
    public class Scholar : Profession
    {
        public Scholar(string gender = "M")
        {
            Title = "Scholar";
            Gender = GetGender(gender);
            ProfessionSummary = "The scholar is a quick learner and widely knowledgeable, but spends more" +
                "time reading books than on physical pursuits.";
            BaseHealth = 20;
            BaseStamina = 15;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 2 },
                { "DEX", 2 },
                { "SKL", 3 },
                { "APT", 9 },
                { "FOR", 2 },
                { "CHA", 3 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 1 },
                { "Explosives", 0 },
                { "Veterancy", 0 },
                { "Bestiary", 1 },
                { "Engineering", 1 },
                { "History", 2 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 400 },
                { new Diploma(), 1 }
            };
            StartingEquipmentDict = new Dictionary<string, Items.Equipment.EquipmentItem>()
            {
                { "MainHand", new BareHand() },
                { "OffHand", new HistoryTome() },
                { "Body", new Clothing() },
                { "Charm 1", new QuillAndInkwell() },
                { "Charm 2", new Unadorned() }
            };
        }
    }
}
