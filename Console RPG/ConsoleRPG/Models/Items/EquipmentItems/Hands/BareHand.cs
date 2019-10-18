using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class BareHand : EquipmentItem
    {
        public BareHand()
        {
            EquipmentTags.Add("None");
            EquipmentTags.Add("Hand");

            ItemName = "Bare hand";
            ItemDescrip = "An empty hand. Can punch and throw items.";
        }
    }
}
