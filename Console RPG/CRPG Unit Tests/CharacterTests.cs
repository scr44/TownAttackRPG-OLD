using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Hands;
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
    public class EquipmentFunctions
    {
        [TestMethod]
        public void HasStartingEquipment()
        {
            // Create new mercenary character
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            // Get merc character's equipped gear
            Dictionary<string,EquipmentItem> charEquipment = Guinevere.Equipment.Equipped;
            // Get mercenary profession's default equipped gear
            Dictionary<string, EquipmentItem> defaultEquipment = new Mercenary("M").StartingEquipment.Equipped;
            //CollectionAssert.AreEqual(charEquipment, defaultEquipment, "New character's gear should match their profession's starting gear.");
            Assert.AreEqual(charEquipment.ToString(), defaultEquipment.ToString());
        }
        [TestMethod]
        public void Toggle2H()
        {
            // Create new mercenary character (starts with 2H)
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            Assert.IsTrue(Guinevere.Equipment.Equipped["OffHand"] is TwoHanding, 
                "Character should begin with primary weapon Two-handed");

            Guinevere.Toggle2H();

            Assert.IsFalse(Guinevere.Equipment.Equipped["OffHand"] is TwoHanding,
                "Upon 2H toggle on, Character should no longer be two-handing their weapon.");
            Assert.IsTrue(Guinevere.Equipment.Equipped["OffHand"] is BareHand, 
                "Immediately after 2H toggled off, Character's offhand should be empty.");

            Guinevere.Toggle2H();

            Assert.IsTrue(Guinevere.Equipment.Equipped["OffHand"] is TwoHanding,
                "Upon 2H toggle on, Character should be two-handing their weapon.");
        }
        [TestMethod]
        public void EquipAndUnequipPrimary()
        {
            // Create new mercenary character
            Character Guinevere = new Character("Guinevere", new Mercenary("F"));
            Assert.IsFalse(Guinevere.Equipment.Equipped["MainHand"] is BareHand,
                "Character should start with a weapon in their MainHand slot.");
            
            // Check unequipping behavior
            Guinevere.Unequip("MainHand");

            Assert.IsTrue(Guinevere.Equipment.Equipped["MainHand"] is BareHand
                && Guinevere.Equipment.Equipped["OffHand"] is BareHand,
                "When 2H weapon is unequipped, both hands should be bare handed.");

            // Guinevere.Inventory.InvList.Contains();

            // Check equipping behavior
        }
    }

    [TestClass]
    public class InventoryBehavior
    {

    }
}
