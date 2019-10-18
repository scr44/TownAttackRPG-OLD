using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Skills;

namespace ConsoleRPG.Models.Skills.Techniques.Swords
{
    public class DoubleSlash : Skill
    {
        public DoubleSlash(Actor self) : base(self)
        {
            #region Tags and Metadata
            base.SkillName = "Double Slash";
            base.ShortDescrip = "Make two slashes in quick succession.";
            base.SkillTags = new List<string>() { "Sword", "Technique", "Two-Handed", "Physical", "Attack" };
            #endregion

            #region Cooldown and Stamina
            base.CooldownMax = 0;
            base.SPCost = 5;
            #endregion

            #region Requirements
            base.SkillProfessionReqs = new List<string>() { "Knight" };
            base.SkillStatReqs = null;
            base.SkillEquipmentTagReqs = new List<string>() { "Sword" };
            #endregion
        }

        #region Interpolated Description
        public override string FullDescrip 
            => $"Two-handed Knightly Sword Technique: " +
            $"Attack twice, dealing {1 * Self.DMG("slash")} slashing damage each time.";
        #endregion

        #region Targeting and Behavior
        override public void OnTarget(Actor target)
        {
            target.Damaged(1 * Self.DMG("slash"), "slash"); // TODO Skill: add AP arg
            target.Damaged(1 * Self.DMG("slash"), "slash");
        }
        #endregion

        public override void Use(Actor target, List<Actor> targetList = null)
        {
            base.Use(); // Checks for ready & skill reqs, then takes stamina and starts cooldown
            OnTarget(target);
        }
    }
}
