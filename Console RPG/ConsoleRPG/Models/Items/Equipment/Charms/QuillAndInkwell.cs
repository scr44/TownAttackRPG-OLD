using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class QuillAndInkwell : EquipmentItem
    {
        public QuillAndInkwell()
        {
            EquipmentTags.Add("Charm");

            ItemName = "Quill and Inkwell";
            ItemDescrip = "Writing utensils. The scholar often stops to scratch down notes," +
                "even in the middle of combat.";
            Value = 20;
            Weight = .5;
            Condition = 100.00;

            CharmStats.Add("APT", 1);

            ValidSlots["Charm 1"] = true;
            ValidSlots["Charm 2"] = true;

            ReqStats.Add("APT", 5);
        }
    }
}
