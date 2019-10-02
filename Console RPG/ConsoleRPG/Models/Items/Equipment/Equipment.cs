﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Character.Stats;

namespace ConsoleRPG.Models.Items.Equipment
{
    public class Equipment : Item
    {
        public bool IsWeapon { get; protected set; }
        public bool IsArmor { get; protected set; }
        public bool IsCharm { get; protected set; }
        public double Condition { get; protected set; }

        #region Stats Tables
        /// <summary>
        /// Weapon-specific statistics
        /// </summary>
        public Dictionary<string, double> WeaponStats { get; protected set; } =
            new Dictionary<string, double>()
            {
                { "accuracy", 100 },
                { "parryChance", 0 },
                { "slashMultiplier", 1 },
                { "pierceMultiplier", 1 },
                { "crushMultiplier", 1 }
            };
        /// <summary>
        /// Armor-specific statistics
        /// </summary>
        public Dictionary<string, double> ArmorStats { get; protected set; } =
            new Dictionary<string, double>()
            {
                { "armorHP", 0 },
                { "blockChance", 0 },
                { "slashPROT", 0 },
                { "piercePROT", 0 },
                { "crushPROT", 0 },
            };
        /// <summary>
        ///  Charm-specific statistics
        /// </summary>
        public Dictionary<string, int> CharmStats { get; protected set; } =
            new Dictionary<string, int>();
        /// <summary>
        /// Stat requirements to equip
        /// </summary>
        public Dictionary<string, int> ReqStats { get; protected set; } =
            new Dictionary<string, int>();
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
            };
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
        /// Adds points to the charm's given Attribute or Talent bonus.
        /// </summary>
        /// <param name="stat">Attribute to affect</param>
        /// <param name="points">Points to increase (negative to decrease)</param>
        public void AddCharmStat(string stat, int points)
        {
            CharmStats.Add(stat, points);
        }
        public void BreakEquipment()
        {
            //TODO add equipment breaking behavior (unequip, prevent equip)
        }
        public void CharmEffect()
        { // TODO add Charm Effect method to Equipment class 
        }
    }
}