using ConsoleRPG.Models.Actors.Characters;
using System;
using System.Collections.Generic;
using ConsoleRPG.Menus;
using ConsoleRPG.Menus.Startup;
using ConsoleRPG.Menus.InfoPages;

namespace ConsoleRPG
{
    public class Game
    {
        #region Menu Objects
        SplashScreen SplashScreen = new SplashScreen();
        MainMenu MainMenu = new MainMenu();
        ScenarioSelect ScenarioMenu = new ScenarioSelect();
        ProfessionSelect ProfessionMenu = new ProfessionSelect();
        #endregion

        #region Menu Selections
        public void BootUpConsole()
        {
            //Console.SetWindowSize(130, 50);
            Console.SetWindowSize(130, 40);
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
                Selection = MainMenu.DisplayOptions();
                switch (Selection)
                {
                    case "New Game":
                        Selection = "Run Scenario Menu";
                        break;

                    case "Continue":
                        FeatureIncompleteInfoPage.Display();
                        Selection = "Run Main Menu";
                        break;

                    case "Options":
                        FeatureIncompleteInfoPage.Display();
                        Selection = "Run Main Menu";
                        break;

                    case "Quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Selection = "Run Main Menu";
                        break;
                }
            }
            return Selection;
        }
        public string RunScenarioSelect()
        {
            while (Selection == "Run Scenario Menu")
            {
                Selection = ScenarioMenu.DisplayOptions();
                switch (Selection)
                {
                    case "Tutorial":
                        Selection = "Start Tutorial";
                        break;

                    case "Town Attack Classic":
                        Selection = "Start TAC";
                        break;

                    default:
                        Selection = "Run Main Menu";
                        break;
                }
            }
            return Selection;
        }
        public string RunProfessionMenu()
        {
            while (Selection == "Run Profession Menu")
            {
                Selection = ProfessionMenu.DisplayOptions();
                switch (Selection)
                {
                    case "Knight":
                        Selection = "Run Main Menu";
                        break;

                    case "Scholar":
                        Selection = "Run Main Menu";
                        break;

                    default:
                        Selection = "Run Scenario Menu";
                        break;
                }
            }
            return Selection;
        }
        #endregion

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
                else if (Selection == "Run Scenario Menu")
                {
                    Selection = RunScenarioSelect();
                }
                else if (Selection == "Run Profession Menu")
                {
                    Selection = RunProfessionMenu();
                }
            }
        }

       
    }
}
