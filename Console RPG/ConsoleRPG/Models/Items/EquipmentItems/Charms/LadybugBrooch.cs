using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class LadybugBrooch : EquipmentItem
    {
        public LadybugBrooch()
        {
            EquipmentTags.Add("Charm");
            EquipmentTags.Add("Jewelry");

            ItemName = "Ladybug Brooch";
            ItemDescrip = "A blue brooch shaped in the likeness of a ladybug. Stylish and expensive.";
            Value = 1000;
            Weight = 0.1;
            Condition = 100.00;

            CharmStats.Add("CHA", 1);

            ValidSlots["Charm 1"] = true;
            ValidSlots["Charm 2"] = true;

        }
    }
}
