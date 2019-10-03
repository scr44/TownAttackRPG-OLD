using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Effects.EffectInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects.StatusConditions
{
    public class Poisoned : Effect, IPoison
    {
        public Poisoned(int duration, int dmg, Actor target)
        {
            EffectKeywords.Add("Status Condition");
            EffectKeywords.Add("Negative Condition");
            EffectKeywords.Add("Damage Over Time");

            EffectName = "Poisoned";
            EffectDescrip = "Takes poison damage over time.";
            Duration = duration;
            Target = target;
            DMG = dmg;
        }

        int DMG;

        public void PoisonDamage(Actor target, int dmg)
        {
            target.TakeHit("poison", dmg, 0);
        }

        public override void TickEffect()
        {
            PoisonDamage(Target, DMG);
            base.TickEffect();
        }
    }
}
