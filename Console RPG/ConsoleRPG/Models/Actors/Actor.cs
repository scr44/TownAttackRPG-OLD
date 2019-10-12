using ConsoleRPG.Models.Actors.Characters.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors
{
    public abstract class Actor
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

        #region Offense
        virtual public double DMG(string dmgType)
        {
            return 1.0; // Actors default to having no damage multiplier
        }
        #endregion

        #region Defense
        virtual public double PROT(string dmgType)
        {
            return 1.0; // Actors default to having no damage protection
        }
        #endregion

        #region Combat Functions
        virtual public void Damaged(double dmgRaw, string dmgType, double dmgAP = 0.00)
        {
            
        }
        virtual public void Healed(double healAmt)
        {
            
        }
        #endregion
    }
}
