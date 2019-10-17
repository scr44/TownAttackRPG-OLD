using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Skills
{
    abstract public class Skill
    {
        public Skill(Actor self)
        {
            this.Self = self;
            // set all the requirements in the constructor
        }

        #region Tags and Metadata
        abstract public string SkillName { get; }
        abstract public string ShortDescrip { get; }
        abstract public string FullDescrip { get; } // interpolated with dmg amounts etc
        abstract public List<string> SkillTags { get; }
        public Actor Self { get; }
        #endregion

        #region Skill Requirements
        abstract public Dictionary<string, int> SkillStatReqs { get; }
        abstract public Dictionary<string, bool> SkillEquipmentReqs { get; }
        abstract public List<string> SkillProfessionReqs { get; } //  if Profession.Name is in list
        abstract public bool Skill2HReq { get; }

        abstract public bool MeetsSkillReqs { get; }
        #endregion

        #region Targeting and Behavior
        virtual public void OnTarget(Actor target)
        { }
        virtual public void OnSelf()
        { }
        virtual public void OnMany(List<Actor> targetList)
        { }
        #endregion

        /// <summary>
        /// Uses the skill. Leave args empty if the skill is only self-targeting.
        /// </summary>
        /// <param name="target">The target for single target effects.</param>
        /// <param name="targetList">The list of targets for multi-target effects.</param>
        abstract public void Use(Actor target = null, List<Actor> targetList = null);
        // if not ready, return "SkillNotReady" exception.
        // if skill reqs met, activate skill; else, return a "ReqsNotMet" exception.

        #region Cooldown and Stamina
        public int CooldownMax { get; }
        public int Cooldown { get; private set; }
        public void StartCD()
        {
            Cooldown = CooldownMax;

        }
        public void TickCD()
        {
            if (Cooldown > 0)
            {
                Cooldown--;
            }
        }

        public int SPCost { get; }

        public bool Ready
        {
            get
            {
                return (Cooldown == 0) && (SPCost <= Self.SP.Current);
            }
        }
        public void ActivateSkill()
        {
            StartCD();
            Self.SP.AdjustSP(-SPCost);
        }
        #endregion
    }
}
