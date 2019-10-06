using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleRPG.Models.Menus.Startup
{
    public class MainMenu : Menu
    {

        string Title = @"





       ::::::::::: ::::::::  :::       ::: ::::    :::          ::: ::::::::::: ::::::::::: :::      ::::::::  :::    ::: 
           :+:    :+:    :+: :+:       :+: :+:+:   :+:        :+: :+:   :+:         :+:   :+: :+:   :+:    :+: :+:   :+:  
           +:+    +:+    +:+ +:+       +:+ :+:+:+  +:+       +:+   +:+  +:+         +:+  +:+   +:+  +:+        +:+  +:+   
           +#+    +#+    +:+ +#+  +:+  +#+ +#+ +:+ +#+      +#++:++#++: +#+         +#+ +#++:++#++: +#+        +#++:++    
           +#+    +#+    +#+ +#+ +#+#+ +#+ +#+  +#+#+#      +#+     +#+ +#+         +#+ +#+     +#+ +#+        +#+  +#+   
           #+#    #+#    #+#  #+#+# #+#+#  #+#   #+#+#      #+#     #+# #+#         #+# #+#     #+# #+#    #+# #+#   #+#  
           ###     ########    ###   ###   ###    ####      ###     ### ###         ### ###     ###  ########  ###    ### 



                                                  :::::::::  :::::::::   :::::::: 
                                                 :+:    :+: :+:    :+: :+:    :+: 
                                                +:+    +:+ +:+    +:+ +:+         
                                               +#++:++#:  +#++:++#+  :#:          
                                              +#+    +#+ +#+        +#+   +#+#    
                                             #+#    #+# #+#        #+#    #+#     
                                            ###    ### ###         ########   ";
        string MenuOptions = @"
                                                            New Game

                                                        Continue From Save

                                                            Options

                                                             Quit
";
        string MenuOptions1 = @"
                                                          > New Game <

                                                        Continue From Save  

                                                            Options

                                                             Quit
";
        string MenuOptions2= @"
                                                            New Game

                                                      > Continue From Save <

                                                            Options

                                                             Quit
";
        string MenuOptions3= @"
                                                            New Game

                                                        Continue From Save

                                                          > Options <

                                                             Quit
";
        string MenuOptions4= @"
                                                            New Game

                                                        Continue From Save

                                                            Options

                                                           > Quit <
";

        public int Selection { get; private set; }

        override public int Options()
        {
            int cursor = 1;
            while(cursor != 0)
            {
                Console.Clear();
                Console.WriteLine(Title);

                for (int i = 0; i < 10; i++)
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
                Console.WriteLine(MenuOptions1);
            }
            else if (cursor == 2)
            {
                Console.WriteLine(MenuOptions2);
            }
            else if (cursor == 3)
            {
                Console.WriteLine(MenuOptions3);
            }
            else if (cursor == 4)
            {
                Console.WriteLine(MenuOptions4);
            }

            return Console.ReadKey().Key;
        }
        override public int MoveCursor(ConsoleKey keyPressed, int cursor, int maxCursor=4)
        {
            if(keyPressed == ConsoleKey.UpArrow)
            {
                if(cursor == 1)
                { return maxCursor; }
                else
                { return cursor -= 1; }
            }
            else if(keyPressed == ConsoleKey.DownArrow)
            {
                if (cursor == maxCursor)
                { return 1; }
                else
                { return cursor += 1; }
            }
            else if(keyPressed == ConsoleKey.Enter)
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
