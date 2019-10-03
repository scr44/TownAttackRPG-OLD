using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items
{
    public class Item
    {
        public string ItemName { get; protected set; }
        public string ItemDescrip { get; protected set; }
        public int Value { get; protected set; } = 0;
        public double Weight { get; protected set; } = 0;
    }
}
