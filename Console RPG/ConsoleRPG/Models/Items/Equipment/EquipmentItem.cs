using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Character.Stats;

namespace ConsoleRPG.Models.Items.Equipment
{
    public class EquipmentItem : Item
    {
        public List<string> EquipmentKeywords { get; protected set; } =
            new List<string>();
        public double Condition { get; protected set; } = 100; // TODO when building combat, handle equipment degradation

        #region Stats Tables
        /// <summary>
        /// Weapon-specific statistics
        /// </summary>
        public Dictionary<string, double> WeaponStats { get; protected set; } =
            new Dictionary<string, double>()
            {
                { "accuracy", 1.00 },
                { "parryChance", 0.00 },
                { "slashMultiplier", 1.00 },
                { "pierceMultiplier", 1.00 },
                { "crushMultiplier", 1.00 },
                { "critChance", 0.05 },
                { "critMultiplier", 2.00 }
            };
        /// <summary>
        /// Armor-specific statistics
        /// </summary>
        public Dictionary<string, double> ArmorStats { get; protected set; } =
            new Dictionary<string, double>()
            {
                { "healthBonus", 0 },
                { "blockChance", 0 },
                { "slashPROT", 0 },
                { "piercePROT", 0 },
                { "crushPROT", 0 },
            };
        /// <summary>
        ///  Charm-specific statistics
        /// </summary>
        public Dictionary<string, double> CharmStats { get; protected set; } =
            new Dictionary<string, double>()
            {
                { "staminaBonus", 0 }
            };
        /// <summary>
        /// Stat requirements to equip
        /// </summary>
        public Dictionary<string, double> ReqStats { get; protected set; } =
            new Dictionary<string, double>();
        /// <summary>
        /// List of valid equippable slots.
        /// </summary>
        public Dictionary<string, bool> ValidSlots { get; protected set; } =
            new Dictionary<string, bool>()
            {
                { "MainHand", false },
                { "OffHand", false },
                { "Body", false },
                { "Charm 1", false },
                { "Charm 2", false }
            }; // TODO test ValidSlots requirement for equipping items
        #endregion

        /// <summary>
        /// Changes the item's condition by the given points.
        /// </summary>
        /// <param name="points"></param>
        public void ChangeEquipCond(double points)
        {
            Condition += points;
            if (Condition > 100)
            { Condition = 100; }
            else if (Condition < 0)
            {
                Condition = 0;
                BreakEquipment();
            }
        }
        /// <summary>
        /// Changes the equipment's requirement for a single modifiable stat (Attribute, Talent, etc.)
        /// </summary>
        /// <param name="stat">An Attribute or Talent</param>
        /// <param name="points"></param>
        public void ChangeReq(string stat, int points)
        {
            try
            {
                ReqStats.Add(stat, points);
            }
            catch (ArgumentException)
            {
                ReqStats[stat] += points;
            }
            // TODO add ability requirements to Equipment class
        }
        /// <summary>
        /// Sets a KeyValuePair(stat, points) in the given statsTable.
        /// </summary>
        /// <param name="stat">The stat to add, e.g. "crush PROT" or "STR".</param>
        /// <param name="points">The amount of points to set the new stat to. </param>
        /// <param name="statsTable"></param>
        public void SetEquipmentStat(string stat, double points, Dictionary<string, double> statsTable )
        {
            if( !(statsTable.TryAdd(stat, points)) )
            {
                statsTable[stat] = points;
            }
        }
        public void DamageEquipment(double points)
        {
            Condition -= points;
            if (Condition <= 0)
            {
                BreakEquipment();
            }
        }
        public void BreakEquipment()
        {
            EquipmentKeywords.Add("Broken");
            Condition = 0;
            //TODO add equipment breaking behavior (unequip, prevent equip)
        }
        public void RepairEquipment(double points)
        {
            EquipmentKeywords.Remove("Broken");
            Condition += points;
        }
        public void CharmEffect()
        { // TODO add Charm Effect method to Equipment class 
        }
    }
}
