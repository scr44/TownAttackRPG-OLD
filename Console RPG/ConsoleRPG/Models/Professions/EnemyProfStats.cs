using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Professions
{
    public class EnemyProfStats : Profession
    {
        public EnemyProfStats(int baseHP, int baseSP, int SPRegen)
        {
            BaseHealth = baseHP;
            BaseStamina = baseSP;
            BaseStaminaRegen = SPRegen;
        }
    }
}
