using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class Naked : EquipmentItem
    {
        public Naked()
        {
            EquipmentKeywords.Add("None");

            ItemName = "Naked";
            ItemDescrip = "Have some decency!";
        }

        // TODO add CHA modifiers to "naked" equipment based on gender of user and target
    }
}
