using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class PlateArmor : EquipmentItem
    {
        public PlateArmor()
        {
            EquipmentTags.Add("Heavy");
            EquipmentTags.Add("Armor");
            EquipmentTags.Add("Metal");

            ItemName = "Plate Armor";
            ItemDescrip = "A complete set of plate armor. Renders the wearer nearly impervious to slashing attacks," +
                "though heavy crushing blows can still injure, and skilled opponents can pierce the weak points.";
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

            ReqStats.Add("STR", 6);
            ReqStats.Add("FOR", 5);
        }
    }
}
