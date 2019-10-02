using ConsoleRPG.Models.Character.Professions;
using ConsoleRPG.Models.Character.Stats;
using ConsoleRPG.Models.Items.Equipment;
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
            EquippedItems = prof.StartingEquipment;
            Inventory = prof.StartingInventory;
        }

        public string Name { get; }
        public string Gender { get; }
        public Profession Profession { get; }
        public BaseAttributes BaseAttributes { get; private set; }
        public EquippedItems EquippedItems { get; private set; }
        public Inventory Inventory { get; private set; }
        public Modifiers StatMods { get; private set; }

        public void Equip(string slot, Equipment item)
        {
            Inventory.TakeItem(item);
            Equipment priorItem = EquippedItems.Equip(slot, item);
            if (!(priorItem is null))
            { Inventory.StoreItem(priorItem); }
        }
        public void Unequip(string slot)
        {
            Equipment priorItem = EquippedItems.Unequip(slot);
            if (!(priorItem is null))
            { Inventory.StoreItem(priorItem); }
        }
    }
}
