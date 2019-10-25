using ConsoleRPG.Menus.Combat;
using ConsoleRPG.Models.Actors;
using ConsoleRPG.Models.Actors.ActorProperties;
using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Party;
using ConsoleRPG.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Scenario
{
    abstract public class CombatEvent
    {
        public CombatEvent(Party playerParty)
        {
            // TODO Combat Event: generate turn order
            PlayerParty = playerParty;
            CombatUI = new CombatUI((Character)playerParty.PartyMembers[0]);
        }
        
        public CombatUI CombatUI { get; protected set; }
        public Party PlayerParty { get; protected set; }
        public List<Actor> EnemyParty { get; protected set; }
        public List<Actor> AllyParty { get; protected set; }
        public Inventory Rewards { get; protected set; } = new Inventory();

        /// <summary>
        /// Format combat dialogue to output to the combat menu terminal.
        /// </summary>
        /// <param name="dialogue"></param>
        /// <returns></returns>
        public string CombatDialogue(string dialogue, Actor speaker=null)
        {
            // format combat dialogue to output to the combat menu terminal
            if (!(speaker is null))
            {
                return $"{speaker.Name} says \"{dialogue}\"";
            }
            else
            {
                return dialogue;
            }
        }
        public void Say(string dialogue, Actor speaker = null)
        {
            string text = CombatDialogue(dialogue, speaker);
            CombatUI.WriteToLog(text);
            CombatUI.Display();
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

        public abstract void Run();
        public void Pause()
        {
            ConsoleKey key = Console.ReadKey().Key;
        }
    }
}
