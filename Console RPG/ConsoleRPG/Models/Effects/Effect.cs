using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Effects
{
    public abstract class Effect
    {//TODO handle effects lasting beyond combat
        public string EffectName { get; protected set; }
        public string EffectDescrip { get; protected set; }
        public int EffectDuration { get; protected set; } // number of turns effect has remaining
        /// <summary>
        /// Dictionary of the Attribute, Talent, 
        /// </summary>
        public Dictionary<string, int> EffectStatsModified { get; protected set; }
    }
}
