using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character
{
    public class Inventory
    {
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
        public void RemoveItem(Item item)
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
        }
        public void DepositItem(Item item, Inventory container)
        {
            container.AddItem(item);
            this.RemoveItem(item);
        }
        public void TakeItem(Item item, Inventory container)
        {
            this.AddItem(item);
            container.RemoveItem(item);
        }
    }
}
