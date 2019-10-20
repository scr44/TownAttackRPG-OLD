using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Actors.CombatInterfaces;
using ConsoleRPG.Models.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors
{
    public abstract class Actor : IDamage
    {
        public string Gender { get; set; }
        #region Pronouns
        // Pronouns for string interpolation in events and combat
        public string HisHer
        {
            get
            {
                if (Gender == "Male")
                {
                    return "His";
                }
                else if (Gender == "Female")
                {
                    return "Her";
                }
                else
                {
                    return "Its";
                }
            }
        }
        public string HisHers
        {
            get
            {
                if (Gender == "Male")
                {
                    return "His";
                }
                else if (Gender == "Female")
                {
                    return "Hers";
                }
                else
                {
                    return "Its";
                }
            }
        }
        public string HeShe
        {
            get
            {
                if (Gender == "Male")
                {
                    return "He";
                }
                else if (Gender == "Female")
                {
                    return "She";
                }
                else
                {
                    return "It";
                }
            }
        }
        #endregion

        #region Health, Stamina
        public bool IsAlive
        {
            get
            {
                return HP.Current > 0;
            }
        }
        abstract public Health HP { get; protected set; }
        abstract public Stamina SP { get; protected set; }

        virtual public void Damaged(double dmgRaw, string dmgType, double dmgAP = 0)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Active Effects
        public ActiveEffects ActiveEffects { get; protected set; } = new ActiveEffects();
        virtual public double EffectMod(string stat)
        {
            double mod = 0;
            foreach (Effect effect in this.ActiveEffects.EffectList)
            {
                if (effect.StatMod.ContainsKey(stat))
                {
                    mod += effect.StatMod[stat];
                }
            }
            return mod;
        }
        #endregion

        #region Offense
        abstract public double DMG(string dmgType);
        public double ArmorPiercing = 0;
        #endregion

        #region Defense
        abstract public double PROT(string dmgType, bool weaponBlock);
        #endregion
    }
}
