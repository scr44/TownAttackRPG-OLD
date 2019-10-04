using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Professions.Default_Professions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(Guinevere.Profession is Mercenary, true);
            Assert.AreEqual(Valerian.Profession is Mercenary, true);
        }
        [TestMethod]
        public void HasStartingStats()
        {
            CollectionAssert.AreEqual(Guinevere.BaseAttributes.ValueDict, new Mercenary().StartingAttributes.ValueDict);
        }
    }

    [TestClass]
    public class EquippingAndUnequipping
    {
        public Character Guinevere = new Character("Guinevere", new Mercenary("F"));
        [TestMethod]
        public void HasStartingEquipment()
        {
            CollectionAssert.AreEqual(Guinevere.Equipment.Equipped,
                            new Mercenary().StartingEquipment.Equipped);
        }
        [TestMethod]
        public void Toggle2H()
        {
            Guinevere.Toggle2H();
            Assert.AreNotEqual(Guinevere.Equipment.Equipped["OffHand"] is TwoHanding, true);
        }
    }
}
