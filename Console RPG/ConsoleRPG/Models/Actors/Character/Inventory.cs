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

        public List<Item> InvList = new List<Item>();

        public void DisplayInventory()
        {
            if (InvList.Count > 0)
            {
                foreach (Item item in InvList)
                {
                    Console.WriteLine($"* {item.ItemName}: {item.ItemDescrip}");
                    //TODO 01: How do you get a subclass back once you've put it in a container of superclasses?
                }
            }
            else
            {
                Console.WriteLine("No items in inventory.");
            }
        }
        public void StoreItem(Item item)
        {
            InvList.Add(item);
        }
        public void RemoveItem(Item item)
        {
            InvList.Remove(item);
        }
    }
}
