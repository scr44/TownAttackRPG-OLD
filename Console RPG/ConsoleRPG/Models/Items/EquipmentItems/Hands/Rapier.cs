using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class Rapier : EquipmentItem
    {
        public Rapier()
        {
            EquipmentTags.Add("Sword");
            EquipmentTags.Add("Weapon");

            ItemName = "Rapier";
            ItemDescrip = "A slender thrusting sword. Excellent for penetrating the weak points of enemy armor.";
            Value = 2000;
            Weight = 4.0;
            Condition = 100.00;

            WeaponStats = new Dictionary<string, double>()
            {
                { "accuracy", .95 },
                { "parryChance", .25 },
                { "slashMultiplier", 5.00 },
                { "pierceMultiplier", 30.00 },
                { "crushMultiplier", 0.00 },
                { "critChance", 0.10 },
                { "critMultiplier", 1.75 },

                { "bleedMultiplier", 1.10 }
            };

            ValidSlots["MainHand"] = true;
            ValidSlots["OffHand"] = true;

            ReqStats.Add("DEX", 5);
            ReqStats.Add("SKL", 7);
        }
    }
}
