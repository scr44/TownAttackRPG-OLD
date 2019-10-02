using ConsoleRPG.Models.Character.Professions;
using ConsoleRPG.Models.Character.Stats;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Character
{
    public class Character
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
                if (!(EquippedItems.Equipped["MainHand"] is BareHand)) // TODO Can't two-hand a bare fist... yet, maybe add power stancing later
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

        #region General Stats
        #region Base Stats
        public BaseAttributes BaseAttributes { get; private set; }
        public BaseTalents BaseTalents { get; private set; }
        #endregion
        #region Modified Stats
        // TODO build buff and debuff modules
        //public ActiveBuffs
        //public ActiveDebuffs
        //public int BuffStatMod
        //public int DebuffStatMod
        /// <summary>
        /// Returns the total equipment modifier for the given stat.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int EquipmentMod(string stat)
        {
            int mod = 0;
            foreach (Equipment item in EquippedItems.Equipped.Values)
            {
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
        public Dictionary<string,int> Attributes
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "STR", BaseAttributes.Attr["STR"] + EquipmentMod("STR") },
                    { "DEX", BaseAttributes.Attr["DEX"] + EquipmentMod("DEX") },
                    { "SKL", BaseAttributes.Attr["SKL"] + EquipmentMod("STR") },
                    { "APT", BaseAttributes.Attr["APT"] + EquipmentMod("APT") },
                    { "PER", BaseAttributes.Attr["PER"] + EquipmentMod("PER") },
                    { "CHA", BaseAttributes.Attr["CHA"] + EquipmentMod("CHA") },
                };
            }
        }
        public Dictionary<string,int> Talents
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "Medicine", BaseTalents.Talent["Medicine"] + EquipmentMod("Medicine") },
                    { "Herbalism", BaseTalents.Talent["Herbalism"] + EquipmentMod("Herbalism") },
                    { "Explosives", BaseTalents.Talent["Explosives"] + EquipmentMod("Explosives") },
                    { "Veterancy", BaseTalents.Talent["Veterancy"] + EquipmentMod("Veterancy") },
                    { "Bestiary", BaseTalents.Talent["Bestiary"] + EquipmentMod("Bestiary") },
                    { "Engineering", BaseTalents.Talent["Engineering"] + EquipmentMod("Engineering") },
                    { "History", BaseTalents.Talent["History"] + EquipmentMod("History") },
                };
            }
        }
        #endregion
        #endregion

        #region Health and Stamina
        public double BaseHealth { get; private set; }
        public double BaseStamina { get; private set; } = 4;
        public double HP { get; private set; }
        public double AP { get; private set; }
        #endregion

    }
}
