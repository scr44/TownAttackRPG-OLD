using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class Character : Actor
    {
        public Character(string name, Profession prof)
        {
            Name = name;
            Gender = prof.Gender;
            Profession = prof;
            BaseAttributes = prof.StartingAttributes;
            BaseTalents = prof.StartingTalents;
            EquippedItems = prof.StartingEquipment;
            Inventory = prof.StartingInventory;

            BaseHealth = prof.BaseHealth;
        }

        #region Flavor Text Info
        public string Name { get; }
        public string Gender { get; }
        public Profession Profession { get; }
        #endregion

        #region Inventory and Equipment
        public EquippedItems EquippedItems { get; private set; }
        public Inventory Inventory { get; private set; }

        /// <summary>
        /// Equips an item and moves prior equipped item to inventory.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        public void Equip(string slot, Equipment item)
        {
            Inventory.TakeItem(item);
            Equipment priorItem = EquippedItems.Equip(slot, item);
            if (!(priorItem is null))
            { Inventory.StoreItem(priorItem); }
        }
        /// <summary>
        /// Unequips an item and stores it in the inventory.
        /// </summary>
        /// <param name="slot"></param>
        public void Unequip(string slot)
        {
            Equipment priorItem = EquippedItems.Unequip(slot);
            if (!(priorItem is null))
            { Inventory.StoreItem(priorItem); }
        }
        /// <summary>
        /// Toggles whether the primary weapon is being two-handed. If changing to two-handing, returns previously equipped offhand item.
        /// </summary>
        /// <returns></returns>
        public void Toggle2H()
        {
            if (EquippedItems.Is2H)
            {
                Unequip("OffHand");
            }
            else
            {
                if (EquippedItems.Equipped["MainHand"].EquipmentKeywords.Contains("Can2H"))
                {
                    Unequip("OffHand");
                    EquippedItems.Equipped["OffHand"] = new TwoHanding();
                }
            }
        }
        public void CheckEquipment()
        {
            Console.WriteLine($"{Name}'s Equipment");
            Console.WriteLine("===================================");
            EquippedItems.DisplayEquipment();
        }
        public void CheckInventory()
        {
            Console.WriteLine($"{Name}'s Inventory");
            Console.WriteLine("===================================");
            Inventory.DisplayInventory();
        }
        // TODO implement trade function for selling items and exchanging with party members
        #endregion

        #region Base Attributes and Talents
        public BaseAttributes BaseAttributes { get; private set; }
        public BaseTalents BaseTalents { get; private set; }
        #endregion

        #region Health, Stamina, XP
        public double BaseHealth { get; private set; }
        public double BaseStamina { get; private set; }
        public double HP { get; private set; }
        public double SP { get; private set; }
        public double MaxHP
        {
            get
            {
                return BaseHealth + EquipmentMod("healthBonus");
                // TODO add max health modifier from Effects
            }
        }
        public double MaxSP
        {
            get
            {
                return Profession.BaseStamina + EquipmentMod("staminaBonus");
            }
        }
        public double percentHP
        {
            get
            {
                return Math.Round((HP / MaxHP * 100),2);
            }
        }
        public double percentSP
        {
            get
            {
                return Math.Round((SP / MaxSP * 100), 2);
            }
        }
        public int XP { get; private set; } = 0;
        public int NextLevelXP { get; private set; } = 100; // TODO build level up module
        #endregion

        #region Stat Modifiers
        // TODO build Effects and modify character stats from them
        /// <summary>
        /// Returns the total equipment modifier for the given stat.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public double EquipmentMod(string stat)
        {
            double mod = 0;
            foreach (Equipment item in EquippedItems.Equipped.Values)
            {
                foreach (KeyValuePair<string, double> itemStat in item.WeaponStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
                foreach (KeyValuePair<string, double> itemStat in item.ArmorStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
                foreach (KeyValuePair<string, int> itemStat in item.CharmStats)
                {
                    if (itemStat.Key == stat)
                    {
                        mod += itemStat.Value;
                    }
                }
            }
            return mod;
        }
        /// <summary>
        /// A dictionary of the current modded attribute values.
        /// </summary>
        public Dictionary<string, int> Attributes
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "STR", BaseAttributes.Attr["STR"] + (int)EquipmentMod("STR") },
                    { "DEX", BaseAttributes.Attr["DEX"] + (int)EquipmentMod("DEX") },
                    { "SKL", BaseAttributes.Attr["SKL"] + (int)EquipmentMod("STR") },
                    { "APT", BaseAttributes.Attr["APT"] + (int)EquipmentMod("APT") },
                    { "PER", BaseAttributes.Attr["PER"] + (int)EquipmentMod("PER") },
                    { "CHA", BaseAttributes.Attr["CHA"] + (int)EquipmentMod("CHA") },
                };
            }
        }
        public Dictionary<string, int> Talents
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "Medicine", BaseTalents.Talent["Medicine"] + (int)EquipmentMod("Medicine") },
                    { "Herbalism", BaseTalents.Talent["Herbalism"] + (int)EquipmentMod("Herbalism") },
                    { "Explosives", BaseTalents.Talent["Explosives"] + (int)EquipmentMod("Explosives") },
                    { "Veterancy", BaseTalents.Talent["Veterancy"] + (int)EquipmentMod("Veterancy") },
                    { "Bestiary", BaseTalents.Talent["Bestiary"] + (int)EquipmentMod("Bestiary") },
                    { "Engineering", BaseTalents.Talent["Engineering"] + (int)EquipmentMod("Engineering") },
                    { "History", BaseTalents.Talent["History"] + (int)EquipmentMod("History") },
                };
            }
        }
        #endregion

    }
}
