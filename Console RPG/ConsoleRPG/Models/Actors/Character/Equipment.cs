using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class Equipment
    {
        #region Constructors
        public Equipment() { }
        public Equipment(EquipmentItem main, EquipmentItem off, EquipmentItem body, EquipmentItem charm1, EquipmentItem charm2)
        {
            Equipped["MainHand"] = main;
            Equipped["OffHand"] = off;
            Equipped["Body"] = body;
            Equipped["Charm 1"] = charm1;
            Equipped["Charm 2"] = charm2;
        }
        #endregion

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
                if (Slot["MainHand"].EquipmentKeywords.Contains("Can2H"))
                {
                    Unequip("OffHand");
                    Slot["OffHand"] = new TwoHanding();
                }
            }
        }
        /// <summary>
        /// Equips an item and moves prior equipped item to inventory.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        public bool Equip(string slot, EquipmentItem equipment)
        {
            if (
                  equipment.ValidSlots[slot] == true
             && !(equipment.EquipmentKeywords.Contains("NotEquippable"))
             && !(equipment.EquipmentKeywords.Contains("Broken")))
            {
                EquipmentItem priorEquipment = Slot[slot];
                Slot[slot] = equipment;
                if (// If the slot was empty
                       priorEquipment is BareHand
                    || priorEquipment is Naked
                    || priorEquipment is Unadorned)
                {
                    return true; // New item equipped
                }
                else // If the slot had equipment
                {
                    // add the prior item to the inventory
                    return true;
                }
            }
            else
            {
                return false; // Don't equip the item
            }
        }
        /// <summary>
        /// Unequips an item and stores it in the inventory.
        /// </summary>
        /// <param name="slot"></param>
        public void Unequip(string slot)
        {
            EquipmentItem priorItem = Slot.Unequip(slot);
            if (!(priorItem is null))
            { Inventory.StoreItem(priorItem); }
        }

        public void DisplayEquipment()
        {
            foreach (KeyValuePair<string, EquipmentItem> equipment in Equipped)
            {
                Console.WriteLine($"{equipment.Key} - {equipment.Value.ItemName}: {equipment.Value.ItemDescrip}\n");
            }
        }
    }
}
