using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Models.Character.Stats;
using ConsoleRPG.Models.Items.Equipment;
using ConsoleRPG.Models.Items.Equipment.Body;
using ConsoleRPG.Models.Items.Equipment.Hands;
using ConsoleRPG.Models.Items.Equipment.Charms;

namespace ConsoleRPG.Models.Character.Professions.Default_Professions
{
    public class Mercenary : Profession
    {
        public Mercenary()
        {
            Title = "Mercenary";
            ProfessionSummary = "A veteran fighter for hire. She is a master of the longsword; but constant concussions and old wounds have damaged her senses, and her social graces are lacking.";
            Gender = "Female";
            BaseHealth = 20;
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
