using ConsoleRPG.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Character
{
    public class Inventory
    {
        public Inventory() { }

        public List<Item> InvList = new List<Item>();

        public void StoreItem(Item item)
        {
            InvList.Add(item);
        }
        public void TakeItem(Item item)
        {
            InvList.Remove(item);
        }
    }
}
