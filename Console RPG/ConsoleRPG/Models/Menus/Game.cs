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

        public string Selection { get; private set; } = "Run Main Menu";
        
        public void Start()
        {
            BootUpConsole();
            RunSplashScreen();
            while(true)
            {
                if (Selection == "Run Main Menu")
                {
                    Selection = RunMainMenu();
                }
                else if (Selection == "Run New Game Menu")
                {
                    Selection = RunNewGameMenu();
                }
                else if (Selection == "Run Profession Menu")
                {
                    Selection = RunProfessionMenu();
                }
            }
        }
        public void BootUpConsole()
        {
            Console.SetWindowSize(130, 50);
        }
        public void RunSplashScreen()
        {
            SplashScreen.FlashingPrompt();
            SplashScreen.AscendingTitle();
            Console.ReadKey();
        }
        public string RunMainMenu()
        {
            while (Selection == "Run Main Menu")
            {
                Selection = MainMenu.Options();

                if (Selection == "New Game")
                {
                    Selection = "Run New Game Menu";
                }
                else if (Selection == "Continue")
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Console.ReadKey();
                    Selection = "Run Main Menu";
                }
                else if (Selection == "Options")
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Console.ReadKey();
                    Selection = "Run Main Menu";
                }
                else if (Selection == "Quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Selection = "Run Main Menu";
                }
            }
            return Selection;
        }
        public string RunNewGameMenu()
        {
            while (Selection == "Run New Game Menu")
            {
                Selection = NewGameMenu.Options();
                if (Selection == "Select Pre-Made Profession")
                {
                    Selection = "Run Profession Menu";
                }
                else if (Selection == "Custom Profession")
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, this feature is incomplete.");
                    Selection = "Run New Game Menu";
                    Console.ReadKey();
                }
                else // Back
                {
                    Selection = "Run Main Menu";
                }
            }
            return Selection;
        }
        public string RunProfessionMenu()
        {
            while (Selection == "Run Profession Menu")
            {
                Selection = ProfessionMenu.Options();
                if (Selection == "Knight")
                {
                    Selection = "Run Main Menu";
                }
                else if (Selection == "Scholar")
                {
                    Selection = "Run Main Menu";
                }
                else
                {
                    Selection = "Run New Game Menu";
                }
            }
            return Selection;
        }
    }
}
