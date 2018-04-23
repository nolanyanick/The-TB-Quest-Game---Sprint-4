using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        public enum ViewStatus
        {
            PirateInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePirate;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gameTraveler, Universe gameUniverse)
        {
            _gamePirate = gameTraveler;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.PirateInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText,  Menu menu, string inputBoxPrompt)
        {            
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayStatusBox();
            DisplayInputBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;
            Console.CursorVisible = false;

            //
            // an array of valid keys form the menu dicitonary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate key pressed in menu choices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                keyPressed = keyPressedInfo.KeyChar;

            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;
            
            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            bool validResponse = false;
            string userResponse;

            while (!validResponse)
            {
                userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "YES")
                {
                    validResponse = true;
                    return userResponse;
                }
                else if(userResponse == "NO")
                {
                    validResponse = true;
                    return userResponse;
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter 'Yes' or 'No'. Please try again.");
                    DisplayInputBoxPrompt("Would you like to continue this conversation? (Yes or No): ");                    
                }
            }

            Console.CursorVisible = false;

            return "";
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either mininumValue or maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.GenderType GetGender()
        {
            Character.GenderType genderType;            

            if (!Enum.TryParse<Character.GenderType>(Console.ReadLine().ToUpper(), out genderType))
            {
                DisplayInputErrorMessage($"Invalid input. Your gender as been set to: '{Character.GenderType.OTHER}'. " +
                "You may change this at any time. Press any key to continue.");
                GetContinueKey();
            }      
            
            return genderType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 48);
            Console.WriteLine(tabSpace + @" _____ _           _   _  _        _      ____                 ");
            Console.WriteLine(tabSpace + @"|_   _| |         | | | |(_)      | |    /  __\                ");
            Console.WriteLine(tabSpace + @"  | | | |__   ___ | |_| | _  ___  | |__  | |__  ___  ___   ___ ");
            Console.WriteLine(tabSpace + @"  | | | '_ \ / _ \|  _  || |/ _ \ | '_ \ \__  \/ _ \/ _ \ / __\");
            Console.WriteLine(tabSpace + @"  | | | | | |  __/| | | || | (_) || | | |___| |  __/ (_) |\__ \");
            Console.WriteLine(tabSpace + @"  \_/ |_| |_|\___||_| |_||_|\__  ||_| |_|\____/\___|\__/\_\___/");
            Console.WriteLine(tabSpace + @"                              _/ /                             ");
            Console.WriteLine(tabSpace + @"                             |__/                              ");                         

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }
     
            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The High Seas";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;            
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }            
        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {         
            Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.StatusBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePirate, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight -2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        #region ----- display colored text -----

        /// <summary>
        /// displays specific info in a different color
        /// </summary>        
        public void DisplayColoredText(string information, PlayerAction choosenAction, IslandLocation location)
        {
            int cursorPosition;
            Console.CursorVisible = false;

            switch (choosenAction)
            {
                //
                // DEAFULT PAGE ********************EDIT PLAYER ACTION***************************
                //
                case PlayerAction.ReturnToMainMenu:
                    //-----NAME-----//
                    information = location.CommonName;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 20, ConsoleLayout.MenuBoxPositionTop + 3);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //-----COORDIANTES-----//
                    information = location.Coordinates;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 15, ConsoleLayout.MenuBoxPositionTop + 4);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(information);
                    break;

                case PlayerAction.None:
                    #region ***COLORS FOR MISC/OTHER SCREENS

                    #region ---echo info screen---

                    if (_gamePirate.Name != null)
                    {
                        //----NAME----//
                        information = _gamePirate.Name;
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 20, ConsoleLayout.MenuBoxPositionTop + 7);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(information);

                        //----AGE----//
                        information = _gamePirate.Age.ToString();
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 19, ConsoleLayout.MenuBoxPositionTop + 8);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(information);

                        //----GENDER----//
                        information = Text.UppercaseFirst(_gamePirate.Gender.ToString());
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 22, ConsoleLayout.MenuBoxPositionTop + 9);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(information);

                        //----PERSONALITY----//
                        information = _gamePirate.PersonlityDescription();
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 27, ConsoleLayout.MenuBoxPositionTop + 10);
                        if (_gamePirate.Personality)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(information);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(information);
                        }

                        break;
                    }

                    #endregion

                    #region ---random name screen---

                    if (_gamePirate.Name == null)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 15, ConsoleLayout.MenuBoxPositionTop + 3);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(information);
                        break;
                    }

                    #endregion                

                    #endregion
                    break;

                case PlayerAction.LookAround:
                    #region ***COLORS FOR LOOK AROUND/CURRENT LOCATION SCREENS                  

                    //-----NAME-----//
                    information = location.CommonName;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 20, ConsoleLayout.MenuBoxPositionTop + 3);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //-----COORDIANTES-----//
                    information = location.Coordinates;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 15, ConsoleLayout.MenuBoxPositionTop + 4);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(information);

                    #endregion
                    break;

                case PlayerAction.Travel:
                    #region ***COLORS FOR TRAVEL SCREEN

                    //----ID----// 
                    cursorPosition = 8;
                    foreach (IslandLocation island in _gameUniverse.IslandLocations)
                    {
                        if (island.IslandLocationID != _gamePirate.IslandLocationId)
                        {
                            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(island.IslandLocationID);
                        }
                    }

                    //----NAME----//      
                    cursorPosition = 8;
                    foreach (IslandLocation island in _gameUniverse.IslandLocations)
                    {
                        if (island.IslandLocationID != _gamePirate.IslandLocationId)
                        {
                            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(island.CommonName);
                        }
                    }

                    //----ACCESSIBILITY----//      
                    cursorPosition = 8;
                    foreach (IslandLocation island in _gameUniverse.IslandLocations)
                    {
                        if (island.IslandLocationID != _gamePirate.IslandLocationId)
                        {
                            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 42, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                            if (island.Accessible)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(island.Accessible);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(island.Accessible);
                            }
                        }
                    }

                    #endregion
                    break;

                case PlayerAction.PlayerInfo:
                    #region ***COLORS FOR PLAYER INFO SCREEN

                    //----NAME----//
                    information = _gamePirate.Name;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 20, ConsoleLayout.MenuBoxPositionTop + 3);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //----AGE----//
                    information = _gamePirate.Age.ToString();
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 19, ConsoleLayout.MenuBoxPositionTop + 4);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //----GENDER----//
                    information = Text.UppercaseFirst(_gamePirate.Gender.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 22, ConsoleLayout.MenuBoxPositionTop + 5);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //----PERSONALITY----//
                    information = _gamePirate.PersonlityDescription();
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 27, ConsoleLayout.MenuBoxPositionTop + 6);
                    if (_gamePirate.Personality)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(information);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(information);
                    }

                    #endregion
                    break;

                case PlayerAction.EditPlayerInfo:
                    #region ***COLORS FOR EDIT INFO SCREEN

                    //-----NAME1-----//
                    information = _gamePirate.Name;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 32, ConsoleLayout.MenuBoxPositionTop + 7);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //-----NAME2-----//
                    information = _gamePirate.Name;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 20, ConsoleLayout.MenuBoxPositionTop + 9);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //-----AGE-----//
                    information = _gamePirate.Age.ToString();
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 19, ConsoleLayout.MenuBoxPositionTop + 10);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    //-----GENDER-----//
                    information = Text.UppercaseFirst(_gamePirate.Gender.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 22, ConsoleLayout.MenuBoxPositionTop + 11);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(information);

                    #endregion                    
                    break;

                case PlayerAction.PirateLocationsVisited:
                    #region ***COLORS FOR LOCATIONS VISITED SCREEN

                    List<IslandLocation> visitedIslandLocations = new List<IslandLocation>();

                    // add visited locations to a list
                    foreach (int islandLocationID in _gamePirate.IslandLocationsVisited)
                    {
                        visitedIslandLocations.Add(_gameUniverse.GetIslandLocationById(islandLocationID));
                    }

                    //----ID----// 
                    cursorPosition = 7;
                    foreach (IslandLocation island in visitedIslandLocations)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(island.IslandLocationID);
                    }

                    //----NAME----//      
                    cursorPosition = 7;
                    foreach (IslandLocation island in visitedIslandLocations)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(island.CommonName);
                    }

                    #endregion
                    break;

                case PlayerAction.ListDestinations:
                    #region ***COLORS FOR LIST DESTINATIONS SCREEN

                    //----ID----// 
                    cursorPosition = 7;
                    foreach (IslandLocation island in _gameUniverse.IslandLocations)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(island.IslandLocationID);
                    }

                    //----NAME----//      
                    cursorPosition = 7;
                    foreach (IslandLocation island in _gameUniverse.IslandLocations)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(island.CommonName);
                    }

                    #endregion
                    break;

                case PlayerAction.Exit:
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// displays game objects in color
        /// </summary>
        public void DisplayColoredObjects(PlayerAction choosenAction, int id)
        {
            int cursorPosition;
            List<GameObject> gameObjectsInCurrentIslandLocation = _gameUniverse.GetGameObjectsByIslandLocaitonId(_gamePirate.IslandLocationId);

            switch (choosenAction)
            {
                case PlayerAction.LookAt:
                    #region ***COLORS FOR LOOK AT SCREEN
                    
                    #region --- display a list of objects in current location ---

                    if (_gamePirate.IndividualGameObject == 0)
                    {
                        //-----NAME-----//
                        cursorPosition = 7;
                        foreach (var gameObject in gameObjectsInCurrentIslandLocation)
                        {
                            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(gameObject.Name);
                        }

                        //-----ID-----//
                        cursorPosition = 7;
                        foreach (var gameObject in gameObjectsInCurrentIslandLocation)
                        {
                            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(gameObject.Id);
                        }
                    }

                    #endregion

                    #region --- display individual object information ---

                    if (_gamePirate.IndividualGameObject != 0 && gameObjectsInCurrentIslandLocation.Count > 0)
                    {
                        GameObject gameObjectToWrite = null;

                        foreach (GameObject gameObject in _gameUniverse.GameObjects)
                        {
                            if (gameObject.Id == id)
                            {
                                gameObjectToWrite = gameObject;
                            }
                        }

                        //-----NAME-----//                   
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 3);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"{gameObjectToWrite.Name} \n \n");

                        //-----DESCRIPTION-----//                    
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 5);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"{gameObjectToWrite.Description} \n \n");

                        //-----MORE INFO-----// 
                        string information =
                        $"The {gameObjectToWrite.Name} has a value of {gameObjectToWrite.Value} and ";

                        if (gameObjectToWrite.CanInventory)
                        {
                            information += "can be added to your inventory.";
                        }
                        else
                        {
                            information += "cannot be added to your inventory.";
                        }

                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 7);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(information);
                    }

                    #endregion

                    #region --- display 'no objects in area' notice ---

                    if (_gamePirate.IndividualGameObject == 0 && gameObjectsInCurrentIslandLocation.Count == 0)
                    {
                        //-----NOTICE-----//                   
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("It appears there are no game objects here!");
                    }

                    #endregion

                    #endregion
                    break;

                case PlayerAction.LookAround:
                    #region ***COLORS FOR LOOK AROUND OBJECTS

                    //-----NAME-----//
                    cursorPosition = 14;
                    foreach (var gameObject in gameObjectsInCurrentIslandLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(gameObject.Name);
                    }

                    //-----ID-----//
                    cursorPosition = 14;
                    foreach (var gameObject in gameObjectsInCurrentIslandLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(gameObject.Id);
                    }

                    //-----GAME OBJECTS-----//                    
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 10);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Game Objects");

                    #endregion
                    break;

                case PlayerAction.TreasureInventory:
                    #region ***COLORS FOR TREASURE INVENTORY

                    //-----NAME-----//
                    cursorPosition = 5;
                    foreach (var gameObject in _gamePirate.TreasureInventory)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(gameObject.Name);
                    }

                    //-----ID-----//
                    cursorPosition = 5;
                    foreach (var gameObject in _gamePirate.TreasureInventory)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(gameObject.Id);
                    }

                    //-----RARITY
                    cursorPosition = 5;
                    foreach (var gameObject in _gamePirate.TreasureInventory)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 42, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);

                        if (gameObject.Rarity == Treasure.RarityLevel.Common)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(gameObject.Rarity);
                        }
                        else if (gameObject.Rarity == Treasure.RarityLevel.Unique)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(gameObject.Rarity);
                        }
                        else if (gameObject.Rarity == Treasure.RarityLevel.Rare)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(gameObject.Rarity);
                        }
                        else if (gameObject.Rarity == Treasure.RarityLevel.Legendary)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(gameObject.Rarity);
                        }
                    }

                    #endregion
                    break;

                case PlayerAction.ListGameObjects:
                    #region ***COLORS FOR LIST GAME OBJECTS SCREEN

                    //----ID----// 
                    cursorPosition = 7;
                    foreach (GameObject allGameObjects in _gameUniverse.GameObjects)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(allGameObjects.Id);
                    }

                    //----NAME----//      
                    cursorPosition = 7;
                    foreach (GameObject allGameObjects in _gameUniverse.GameObjects)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(allGameObjects.Name);
                    }

                    //----ISLAND LOCATION----//      
                    cursorPosition = 7;
                    foreach (GameObject allGameObjects in _gameUniverse.GameObjects)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 42, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(allGameObjects.IslandLocationId);
                    }

                    #endregion
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// displays NPCs in color
        /// </summary>
        public void DisplayColoredNpcs(PlayerAction choosenAction)
        {
            int cursorPosition;
            List<Npc> npcsInCurrentLocation = _gameUniverse.GetNpcsByIslandLocation(_gamePirate.IslandLocationId);

            switch (choosenAction)
            {
                case PlayerAction.ListNpcs:
                    #region ***COLORS FOR LIST NPCS SCREEN

                    //----ID----// 
                    cursorPosition = 7;
                    foreach (Npc allNpcs in _gameUniverse.Npcs)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(allNpcs.Id);
                    }

                    //----NAME----//      
                    cursorPosition = 7;
                    foreach (Npc allNpcs in _gameUniverse.Npcs)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(allNpcs.Name);
                    }

                    //----ISLAND LOCATION----//      
                    cursorPosition = 7;
                    foreach (Npc allNpcs in _gameUniverse.Npcs)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 42, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(allNpcs.IslandLocationId);
                    }

                    #endregion
                    break;

                case PlayerAction.LookAround:
                    #region ***COLORS FOR LOOK AROUND: NPCS

                    //-----NAME-----//
                    cursorPosition = 14;
                    foreach (var npc in npcsInCurrentLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 50, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(npc.Name);
                    }

                    //-----ID-----//
                    cursorPosition = 14;
                    foreach (var npc in npcsInCurrentLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 40, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(npc.Id);
                    }

                    //-----HEADER-----//                    
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 40, ConsoleLayout.MenuBoxPositionTop + 10);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("NPCs");

                    //-----TABLE-----//
                    cursorPosition = 12;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 40, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("ID".PadRight(10) + "Name".PadRight(30) + " \n");

                    //-----TABLE DECORATION-----//  
                    cursorPosition = 13;
                    Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 40, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("---".PadRight(10) + "------------------".PadRight(30) + " \n");

                    #endregion
                    break;

                case PlayerAction.TalkTo:
                    #region ***COLORS FOR TALK TO

                    //-----NAME-----//
                    cursorPosition = 7;
                    foreach (var npc in npcsInCurrentLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 12, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(npc.Name);
                    }

                    //-----ID-----//
                    cursorPosition = 7;
                    foreach (var npc in npcsInCurrentLocation)
                    {
                        Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + cursorPosition++);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(npc.Id);
                    }

                    #endregion
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region ----- get initial player info -----

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Player GetInitialPirateInfo()
        {
            Player pirate = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Quest Setup", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get pirates's age
            //
            DisplayGamePlayScreen("Quest Setup - Age", Text.InitializeMissionGetPrisonerAge(), ActionMenu.MissionIntro, "");
            int gameTravelerAge;
            GetInteger($"Enter your age {pirate.Name}: ", 0, 1000000, out gameTravelerAge);
            pirate.Age = gameTravelerAge;

            //
            // get pirate's gender
            //
            DisplayGamePlayScreen("Quest Setup - Gender", Text.InitializeMissionGetPrisonerGender, ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your gender {pirate.Name}: ");
            pirate.Gender = GetGender();

            //
            // get pirates's personality
            //
            bool selectingPersona = true;
            string prompt = $"Enter 'Yes' or 'No' {pirate.Name}: ";
            DisplayGamePlayScreen("Quest Setup - Personality", Text.InitializeMissionGetPrisonerPersonality(pirate), ActionMenu.MissionIntro, "");

            // validate
            while (selectingPersona)
            {
                string userResponse;
                DisplayInputBoxPrompt(prompt);
                userResponse = GetString().ToUpper();

                if (userResponse == "YES")
                {
                    pirate.Personality = true;
                    selectingPersona = false;
                }
                else if (userResponse == "NO")
                {
                    pirate.Personality = false;
                    selectingPersona = false;
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("You must enter either 'Yes' or 'No'. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }
            
            return pirate;
        }

        /// <summary>
        /// get pirate's name
        /// </summary>
        public string GetPirateName(Player gamePirate, PlayerAction choosenAction, IslandLocation location)
        {
            bool choosingName = true;

            //
            // allows user to enter a custom name
            //
            DisplayGamePlayScreen("Quest Setup - Name", Text.InitializeMissionGetPrisonerName(), ActionMenu.InitializePlayerName, "");
            DisplayInputBoxPrompt("Enter your name: ");
            gamePirate.Name = GetString();
            

            if (gamePirate.Name == "1")
            {
                //
                // this code will generate a random name
                //
                gamePirate.Name = GenerateRandomName();

                while (choosingName)
                {
                    string userResponese;
                    string prompt = $"Generate new Name? (Yes or No): ";

                    DisplayGamePlayScreen("Quest Setup - Name", Text.InitializeMissionGetRandomName, ActionMenu.InitializeRandomName, "");
                    DisplayColoredText(gamePirate.Name ,choosenAction, location);
                    DisplayInputBoxPrompt(prompt);
                    userResponese = GetString().ToUpper();

                    if (userResponese == "YES")
                    {
                        //
                        // this code will generate a random name
                        //
                        gamePirate.Name = GenerateRandomName();
                        choosingName = true;
                    }
                    else if (userResponese == "NO")
                    {
                        choosingName = false;

                        // 
                        // change view status to playing game
                        //
                        _viewStatus = ViewStatus.PlayingGame;

                        return gamePirate.Name;
                    }
                    else if (userResponese == "1")
                    {
                        //
                        // allows user to return to previous screen and enter a custom name
                        //
                        DisplayGamePlayScreen("Quest Setup - Name", Text.InitializeMissionGetPrisonerName(), ActionMenu.InitializePlayerName, "");
                        DisplayInputBoxPrompt("Enter your name: ");
                        gamePirate.Name = GetString();

                        if (gamePirate.Name == "1")
                        {
                            gamePirate.Name = GenerateRandomName();
                            choosingName = true;
                        }
                        else
                        {
                            choosingName = false;

                            // 
                            // change view status to playing game
                            //
                            _viewStatus = ViewStatus.PlayingGame;

                            return gamePirate.Name;
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You must enter either 'Yes','No', or a menu option. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                        GetContinueKey();
                    }
                }

            }

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return gamePirate.Name;
        }

        /// <summary>
        /// generates a random name string and returns that string
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomName()
        {
            // list of random 'pirate' names
            List<string> names = new List<string>()
            {
                //male names
                "Wayne 'Silver Tooth' Colby",
                "Farr 'Liar' Richmond",
                "Trevin 'Rage' Sweet",
                "Delton 'Double-Crossed' Fischer",
                "Wyatt 'Mutiny' Lucifer",
                "Garton 'Speechless' Brudge",
                "Burton 'Twisting' Ogden",
                "Paley 'Four-Teeth' Smith",
                "Washington 'The Hero' Marlowe",
                "Bramwell 'Rum Lover' Jeronimo",
                "Tomlin 'One-Eared' Shell",
                "Meldrick 'Rough Dog' Griffin",
                "Hawthorne 'One-Eyed' Kimberley",
                "Denver 'Fierce' Swales",
                "Winton 'Shaded' Penney",
                "Radburn 'Roaring' Charles",
                "Filmore 'Pirate' Frederik",
                "Harold 'Foxy' Sans",
                "Leland 'Four Fingers' Burling",
                "Sully 'Swine' Ottinger",

                // female names
                "Eugenie 'Crazy' Ethel",
                "Mettie 'The Hawk' Gnash",
                "Teresa 'Temptation' Crowley",
                "Sadye 'Barnacle' Atherton",
                "Blossom 'Shrew' Branson",
                "Adella 'Riot' Griffin",
                "Patsy 'Silver Hair' Watt",
                "Georgie 'The Marked' Arlin",
                "Harriett 'Thoothless' Shurman",
                "Taylor 'The Confident' Achey",
                "Melissa 'Vixen' Stratford",
                "Enola 'Treasure' Bradford",
                "Prudence 'Shark Bait' Merton",
                "Vira 'The Fool' Bing",
                "Vala 'Brown Teeth' Alistair",
                "Claire 'Dawg' Hastings",
                "Dolores 'The Bright' Tindall",
                "Elfrida 'Buccaneer' Smith",
                "Hulda 'Three-Teeth' Cloven",
                "Blanche 'One-Legged' Compton"
            };
            string pirateName;
            Random randomName = new Random();

            int randomNumber = randomName.Next(names.Count); //create a variable that will select a random name from the "names" list                    
            pirateName = names[randomNumber]; //assigns a random List<string> taken from the "names" list to the pirateName(string) 

            return pirateName;
        }

        #endregion

        #region ----- display responses to menu action choices -----

        /// <summary>
        /// displays all player information
        /// </summary>
        public void DisplayPirateInfo()
        {
            DisplayGamePlayScreen("Player Information", Text.PrisonerInfo(_gamePirate), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// edits player information
        /// </summary>        
        public void DisplayEditPirateInformation()
        {
            string userResponse;
            bool editingInfo = true;

            DisplayGamePlayScreen("Edit Player Information", Text.EditPrisonerInfo(), ActionMenu.PlayerMenu, "");
            DisplayColoredText("", PlayerAction.EditPlayerInfo, _gameUniverse.IslandLocations[0]);        

            while (editingInfo)
            {
                DisplayInputBoxPrompt($"Enter your selection {_gamePirate.Name}: ");
                userResponse = GetString().ToUpper();
                if (userResponse == "A" || userResponse == "B" || userResponse == "C")
                {
                    switch (userResponse)
                    {
                        case "A":
                            DisplayGamePlayScreen("Edit Player Information", $"You have selcted to edit your Name.\n" + "If you change your mind, you may enter 'Back' to be returned to the previous menu.\n", ActionMenu.PlayerMenu, "");
                            DisplayInputBoxPrompt($"Enter your new name: ");
                            _gamePirate.Name = GetString();
                            editingInfo = false;
                            break;
                           

                        case "B":
                            int pirateAge = 0;
                            DisplayGamePlayScreen("Edit Player Information", $"You have selcted to edit your Age.\n" + "If you change your mind, you may enter 'Back' to be returned to the previous menu.\n", ActionMenu.PlayerMenu, "");
                            DisplayInputBoxPrompt($"Enter your new age: ");
                            GetInteger($"Enter your age {_gamePirate.Name}: ", 0, 1000000, out pirateAge);
                            _gamePirate.Age = pirateAge;
                            editingInfo = false;
                            break;

                        case "C":
                            DisplayGamePlayScreen("Edit Player Information", $"You have selcted to edit your Gender.\n" + "If you change your mind, you may enter 'Back' to be returned to the previous menu.\n", ActionMenu.PlayerMenu, "");
                            DisplayInputBoxPrompt($"Enter your new gender: ");
                            _gamePirate.Gender = GetGender();
                            editingInfo = false;
                            break; ;                 

                        default:
                            break;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("You must enter a correct corresponding letter. Please try again.");
                    DisplayInputBoxPrompt($"Enter your selection, {_gamePirate.Name}: ");
                }
            }            
        }

        /// <summary>
        /// displays a closing screen upon exiting
        /// </summary>
        public void DisplayClosingScreen()
        {                        
            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 6);
            string tabSpace = new String(' ', 45);
            Console.WriteLine(tabSpace + @" _____ _                    _                                           ");
            Console.WriteLine(tabSpace + @"|_   _| |                  | |  _                                       ");
            Console.WriteLine(tabSpace + @"  | | | |__   ___    ____  | | / /___                                   ");
            Console.WriteLine(tabSpace + @"  | | |  _ \ / _ \  |  _ \ | |/ // __\                                  ");
            Console.WriteLine(tabSpace + @"  | | | | | | (_) | | | | ||  _ \\__ \                                  ");
            Console.WriteLine(tabSpace + @"  \_/ |_| |_|\__/\_\|_| |_||_| \_\___/                                  ");
            Console.WriteLine(tabSpace + @"                  _______                                               ");
            Console.WriteLine(tabSpace + @"                 /  ____/                                               ");
            Console.WriteLine(tabSpace + @"                 | |__  ___  _ __                                       ");
            Console.WriteLine(tabSpace + @"                 |  __|/ _ \| '__/                                      ");
            Console.WriteLine(tabSpace + @"                 | |  | (_) | |                                         ");
            Console.WriteLine(tabSpace + @"                 \_/   \___/|_|                                         ");
            Console.WriteLine(tabSpace + @"                            ______ _               _               _    ");
            Console.WriteLine(tabSpace + @"                            |  __ \ |             (_)             | |   ");
            Console.WriteLine(tabSpace + @"                            | |_/ / | ___ __     _ _  ____   ___  | |   ");
            Console.WriteLine(tabSpace + @"                            |  __/| |/ _ \\ \   / / ||  _ \ / _ \ |_|   ");
            Console.WriteLine(tabSpace + @"                            | |   | | (_) |\ \ / /| || | | | (_) | _    ");
            Console.WriteLine(tabSpace + @"                            \_|   |_|\__/\_\\_  / |_||_| |_|\__  |(_)   ");
            Console.WriteLine(tabSpace + @"                                            _/ /              _/ /      ");
            Console.WriteLine(tabSpace + @"                                           |__/              |__/       ");

            Console.SetCursorPosition(85, 30);
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }        

        /// <summary>
        /// displays a list of all island locations
        /// </summary>
        public void DisplayListOfIslandLocations()
        {
            DisplayGamePlayScreen("List - Island Locations", Text.ListAllRoomLocations(), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// displays a list of all game objects
        /// </summary>
        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// displays a list of all NPCs
        /// </summary>        
        public void DisplayListOfAllNpcs()
        {
            DisplayGamePlayScreen("List: NPCs", Text.ListAllNpcs(), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// gets the specific NPC the player wants to interact with
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            //
            // get a list of NPCs in the current location
            //
            List<Npc> npcsInCurrentLocation = _gameUniverse.GetNpcsByIslandLocation(_gamePirate.IslandLocationId);

            if (npcsInCurrentLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(), ActionMenu.NpcMenu, "");
                DisplayColoredNpcs(PlayerAction.TalkTo);

                while (!validNpcId)
                {
                    //
                    // get an integer fomr the user
                    //
                    GetInteger($"Enter the Id number of the NPC you wish to speak to: ", 0, 0, out npcId);

                    //
                    // validate integer as a valid game object id and in the current location
                    //                    
                    if (_gameUniverse.IsValidNpcByLocationId(npcId, _gamePirate.IslandLocationId))
                    {
                        Npc npc = _gameUniverse.GetNpcById(npcId);
                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                        }

                        if (npc.DialogueExhausted)
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"{npc.Name} has nothing more to say to you. Please try again.");
                            validNpcId = false;
                        }

                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        } 

        /// <summary>
        /// displays the NPC's message to the player
        /// </summary>
        public void DisplayTalkTo(Npc npc)
        {
            ISpeak speakingNpc = npc as ISpeak;
            bool speakingToNpc = true;
            int messageIndex = -1;

            string message = speakingNpc.Speak();

            while (speakingToNpc)
            {
                messageIndex++;
                if (messageIndex >= speakingNpc.Messages.Count)
                {
                    npc.DialogueExhausted = true;
                    DisplayInputErrorMessage($"{npc.Name} has nothing more to say at this time. Press the Enter key to continue.");
                    GetContinueKey();
                    DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");                    
                    break;
                }

                message = speakingNpc.Messages[messageIndex];

                if (message == "")
                {
                    message = "It appears this NPC has nothing to say. Please try again.";
                    DisplayGamePlayScreen($"Speak to Character: {npc.Name}", message, ActionMenu.NpcMenu, "");
                    speakingToNpc = false;
                }

                DisplayGamePlayScreen($"Speak to Character: {npc.Name}", message, ActionMenu.NpcMenu, "");
                DisplayInputBoxPrompt("Would you like to continue this conversation? (Yes or No): ");

                //
                // determines if the user would like to continue the current conversation
                //
                if (GetString() == "NO")
                {
                    DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                    DisplayInputErrorMessage($"NOTE: {npc.Name} has nothing more to say");
                    speakingToNpc = false;
                }                
            }
        }

        /// <summary>
        /// gets the specific game object the player wants to look at
        /// </summary>
        public int DisplayGetGameObjectsToLookAt()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of game objects in the current island location
            //
            List<GameObject> gameObjectsInIslandLocation = _gameUniverse.GetGameObjectsByIslandLocaitonId(_gamePirate.IslandLocationId);

            if (gameObjectsInIslandLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInIslandLocation), ActionMenu.ObjectMenu, "");
                DisplayColoredObjects(PlayerAction.LookAround, 0);
                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in the current location
                    //
                    if (_gameUniverse.IsValidGameObjectByLocaitonId(gameObjectId, _gamePirate.IslandLocationId))
                    {
                        validGameObjectId = true;
                        _gamePirate.IndividualGameObject = gameObjectId;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You have entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// displays information for a specific game object
        /// </summary>
        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen($"{gameObject.Name} Information", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// displays information pertaining to the current location
        /// </summary>
        public void DisplayLookAround()
        {
            //
            // get current island location
            //
            IslandLocation currentIslandLocation = _gameUniverse.GetIslandLocationById(_gamePirate.IslandLocationId);

            //
            // get list of game objects in current island location
            //
            List<GameObject> gameObjectsInCurrentIslandLocation = _gameUniverse.GetGameObjectsByIslandLocaitonId(_gamePirate.IslandLocationId);

            //
            // get list of game objects in current island location
            //
            List<Npc> npcsInCurrentLocation = _gameUniverse.GetNpcsByIslandLocation(_gamePirate.IslandLocationId);

            string messageBoxText = Text.LookAround(currentIslandLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentIslandLocation);


            DisplayGamePlayScreen("Current Location - Look Around", messageBoxText, ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// gets a location ID and confirms if it's valid
        /// </summary>        
        public int DisplayGetNextIslandLocation()
        {
            int islandLocationId = 0;
            bool validIslandLocationId = false;

            DisplayGamePlayScreen("Travel to a new Island", Text.Travel(_gamePirate), ActionMenu.MainMenu, "");
            DisplayColoredText("", PlayerAction.Travel, _gameUniverse.IslandLocations[1]);

            while (!validIslandLocationId)
            {
                //
                // get and integer from the user
                //
                GetInteger($"Enter your new location {_gamePirate.Name}: ", 0, _gameUniverse.GetMaxIslandLocationId(), out islandLocationId);

                //
                // validate choosen integer and determine accessbility level
                //
                if (_gameUniverse.IsValidIslandLocationId(islandLocationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(islandLocationId))
                    {
                        validIslandLocationId = true;
                    }
                    else
                    {
                        // display a specfic error message based on the choosen ID/location
                        switch(islandLocationId)
                        {
                            case 3:
                                #region ***ISLA DE LA MUERTE
                                
                                    ClearInputBox();
                                    DisplayInputErrorMessage("More XP, or a strong ship and crew are needed to travel to here. Please try again. ");
                                    break;
                                
                                #endregion
                            case 4:
                                #region ***MONARCH BAY
                                
                                    ClearInputBox();
                                    DisplayInputErrorMessage("Monarch Bay is expensive. More Coin is needed to travel to here. Please try again. ");
                                    break;
                                
                                #endregion 
                            case 5:
                                #region ***ISLE DU SOLEIL
                                
                                    ClearInputBox();
                                    DisplayInputErrorMessage("A special object is required to navigate these dangerous waters. Please try again. ");
                                    break;                                

                                #endregion
                            case 6:
                                #region ***RENEGADE'S BEACH

                                    ClearInputBox();
                                    DisplayInputErrorMessage("You need a strong ship to travel and defend against pirates here. Please try again.");                                    
                                    break;                                

                                #endregion
                            case 7:
                                #region ***SHIPWRECK COVE

                                    ClearInputBox();
                                    DisplayInputErrorMessage("A small ship is needed to maneuver through these crowded waters. Please try again. ");
                                    break;

                                #endregion
                            default:
                                #region ***DEFAULT

                                ClearInputBox();
                                DisplayInputErrorMessage("It appears you attempted to travel to inaccessible location. Please try again.");

                                #endregion
                                break;
                        }                        
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("It appears you entered an invalid Island location ID. Please try again.");
                }
            }

            return islandLocationId;
        }

        /// <summary>
        /// displays all locations that the player has already visited
        /// </summary>
        public void DisplayLocationsVisited()
        {
            List<IslandLocation> visitedIslandLocations = new List<IslandLocation>();

            foreach (int islandLocationID in _gamePirate.IslandLocationsVisited)
            {
                visitedIslandLocations.Add(_gameUniverse.GetIslandLocationById(islandLocationID));
            }

            DisplayGamePlayScreen("Islands Visited", Text.VisitedLocations(), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// displays the player's current treasure inventory
        /// </summary>
        public void DisplayTreasureInventory()
        {
            DisplayGamePlayScreen("Your Treasure", Text.CurrentTreasureInventory(_gamePirate.TreasureInventory), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// displays the player's current inventory
        /// </summary>
        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePirate.Inventory), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// allows player to choose an item to add to their invetory, and validates for correct choices
        /// </summary>
        public int DisplayGetGameObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of game objects located in the current location
            //
            List<GameObject> gameObjectsInIslandLocation = _gameUniverse.GetGameObjectsByIslandLocaitonId(_gamePirate.IslandLocationId);

            if (gameObjectsInIslandLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Object", Text.GameObjectsChooseList(gameObjectsInIslandLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get integer from player
                    //
                    GetInteger($"Enter the ID number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate chosen integer, make sure its a valid game object id
                    //
                    if (_gameUniverse.IsValidGameObjectByLocaitonId(gameObjectId, _gamePirate.IslandLocationId))
                    {
                        GameObject gameObject = _gameUniverse.GetObjectById(gameObjectId);
                        if (gameObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("This object may not be added to your inventory. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you have entered an invalid game object ID. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Object", "It appears that there are no objects in this location.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// allows player to choose an item to remove from their invetory, and validates for correct choices
        /// </summary>
        public int DisplayGetGameObjectToPutDown()
        {
            int gameObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gamePirate.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Object", Text.GameObjectsChooseList(_gamePirate.Inventory), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get integer from player
                    //
                    GetInteger($"Enter the ID number of the object you wish to remove from your inventory: ", 0, 0, out gameObjectId);

                    //
                    // find game object in player's inventory
                    //
                    GameObject objectToPutDown = null; 
                    foreach (GameObject gameObject in _gamePirate.Inventory)
                    {
                        if (gameObject.Id == gameObjectId)
                        {
                            objectToPutDown = gameObject;
                        }
                    }

                    //
                    // validate chosen game object
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you have entered an ID not in your current inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Put Down Object", "It appears that there are no objects in your inventory.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// displays a confirmation that items have been added to player's inventory
        /// </summary>
        public void DisplayConfirmGameObjectAddedToInvetory(GameObject gameObjectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Object", $"The {gameObjectAddedToInventory.Name} has been added to your inventory.", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// displays a confirmation that items have been removed from the player's inventory
        /// </summary>
        public void DisplayConfirmGameObjectRemovedFromInvetory(GameObject gameObjectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Object", $"The {gameObjectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }

        #endregion

        #endregion
    }
}
