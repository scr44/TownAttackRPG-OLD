using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Combat
{
    interface IAttack
    {
        double EquipmentDmgMultiplier(string dmgType);
        double EffectDmgMultiplier(string dmgType);
        double Bonus2HScaling(string dmgType, bool is2H);
        double DmgMULT(string dmgType);

        
    }
}
