﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Actors.Character.Stats
{
    public class BaseTalents
    {
        #region Talent Descriptions
        /* 
        Medicine: The art of healing wounds and diagnosing injuries.

        Herbalism: Knowledge of herbs and the crafting of poultices and elixirs.

        Explosives: The knowledge to craft throwable weapons.

        Veterancy: Skill at identifying human enemies.Bonuses against human opponents, and can unlock special event actions.

        Bestiary: Skill at identifying beasts. Bonuses against beast enemies, and can unlock special event actions.

        Engineering: Skill at operating and understanding machines. Bonuses against mechanical enemies, and can unlock special event actions.

        History: Skill at identifying monsters and ancient relics. Bonuses against monsters, and can unlock special event actions.
        */
        #endregion

        #region Constructors
        public BaseTalents() { }
        public BaseTalents(int med, int herb, int expl, int vet, int best, int eng, int hist)
        {
            ValueDict["Medicine"] = med;
            ValueDict["Herbalism"] = herb;
            ValueDict["Explosives"] = expl;
            ValueDict["Veterancy"] = vet;
            ValueDict["Bestiary"] = best;
            ValueDict["Engineering"] = eng;
            ValueDict["History"] = hist;
        }
        #endregion

        /// <summary>
        /// Dictionary of Talents.
        /// </summary>
        public Dictionary<string, int> ValueDict { get; private set; }
            = new Dictionary<string, int>()
                {
                    { "Medicine", 0 },
                    { "Herbalism", 0 },
                    { "Explosives", 0 },
                    { "Veterancy", 0 },
                    { "Bestiary", 0 },
                    { "Engineering", 0 },
                    { "History", 0 }
                };

        /// <summary>
        /// Changes a Talent by the given number of points.
        /// </summary>
        /// <param name="stat">Medicine, Speech, Herbalim, BombCrafting, Bestiary, Veterancy, Engineering, or History.</param>
        /// <param name="points">Positive points to increase, negative points to decrease.</param>
        public void ChangeTalent(string stat, int points)
        {
            stat = stat.ToLower();
            ValueDict[stat] += points;
        }
    }
}
