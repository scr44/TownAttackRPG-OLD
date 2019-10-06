using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class Clothing : EquipmentItem
    {
        public Clothing()
        {
            EquipmentTags.Add("Clothing");
            EquipmentTags.Add("Armor");
            EquipmentTags.Add("Cloth");

            ItemName = "Clothing";
            ItemDescrip = "Ordinary clothing. Comfortable, but offers little protection. Still, " +
                "it's better than going into a fight naked.";
            Value = 50;
            Weight = 10.00;
            Condition = 100.00;

            ArmorStats = new Dictionary<string, double>()
            {
                { "healthBonus", 40 },
                { "blockChance", 100 },
                { "slashPROT", .10 },
                { "piercePROT", .10 },
                { "crushPROT", .30 }
            };

            ReqStats.Add("CHA", 2);
        }
    }
}
