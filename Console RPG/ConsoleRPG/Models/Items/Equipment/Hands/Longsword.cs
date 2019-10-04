using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class Longsword : EquipmentItem
    {
        public Longsword()
        {
            EquipmentKeywords.Add("Sword");
            EquipmentKeywords.Add("Weapon");
            EquipmentKeywords.Add("Can2H");

            ItemName = "Longsword";
            ItemDescrip = "A versatile weapon. Good damage, with a wide variety of attack techniques for any situation.";
            Value = 1000;
            Weight = 8.0;
            Condition = 100.00;

            WeaponStats = new Dictionary<string, double>()
            {
                { "accuracy", .95 },
                { "parryChance", .15 },
                { "slashMultiplier", 15.00 },
                { "pierceMultiplier", 20.00 },
                { "crushMultiplier", 5.00 },
                { "critChance", 0.05 },
                { "critMultiplier", 1.5 }
            };

            ValidSlots["MainHand"] = true;
            ValidSlots["OffHand"] = true;

            ReqStats.Add("STR", 6);
            ReqStats.Add("DEX", 6);
            ReqStats.Add("SKL", 6);
        }

    }
}
