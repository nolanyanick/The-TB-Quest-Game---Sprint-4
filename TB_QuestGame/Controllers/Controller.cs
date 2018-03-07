using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private IslandLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction travelerActionChoice = PlayerAction.None;
            IslandLocation location = new IslandLocation();

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Quest Intro", Text.QuestIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission(travelerActionChoice, location);

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                

                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.EditPlayerInfo:
                        _gameConsoleView.DisplayEditPirateInfo();
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPirateInfo();                       
                        break;

                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfIslandLocations();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.Travel:

                        //
                        // determine if the player has a ship in order to travel
                        //
                        if (_gamePlayer.Ship == Player.ShipType.None)
                        {
                            _gamePlayer.ShipOwner = false;
                            _gameConsoleView.DisplayInputErrorMessage("You currently do not own a ship needed to travel. Obtain a ship, and try again.");
                            break;
                        }
                        else
                        {
                            _gamePlayer.ShipOwner = true;
                        }

                        //
                        // get new location choice and update current location
                        //
                        _gamePlayer.IslandLocationId = _gameConsoleView.DisplayGetNextIslandLocation();
                        _currentLocation = _gameUniverse.GetIslandLocationById(_gamePlayer.IslandLocationId);

                        //
                        // display game play screen with current location info and coordiantes
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        _gameConsoleView.DisplayColoredText(_currentLocation.CommonName, travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.Exit:
                        _gameConsoleView.DisplayClosingScreen();
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission(PlayerAction choosenAction, IslandLocation location)
        {
            //Player pirate = _gameConsoleView.GetInitialPirateInfo();
            Player pirate = new Player();

            //_gamePlayer.Age = pirate.Age;
            //_gamePlayer.Gender = pirate.Gender;
            //_gamePlayer.Personality = pirate.Personality;

            _gamePlayer.Age = 50;
            _gamePlayer.Gender = Character.GenderType.MALE;
            _gamePlayer.Personality = false;
            //_gamePlayer.Name = "Bill";
            _gamePlayer.Name = _gameConsoleView.GetPirateName(pirate, choosenAction, location);

            _gamePlayer.ShipOwner = pirate.ShipOwner;
            _gamePlayer.Coin = pirate.Coin;
            _gamePlayer.Weapon = pirate.Weapon;
            _gamePlayer.Ship = Player.ShipType.BritishManOWar;

            //
            // echo the pirates's info
            //
           _gameConsoleView.DisplayGamePlayScreen("Quest Setup - Complete", Text.InitializeMissionEchoPirateInfo(pirate), ActionMenu.MissionIntro, "");
           _gameConsoleView.GetContinueKey();
        }

        #endregion
    }
}
