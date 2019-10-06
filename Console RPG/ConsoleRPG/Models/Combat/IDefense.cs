using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Combat
{
    interface IDefense
    {
        /// <summary>
        /// Reduces damage per armor, adds armor piercing damage, then deals remaining damage to Actor's HP.
        /// </summary>
        /// <param name="dmgType">The damage type.</param>
        /// <param name="dmg">The amount of damage.</param>
        /// <param name="ap">The armor-piercing multiplier of the attack.</param>
        //void TakeHit(string dmgType, int dmg, double ap)
        //{
        //    double reducedDmg = (1 - EquipmentPROT(dmgType)) * dmg + (EquipmentPROT(dmgType) * dmg * ap);
        //    TakeHpDmg((int)reducedDmg);
        //}
        bool TryBlock(EquipmentItem equipment);
    }
}
