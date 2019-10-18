using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Characters
{
    [TestClass]
    public class CharacterCreation
    {
        // Create a female Knight named Guinevere
        public Character Guinevere = new Character("Guinevere", new Knight("F"));
        // Create a male Knight named Valerian
        public Character Valerian = new Character("Valerian", new Knight("M"));

        [TestMethod]
        public void HasGivenName()
        {
            Assert.AreEqual(Guinevere.Name, "Guinevere");
            Assert.AreEqual(Valerian.Name, "Valerian");
        }
        [TestMethod]
        public void HasGivenGender()
        {
            Assert.AreEqual(Guinevere.Gender, "Female");
            Assert.AreEqual(Valerian.Gender, "Male");
        }
        [TestMethod]
        public void IsGivenProfession()
        {
            Assert.AreEqual(Guinevere.Profession is Knight, true);
            Assert.AreEqual(Valerian.Profession is Knight, true);
        }
        [TestMethod]
        public void HasStartingStats()
        {
            CollectionAssert.AreEqual(Guinevere.Attributes.BaseValue, new Knight().StartingAttributesDict, 
                "Character should construct with Profession's starting attributes.");
            CollectionAssert.AreEqual(Guinevere.Talents.BaseValue, new Knight().StartingTalentsDict, 
                "Character should construct with Profession's starting talents.");

            Assert.AreEqual(Guinevere.HP.Base, new Knight().BaseHealth,
                "Character should have their profession's base health.");
            Assert.AreEqual(Guinevere.SP.Base, new Knight().BaseStamina,
                "Character should have their profession's base stamina.");
        }
        [TestMethod]
        public void HasStartingInventory()
        {
            Dictionary<string, Item> characterContents = Guinevere.Inventory.InventoryContents;
            Dictionary<string, int> characterCounts = Guinevere.Inventory.InventoryCounts;

            Dictionary<Item, int> synthesizedInventory = new Dictionary<Item, int>();

            foreach(KeyValuePair<string, Item> item in characterContents)
            {
                synthesizedInventory.Add(item.Value, characterCounts[item.Key]);
            }

            Dictionary<Item, int> defaultInventory = new Knight().StartingInventoryDict;

            Assert.AreEqual(synthesizedInventory.ToString(), defaultInventory.ToString(),
                "The two Character inventory types should contain the data from the profession's default inventory.");
        }
        [TestMethod]
        public void HasStartingEquipment()
        {
            // Get merc character's equipped gear
            Dictionary<string, EquipmentItem> charEquipment = Guinevere.Equipment.Slot;
            // Get Knight profession's default equipped gear
            Dictionary<string, EquipmentItem> defaultEquipment = new Knight("M").StartingEquipmentDict;
            Assert.AreEqual(charEquipment.ToString(), defaultEquipment.ToString(), "New character's gear should match their profession's starting gear.");
        }
    }
    [TestClass]
    public class InventoryBehavior
    {
        [TestMethod]
        public void AddingItems()
        {
            // generate new empty inventory
            Inventory inventory = new Inventory();

            Assert.IsTrue(inventory.InventoryCounts.Values.Count == 0, "Brand-new inventory should have 0 items.");

            for (int i = 0; i < 5; i++)
            {
                inventory.AddItem(new Longsword());
            }

            Assert.IsTrue(inventory.InventoryContents.Count == 1, "Inventory should only have one actual Longsword object stored.");
            Assert.IsTrue(inventory.InventoryCounts["Longsword"] == 5, "Inventory should know it has 5 longswords available to dispense.");

        }
        [TestMethod]
        public void RemovingItems()
        {
            // generate new inventory with 5000 coins in it.
            Dictionary<Item, int> init = new Dictionary<Item, int>()
            {
                { new Coins(), 5000 }
            };
            Inventory inventory = new Inventory(init);

            Assert.IsTrue(inventory.InventoryContents.Count == 1,
                "Inventory should only contain one actual Coins object");
            Assert.IsTrue(inventory.InventoryCounts["Coins"] == 5000,
                "Inventory should have 5000 coins available");

            // spend 2500 coins
            inventory.RemoveItem("Coins", 2500);

            Assert.IsTrue(inventory.InventoryContents.Count == 1,
                "Inventory should only contain one actual Coins object");
            Assert.IsTrue(inventory.InventoryCounts["Coins"] == 2500,
                "Inventory should have 2500 coins available");
        }

        public Character Guinevere = new Character("Guinevere", new Knight("F"));

        [TestMethod]
        public void CharacterRemovesItem()
        {
            Assert.IsTrue(Guinevere.Inventory.InventoryContents.ContainsKey("Memento"),
                "Knights should start with a Memento in their inventories.");
            Guinevere.Inventory.RemoveItem("Memento");
            Assert.IsFalse(Guinevere.Inventory.InventoryContents.ContainsKey("Memento"),
                "The Memento should be removed.");
        }
        [TestMethod]
        public void CharacterAddsItem()
        {
            Guinevere.Inventory.AddItem(new Memento());
            Assert.IsTrue(Guinevere.Inventory.InventoryContents.ContainsKey("Memento"),
                "A new Memento should be added to the character's inventory.");
        }
        [TestMethod]
        public void WeightCapacityScaling()
        {
            Assert.AreEqual(Guinevere.Inventory.WeightCapacity, 7 * 15,
                "Weight capacity should equal 15 times strength when STR <= 10.");
            Guinevere.Attributes.ChangeAttribute("STR", 3);
            Assert.AreEqual(Guinevere.Inventory.WeightCapacity, 10 * 15,
                "Weight capacity should equal 15 times strength when STR <= 10.");
            Guinevere.Attributes.ChangeAttribute("STR", 10);
            Assert.AreEqual(Guinevere.Inventory.WeightCapacity, 10 * 15 + 10 * 5,
                "When STR > 10, scaling bonus per point falls to 5.");
        }
        [TestMethod]
        public void CharacterOverburdened()
        {
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            Guinevere.Inventory.AddItem(new PlateArmor(), 5);
            Assert.IsTrue(Guinevere.Inventory.IsOverburdened,
                "Character should be overburdened when Weight > Weight Capacity.");
        }
    }
    [TestClass]
    public class EquipmentBehavior
    {
        [TestMethod]
        public void Toggle2HFunctionality()
        {
            // Create new Knight character (starts with 2H)
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is TwoHanding, 
                "Knight Character should begin with primary weapon Two-handed");

            Guinevere.Equipment.Toggle2H();

            Assert.IsFalse(Guinevere.Equipment.Slot["OffHand"] is TwoHanding,
                "Upon 2H toggle off, Character should no longer be two-handing their weapon.");
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is BareHand, 
                "Upon 2H toggle off, Character's offhand should be empty.");

            Guinevere.Equipment.Toggle2H();

            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is TwoHanding,
                "Upon 2H toggle on, Character should be two-handing their weapon.");
        }
        [TestMethod]
        public void Equipping()
        {
            // Create new Knight character with a longsword
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is TwoHanding,
                "Character should start off two-handing their weapon.");

            // Add a new longsword to their inventory
            Guinevere.Inventory.AddItem(new Longsword());

            // Equip the Longsword in the OffHand slot, have to cast it back out of Item
            Guinevere.Equipment.Equip("OffHand", (EquipmentItem)Guinevere.Inventory.InventoryContents["Longsword"]);
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is Longsword,
                "Character should have the longsword from their inventory equipped.");

            // Make sure the Longsword was taken from the inventory
            Assert.IsFalse(Guinevere.Inventory.InventoryContents.ContainsKey("Longsword"),
                "Longsword should be gone from character's inventory.");
            Assert.IsFalse(Guinevere.Inventory.InventoryCounts.ContainsKey("Longsword"),
                "Character's inventory should have no more Longswords.");
        }
        [TestMethod]
        public void Unequipping()
        {
            // Create new Knight character with a longsword
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            Assert.IsTrue(Guinevere.Equipment.Slot["MainHand"] is Longsword,
                "Character should start with a Longsword in their MainHand slot for this test.");

            // Unequip the longsword
            Guinevere.Equipment.Unequip("MainHand");

            Assert.IsTrue(Guinevere.Equipment.Slot["MainHand"] is BareHand
                && Guinevere.Equipment.Slot["OffHand"] is BareHand,
                "When 2H weapon is unequipped, both hands should be bare handed.");

            // Confirm that a single longsword was deposited in the character's inventory
            Assert.IsTrue(Guinevere.Inventory.InventoryContents.ContainsKey("Longsword"),
                "Character should have a longsword in their inventory.");

            Assert.IsTrue(Guinevere.Inventory.InventoryCounts["Longsword"] == 1,
                "Charater should have exactly 1 Longsword in their inventory.");

            
        }
        [TestMethod]
        public void BreakingAndRepairing()
        {
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            Longsword brokenSword = new Longsword();

            Guinevere.Inventory.AddItem(brokenSword);

            brokenSword.DamageEquipment(100);

            Assert.IsTrue(brokenSword.Condition == 0, 
                "Broken weapon's durability should be 0.");

            Assert.IsTrue(brokenSword.EquipmentTags.Contains("Broken"),
                "Equipment item should have the broken keyword.");

            Assert.IsFalse(Guinevere.Equipment.Equip("OffHand", brokenSword),
                "Broken gear should not be equippable.");

            brokenSword.RepairEquipment(5);

            Assert.IsFalse(brokenSword.EquipmentTags.Contains("Broken"),
                "Equipment item should no longer be broken.");

            Assert.IsTrue(Guinevere.Equipment.Equip("OffHand", brokenSword),
                "Sword should no longer be broken.");
        }
        [TestMethod]
        public void CantUseFists2H()
        {
            // Create new Knight character with a longsword
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            Guinevere.Equipment.Unequip("MainHand");

            // try to 2H bare fists
            Guinevere.Equipment.Toggle2H();
            Assert.IsFalse(Guinevere.Equipment.Is2H, 
                "Character shouldn't be able to 2H their bare fists"); // yet, anyway
        }
    }
    [TestClass]
    public class HealthAndStamina
    {
        public Character Guinevere = new Character("Guinevere", new Knight("F"));

        [TestMethod]
        public void HPLoss()
        {
            Assert.AreEqual(100, Guinevere.HP.Current,
                "Knight should start with 100 health from base + armor healthBonus.");

            // Take 40 health damage
            Guinevere.HP.AdjustHP(-40);

            Assert.AreEqual(60, Guinevere.HP.Current,
                "Character should have 60 HP left.");
            Assert.AreEqual(60, Guinevere.HP.Percent,
                "Character should have 60% HP left.");
        }
        [TestMethod]
        public void HPRestore()
        {
            Guinevere.HP.AdjustHP(-40);
            Guinevere.HP.AdjustHP(30);

            Assert.AreEqual(90, Guinevere.HP.Current,
                "Character should have 90 HP.");

            Guinevere.HP.AdjustHP(500);

            Assert.AreEqual(100, Guinevere.HP.Current,
                "Character HP should not exceed MaxHP.");

            Guinevere.HP.AdjustBaseRegen(5);
            Guinevere.HP.AdjustHP(-99);
            Guinevere.HP.RegenTick();

            Assert.AreEqual(6, Guinevere.HP.Current,
                "Character should regenerate 5 HP.");
        }
        [TestMethod]
        public void SPLoss()
        {
            Assert.AreEqual(20, Guinevere.SP.Current,
                "Knight should start with 20 SP from base stamina.");

            // Use 10 stamina
            Guinevere.SP.AdjustSP(-10);

            Assert.AreEqual(10, Guinevere.SP.Current,
                "Character should have 10 SP left.");
            Assert.AreEqual(50, Guinevere.SP.Percent,
                "Character should have 50% SP left.");

            // Use 20 stamina (not yet possible to overexhaust in gameplay)
            Guinevere.SP.AdjustSP(-20);

            Assert.AreEqual(0, Guinevere.SP.Current,
                "Character should have 0 SP left.");
        }
        [TestMethod]
        public void SPRestore()
        {
            Guinevere.SP.AdjustSP(-20);

            // SP Regeneration (per turn/tick)
            Guinevere.SP.RegenTick();

            Assert.AreEqual(10, Guinevere.SP.Current,
                "Character should have 10 SP after one regen tick.");

            // SP Restoration (potions etc)
            Guinevere.SP.AdjustSP(10);

            Assert.AreEqual(20, Guinevere.SP.Current,
                "Character should have 20 SP after restored SP.");

            Guinevere.SP.AdjustSP(400);
            Assert.AreEqual(20, Guinevere.SP.Current,
                "Character SP should not exceed MaxSP.");
        }

    }
    [TestClass]
    public class LevelAndExperience
    {
        [TestMethod]
        public void GainXP()
        {
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            // Change knight's APT to 5 (2 + 3), the base level
            Guinevere.Attributes.ChangeAttribute("APT", 3);

            Assert.AreEqual(1, Guinevere.XP.Level,
                "New character should start at lvl 1.");
            Assert.AreEqual(0, Guinevere.XP.Current,
                "New character should start with 0 XP.");

            Guinevere.XP.GainXP(50);

            Assert.AreEqual(50, Guinevere.XP.Current,
                "Character should gain 50 XP.");

            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(50, Guinevere.XP.Current,
                "Extra XP should roll over after level up.");
        }
        [TestMethod]
        public void LevelingUp()
        {
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            // Change knight's APT to 5 (2 + 3), the base level
            Guinevere.Attributes.ChangeAttribute("APT", 3);
            Guinevere.XP.GainXP(50);
            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(2, Guinevere.XP.Level,
                "Character should have leveled up to 2.");

            Assert.AreEqual(2, Guinevere.XP.AvailableAttributePts,
                "Character should have 2 Attribute points for reaching level 2.");

            Assert.AreEqual(0, Guinevere.XP.AvailableTalentPts,
                "Character should have 0 Talent points for reaching lvl 2.");

            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(3, Guinevere.XP.Level,
                "Character should be lvl 3.");

            Assert.AreEqual(3, Guinevere.XP.AvailableAttributePts,
                "Character should have 3 Attribute points for reaching level 3.");

            Assert.AreEqual(1, Guinevere.XP.AvailableTalentPts,
                "Character should have 1 Talent points for reaching lvl 3.");

            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(4, Guinevere.XP.Level,
                "Character should be lvl 4.");

            Assert.AreEqual(5, Guinevere.XP.AvailableAttributePts,
                "Character should have 5 Attribute points for reaching level 4.");

            Assert.AreEqual(1, Guinevere.XP.AvailableTalentPts,
                "Character should have 1 Talent points for reaching lvl 4.");

            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(5, Guinevere.XP.Level,
                "Character should be lvl 5.");

            Assert.AreEqual(6, Guinevere.XP.AvailableAttributePts,
                "Character should have 6 Attribute points for reaching level 5.");

            Assert.AreEqual(1, Guinevere.XP.AvailableTalentPts,
                "Character should have 1 Talent points for reaching lvl 5.");

            Guinevere.XP.GainXP(Guinevere.XP.Needed);

            Assert.AreEqual(6, Guinevere.XP.Level,
                "Character should be lvl 6.");

            Assert.AreEqual(8, Guinevere.XP.AvailableAttributePts,
                "Character should have 8 Attribute points for reaching level 6.");

            Assert.AreEqual(2, Guinevere.XP.AvailableTalentPts,
                "Character should have 2 Talent points for reaching lvl 6.");

        }
    }
    [TestClass]
    public class Miscellaneous
    {
        [TestMethod]
        public void CheckIfActorIsCharacter()
        {
            Character Guinevere = new Character("Guinevere", new Knight("F"));
            List<Actor> list = new List<Actor>();
            list.Add(Guinevere);
            Assert.IsTrue(list[0] is Actor);
            Assert.IsTrue(list[0] is Character);
        }
    }
}
