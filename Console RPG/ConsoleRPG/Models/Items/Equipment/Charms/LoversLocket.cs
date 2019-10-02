using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Charms
{
    public class LoversLocket : Equipment
    {
        public LoversLocket()
        {
            ItemName = "Lover's Locket";
            ItemDescrip = "A copper locket holding the picture of a long-departed lover. The lasting gloom of lessons learned.";
            Value = 500;
            Weight = 0.1;
            Condition = 100.00;

            IsWeapon = false;
            IsArmor = false;
            IsCharm = true;

            AddCharmStat("APT", 1);
            AddCharmStat("CHA", -1);
        }
    }
}
