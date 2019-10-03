using ConsoleRPG.Models.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects
{
    public abstract class Effect
    {//TODO handle effects lasting beyond combat
        public string EffectName { get; protected set; }
        public string EffectDescrip { get; protected set; }
        public int Duration { get; protected set; } // number of turns effect has remaining
        public Actor Target { get; protected set; }
        /// <summary>
        /// Dictionary of the Attribute, Talent, 
        /// </summary>
        public Dictionary<string, int> EffectStatsModified { get; protected set; }

        public virtual void TickEffect()
        {
            Duration -= 1;
        }
    }
}
