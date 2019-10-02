using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class Longsword : Equipment
    {
        public Longsword()
        {
            ItemName = "Longsword";
            ItemDescrip = "A versatile weapon. Good damage, with a wide variety of attack techniques for any situation.";
            Value = 1000;
            Weight = 8.0;
            Condition = 100.00;

            IsWeapon = true;
            IsArmor = false;
            IsCharm = false;

            WeaponStats = new Dictionary<string, double>()
            {
                { "accuracy", 0 },
                { "parryChance", 15 },
                { "slashMultiplier", 15 },
                { "pierceMultiplier", 20 },
                { "crushMultiplier", 5 }
            };

            ReqStats.Add("STR", 6);
            ReqStats.Add("DEX", 6);
            ReqStats.Add("SKL", 6);
        }

        // TODO add Techniques (methods) to weapon items
    }
}
