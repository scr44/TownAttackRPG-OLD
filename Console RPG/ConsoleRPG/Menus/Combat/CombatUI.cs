using ConsoleRPG.Models.Actors.Characters;
using ConsoleRPG.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Menus.Combat
{
    public class CombatUI
    {
        public CombatUI(Character player)
        {
            Player = player;
        }
        Character Player { get; }

        int MaxBarLength = 40;
        string HPbar
        {
            get
            {
                int fillLength = (int)(MaxBarLength * Player.HP.Percent * 0.01);
                string bar = new string('=', fillLength) + new string(' ', MaxBarLength - fillLength);
                return bar;
            }
        }
        string SPbar
        {
            get
            {
                int fillLength = (int)(MaxBarLength * Player.SP.Percent * 0.01);
                string bar = new string(' ', MaxBarLength - fillLength) + new string('=', fillLength);
                return bar;
            }
        }
        string MainHand
        {
            get
            {
                return Player.Equipment.Slot["MainHand"].ItemName;
            }
        }
        string OffHand
        {
            get
            {
                return Player.Equipment.Slot["OffHand"].ItemName;
            }
        }
        List<string> skillNames
        {
            get
            {
                List<string> names = new List<string>();
                foreach (KeyValuePair<int, string> skill in Player.Skillbar.SkillNames)
                {
                    names.Add(skill.Value);
                }
                return names;
            }
        }

        List<string> CombatLog { get; set; } = new List<string>(14)
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        List<string> TargetingMenu { get; set; } = new List<string>(14)
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        public void WriteToLog(string text, int line=14)
        {
            if (line == 14)
            {
                CombatLog.RemoveAt(0);
                CombatLog.Add(text);
            }
            else
            {
                CombatLog[line] = text;
            }
        }

        public string AssembleHUD()
        {
            string HUD = "";
            HUD +=  "+-----------------------------------------------------------------------------------------------------+" + "\n";
            for (int i=0; i<14; i++)
            {
                HUD += $"| {CombatLog[i],-80}" + " | " + $"{TargetingMenu[i],-17}|\n";
            }
            HUD +=  "+-----------------------------------------------------------------------------------------------------+" + "\n";
            HUD += $"{new string(' ', 20)}HP{new string(' ', 32)}SP" + "\n";
            HUD += $"+----------------------------------------+ +----------------------------------------+ +----------------+" + "\n";
            HUD += $"|{HPbar,-40}" +                        $"| |{SPbar,-40}|" +                         " | Main Hand      |" + "\n";
            HUD += $"+----------------------------------------+ +----------------------------------------+ | Main Hand      |" + "\n";
            HUD += $"+-----------------------------------------------------------------------------------+ | {MainHand,-15}|" + "\n";
            HUD += $"|      1      |      2      |      3      |      4      |      5      |      6      | | {OffHand,-15}  | " + "\n";
            HUD += $"|{skillNames[0],-13}|{skillNames[1],-13}|{skillNames[2],-13}|{skillNames[3],-13}|{skillNames[4],-13}|{skillNames[5],-13}|                |" + "\n";
            return HUD;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(AssembleHUD());
        }
    }
}
