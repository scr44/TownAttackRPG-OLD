using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects.EffectInterfaces
{
    interface IStatBuffOrDebuff
    {
        void AdjustStatMod(string stat, double points);
    }
}
