using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class FancyClothing : EquipmentItem
    {
        public FancyClothing()
        {
            EquipmentTags.Add("Light");
            EquipmentTags.Add("Armor");
            EquipmentTags.Add("Cloth");

            ItemName = "Fancy Clothing";
            ItemDescrip = "Ornate dress for a night on the town. Reinforced with metal " +
                "studs in case the wearer's honor needs to be violently defended.";
            Value = 1000;
            Weight = 10.00;
            Condition = 100.00;

            ArmorStats = new Dictionary<string, double>()
            {
                { "healthBonus",  40 },
                { "blockChance", 100 },
                { "slashPROT", .20 },
                { "piercePROT", .20 },
                { "crushPROT", .20 }
            };

            ValidSlots["Body"] = true;

            ReqStats.Add("CHA", 6);
        }
    }
}
