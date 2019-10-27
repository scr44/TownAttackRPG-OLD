using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Items.VendorTrash
{
    public class Rubbish : Item
    {
        public Rubbish()
        {
            ItemName = "Rubbish";
            ItemDescrip = "Worthless junk.";
            Value = 0;
            Weight = 1;
        }
    }
}
