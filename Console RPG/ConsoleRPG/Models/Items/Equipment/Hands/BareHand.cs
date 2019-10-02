using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class BareHand : Equipment
    {
        public BareHand()
        {
            ItemName = "Bare hand";
            ItemDescrip = "An empty hand. Can punch and throw items.";
            Value = 0;
            Weight = 0;
            Condition = 0;

            IsWeapon = true;
            IsArmor = false;
            IsCharm = false;

        }

        // TODO add item throwing Techniques to bare hand weapon
    }
}
