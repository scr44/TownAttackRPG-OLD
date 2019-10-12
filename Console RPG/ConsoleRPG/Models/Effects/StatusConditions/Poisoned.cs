using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
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
            EffectTags.Add("Status Condition");
            EffectTags.Add("Negative Condition");
            EffectTags.Add("Damage Over Time");

            EffectName = "Poisoned";
            EffectDescrip = "Takes poison damage over time.";
            Duration = duration;
            Target = target;
            DMG = dmg;
        }

        int DMG { get; }

        public void PoisonDamage(Actor target, int dmg)
        {
            target.Damaged(DMG, "poison", 0);
        }

        public override void TickAction()
        {
            PoisonDamage(Target, DMG);

            base.TickAction();
        }
    }
}
