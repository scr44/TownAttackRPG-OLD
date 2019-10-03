using ConsoleRPG.Models.Actors.Character;
using ConsoleRPG.Models.Professions.Default_Professions;
using ConsoleRPG.Models.Items;
using ConsoleRPG.Models.Items.Equipment;
using System;
using System.Collections.Generic;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Guinevere = new Character("Guinevere", new Mercenary());

            Console.WriteLine($"{Guinevere.Name} is a {Guinevere.Gender.ToLower()} {Guinevere.Profession.Title.ToLower()}: {Guinevere.Profession.ProfessionSummary}");
            Console.WriteLine("\nHer attributes are:");
            foreach(KeyValuePair<string,int> stat in Guinevere.BaseAttributes.Attr)
            {
                Console.WriteLine($"{stat.Key}: {Guinevere.BaseAttributes.Attr[stat.Key]}");
            }
            Console.WriteLine("\nShe is currently using the following equipment:");
            Guinevere.CheckEquipment();

            Console.WriteLine("\nIf she stops two-handing her weapon, her equipment looks like this:");
            Guinevere.Toggle2H();
            Guinevere.CheckEquipment();

            Console.WriteLine("\nWhen she puts her sword away, her equipment looks like this:");
            Guinevere.Unequip("MainHand");
            foreach (KeyValuePair<string, Equipment> equipment in Guinevere.EquippedItems.Equipped)
            {
                Console.WriteLine($"{equipment.Key}: {equipment.Value.ItemName} - {equipment.Value.ItemDescrip}\n");
            }
            Console.WriteLine("\nand the sword is back in her inventory:");
            Guinevere.CheckInventory();

            Console.WriteLine("\nIf she tries to two-hand her fist, it doesn't work:");
            Guinevere.Toggle2H();
            Guinevere.CheckEquipment();

            Console.WriteLine("\nShe has to re-equip her sword first. Then, she can go back to two-handing it.");
            //Guinevere.Equip("MainHand", Guinevere.Inventory.InvList[0]); // TODO fix equipping items from inventory

            Console.ReadLine();
        }
    }
}
