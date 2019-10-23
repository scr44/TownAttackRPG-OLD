using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.ActorProperties;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Scenario
{
    public class CombatEvent
    {
        public CombatEvent(List<Character> playerParty, List<Actor> enemyParty, List<Actor> allyParty = null)
        {
            // generate turn order

            PlayerParty = playerParty;
            EnemyParty = enemyParty;
            AllyParty = allyParty;
        }

        public List<Character> PlayerParty { get; protected set; }
        public List<Actor> EnemyParty { get; protected set; }
        public List<Actor> AllyParty { get; protected set; }

        public Inventory Rewards { get; protected set; } = new Inventory();

        /// <summary>
        /// Format combat dialogue to output to the combat menu terminal.
        /// </summary>
        /// <param name="dialogue"></param>
        /// <returns></returns>
        public string CombatDialogue(string dialogue)
        {
            // format combat dialogue to output to the combat menu terminal
            return dialogue;
        }

        /// <summary>
        /// Format combat feedback to output to the combat menu terminal.
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public string Feedback(string feedback)
        {
            // format combat feedback to output to the combat menu terminal
            return feedback;
        }

        /// <summary>
        /// Select the party member and skill to use on the given target(s).
        /// </summary>
        /// <param name="partyMember"></param>
        /// <param name="skill"></param>
        /// <param name="target"></param>
        /// <param name="targetList"></param>
        public void PartyMemberUsesSkill(Character partyMember, Skill skill, List<Actor> targetList = null)
        {
            // use skill on targets from menu
        }

        /// <summary>
        /// The enemy uses a skill on the given target(s).
        /// </summary>
        /// <param name="enemyActor"></param>
        /// <param name="skill"></param>
        /// <param name="target"></param>
        /// <param name="targetList"></param>
        public void EnemyUsesSkill(Actor enemyActor, Skill skill, List<Actor> targetList = null)
        { 
            // put in enemy AI here
        }

        public void EnemyKilled(Actor enemyActor)
        {
            // award XP to party

            // drop loot into the "rewards" inventory
        }


    }
}
