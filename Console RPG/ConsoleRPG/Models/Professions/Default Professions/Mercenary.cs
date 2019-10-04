using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Actors.Character.Stats;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Charms;
using ConsoleRPG.Models.Items.Equipment.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Professions.Default_Professions
{
    public class Mercenary : Profession
    {
        public Mercenary(string gender="F")
        {
            Title = "Mercenary";
            Gender = GetGender(gender);
            ProfessionSummary = "Mercenaries are masters of the longsword; but constant concussions and old wounds have damaged their senses, and their social graces are lacking.";
            BaseHealth = 20;
            BaseStamina = 20;
            StartingAttributes = new BaseAttributes(
                str: 6,
                dex: 6,
                skl: 7,
                apt: 4,
                per: 2,
                cha: 3
                );
            StartingTalents = new BaseTalents(
                med: 0,
                herb: 0,
                expl: 0,
                vet: 2,
                best: 0,
                eng: 0,
                hist: 0
                );
            StartingInventory = new Inventory();
            StartingEquipment = new EquippedItems(
                main: new Longsword(),
                off: new TwoHanding(),
                body: new HalfPlate(),
                charm1: new LoversLocket(),
                charm2: new Unadorned()
                );
        }
    }
}
