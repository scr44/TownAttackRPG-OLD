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
                    return "his";
                }
                else if (Gender == "Female")
                {
                    return "her";
                }
                else
                {
                    return "its";
                }
            }
        }
        public string HisHers
        {
            get
            {
                if (Gender == "Male")
                {
                    return "his";
                }
                else if (Gender == "Female")
                {
                    return "hers";
                }
                else
                {
                    return "its";
                }
            }
        }
        public string HeShe
        {
            get
            {
                if (Gender == "Male")
                {
                    return "he";
                }
                else if (Gender == "Female")
                {
                    return "she";
                }
                else
                {
                    return "it";
                }
            }
        }
        public string GenderAdjective
        {
            get
            {
                if (Gender == "Male")
                {
                    return " male";
                }
                else if (Gender == "Female")
                {
                    return " female";
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
        // TODO consider making these all an interface later
        public virtual void TakeHit(string dmgType, int dmg, double ap) { }
        public virtual void TakeHpDmg(int dmg) { }
        public virtual void RestoreHp(int hp) { }
    }
}
