using ConsoleRPG.Models.Menus.Startup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Models.Menus
{
    public class Game
    {
        public Game()
        {
            SplashScreen = new SplashScreen();
            MainMenu = new MainMenu();
            NewGameMenu = new NewGameMenu();
            ProfessionMenu = new ProfessionMenu();
        }

        public SplashScreen SplashScreen { get; private set; }
        public MainMenu MainMenu { get; private set; }
        public NewGameMenu NewGameMenu { get; private set; }
        public ProfessionMenu ProfessionMenu { get; private set; }

        public int Selection { get; private set; } = 0;
        
        public void Start()
        {
            StartConsole();
            RunSplashScreen();
            RunMainMenu();
        }
        public void StartConsole()
        {
            Console.SetWindowSize(130, 50);
        }
        public void RunSplashScreen()
        {
            SplashScreen.FlashingPrompt();
            SplashScreen.AscendingTitle();
            Console.ReadKey();
        }
        public void RunMainMenu()
        { // TODO Menus: change hardcoded selection numbers to strings that say what the selected option is
            while (Selection == 0)
            {
                Selection = MainMenu.Options();

                if (Selection == 1)
                {
                    Selection = 0;
                    RunNewGameMenu();
                }
                else if (Selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Console.ReadKey();
                    Selection = 0;
                }
                else if (Selection == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Console.ReadKey();
                    Selection = 0;
                }
                else if (Selection == 0)
                {
                    continue;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        public void RunNewGameMenu()
        {
            while (Selection == 0)
            {
                Selection = NewGameMenu.Options();
                if (Selection == 1)
                {
                    Selection = 0;
                    RunProfessionMenu();
                }
                else if (Selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Selection = 0;
                    Console.ReadKey();
                }
                else
                {
                    Selection = 0;
                    RunMainMenu();
                }
            }
        }
        public void RunProfessionMenu()
        {
            while (Selection == 0)
            {
                Selection = ProfessionMenu.Options();
                if (Selection == 1)
                {
                    
                }
                else if (Selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Selection = 0;
                    Console.ReadKey();
                }
                else
                {
                    Selection = 0;
                    RunNewGameMenu();
                }
            }
        }
    }
}
