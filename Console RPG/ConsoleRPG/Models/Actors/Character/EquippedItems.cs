using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class EquippedItems
    {
        #region Constructors
        public EquippedItems() { }
        public EquippedItems(EquipmentItem main, EquipmentItem off, EquipmentItem body, EquipmentItem charm1, EquipmentItem charm2)
        {
            Equipped["MainHand"] = main;
            Equipped["OffHand"] = off;
            Equipped["Body"] = body;
            Equipped["Charm 1"] = charm1;
            Equipped["Charm 2"] = charm2;
        }
        #endregion

        #region Properties
        public Dictionary<string, EquipmentItem> Equipped { get; set; } =
            new Dictionary<string, EquipmentItem>()
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
        #endregion

        #region Methods
        /// <summary>
        /// Unequips an Equipment object and returns it. If slot was empty, returns null.
        /// </summary>
        /// <param name="slot">"MainHand", "OffHand", "Body", "Charm 1", "Charm 2" (Case sensitive)</param>
        /// <returns></returns>
        public EquipmentItem Unequip(string slot)
        {
            EquipmentItem removedItem = Equipped[slot];
            if (slot == "MainHand")
            {
                Equipped[slot] = new BareHand();
                if (Is2H)
                {
                    Unequip("OffHand");
                }
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

            if (removedItem is BareHand || removedItem is Naked || removedItem is Unadorned || removedItem is TwoHanding)
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
        public EquipmentItem Equip(string slot, EquipmentItem item)
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
                EquipmentItem unequipped = Equipped[slot];
                Equipped[slot] = item;
                return unequipped;
            }
        }

        public void DisplayEquipment()
        {
            foreach (KeyValuePair<string, EquipmentItem> equipment in Equipped)
            {
                Console.WriteLine($"{equipment.Key} - {equipment.Value.ItemName}: {equipment.Value.ItemDescrip}\n");
            }
        }
        #endregion
    }
}
