using ConsoleRPG.Models.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects
{
    public abstract class Effect
    {//TODO handle effects lasting beyond combat
        public List<string> EffectKeywords { get; protected set; } = new List<string>();

        public string EffectName { get; protected set; }
        public string EffectDescrip { get; protected set; }
        /// <summary>
        /// Number of ticks an effect has remaining.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The target of the effect.
        /// </summary>
        public Actor Target { get; protected set; }
        /// <summary>
        /// Dictionary of the Attribute, Talent, Charm, and other stats modified by the Effect.
        /// </summary>
        public Dictionary<string, int> EffectStatsModified { get; protected set; }

        public virtual void TriggerEffect()
        {

        } // TODO 03: build an Effect with a triggered function (eg next attack skill costs less AP)
        public virtual void TickEffect()
        {
            Duration -= 1;
        }
    }
}
