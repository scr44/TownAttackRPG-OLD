using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class Naked : Equipment
    {
        public Naked()
        {
            ItemName = "Naked";
            ItemDescrip = "Have some decency!";
            Value = 0;
            Condition = 100.00;
        }

        // TODO add CHA modifiers to "naked" equipment based on gender of user and target
    }
}
