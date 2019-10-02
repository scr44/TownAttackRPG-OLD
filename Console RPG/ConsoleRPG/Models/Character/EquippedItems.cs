using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Equipment.Charms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Character
{
    public class EquippedItems
    {
        public EquippedItems() { }
        public EquippedItems(Equipment main, Equipment off, Equipment body, Equipment charm1, Equipment charm2)
        {
            Equipped["MainHand"] = main;
            Equipped["OffHand"] = off;
            Equipped["Body"] = body;
            Equipped["Charm 1"] = charm1;
            Equipped["Charm 2"] = charm2;
        }

        public Dictionary<string, Equipment> Equipped { get; set; } =
            new Dictionary<string, Equipment>()
            {
                { "MainHand", new BareHand() },
                { "OffHand", new BareHand() },
                { "Body", new Naked() },
                { "Charm 1", new Unadorned() },
                { "Charm 2", new Unadorned() }
            };
        public bool Is2H
        {
            get
            {
                if (Equipped["OffHand"] is TwoHanding)
                { return true; }
                else
                { return false; }
            }
        }

        /// <summary>
        /// Unequips an Equipment object and returns it. If slot was empty, returns null.
        /// </summary>
        /// <param name="slot">"MainHand", "OffHand", "Body", "Charm 1", "Charm 2" (Case sensitive)</param>
        /// <returns></returns>
        public Equipment Unequip(string slot)
        {
            Equipment removedItem = Equipped[slot];
            if (slot == "MainHand")
            {
                Equipped[slot] = new BareHand();
            }
            else if (slot == "OffHand")
            {
                Equipped[slot] = new BareHand();
            }
            else if (slot == "Body")
            {
                Equipped[slot] = new Naked();
            }
            else if (slot == "Charm 1" || slot == "Charm 2")
            {
                Equipped[slot] = new Unadorned();
            }
            else
            {
                throw new ArgumentException("Tried to unequip from an invalid slot.");
            }

            if (removedItem is BareHand || removedItem is Naked || removedItem is Unadorned)
            { return null; }
            else
            { return removedItem; }
        }
        /// <summary>
        /// Equips new Equipment object in the given slot. If invalid slot, no change made. If item was equipped, returns previously-equipped item. If no item was equipped, returns null.
        /// </summary>
        /// <param name="slot">"MainHand", "OffHand", "Body", "Charm 1", "Charm 2" (Case sensitive)</param>
        /// <param name="item">The item to equip.</param>
        /// <returns></returns>
        public Equipment Equip(string slot, Equipment item)
        {
            if (item.ValidSlots[slot] == false)
            {
                // TODO add a notification that item was not equipped
                return item;
            }
            if (Equipped[slot] is BareHand || Equipped[slot] is Naked || Equipped[slot] is Unadorned)
            {
                Equipped[slot] = item;
                return null;
            }
            else
            {
                Equipment unequipped = Equipped[slot];
                Equipped[slot] = item;
                return unequipped;
            }
        }
        /// <summary>
        /// Toggles whether the primary weapon is being two-handed. If changing to two-handing, returns previously equipped offhand item.
        /// </summary>
        /// <returns></returns>
        public Equipment Toggle2H()
        {
            if (Is2H)
            {
                Unequip("OffHand");
                return null;
            }
            else
            {
                // TODO when toggling, return offhand item to inventory. Possible back equip slot?
                Equipment unequipped = Unequip("OffHand");
                Equipped["OffHand"] = new TwoHanding();
                return unequipped;
            }
        }
    }
}
