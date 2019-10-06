using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Hands
{
    public class HistoryTome : EquipmentItem
    {
        public HistoryTome()
        {
            EquipmentTags.Add("Book");
            EquipmentTags.Add("Weapon");
            EquipmentTags.Add("Charm");

            ItemName = "History Tome";
            ItemDescrip = "A thick book filled with dry analyses of ancient civilizations. Also good " +
                "for thwacking inattentive pupils during class.";
            Value = 10;
            Weight = 1.0;
            Condition = 100.00;

            WeaponStats = new Dictionary<string, double>()
            {
                { "accuracy", .95 },
                { "parryChance", .00 },
                { "slashMultiplier", 0.00 },
                { "pierceMultiplier", 0.00 },
                { "crushMultiplier", 1.00 },
                { "critChance", 0.01 },
                { "critMultiplier", 5 }
            };

            CharmStats = new Dictionary<string, double>()
            {
                { "APT", 1 },
                { "History", 1 }
            };

            ValidSlots["MainHand"] = true;
            ValidSlots["OffHand"] = true;

            ReqStats.Add("SKL", 5);
            ReqStats.Add("APT", 6);
        }
    }
}
