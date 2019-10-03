using ConsoleRPG.Models.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects.EffectInterfaces
{
    interface IPoison
    {
        void PoisonDamage(Actor target, int dmg);
    }
}
