using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Items.VendorTrash;
using ConsoleRPG.Models.Professions.Default_Professions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CRPG_Unit_Tests
{
    [TestClass]
    public class CharacterCreationTests
    {
        // Create a female mercenary named Guinevere
        public Character Guinevere = new Character("Guinevere", new Mercenary("F"));
        // Create a male mercenary named Valerian
        public Character Valerian = new Character("Valerian", new Mercenary("M"));

        [TestMethod]
        public void CharacterHasGivenName()
        {
            Assert.AreEqual(Guinevere.Name, "Guinevere");
            Assert.AreEqual(Valerian.Name, "Valerian");
        }
        [TestMethod]
        public void CharacterHasGivenGender()
        {
            Assert.AreEqual(Guinevere.Gender, "Female");
            Assert.AreEqual(Valerian.Gender, "Male");
        }
        [TestMethod]
        public void CharacterIsGivenProfession()
        {
            Assert.AreEqual(Guinevere.Profession is Mercenary, true);
            Assert.AreEqual(Valerian.Profession is Mercenary, true);
        }
        [TestMethod]
        public void CharacterHasStartingStats()
        {
            CollectionAssert.AreEqual(Guinevere.Attributes.BaseValue, new Mercenary().StartingAttributesDict, 
                "Character should construct with Profession's starting attributes.");
            CollectionAssert.AreEqual(Guinevere.Talents.BaseValue, new Mercenary().StartingTalentsDict, 
                "Character should construct with Profession's starting talents.");

            Assert.AreEqual(Guinevere.BaseHealth, new Mercenary().BaseHealth,
                "Character should have their profession's base health.");
            Assert.AreEqual(Guinevere.BaseStamina, new Mercenary().BaseStamina,
                "Character should have their profession's base stamina.");
        }
        [TestMethod]
        public void CharacterHasStartingInventory()
        {
            Dictionary<string, Item> characterContents = Guinevere.Inventory.InventoryContents;
            Dictionary<string, int> characterCounts = Guinevere.Inventory.InventoryCounts;

            Dictionary<Item, int> synthesizedInventory = new Dictionary<Item, int>();

            foreach(KeyValuePair<string, Item> item in characterContents)
            {
                synthesizedInventory.Add(item.Value, characterCounts[item.Key]);
            }

            Dictionary<Item, int> defaultInventory = new Mercenary().StartingInventoryDict;

            Assert.AreEqual(synthesizedInventory.ToString(), defaultInventory.ToString(),
                "The two Character inventory types should contain the data from the profession's default inventory.");
        }
        [TestMethod]
        public void CharacterHasStartingEquipment()
        {
            // Get merc character's equipped gear
            Dictionary<string, EquipmentItem> charEquipment = Guinevere.Equipment.Slot;
            // Get mercenary profession's default equipped gear
            Dictionary<string, EquipmentItem> defaultEquipment = new Mercenary("M").StartingEquipmentDict;
            Assert.AreEqual(charEquipment.ToString(), defaultEquipment.ToString(), "New character's gear should match their profession's starting gear.");
        }
    }
    [TestClass]
    public class InventoryTests
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
            inventory.RemoveItem(new Coins(), 2500);

            Assert.IsTrue(inventory.InventoryContents.Count == 1,
                "Inventory should only contain one actual Coins object");
            Assert.IsTrue(inventory.InventoryCounts["Coins"] == 2500,
                "Inventory should have 2500 coins available");
        }

        public Character Guinevere = new Character("Guinevere", new Mercenary("F"));

        [TestMethod]
        public void CharacterRemovesItem()
        {
            Assert.IsTrue(Guinevere.Inventory.InventoryContents.ContainsKey("Memento"),
                "Mercenaries should start with a Memento in their inventories.");
            Guinevere.Inventory.RemoveItem(new Memento());
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
            Assert.AreEqual(Guinevere.WeightCapacity, 6 * 15,
                "Weight capacity should equal 15 times strength when STR <= 10.");
            Guinevere.Attributes.ChangeAttribute("STR", 4);
            Assert.AreEqual(Guinevere.WeightCapacity, 10 * 15,
                "Weight capacity should equal 15 times strength when STR <= 10.");
            Guinevere.Attributes.ChangeAttribute("STR", 10);
            Assert.AreEqual(Guinevere.WeightCapacity, 10 * 15 + 10 * 5,
                "When STR > 10, scaling bonus per point falls to 5.");
        }
        [TestMethod]
        public void CharacterOverburdened()
        {
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            Guinevere.Inventory.AddItem(new HalfPlate(), 5);
            Assert.IsTrue(Guinevere.IsOverburdened, "Character should be overburdened when Weight > Weight Capacity.");
        }
    }
    [TestClass]
    public class EquipmentFunctions
    {
        [TestMethod]
        public void Toggle2HFunctionality()
        {
            // Create new mercenary character (starts with 2H)
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is TwoHanding, 
                "Character should begin with primary weapon Two-handed");

            Guinevere.Equipment.Toggle2H();

            Assert.IsFalse(Guinevere.Equipment.Slot["OffHand"] is TwoHanding,
                "Upon 2H toggle off, Character should no longer be two-handing their weapon.");
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is BareHand, 
                "Immediately after 2H toggled off, Character's offhand should be empty.");

            Guinevere.Equipment.Toggle2H();

            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is TwoHanding,
                "Upon 2H toggle on, Character should be two-handing their weapon.");
        }
        [TestMethod]
        public void EquippingAndUnequipping()
        {
            // Create new mercenary character with a longsword
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
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

            // try to 2H bare fists
            Guinevere.Equipment.Toggle2H();
            Assert.IsFalse(Guinevere.Equipment.Is2H, "Character shouldn't be able to 2H their bare fists"); // yet, anyway

            // Equip the Longsword in the OffHand slot, have to cast it back out of Item
            Guinevere.Equipment.Equip("OffHand", (EquipmentItem)Guinevere.Inventory.InventoryContents["Longsword"]);
            Assert.IsTrue(Guinevere.Equipment.Slot["OffHand"] is Longsword,
                "Character should have the longsword from their inventory equipped.");
            Assert.IsFalse(Guinevere.Inventory.InventoryContents.ContainsKey("Longsword"),
                "Longsword should be gone from character's inventory.");
            Assert.IsFalse(Guinevere.Inventory.InventoryCounts.ContainsKey("Longsword"),
                "Character's inventory should have no more Longswords.");

            // Swap Longsword to main hand
            Guinevere.Equipment.Unequip("OffHand");
            Guinevere.Equipment.Equip("MainHand", (EquipmentItem)Guinevere.Inventory.InventoryContents["Longsword"]);
            Assert.IsTrue(Guinevere.Equipment.Slot["MainHand"] is Longsword,
                "Character should have the longsword from their inventory equipped.");
            Assert.IsFalse(Guinevere.Inventory.InventoryContents.ContainsKey("Longsword"),
                "Longsword should be gone from character's inventory.");
            Assert.IsFalse(Guinevere.Inventory.InventoryCounts.ContainsKey("Longsword"),
                "Character's inventory should have no more Longswords.");

            // Check that 2H is off, then toggle it on
            Assert.IsFalse(Guinevere.Equipment.Is2H, "Newly equipped items should start 1H.");
            Guinevere.Equipment.Toggle2H();
            Assert.IsTrue(Guinevere.Equipment.Is2H, "Longsword should be 2H.");
        }
        [TestMethod]
        public void BreakingAndRepairing()
        {
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));

            Longsword brokenSword = new Longsword();

            Guinevere.Inventory.AddItem(brokenSword);
            brokenSword.DamageEquipment(100);
            Assert.IsTrue(brokenSword.EquipmentKeywords.Contains("Broken"),
                "Equipment item should be broken.");
            Assert.IsFalse(Guinevere.Equipment.Equip("OffHand", brokenSword),
                "Broken gear should not be equippable.");
            brokenSword.RepairEquipment(5);
            Assert.IsFalse(brokenSword.EquipmentKeywords.Contains("Broken"),
                "Equipment item should no longer be broken.");
            Assert.IsTrue(Guinevere.Equipment.Equip("OffHand", brokenSword),
                "Sword should no longer be broken.");
        }
    }
    [TestClass]
    public class HpSpAndXp
    {
        // Break HP, SP, and XP out into their own classes
    }
    [TestClass]
    public class DamageAndProt
    {

    }
    [TestClass]
    public class LevelAndExperience
    {
        [TestMethod]
        public void GainExperience()
        {

        }
    }


}
