﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Menus.Startup
{
    public class ProfessionMenu : Menu
    {
        public string Title = @"

                                                    ==========================
                    F1: Attribute   F2: Talent      = Choose Your Profession =               
                          Info           Info       ==========================                 
";

        public string MenuOptions = @"

    Knight                          
                                    

    Scholar                         
                                
                                
    Noble


    Constable


    Footman


    Plague Doctor


    Squire


    Barmaid


    Huntress

    
    Convict


    Blacksmith


        ?

";
        public string KnightSelected = @"
  ==========
  | Knight |             Knights are masters of the longsword clad in sturdy plate armor; but they often 
  ==========                        
                         neglect their academic studies in favor of drinking and skirt-chasing.
    Scholar                         
                                
                                
    Noble
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 7            Medicine: 0         * Longsword             * Coins x800                     
                                                                                                    
                           DEX: 7            Explosives: 0       * Plate Armor           * Memento x1                          
    Footman
                           SKL: 7            Veterancy: 2        * Lover's Locket                     

    Plague Doctor          APT: 2            Bestiary: 0                                                           
                                                                                                    
                           FOR: 6            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 4            History: 0
                                                                                                    
    Barmaid
                         Tips: You will be a powerful combatant from the beginning of the game to the end, but
                                                                                                    
    Huntress                   your growth potential is limited compared to other classes. Try to reach the end
                                                                                                    
                               quickly, before the enemies begin to outpace you.                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string ScholarSelected = @"
            
    Knight               Scholars are quick learners and widely knowledgeable, but spend more time reading books  
                                    
  ===========            than on physical pursuits.                    
  | Scholar |                       
  ===========                     
                                
    Noble
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 2            Medicine: 1         * History Tome          * Coins x400                     
                                                                                                    
                           DEX: 2            Explosives: 0       * Clothing              * Diploma x1                          
    Footman
                           SKL: 3            Veterancy: 0        * Quill and Inkwell                  

    Plague Doctor          APT: 9            Bestiary: 1                                                           
                                                                                                    
                           FOR: 3            Engineering: 1                                           
    Squire                                                                                                    
                           CHA: 3            History: 2
                                                                                                    
    Barmaid
                         Tips: The scholar is very weak at the start of the game, but will quickly ramp up in power.
                                                                                                    
    Huntress                   Rely on your teammates until you have some experience under your belt.
                                                                                                    
                                                                                                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string NobleSelected = @"
            
    Knight               Wealthy and fashionable, this member of the noble class is well-educated in the art of oration.   
                                    
                         They have some training as a duelist, but have never been in a real fight.
    Scholar                         
                                  
  =========                     
  | Noble |
  =========              Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 3            Medicine: 0         * Rapier                * Coins x3000                    
                                                                                                    
                           DEX: 5            Explosives: 0       * Fancy Clothing                                              
    Footman
                           SKL: 7            Veterancy: 0        * Ladybug Brooch                 

    Plague Doctor          APT: 5            Bestiary: 0         * Heirloom Ring                                   
                                                                                                    
                           FOR: 3            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 8            History: 2
                                                                                                    
    Barmaid
                         Tips: Discretion is the better part of valor, and the rewards for resolving situations
                                                                                                    
    Huntress                   without violence can be better than simply bludgeoning your way through. If 
                                                                                                    
                               diplomacy fails, stick them with the pointy end.      
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string ConstableSelected = @"
            
    Knight               The town's venerable lawman. Knows his way around locks and is well-versed in breaking up    
                                    
                         bar brawls. The stiffness of age is beginning to set in.                    
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
  =============                                                                                     
  | Constable |            STR: 6            Medicine: 0         * Truncheon             * Coins x1000                    
  =============                                                                                     
                           DEX: 3            Explosives: 0       * Studded Gauntlet      * Healing Elixir x 5     
    Footman
                           SKL: 6            Veterancy: 1        * Constable Uniform              

    Plague Doctor          APT: 4            Bestiary: 0         * Lawman's Badge                                  
                                                                                                    
                           FOR: 5            Engineering: 1                                           
    Squire                                                                                                    
                           CHA: 5            History: 0
                                                                                                    
    Barmaid
                         Tips: Use your gauntlet to chain stun effects on enemies, while your teammates finish them
                                                                                                    
    Huntress                   off. Mark enemies to let you and your teammates deal extra damage to them.
                                                                                                    
                                                                                                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string FootmanSelected = @"
            
    Knight               A recently retired soldier. Lethal with a spear and shield, but his time int he military     
                                    
                         left him rather uncouth. Can still hold his own, but old wounds slow him down.
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 4            Medicine: 0         * Spear                 * Coins x700                     
                                                                                                    
  ===========              DEX: 2            Explosives: 0       * Heater Shield         * Healing Elixir x 5     
  | Footman |
  ===========              SKL: 7            Veterancy: 3        * Gambeson                      

    Plague Doctor          APT: 4            Bestiary: 0         * Medal of Service                              
                                                                                                    
                           FOR: 7            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 3            History: 0
                                                                                                    
    Barmaid
                         Tips: The spear does relatively little base damage, but has a high critical multiplier.
                                                                                                    
    Huntress                   Find weak points in your enemies' armor and finish them with a single strike.
                                                                                                    
                                                                                                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string PlagueDoctorSelected = @"
            
    Knight               This traveling surgeon wears an unsettling beak-shaped mask and goggles. Her cures are of    
                                    
                         dubious merit, but the efficacy of her poisons is inarguable.               
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 4            Medicine: 3         * Knife                 * Coins x700                     
                                                                                                    
                           DEX: 3            Explosives: 0       * Bare Hand             * Poison Ointment x5    
    Footman  
                           SKL: 6            Veterancy: 0        * Thick Robes                    
  =================
  | Plague Doctor |        APT: 5            Bestiary: 2         * Beaked Mask                                     
  =================                                                                                 
                           FOR: 6            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 2            History: 0
                                                                                                    
    Barmaid
                         Tips: Use thrown vials and poisoned weapons to stack damage effects on enemies. Keep
                                                                                                    
    Huntress                   teammates healthy with your abilities.
                                                                                                    
                                                                                                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string SquireSelected = @"
            
    Knight               A young farmboy from one of the surrounding villages, passing through town on his way to     
                                    
                         become a squire at the castle. Energetic, but clumsy.                       
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 5            Medicine: 0         * Family Sword          * Coins x100                     
                                                                                                    
                           DEX: 5            Explosives: 0       * Hand-Me-Down Shield   * Packed Lunch x10    
    Footman  
                           SKL: 2            Veterancy: 0        * Clothing                       
                   
    Plague Doctor          APT: 4            Bestiary: 2         * Sweetheart's Bracelet                           
                                                                                                    
  ==========               FOR: 5            Engineering: 0                                           
  | Squire |                                                                                                  
  ==========               CHA: 5            History: 0
                                                                                                    
    Barmaid
                         Tips: Exploit the squire's high energy regeneration to use cheap skills repeatedly   
                                                                                                    
    Huntress                   and defeat enemies before they can get around your shield.
                                                                                                    
                                                                                                        
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string BarmaidSelected = @"
            
    Knight               The charming young barmaid from the local tavern. Strong, fast, and possessing a seemingly  
                                    
                         endless supply of drink, but has no combat training whatsoever.             
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 7            Medicine: 0         * Frying Pan            * Coins x250                     
                                                                                                    
                           DEX: 6            Explosives: 0       * Barmaid's Blouse      * Bottomless Beer Mug 
    Footman  
                           SKL: 1            Veterancy: 0        * Drinking Contest Trophy        
                   
    Plague Doctor          APT: 4            Bestiary: 0                                                           
                                                                                                    
                           FOR: 3            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 8            History: 0
  ===========                                                                                       
  | Barmaid |
  ===========            Tips: You have an endless supply of free healing that causes the drunk status effect.
                                                                                                    
    Huntress                   Trade hits with enemies while drunk to reduce damage taken and increase your own.
                                                                                                    
                               If combat drags on for too long, you may become too drunk to fight effectively.
    Convict
                                                                                                    
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string HuntressSelected = @"
            
    Knight               A dangerous huntress from the wildling tribes of the forest. Knows how to trap and slay     
                                    
                         any wild creature, but has no understanding of civilized society.          
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 4            Medicine: 0         * Hunter's Paired Axe   * Mushroom Brew x10              
                                                                                                    
                           DEX: 8            Explosives: 0       * Hunter's Paired Axe   * Herbal Poultice x5  
    Footman  
                           SKL: 7            Veterancy: 0        * Wildling Rags         * Witch's Ointment x5 
                   
    Plague Doctor          APT: 5            Bestiary: 3         * Beast Skull Necklace  * Pungent Nuts x5         
                                                                                                    
                           FOR: 4            Engineering: 0                                           
    Squire                                                                                                    
                           CHA: 1            History: 0
                                                                                                    
    Barmaid  
                         Tips: Your paired axes are deadly, allowing you to attack twice per skill use. Imbibing 
  ============                                                                                      
  | Huntress |                 mushroom brew will send you into a savage fury, during which you can wipe out    
  ============                                                                                      
                               even heavily-armored opponents with your axes, but you only have ten of them. Use
    Convict
                               your items wisely to remove status effects and heal.                
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string ConvictSelected = @"
            
    Knight               A thief arrested while trying to steal horses, now on their way to the gallows. Weak, but   
                                    
                         exceptionally fast and clever.                                             
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 2            Medicine: 0         * Paired Dagger         * Empty                          
                                                                                                    
                           DEX: 9            Explosives: 0       * Paired Dagger                               
    Footman  
                           SKL: 5            Veterancy: 1        * Prisoner's Chains                           
                   
    Plague Doctor          APT: 7            Bestiary: 2         * Lucky Rabbit's Paw                              
                                                                                                    
                           FOR: 3            Engineering: 2                                           
    Squire                                                                                                    
                           CHA: 4            History: 0
                                                                                                    
    Barmaid  
                         Tips: The thief's stamina regenerates more quickly than any other class. Use this to attack
                                                                                                    
    Huntress                   enemies with high-damaging skills every turn. Your daggers have a high critical multiplier
                                                                                                    
  ===========                  that can make up for their low base damage.                                        
  | Convict |
  ===========                                                                                      
                                                                                                    
    Blacksmith
                                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string BlacksmithSelected = @"
            
    Knight               The town blacksmith is incredibly strong, and knows every weak point that armor can have.   
                                    
                         However, he is slow to move, and has a gruff demeanor.                     
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 9            Medicine: 0         * Blacksmith's Hammer   * Coins x1200                   
                                                                                                    
                           DEX: 2            Explosives: 1       * Bare Hand             * Healing Elixir x5   
    Footman  
                           SKL: 7            Veterancy: 0        * Blacksmith's Apron                          
                   
    Plague Doctor          APT: 3            Bestiary: 0         * Silver Ingot                                    
                                                                                                    
                           FOR: 6            Engineering: 3                                           
    Squire                                                                                                    
                           CHA: 3            History: 0
                                                                                                    
    Barmaid  
                         Tips: The blacksmith is simple and straightforward: hit them until they stop moving. You can also
                                                                                                    
    Huntress                   analyze armored enemies to reveal their weaknesses and give your entire party greater armor 
                                                                                                    
                               penetration.                                                                       
    Convict  
                                                                                                   
  ==============                                                                                    
  | Blacksmith |
  ==============                                                                                    
                                                                                                    
    Alchemist
                                                                                                    

      

";
        public string AlchemistSelected = @"
            
    Knight               The town blacksmith is incredibly strong, and knows every weak point that armor can have.   
                                    
                         However, he is slow to move, and has a gruff demeanor.                     
    Scholar                         
                                  
                                
    Noble  
                         Attributes             Talents          Starting Equipment      Starting Inventory
                                                                                                    
    Constable              STR: 9            Medicine: 0         * Blacksmith's Hammer   * Coins x1200                   
                                                                                                    
                           DEX: 2            Explosives: 1       * Bare Hand             * Healing Elixir x5   
    Footman  
                           SKL: 7            Veterancy: 0        * Blacksmith's Apron                          
                   
    Plague Doctor          APT: 3            Bestiary: 0         * Silver Ingot                                    
                                                                                                    
                           FOR: 6            Engineering: 3                                           
    Squire                                                                                                    
                           CHA: 3            History: 0
                                                                                                    
    Barmaid  
                         Tips: The thief's stamina regenerates more quickly than any other class. Use this to attack
                                                                                                    
    Huntress                   enemies with high-damaging skills every turn. Your daggers have a high critical multiplier
                                                                                                    
                               that can make up for their low base damage.                                        
    Convict  
                                                                                                   
                                                                                                    
    Blacksmith  
                                                                                                    
  =============                                                                                     
  | Alchemist |
  =============                                                                                     

      

";

        override public string Selection { get; set; }

        override public string Options()
        {
            int cursor = 1;
            while (cursor != 0)
            {
                Console.Clear();
                Console.WriteLine(Title);

                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine();
                }

                ConsoleKey keyPressed = DisplayCursor(cursor);

                cursor = MoveCursor(keyPressed, cursor);
            }
            return Selection;
        }
        override public ConsoleKey DisplayCursor(int cursor)
        {
            if (cursor == 1)
            {
                Console.WriteLine(KnightSelected);
            }
            else if (cursor == 2)
            {
                Console.WriteLine(ScholarSelected);
            }
            else if (cursor == 3)
            {
                Console.WriteLine(NobleSelected);
            }

            return Console.ReadKey().Key;
        }
        override public int MoveCursor(ConsoleKey keyPressed, int cursor, int maxCursor = 3)
        {
            if (keyPressed == ConsoleKey.UpArrow)
            {
                CursorMoveBeep();
                if (cursor == 1)
                { return maxCursor; }
                else
                { return cursor -= 1; }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                CursorMoveBeep();
                if (cursor == maxCursor)
                { return 1; }
                else
                { return cursor += 1; }
            }
            else if (keyPressed == ConsoleKey.Enter)
            {
                CursorSelectBeep();
                SelectOption(cursor);
                return 0;
            }
            else
            {
                return cursor;
            }
        }
        override public void SelectOption(int cursor)
        {
            if (cursor == 1)
            {
                Selection = "Knight";
            }
            else if (cursor == 2)
            {
                Selection = "Scholar";
            }
            else if (cursor == 3)
            {
                Selection = "Noble";
            }
        }
        public override void CursorMoveBeep()
        {
            Console.Beep(500, 100);
        }

        public override void CursorSelectBeep()
        {
            Console.Beep(900, 100);
            Console.Beep(1200, 80);
        }
    }
}
