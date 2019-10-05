using ConsoleRPG.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character.Stats
{
    public class Attributes
    {
        #region Attribute Descriptions
        /* 
        Strength (STR): A character's brute power. Required for heavy weapons and armor, as well as strong attacks. Affects melee attacks, weight capacity, and ability to perform physical feats.

        Dexterity (DEX): A character's finesse. Required for light weapons and agile attacks. Affects melee attacks, parry chance, and ability to perform physical feats.

        Skill (SKL): A character's level of training and precision. Unlocks advanced weapon techniques. Affects armor penetration.

        Aptitude (APT): A character's ability to learn new things quickly. Affects how much experience is gained.

        Fortitude (FOR): A character's resilience and will to survive. Affects damage PROT.

        Charisma (CHA): A character's talent at persuading others. Opens many options in dialogue.
         
        ALL attributes can be used in event/conversation checks.     
        */
        #endregion

        #region Constructors
        /// <summary>
        /// Sets all Attributes to the base level (5).
        /// </summary>
        public Attributes()
        {

        }
        /// <summary>
        /// Sets actor's base attributes to given levels.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dex"></param>
        /// <param name="skl"></param>
        /// <param name="apt"></param>
        /// <param name="fort"></param>
        /// <param name="cha"></param>
        public Attributes(Character character, int str, int dex, int skl, int apt, int fort, int cha)
        {
            this.AttachedCharacter = character;
            BaseValue["STR"] = str;
            BaseValue["DEX"] = dex;
            BaseValue["SKL"] = skl;
            BaseValue["APT"] = apt;
            BaseValue["FOR"] = fort;
            BaseValue["CHA"] = cha;
        }
        public Attributes(Character character, Dictionary<string, int> initDict)
        {
            this.AttachedCharacter = character;
            this.BaseValue = initDict;
        }
        #endregion

        public Character AttachedCharacter { get; }

        /// <summary>
        /// Dictionary of Attributes
        /// </summary>
        public Dictionary<string, int> BaseValue { get; private set; } = new Dictionary<string, int>()
        {
            { "STR", 5 },
            { "DEX", 5 },
            { "SKL", 5 },
            { "APT", 5 },
            { "FOR", 5 },
            { "CHA", 5 }
        };
        /// <summary>
        /// Dictionary of Attributes + AttributeMods
        /// </summary>
        public Dictionary<string, int> ModdedValue
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "STR", BaseValue["STR"] + (int)AttachedCharacter.EquipmentMod("STR") + (int)AttachedCharacter.EffectMod("STR") },
                    { "DEX", BaseValue["DEX"] + (int)AttachedCharacter.EquipmentMod("DEX") + (int)AttachedCharacter.EffectMod("DEX") },
                    { "SKL", BaseValue["SKL"] + (int)AttachedCharacter.EquipmentMod("SKL") + (int)AttachedCharacter.EffectMod("SKL") },
                    { "APT", BaseValue["APT"] + (int)AttachedCharacter.EquipmentMod("APT") + (int)AttachedCharacter.EffectMod("APT") },
                    { "FOR", BaseValue["FOR"] + (int)AttachedCharacter.EquipmentMod("FOR") + (int)AttachedCharacter.EffectMod("FOR") },
                    { "CHA", BaseValue["CHA"] + (int)AttachedCharacter.EquipmentMod("CHA") + (int)AttachedCharacter.EffectMod("CHA") },
                };
            }
        }

        /// <summary>
        /// Changes an Attribute by the given points.
        /// </summary>
        /// <param name="stat">STR, DEX, SKL, APT, PER, or CHA</param>
        /// <param name="points">Positive points to increase, negative points to decrease.</param>
        public void ChangeAttribute(string stat, int points)
        {
            if (BaseValue.ContainsKey(stat))
            {
                stat = stat.ToUpper();
                BaseValue[stat] += points;
            }
            else
            {
                throw new ArgumentException("Tried to change an invalid Attribute.");
            }
        }
    }
}
