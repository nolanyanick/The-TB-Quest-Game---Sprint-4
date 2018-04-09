using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            AdminMenu,
            InitializePlayerName,
            InitializeRandomName
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.Exit }
                }
        };

        public static Menu InitializePlayerName = new Menu()
        {
            MenuName = "SetupMenu",
            MenuTitle = "Setup Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.RandomName }
            }            
        };

        public static Menu InitializeRandomName = new Menu()
        {
            MenuName = "SetupMenu",
            MenuTitle = "Setup Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.Return }
            }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.LookAround },
                    { '3', PlayerAction.LookAt },
                    { '4', PlayerAction.PickUp },
                    { '5', PlayerAction.PutDown },
                    { '6', PlayerAction.Inventory },
                    { '7', PlayerAction.TreasureInventory },
                    { '8', PlayerAction.Travel },
                    { '9', PlayerAction.PirateLocationsVisited },
                    { 'e', PlayerAction.EditPlayerInfo },
                    { 'a', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.ListDestinations },
                {'2', PlayerAction.ListGameObjects },
                {'0', PlayerAction.ReturnToMainMenu }
            }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Player",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.PirateInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
