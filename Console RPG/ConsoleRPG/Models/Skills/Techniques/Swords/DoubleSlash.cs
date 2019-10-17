using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Skills;

namespace ConsoleRPG.Models.Skills.Techniques.Swords
{
    public class DoubleSlash : Skill
    {
        public DoubleSlash(Actor self)
        {
            this.Self = self;
        }

        #region Tags and Metadata
        public override string SkillName { get; } = "Double Slash";
        public override string ShortDescrip { get; } = "Make two slashes in quick succession.";
        public override string FullDescrip
        {
            get
            {
                return $"Deal {1 * Self.DMG("slash")} slashing damage twice.";
            }
        }

        public override List<string> SkillTags => throw new NotImplementedException();

        public Actor Self { get; }
        #endregion

        #region Skill Requirements
        public override Dictionary<string, int> SkillStatReqs => throw new NotImplementedException();

        public override Dictionary<string, bool> SkillEquipmentReqs => throw new NotImplementedException();

        public override List<string> SkillProfessionReqs => throw new NotImplementedException();

        public override bool Skill2HReq => throw new NotImplementedException();

        public override bool MeetsSkillReqs => throw new NotImplementedException();
        #endregion

        #region Targeting and Behavior
        override public void OnTarget(Actor target)
        {
            target.Damaged(1 * Self.DMG("slash"), "slash"); // TODO Skill: add AP arg
            target.Damaged(1 * Self.DMG("slash"), "slash");
        }
        #endregion

        public override void Use(Actor target = null, List<Actor> targetList = null)
        {
            OnTarget(target);
            
        }
    }
}
