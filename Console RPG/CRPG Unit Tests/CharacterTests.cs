using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Money;
using ConsoleRPG.Models.Professions.Default_Professions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CRPG_Unit_Tests
{
    [TestClass]
    public class CharacterCreation
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
            CollectionAssert.AreEqual(Guinevere.Attributes.BaseValue, new Mercenary().StartingAttributes.BaseValue, "Character should construct with Profession's starting attributes.");
            CollectionAssert.AreEqual(Guinevere.Talents.BaseValue, new Mercenary().StartingTalents.BaseValue, "Character should construct with Profession's starting talents.");
        }
    }

    [TestClass]
    public class CharacterStats
    {
        [TestMethod]
        public void 
    }

    [TestClass]
    public class ArmorDamageAndHP
    {

    }

    [TestClass]
    public class EquipmentFunctions
    {
        [TestMethod]
        public void HasStartingEquipment()
        {
            // Create new mercenary character
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            // Get merc character's equipped gear
            Dictionary<string,EquipmentItem> charEquipment = Guinevere.Equipment.Slot;
            // Get mercenary profession's default equipped gear
            Dictionary<string, EquipmentItem> defaultEquipment = new Mercenary("M").StartingEquipment.Slot;
            //CollectionAssert.AreEqual(charEquipment, defaultEquipment, "New character's gear should match their profession's starting gear.");
            Assert.AreEqual(charEquipment.ToString(), defaultEquipment.ToString());
        }
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

            for(int i=0;i<5; i++)
            {
                inventory.AddItem(new Longsword());
            }

            Assert.IsTrue(inventory.InventoryContents.Count == 1, "Inventory should only have one actual Longsword object stored.");
            Assert.IsTrue(inventory.InventoryCounts["Longsword"] == 5,"Inventory should know it has 5 longswords available to dispense.");

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
    }
}
