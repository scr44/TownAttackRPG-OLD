using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.CombatInterfaces
{
    interface IDamage
    {
        double Damaged(double dmgRaw, string dmgType, double dmgAP = 0, bool weaponBlock = false);
    }
}
