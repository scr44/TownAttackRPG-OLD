using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class BareHand : Equipment
    {
        public BareHand()
        {
            EquipmentKeywords.Add("None");
            EquipmentKeywords.Add("Hand");

            ItemName = "Bare hand";
            ItemDescrip = "An empty hand. Can punch and throw items.";
        }

        // TODO add item throwing Techniques to Hand type equipment
    }
}
