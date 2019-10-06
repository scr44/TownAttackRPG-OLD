using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;

namespace ConsoleRPG.Models.Professions.DefaultProfessions
{
    public class Noble : Profession
    {
        public Noble(string gender = "F")
        {
            Title = "Noble";
            Gender = GetGender(gender);
            if(Gender == "Male")
            {
                Title = "Nobleman";
            }
            else if(Gender == "Female")
            {
                Title = "Noblewoman";
            }
            ProfessionSummary = "Wealthy and fashionable, a member of the noble class well-educated in " +
                "the art of oration. Has some training as a duelist, but has never been in a real fight.";
            BaseHealth = 20;
            BaseStamina = 10;
            BaseStaminaRegen = 10.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 3 },
                { "DEX", 5 },
                { "SKL", 7 },
                { "APT", 5 },
                { "FOR", 3 },
                { "CHA", 8 }
            };
            StartingTalentsDict = new Dictionary<string, int>()
            {
                { "Medicine", 0 },
                { "Explosives", 0 },
                { "Veterancy", 0 },
                { "Bestiary", 0 },
                { "Engineering", 0 },
                { "History", 2 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 3000 },
            };
            StartingEquipmentDict = new Dictionary<string, Items.Equipment.EquipmentItem>()
            {
                { "MainHand", new Rapier() },
                { "OffHand", new BareHand() },
                { "Body", new FancyClothing() },
                { "Charm 1", new LadybugBrooch() },
                { "Charm 2", new HeirloomRing() }
            };
        }
    }
}
