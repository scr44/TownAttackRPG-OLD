﻿using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Characters
{
    public class Equipment
    {
        #region Constructors
        public Equipment() { }
        public Equipment(Character character, EquipmentItem main, EquipmentItem off, 
            EquipmentItem body, EquipmentItem charm1, EquipmentItem charm2)
        {
            Slot["MainHand"] = main;
            Slot["OffHand"] = off;
            Slot["Body"] = body;
            Slot["Charm 1"] = charm1;
            Slot["Charm 2"] = charm2;

            AttachedCharacter = character;
        }
        public Equipment(Character character, Dictionary<string, EquipmentItem> initDict)
        {
            AttachedCharacter = character;
            this.Slot = initDict;
        }
        #endregion

        #region Attached Objects
        public Character AttachedCharacter { get; }
        public Inventory AttachedInventory
        {
            get
            {
                return AttachedCharacter.Inventory;
            }
        }
        #endregion

        #region Slot Dict
        /// <summary>
        /// The set of equipment slots and equipped items.
        /// </summary>
        public Dictionary<string, EquipmentItem> Slot { get; private set; } =
            new Dictionary<string, EquipmentItem>()
            {
                { "MainHand", new BareHand() },
                { "OffHand", new BareHand() },
                { "Body", new Naked() },
                { "Charm 1", new Unadorned() },
                { "Charm 2", new Unadorned() }
            };
        public List<string> AllEquipmentTags
        {
            get
            {
                var equipment = Slot.Values;
                List<string> tags = new List<string>();

                foreach (EquipmentItem item in equipment)
                {
                    for (int i=0; i<item.EquipmentTags.Count; i++)
                    {
                        tags.Add(item.EquipmentTags[i]);
                    }
                }
                return tags;
            }
        }
        #endregion

        #region Two-Handing
        public bool Can2H
        {
            get
            {
                if (Slot["MainHand"].EquipmentTags.Contains("Can2H"))
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Checks whether Character is wielding their primary weapon with both hands.
        /// </summary>
        public bool Is2H
        {
            get
            {
                if (Slot["OffHand"] is TwoHanding)
                { return true; }
                else
                { return false; }
            }
        }
        /// <summary>
        /// Toggles whether the primary weapon is being two-handed. If changing to two-handing, returns previously equipped offhand item.
        /// </summary>
        /// <returns></returns>
        public void Toggle2H()
        {
            if (Is2H)
            {
                Unequip("OffHand");
            }
            else
            {
                if (Can2H)
                {
                    Unequip("OffHand");
                    Slot["OffHand"] = new TwoHanding();
                }
                // if can't 2H the main weapon, do nothing
            }
        }
        #endregion

        #region Equipping
        /// <summary>
        /// Checks to ensure the character's stats meet the equipment requirements.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool MeetsItemReq(EquipmentItem item)
        {
            foreach(KeyValuePair<string, double> req in item.ReqStats)
            {
                if(AttachedCharacter.Attributes.ModdedValue.ContainsKey(req.Key)
                    && req.Value > AttachedCharacter.Attributes.ModdedValue[req.Key])
                {
                    return false;
                }
                if(AttachedCharacter.Talents.ModdedValue.ContainsKey(req.Key)
                    && req.Value > AttachedCharacter.Talents.ModdedValue[req.Key])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Equips an item and moves prior equipped item to inventory.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        public bool Equip(string slot, EquipmentItem equipment)
        {
            if (  equipment.ValidSlots[slot] == true
             &&   MeetsItemReq(equipment)
             && !(equipment.EquipmentTags.Contains("NotEquippable"))
             && !(equipment.EquipmentTags.Contains("Broken")))
            {
                EquipmentItem priorEquipment = Slot[slot]; // Hold the prior equipped item,
                AttachedInventory.RemoveItem(equipment.ItemName);
                Slot[slot] = equipment;                    // and equip the new item.
                if (                             
                       priorEquipment is BareHand
                    || priorEquipment is Naked             // If the slot was empty,
                    || priorEquipment is Unadorned
                    || priorEquipment is TwoHanding)
                {
                    RefreshHpSpOnEquip(priorEquipment, equipment);
                    return true;                           // return true because the equip succeeded.
                }
                else                                       // If the slot had equipment,
                {
                    AttachedInventory.AddItem(equipment);  // add the prior item to the attached inventory
                    RefreshHpSpOnEquip(priorEquipment, equipment);
                    return true;                           // and return true because the equip succeeded.
                }
            }
            else                                           // If invalid slot, non-equippable item, or broken equipment,
            {
                return false;                              // don't equip the item, and return false because the equip failed.
            }
        }
        #endregion

        #region Unequipping
        /// <summary>
        /// Unequips an item and stores it in the inventory.
        /// </summary>
        /// <param name="slot"></param>
        public void Unequip(string slot)
        {
            // Hold the prior equipped item
            EquipmentItem priorEquipment = Slot[slot];

            // 2H primary unequips the offhand as well
            if(Is2H && slot == "MainHand")
            {
                Toggle2H();
            }

            // The actual slot unequip
            if(slot == "MainHand" || slot == "OffHand")
            {
                Slot[slot] = new BareHand();
            }
            else if (slot == "Body")
            {
                Slot[slot] = new Naked();
            }
            else if (slot.StartsWith("Charm"))
            {
                Slot[slot] = new Unadorned();
            }
            else
            {
                throw new ArgumentException("Tried to unequip an invalid slot.");
            }

            // Inventory handling post-unequip
            if (    // If the slot was empty
                       priorEquipment is BareHand
                    || priorEquipment is TwoHanding
                    || priorEquipment is Naked
                    || priorEquipment is Unadorned)
            {
                // Do nothing;
            }
            else
            {
                // Add item to the attached inventory.
                AttachedInventory.AddItem(priorEquipment);
            }
        }
        public void RefreshHpSpOnEquip(EquipmentItem priorItem, EquipmentItem newItem)
        {
            var hp = AttachedCharacter.HP;
            var sp = AttachedCharacter.SP;

            var healthDiff = EquipmentMod("healthBonus", newItem) - EquipmentMod("healthBonus", priorItem);
            var staminaDiff = EquipmentMod("staminaBonus", newItem) - EquipmentMod("staminaBonus", priorItem);

            if (healthDiff > 0)
            {
                hp.AdjustHP(healthDiff); // if new armor has more HP bonus, add HP.
            }
            else if (healthDiff < 0)
            {
                // if new armor has less HP bonus, find the new max HP
                var newMax = hp.Base + EquipmentMod("healthBonus", newItem);
                if(hp.Current > newMax)
                {
                    hp.AdjustHP(newMax - hp.Current); // if current HP exceeds new max, lower to new max.
                }
            }
            else
            {
                // new armor matches health bonus, no change to HP.
            }

            if (staminaDiff > 0)
            {
                sp.AdjustSP(staminaDiff); // if new armor has more SP bonus, add SP.
            }
            else if (staminaDiff < 0)
            {
                // if new armor has less SP bonus, find the new max SP
                var newMax = sp.Base + EquipmentMod("staminaBonus", newItem);
                if (sp.Current > newMax)
                {
                    sp.AdjustSP(newMax - sp.Current); // if current SP exceeds new max, lower to new max.
                }
            }
            else
            {
                // new armor matches health bonus, no change to SP.
            }
        }
        #endregion

        public void DisplayEquipment()
        {
            foreach (KeyValuePair<string, EquipmentItem> equipment in Slot)
            {
                Console.WriteLine($"{equipment.Key} - {equipment.Value.ItemName}: {equipment.Value.ItemDescrip}\n");
            }
        }

        public double EquipmentMod(string stat, EquipmentItem equipment)
        {
            double mod = 0;
            foreach (KeyValuePair<string, double> itemStat in equipment.WeaponStats)
            {
                if (itemStat.Key == stat)
                {
                    mod += itemStat.Value;
                }
            }
            foreach (KeyValuePair<string, double> itemStat in equipment.ArmorStats)
            {
                if (itemStat.Key == stat)
                {
                    mod += itemStat.Value;
                }
            }
            foreach (KeyValuePair<string, double> itemStat in equipment.CharmStats)
            {
                if (itemStat.Key == stat)
                {
                    mod += itemStat.Value;
                }
            }
            return mod;
        }
    }
}
