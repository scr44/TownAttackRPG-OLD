using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors.Characters.Stats;
using ConsoleRPG.Models.Actors.CombatInterfaces;

namespace ConsoleRPG.Models.Actors.Enemies.Unaffiliated
{
    public class TrainingDummy : Enemy
    {
        public TrainingDummy(int baseHP, int baseSP, int SPRegen, string name="Training Dummy") 
            : base(baseHP, baseSP, SPRegen, name)
        {
            // base.Skillbar fills here
        }

        public override double DMG(string dmgType)
        {
            return 0;
        }
        public override double PROT(string dmgType, bool weaponBlock)
        {
            return 0;
        }

        override public void Damaged(double dmgRaw, string dmgType, double dmgAP = 0)
        {
            this.HP.AdjustHP(-dmgRaw);
        }
    }
}
