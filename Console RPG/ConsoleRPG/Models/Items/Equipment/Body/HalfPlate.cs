using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class HalfPlate : Equipment
    {
        public HalfPlate()
        {
            EquipmentKeywords.Add("Heavy");
            EquipmentKeywords.Add("Armor");
            EquipmentKeywords.Add("Metal");

            ItemName = "Half-Plate";
            ItemDescrip = "A set of half-plate. Steel plates protect the most vital areas, and chainmail or thick cloth cover the rest.";
            Value = 3000;
            Weight = 42.00;
            Condition = 100.00;

            ArmorStats = new Dictionary<string, double>()
            {
                { "healthBonus",  80 },
                { "blockChance", 100 },
                { "slashPROT", .80 },
                { "piercePROT", .55 },
                { "crushPROT", .70 }
            };

            ReqStats.Add("STR", 5);
            ReqStats.Add("DEX", 4);
            ReqStats.Add("SKL", 4);
        }
    }
}
