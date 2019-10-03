using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors
{
    public abstract class Actor
    {
        // TODO consider making these all an interface later
        public virtual void TakeHit(string dmgType, int dmg, double ap) { }
        public virtual void TakeHpDmg(int dmg) { }
        public virtual void RestoreHp(int hp) { }
    }
}
