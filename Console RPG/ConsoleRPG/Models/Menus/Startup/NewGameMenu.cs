using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleRPG.Models.Menus
{
    public class NewGameMenu : Menu
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
        string TitleAlt = @"





       ::::::::::: ::::::::  :::       ::: ::::    :::          ::: ::::::::::: ::::::::::: :::      ::::::::  :::    ::: 
           :+:    :+:    :+: :+:       :+: :+:+:   :+:        :+: :+:   :+:         :+:   :+: :+:   :+:    :+: :+:   :+:  
           +:+    +:+    +:+ +:+       +:+ :+:+:+  +:+       +:+   +:+  +:+         +:+  +:+   +:+  +:+        +:+  +:+   
           +#+    +#+    +:+ +#+  +:+  +#+ +#+ +:+ +#+      +#++:++#++: +#+         +#+ +#++:++#++: +#+        +#++:++    
           +#+    +#+    +#+ +#+ +#+#+ +#+ +#+  +#+#+#      +#+     +#+ +#+         +#+ +#+     +#+ +#+        +#+  +#+   
           #+#    #+#    #+#  #+#+# #+#+#  #+#   #+#+#      #+#     #+# #+#         #+# #+#     #+# #+#    #+# #+#   #+#  
           ###     ########    ###   ###   ###    ####      ###     ### ###         ### ###     ###  ########  ###    ### 



                                                  :::::::::  :::::::::   :::::::: 
                                                 :+:    :+:  :+:    :+:  :+:    :+: 
                                                 +:+    +:+  +:+    +:+  +:+         
                                                +#++:++#:    +#++:++#+    :#:          
                                               ++#    ++#    +#+           #++   ##++    
                                               +#+    +#+    #+#           +#+    +#+     
                                              ###    ###     ###             ########   ";
        string MenuOptions = @"
                                                  Select a Pre-Made Profession
                                                         (Recommended)                  
         
                                                       Custom Profession
         
                                                             Back
";
        string MenuOptions1 = @"
                                                > Select a Pre-Made Profession <
                                                         (Recommended)                  
         
                                                       Custom Profession
         
                                                             Back
";
        string MenuOptions2 = @"
                                                  Select a Pre-Made Profession
                                                         (Recommended)                  
         
                                                     > Custom Profession <
         
                                                             Back
";
        string MenuOptions3 = @"
                                                  Select a Pre-Made Profession
                                                         (Recommended)                  
         
                                                       Custom Profession
         
                                                           > Back <
";

        override public string Selection { get; set; } = "Run New Game Menu";

        override public string Options()
        {
            int cursor = 1;
            while (cursor != 0)
            {
                Console.Clear();
                Console.WriteLine(TitleAlt);

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

            return Console.ReadKey().Key;
        }
        override public int MoveCursor(ConsoleKey keyPressed, int cursor, int maxCursor=3)
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
                Selection = "Select Pre-Made Profession";
            }
            else if (cursor == 2)
            {
                Selection = "Custom Profession";
            }
            else // Back
            {
                Selection = "Run Main Menu";
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
