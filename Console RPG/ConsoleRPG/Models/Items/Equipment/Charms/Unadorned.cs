using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class Unadorned : Equipment
    {
        public Unadorned()
        {
            ItemName = "Unadorned";
            ItemDescrip = "Wearing no jewelry or charms in this slot.";
            Value = 0;
            Condition = 100.00;
        }
    }
}
