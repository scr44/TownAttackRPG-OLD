using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleRPG.Models.Menus.Startup
{
    public class SplashScreen
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
        string pressEnter = @"
                                                        Press Enter
";

        #region Title split into words
        string TOWN = @"
::::::::::: ::::::::  :::       ::: ::::    ::: 
    :+:    :+:    :+: :+:       :+: :+:+:   :+: 
    +:+    +:+    +:+ +:+       +:+ :+:+:+  +:+ 
    +#+    +#+    +:+ +#+  +:+  +#+ +#+ +:+ +#+ 
    +#+    +#+    +#+ +#+ +#+#+ +#+ +#+  +#+#+# 
    #+#    #+#    #+#  #+#+# #+#+#  #+#   #+#+# 
    ###     ########    ###   ###   ###    #### 
";
        string ATTACK = @"
    ::: ::::::::::: ::::::::::: :::      ::::::::  :::    ::: 
  :+: :+:   :+:         :+:   :+: :+:   :+:    :+: :+:   :+:  
 +:+   +:+  +:+         +:+  +:+   +:+  +:+        +:+  +:+   
+#++:++#++: +#+         +#+ +#++:++#++: +#+        +#++:++    
+#+     +#+ +#+         +#+ +#+     +#+ +#+        +#+  +#+   
#+#     #+# #+#         #+# #+#     #+# #+#    #+# #+#   #+#  
###     ### ###         ### ###     ###  ########  ###    ###
";
        #endregion

        public void DisplayTitle(bool showPrompt)
        {
            Console.Write(Title);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
            }
            if (showPrompt)
            {
                Console.WriteLine(pressEnter);
            }
        }
        public void FlashingPrompt()
        {
            bool showPrompt = true;
            while(!Console.KeyAvailable)
            {
                Console.Clear();
                for (int i = 0; i < 12; i++)
                {
                    Console.WriteLine();
                }
                DisplayTitle(showPrompt);
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine();
                }
                Thread.Sleep(500);
                showPrompt = !showPrompt;
            }
        }
        public void AscendingTitle()
        {
            for(int j = 11; j > 5; j--)
            {
                Console.Clear();
                for (int i = 0; i < j; i++)
                {
                    Console.WriteLine();
                }
                DisplayTitle(false);
                Thread.Sleep(25);
            }
        }

    }
}
