using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class TwoHanding : EquipmentItem
    {
        public TwoHanding()
        {
            EquipmentKeywords.Add("None");
            EquipmentKeywords.Add("Hand");

            ItemName = "Two-handing";
            ItemDescrip = "This character is using their primary weapon with both hands.";
            
            // TODO add modifier to attack rolls for 2h damage
            // TODO add 2h requirements to Techniques
            // Allow TwoHanding to use Hand abilities like punching, but not throwing
        }
    }
}
