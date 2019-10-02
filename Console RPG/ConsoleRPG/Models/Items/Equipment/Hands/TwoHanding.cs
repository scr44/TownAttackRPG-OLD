using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class TwoHanding : Equipment
    {
        public TwoHanding()
        {
            ItemName = "Two-handing";
            ItemDescrip = "This character is using their primary weapon with both hands.";
            Value = 0;
            Weight = 0.00;
            Condition = 0.00;

            IsWeapon = false;
            IsArmor = false;
            IsCharm = false;

            // TODO add modifier to attack rolls for 2h damage
            // TODO add 2h requirements to Techniques
        }
    }
}
