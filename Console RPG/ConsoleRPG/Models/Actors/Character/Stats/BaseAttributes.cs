using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character.Stats
{
    public class BaseAttributes
    {
        #region Attribute Descriptions
        /* 
        Strength (STR): A character's brute power. Required for heavy weapons and armor, as well as strong attacks. Affects melee attacks, weight capacity, and ability to perform physical feats.

        Dexterity (DEX): A character's finesse. Required for light weapons and agile attacks. Affects melee attacks, parry chance, and ability to perform physical feats.

        Skill (SKL): A character's level of training and precision. Unlocks advanced weapon techniques. Affects armor penetration.

        Aptitude (APT): A character's ability to learn new things quickly. Affects how much experience is gained.

        Perception (PER): A character's skill at thinking ahead and sensory abilities. Improves the effectiveness of items.

        Charisma (CHA): A character's talent at persuading others. Opens many options in dialogue.
         
        ALL attributes can be used in event/conversation checks.     
        */
        #endregion

        #region Constructors
        /// <summary>
        /// Sets all Attributes to the base level (5).
        /// </summary>
        public BaseAttributes()
        {

        }
        /// <summary>
        /// Sets base attributes to given levels.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dex"></param>
        /// <param name="skl"></param>
        /// <param name="apt"></param>
        /// <param name="per"></param>
        /// <param name="cha"></param>
        public BaseAttributes(int str, int dex, int skl, int apt, int per, int cha)
        {
            ValueDict["STR"] = str;
            ValueDict["DEX"] = dex;
            ValueDict["SKL"] = skl;
            ValueDict["APT"] = apt;
            ValueDict["PER"] = per;
            ValueDict["CHA"] = cha;
        }
        #endregion

        /// <summary>
        /// Dictionary of Attributes.
        /// </summary>
        public Dictionary<string, int> ValueDict { get; private set; } = new Dictionary<string, int>()
        {
            { "STR", 5 },
            { "DEX", 5 },
            { "SKL", 5 },
            { "APT", 5 },
            { "PER", 5 },
            { "CHA", 5 }
        };

        /// <summary>
        /// Changes an Attribute by the given points.
        /// </summary>
        /// <param name="stat">STR, DEX, SKL, APT, PER, or CHA</param>
        /// <param name="points">Positive points to increase, negative points to decrease.</param>
        public void ChangeAttribute(string stat, int points)
        {
            stat = stat.ToUpper();
            ValueDict[stat] += points;
        }
    }
}
