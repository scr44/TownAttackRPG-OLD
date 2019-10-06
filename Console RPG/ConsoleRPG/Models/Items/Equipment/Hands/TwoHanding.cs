using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class TwoHanding : EquipmentItem
    {
        public TwoHanding()
        {
            EquipmentTags.Add("None");
            EquipmentTags.Add("Hand");

            ItemName = "Two-handing";
            ItemDescrip = "This character is using their primary weapon with both hands.";
            
            // Allow TwoHanding to use Hand abilities like punching, but not throwing
        }
    }
}
