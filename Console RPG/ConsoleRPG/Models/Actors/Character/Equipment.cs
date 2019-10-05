using ConsoleRPG.Models.Items;
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
        public Equipment(Inventory inventoryPointer, EquipmentItem main, EquipmentItem off, 
            EquipmentItem body, EquipmentItem charm1, EquipmentItem charm2)
        {
            Slot["MainHand"] = main;
            Slot["OffHand"] = off;
            Slot["Body"] = body;
            Slot["Charm 1"] = charm1;
            Slot["Charm 2"] = charm2;

            AttachedInventory = inventoryPointer;
        }
        public Equipment(Inventory inventoryPointer, Dictionary<string, EquipmentItem> initDict)
        {
            this.AttachedInventory = inventoryPointer;
            this.Slot = initDict;
        }
        #endregion

        public Inventory AttachedInventory { get; }
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
                // if can't 2H the main weapon, do nothing
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
                EquipmentItem priorEquipment = Slot[slot]; // Hold the prior equipped item,
                AttachedInventory.RemoveItem(equipment);
                Slot[slot] = equipment;                    // and equip the new item.
                if (                             
                       priorEquipment is BareHand
                    || priorEquipment is Naked             // If the slot was empty,
                    || priorEquipment is Unadorned
                    || priorEquipment is TwoHanding)
                {
                    return true;                           // return true because the equip succeeded.
                }
                else                                       // If the slot had equipment,
                {
                    AttachedInventory.AddItem(equipment);  // add the prior item to the attached inventory
                    return true;                           // and return true because the equip succeeded.
                }
            }
            else                                           // If invalid slot, non-equippable item, or broken equipment,
            {
                return false;                              // don't equip the item, and return false because the equip failed.
            }
        }
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

        public void DisplayEquipment()
        {
            foreach (KeyValuePair<string, EquipmentItem> equipment in Slot)
            {
                Console.WriteLine($"{equipment.Key} - {equipment.Value.ItemName}: {equipment.Value.ItemDescrip}\n");
            }
        }
    }
}
