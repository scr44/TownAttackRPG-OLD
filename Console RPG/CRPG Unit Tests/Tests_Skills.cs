using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Actors.Enemies.Unaffiliated;
using ConsoleRPG.Models.Professions.DefaultProfessions;
using ConsoleRPG.Models.Skills;
using ConsoleRPG.Models.Skills.Techniques.Swords;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skills
{
    [TestClass]
    public class Activation
    {
        [TestMethod]
        public void UseAttackSkill()
        {
            // create a knight
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // attach the "double slash" skill directly to the character (not going through skillbar here)
            DoubleSlash knightSkill = new DoubleSlash(Guinevere);
            Assert.IsTrue(knightSkill.SkillTags.Contains("Attack"), "Double Slash should be an Attack skill");

            // make a training dummy
            TrainingDummy dummy = new TrainingDummy(100,10,10);

            // knight uses skill to attack the dummy
            try
            {
                knightSkill.Use(dummy);
                Assert.IsTrue(true, "Attack skill should activate successfully.");
            }
            catch(Exception e)
            {
                Assert.IsFalse(true, e.Message);
            }
        }
        [TestMethod]
        public void AttackSkillDamage()
        {
            // create a knight
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // attach the "double slash" skill directly to the character (not going through skillbar here)
            DoubleSlash knightSkill = new DoubleSlash(Guinevere);

            // make a training dummy
            TrainingDummy dummy = new TrainingDummy(100, 10, 10);

            // attack the dummy
            knightSkill.Use(dummy);

            // dummy HP should be lower
            Assert.IsTrue(dummy.HP.Current < dummy.HP.Max, "Dummy should have lost health.");
        }
    }

    [TestClass]
    public class Requirements
    {
        [TestMethod]
        public void CheckProfession()
        {
            // create a knight
            Character Guinevere = new Character("Guinevere", new Knight("F"));

            // create a footman
            Character Gilliam = new Character("Gilliam", new Footman("M"));

            // attach the "double slash" skill directly to the characters (not going through skillbar here)
            DoubleSlash knightSkill = new DoubleSlash(Guinevere);
            DoubleSlash footmanSkill = new DoubleSlash(Gilliam);

            // "double slash" should be a Knight-restricted skill
            Assert.IsTrue(knightSkill.SkillProfessionReqs.Contains("Knight"), "Double Slash should be a Knight-only skill.");

            // have the knight use the skill on the footman
            try
            {
                knightSkill.Use(Gilliam);
                Assert.IsTrue(true, "Knight should use the skill successfully.");
            }
            catch(SkillReqsNotMetException)
            {
                Assert.IsFalse(true, "Knight should meet skill requirements.");
            }

            // have the footman try to use the skill on the knight
            try
            {
                footmanSkill.Use(Guinevere);
                Assert.IsFalse(true, "Footman should be unable to use the skill.");
            }
            catch(SkillReqsNotMetException)
            {
                Assert.IsTrue(true, "Footman should not meet the skill requirements.");
            }
        }

        // TODO Test: Check Skill Req
        // TODO Test: Check 2H Req
        // TODO Test: Check Equipment Req
    }
    
}
