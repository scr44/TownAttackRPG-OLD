using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.CombatInterfaces
{
    interface IDamage
    {
        void Damaged(double dmgRaw, string dmgType, double dmgAP = 0);
        //{
        //    // PROT reduces damage multiplicatively
        //    double reducedDmg = dmgRaw * (1 - PROT(dmgType));
        //    // A portion of the blocked damage gets through with the armor piercing multiplier
        //    double armorPiercingDmg = (dmgRaw - reducedDmg) * dmgAP;
        //    // calculate the total amount of damage the character will actually take
        //    double totalDmgTaken = -1 * (reducedDmg + armorPiercingDmg);

        //    // take the damage
        //    HP.AdjustHP(totalDmgTaken);
        //}
    }
}
