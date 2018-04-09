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
        private Player _gamePirate;
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
            _gamePirate = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePirate, _gameUniverse);
            _playingGame = true;
           
            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction travelerActionChoice = PlayerAction.None;                                             

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
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetIslandLocationById(_gamePirate.IslandLocationId);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
            _gameConsoleView.DisplayColoredText("", PlayerAction.ReturnToMainMenu, _currentLocation);

            //
            // game loop
            //
            while (_playingGame)
            {
                Console.CursorVisible = false;
                

                //
                // update all game stats/info
                //
                UpdateGameStatus();

                //
                // get game action from player
                //
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.EditPlayerInfo:                       
                        _gameConsoleView.DisplayEditPirateInformation();

                        //
                        // display game play screen with current location info and coordiantes
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        _gameConsoleView.DisplayColoredText("", PlayerAction.LookAround, _currentLocation);
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPirateInfo();
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.ListDestinations:
                        _gameConsoleView.DisplayListOfIslandLocations();
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.LookAt:
                        LookAtAction();                     
                        break;

                    case PlayerAction.Travel:
                        //
                        // determine if the player has a ship in order to travel
                        //
                        if (_gamePirate.Ship == Ship.ShipType.None)
                        {
                            _gamePirate.ShipOwner = false;
                            _gameConsoleView.DisplayInputErrorMessage("You currently do not own a ship needed to travel. Obtain a ship, and try again.");
                            break;
                        }
                        else
                        {
                            _gamePirate.ShipOwner = true;
                        }

                        //
                        // get new location choice and update current location
                        //
                        _gamePirate.IslandLocationId = _gameConsoleView.DisplayGetNextIslandLocation();
                        _currentLocation = _gameUniverse.GetIslandLocationById(_gamePirate.IslandLocationId);                        

                        //
                        // display game play screen with current location info and coordiantes
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        _gameConsoleView.DisplayColoredText("", PlayerAction.ReturnToMainMenu, _currentLocation);
                        break;

                    case PlayerAction.PirateLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);                    
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;

                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");                        ;
                        break;

                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;

                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        _gameConsoleView.DisplayColoredText("", travelerActionChoice, _currentLocation);
                        break;

                    case PlayerAction.Inventory:
                        _gameConsoleView.DisplayInventory();                        
                        break;

                    case PlayerAction.TreasureInventory:
                        _gameConsoleView.DisplayTreasureInventory();
                        break;

                    case PlayerAction.PickUp:
                        PickUpAction();
                        break;

                    case PlayerAction.PutDown:
                        PutDownAction();
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
        private void InitializeMission()
        {
            Player pirate = _gameConsoleView.GetInitialPirateInfo();

            // player information
            _gamePirate.Age = pirate.Age;
            _gamePirate.Gender = pirate.Gender;
            _gamePirate.Personality = pirate.Personality;
            _gamePirate.Name = _gameConsoleView.GetPirateName(pirate, PlayerAction.None, _currentLocation);
            _gamePirate.IslandLocationId = 1;

            ////player information
            //_gamePirate.Age = 50;
            //_gamePirate.Gender = Character.GenderType.MALE;
            //_gamePirate.Personality = true;
            //_gamePirate.Name = "Bill";

            // to be edited
            _gamePirate.ShipOwner = true;            
            _gamePirate.Coin = 0;
            _gamePirate.Weapon = Player.WeaponType.FISTS;
            _gamePirate.Ship = Ship.ShipType.BritishManOWar;

            //
            // default player stats
            //
            _gamePirate.ExperiencePoints = 0;
            _gamePirate.Health = 100;
            _gamePirate.Lives = 3;

            // default player inventroy   
            _gamePirate.Inventory.Add(_gameUniverse.GetObjectById(24));

            //
            // echo the pirates's info
            //
            _gameConsoleView.DisplayGamePlayScreen("Quest Setup - Complete", Text.InitializeMissionEchoPirateInfo(_gamePirate), ActionMenu.MissionIntro, "");
            _gameConsoleView.DisplayColoredText("", PlayerAction.None, _currentLocation);
            _gameConsoleView.GetContinueKey();
        }

        /// <summary>
        /// updates all the game's info/stats
        /// </summary>
        private void UpdateGameStatus()
        {
            if (!_gamePirate.HasVisited(_currentLocation.IslandLocationID))
            {
                //
                // add a new location to visited list
                //
                _gamePirate.IslandLocationsVisited.Add(_currentLocation.IslandLocationID);
                
                //
                // add experience points for visiting locations
                //
                _gamePirate.ExperiencePoints += _currentLocation.ExperiencePoints;
            }

            //
            // update island accessibility
            //
            #region ---Islands---

            #region ***ISLA DE LA MUERTE

            if (_gamePirate.ExperiencePoints > 10000 || _gamePirate.Crew.Count >= 5)
            {
                _gameUniverse.IslandLocations[3].Accessible = true;
            }
            else
            {
                _gameUniverse.IslandLocations[3].Accessible = false;

            }

            #endregion

            #region ***MONARCH BAY

            if (_gamePirate.Coin > 10000)
            {
                _gameUniverse.IslandLocations[4].Accessible = true;
            }
            else
            {
                _gameUniverse.IslandLocations[4].Accessible = false;

            }

            #endregion

            #region ***ISLE DU SOLEIL

            if (_gamePirate.ExperiencePoints > 999999999)
            {
                _gameUniverse.IslandLocations[5].Accessible = true;
            }
            else
            {
                _gameUniverse.IslandLocations[5].Accessible = false;

            }

            #endregion

            #region ***RENEGADE'S BEACH

            if (_gamePirate.Ship == Ship.ShipType.BritishManOWar || _gamePirate.Ship == Ship.ShipType.SpanishGalleon)
            {
                _gameUniverse.IslandLocations[6].Accessible = true;
            }
            else
            {
                _gameUniverse.IslandLocations[6].Accessible = false;

            }

            #endregion

            #region ***SHIPWRECK COVE

            if (_gamePirate.Ship == Ship.ShipType.Sloop)
            {
                _gameUniverse.IslandLocations[7].Accessible = true;
            }
            else
            {
                _gameUniverse.IslandLocations[7].Accessible = false;

            }

            #endregion

            //
            // add exp. points when the player specific game object
            //
            foreach (GameObject gameObject in _gamePirate.TreasureInventory)
            {
                #region ***TREASURE

                if (gameObject.Id == 11 && gameObject.HasBeenPickedUp == false)
                {
                    _gamePirate.ExperiencePoints += 25;
                    gameObject.HasBeenPickedUp = true;
                }

                if (gameObject.Id == 12 && gameObject.HasBeenPickedUp == false)
                {
                    _gamePirate.ExperiencePoints += 50;
                    gameObject.HasBeenPickedUp = true;
                }

                if (gameObject.Id == 13 && gameObject.HasBeenPickedUp == false)
                {
                    _gamePirate.ExperiencePoints += 75;
                    gameObject.HasBeenPickedUp = true;
                }

                if (gameObject.Id == 14 && gameObject.HasBeenPickedUp == false)
                {
                    _gamePirate.ExperiencePoints += 100;
                    gameObject.HasBeenPickedUp = true;
                }

                #endregion
            }            

            #endregion
        }

        /// <summary>
        /// allows player to look at specific game objects
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in islad location and player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectsToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object form the universe
                //
                GameObject gameObject = _gameUniverse.GetObjectById(gameObjectToLookAtId);

                //
                // display information for the chosen object
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        /// <summary>
        /// allows player to pick up a game object and add it to their inventory
        /// </summary>
        private void PickUpAction()
        {
            //
            // display list of game objects and gets the player's choice
            //
            int gameObjectToPickUpId = _gameConsoleView.DisplayGetGameObjectToPickUp();

            //
            // add the game object to the player's inventory
            //
            if (gameObjectToPickUpId != 0)
            {
                //
                // get game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetObjectById(gameObjectToPickUpId);

                //
                // add game object to player's inventory or treasure inventory
                // and set location Id to 0
                //
                if (gameObject is Treasure)
                {
                    _gamePirate.TreasureInventory.Add(gameObject as Treasure);
                    gameObject.IslandLocationId = 0;
                }
                else
                {
                    _gamePirate.Inventory.Add(gameObject);
                    gameObject.IslandLocationId = 0;
                }

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmGameObjectAddedToInvetory(gameObject);
            }
        }

        /// <summary>
        /// allows player to put down a game object and remove it from their inventory
        /// </summary>
        private void PutDownAction()
        {
            //
            // display list of game objects in the player's inventory and gets the player's choice
            //
            int inventoryObjectToRemoveId = _gameConsoleView.DisplayGetGameObjectToPutDown();

            //
            // get game object from the universe
            //
            GameObject gameObject = _gameUniverse.GetObjectById(inventoryObjectToRemoveId);

            //
            // remove game object from player's inventory
            // and set location Id to current location
            //
            if (gameObject is Treasure)
            {
                _gamePirate.TreasureInventory.Remove(gameObject as Treasure);
                gameObject.IslandLocationId = _gamePirate.IslandLocationId;
            }
            else
            {
                _gamePirate.Inventory.Remove(gameObject);
                gameObject.IslandLocationId = _gamePirate.IslandLocationId;
            }

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmGameObjectRemovedFromInvetory(gameObject);            
        }

        #endregion
    }
}
