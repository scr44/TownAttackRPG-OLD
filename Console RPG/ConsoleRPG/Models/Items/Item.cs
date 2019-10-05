using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Items.Equipment;

namespace ConsoleRPG.Models.Items
{
    abstract public class Item
    {
        public string ItemName { get; protected set; }
        public string ItemDescrip { get; protected set; }
        public int Value { get; protected set; }
        public double Weight { get; protected set; }
    }
}
