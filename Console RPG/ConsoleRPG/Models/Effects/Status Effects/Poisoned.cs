using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Effects.EffectInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects.Status_Effects
{
    public class Poisoned : Effect, IPoison
    {
        public Poisoned(int duration, int dmg, Actor target)
        {
            EffectName = "Poisoned";
            EffectDescrip = "Takes poison damage over time.";
            Duration = duration;
            Target = target;
            DMG = dmg;
        }
        int DMG;

        public void PoisonDamage(Actor target, int dmg)
        {
            // target.TakeDamage("poison", dmg);
            // TODO add TakeDamage method to Actor class
        }

        public override void TickEffect()
        {
            PoisonDamage(Target, DMG);
            base.TickEffect();
        }
    }
}
