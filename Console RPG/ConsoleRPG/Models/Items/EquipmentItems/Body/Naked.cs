using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.Equipment.Body
{
    public class Naked : EquipmentItem
    {
        public Naked()
        {
            EquipmentTags.Add("None");

            ItemName = "Naked";
            Random rand = new Random();
            List<string> nakedDescriptions = new List<string>()
            {
                "Have some decency!",
                "You have no shame, do you?",
                "What would your mother say?",
                "Your birthday suit.",
                "It's a good thing this game uses ASCII graphics."
            };
            ItemDescrip = nakedDescriptions[rand.Next(0,5)];
        }
    }
}
