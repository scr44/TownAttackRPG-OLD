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
    public class Barmaid : Profession
    {
        public Barmaid(string gender = "F")
        {
            Title = "Barmaid";
            Gender = GetGender(gender);
            if(gender == "Male")
            {
                Title = "Barkeep";
            }
            ProfessionSummary = $"The charming {(gender == "female" ? "young barmaid" : "barkeep")} from the local tavern. Strong and fast, with " +
                "a seemingly endless supply of drink, but no combat training.";
            BaseHealth = 40;
            BaseStamina = 20;
            BaseStaminaRegen = 15.0;
            StartingAttributesDict = new Dictionary<string, int>()
            {
                { "STR", 7 },
                { "DEX", 6 },
                { "SKL", 1 },
                { "APT", 4 },
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
                { "History", 0 }
            };
            StartingInventoryDict = new Dictionary<Item, int>()
            {
                { new Coins(), 250 },
                { new BottomlessBeerMug(), 1 }
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
