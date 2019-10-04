using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class Inventory
    {
        public Inventory() { }
        public Inventory(Dictionary<Item,int> initItems)
        {
            foreach(var item in initItems)
            {
                for (int i = 1; i <= item.Value; i++)
                {
                    this.AddItem(item.Key);
                }
            }
        }

        /// <summary>
        /// The contents of a character's inventory.
        /// </summary>
        public Dictionary<string, Item> InventoryContents { get; private set; } =
            new Dictionary<string, Item>();
        /// <summary>
        /// The counts of a character's inventory.
        /// </summary>
        public Dictionary<string, int> InventoryCounts { get; private set; } =
            new Dictionary<string, int>();

        /// <summary>
        /// Adds the given item to the inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if (InventoryContents.TryAdd(item.ItemName, item))
            {
                InventoryCounts.Add(item.ItemName, 1);
            }
            else
            {
                InventoryCounts[item.ItemName]++;
            }
        }
        public void AddItem(Item item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.AddItem(item);
            }
        }
        //public void AddItem(string itemName) // TODO implement string name additem if possible without hardcoding all items
        /// <summary>
        /// Removes an item from the inventory and returns it to the caller.
        /// </summary>
        /// <param name="item">Item to remove</param>
        public Item RemoveItem(Item item)
        {
            if (InventoryCounts[item.ItemName] > 1)
            {
                InventoryCounts[item.ItemName]--;
            }
            else if (InventoryCounts[item.ItemName] == 1)
            {
                InventoryContents.Remove(item.ItemName);
                InventoryCounts.Remove(item.ItemName);
            }
            else
            {
                throw new ArgumentOutOfRangeException("An inventory cannot have a negative number of items.");
            }
            return item;
        }
        public void RemoveItem(Item item, int count)
        {
            for(int i = 0; i < count; i++)
            {
                this.RemoveItem(item);
            }
        }
        /// <summary>
        /// Transfers an item from this inventory to the target inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public void GiveItem(Item item, Inventory target)
        {
            target.AddItem(item);
            this.RemoveItem(item);
        }
        /// <summary>
        /// Transfers an item from the target inventory to this one.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public void TakeItem(Item item, Inventory target)
        {
            this.AddItem(item);
            target.RemoveItem(item);
        }
    }
}
