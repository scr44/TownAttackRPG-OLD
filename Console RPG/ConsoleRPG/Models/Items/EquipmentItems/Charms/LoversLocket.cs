using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class LoversLocket : EquipmentItem
    {
        public LoversLocket()
        {
            EquipmentTags.Add("Charm");
            EquipmentTags.Add("Jewelry");

            ItemName = "Lover's Locket";
            ItemDescrip = "A copper locket holding the picture of a long-departed lover. The lasting gloom of lessons learned.";
            Value = 500;
            Weight = 0.1;
            Condition = 100.00;

            CharmStats.Add("APT", 1);
            CharmStats.Add("CHA", -1);
        
            ValidSlots["Charm 1"] = true;
            ValidSlots["Charm 2"] = true;

        }
    }
}
