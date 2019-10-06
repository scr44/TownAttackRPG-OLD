using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Menus
{
    abstract public class Menu
    {
        public string Title { get; private set; }
        public string MenuOptions { get; private set; }
        public int Selection { get; private set; }

        abstract public int Options();
        abstract public ConsoleKey DisplayCursor(int cursor);
        abstract public int MoveCursor(ConsoleKey keyPressed, int cursor, int maxCursor);
        abstract public void SelectOption(int cursor);
    }
}
