using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Money
{
    public class Coins : Item
    {
        public Coins()
        {
            ItemName = "Coins";
            ItemDescrip = "The currency of the realm.";
            Value = 1;
            Weight = 0;
        }
    }
}
