using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES



        #endregion

        #region FIELDS

        private bool _shipOwner;
        private int _age;
        private int _health;
        private int _lives;
        private int _experiencePoints;
        private string _shipName;
        private List<string> _crew;
        private List<int> _islandLocationsVisited;
        private List<GameObject> _inventory;


        //
        // *NOTE: field, property pair used to examine/use individual objects

        private int _individualGameObject;

        public int IndividualGameObject
        {
            get { return _individualGameObject; }
            set { _individualGameObject = value; }
        }

        private List<Treasure> _treasureInventory;

        public List<Treasure> TreasureInventory
        {
            get { return _treasureInventory; }
            set { _treasureInventory = value; }
        }


        #endregion

        #region PROPERTIES

        public bool ShipOwner
        {
            get { return _shipOwner; }
            set { _shipOwner = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public string ShipName
        {
            get { return _shipName; }
            set { _shipName = value; }
        }

        public List<string> Crew
        {
            get { return _crew; }
            set { _crew = value; }
        }

        public List<int> IslandLocationsVisited
        {
            get { return _islandLocationsVisited; }
            set { _islandLocationsVisited = value; }
        }

        public List<GameObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _islandLocationsVisited = new List<int>();
            _inventory = new List<GameObject>();
            _treasureInventory = new List<Treasure>();

            _crew = new List<string>();
        }

        public Player(string name, GenderType gender, int islandLocationID) : base(name, gender, islandLocationID)
        {
            _islandLocationsVisited = new List<int>();
            _inventory = new List<GameObject>();
            _treasureInventory = new List<Treasure>();

            _crew = new List<string>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// sets player's greeting based on gender and personlity type
        /// </summary>        
        public override string Greeting()
        {
            if (base.Personality)
            {
                return $"Hello! my name is {base.Name}, nice to meet you!";
            }
            else
            {
                if (base.Gender == GenderType.MALE)
                {
                    return "You're a waste of space, but lets talk.";
                }
                else if (base.Gender == GenderType.FEMALE)
                {
                    return "We need to speak, but don't waste my time.";
                }
                else
                {
                    return "As much as I don't want to, we gotta talk.";
                }
            }
        }

        
        
        /// <summary>
        /// determines if the player has visited the island location
        /// </summary>     
        public bool HasVisited(int _islandLocationID)
        {
            if (IslandLocationsVisited.Contains(_islandLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        #endregion
    }
}
            
