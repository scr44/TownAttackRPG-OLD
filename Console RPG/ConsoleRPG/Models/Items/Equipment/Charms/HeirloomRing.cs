using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class HeirloomRing : EquipmentItem
    {
        public HeirloomRing()
        {
            EquipmentTags.Add("Charm");
            EquipmentTags.Add("Jewelry");
            EquipmentTags.Add("Noble Only");

            ItemName = "Heirloom Ring";
            ItemDescrip = "A golden ring with a beautiful sapphire. Passed down from the noble's grandfather. " +
                "A reminder of the family's darkest hour, but also that they persevered nonetheless.";
            Value = 3000;
            Weight = 0.1;
            Condition = 100.00;

            CharmStats.Add("FOR", 1);

            ValidSlots["Charm 1"] = true;
            ValidSlots["Charm 2"] = true;

        }
    }
}
