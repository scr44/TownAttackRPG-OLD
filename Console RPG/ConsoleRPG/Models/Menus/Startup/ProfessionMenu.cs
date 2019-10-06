using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Menus.Startup
{
    public class ProfessionMenu : Menu
    {
        public string Title = @"

                                                    ==========================
                                                    = Choose Your Profession =
                                                    ==========================
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
  = Knight =             Knights are masters of the longsword clad in sturdy plate armor; but they often 
  ==========                        
                         neglect their academic studies in favor of drinking and skirt-chasing.
    Scholar                         
                                
                                
    Noble


    Constable

                        Attributes             Talents          Starting Equipment      Starting Inventory
    Footman


    Plague Doctor


    Squire


    Barmaid
                        Starting Skills

    Huntress

    
    Convict


    Blacksmith


    Alchemist

        ?

";
        public string MenuOptions2 = "";

        public int Selection { get; private set; }

        override public int Options()
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
                Console.WriteLine(MenuOptions2);
            }

            return Console.ReadKey().Key;
        }
        override public int MoveCursor(ConsoleKey keyPressed, int cursor, int maxCursor = 2)
        {
            if (keyPressed == ConsoleKey.UpArrow)
            {
                if (cursor == 1)
                { return maxCursor; }
                else
                { return cursor -= 1; }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                if (cursor == maxCursor)
                { return 1; }
                else
                { return cursor += 1; }
            }
            else if (keyPressed == ConsoleKey.Enter)
            {
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
            Selection = cursor;
        }
    }
}
