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

        public enum ShipType
        {
            None,
            Sloop,
            Frigate,
            Galleon,
            BritishManOWar,
            SpanishGalleon,
            Merchant            
        }

        #endregion

        #region FIELDS

        private bool _shipOwner;
        private int _age;
        private ShipType _ship;
        private List<string> _crew;        
        private string _shipName;
        private List<int> _islandLocationsVisited;

        #endregion

        #region PROPERTIES

        public List<string> Crew
        {
            get { return _crew; }
            set { _crew = value; }
        }

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

             
        public string ShipName
        {
            get { return _shipName; }
            set { _shipName = value; }
        }

        public ShipType Ship
        {
            get { return _ship; }
            set { _ship = value; }
        }

        public List<int> IslandLocationsVisited
        {
            get { return _islandLocationsVisited; }
            set { _islandLocationsVisited = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _islandLocationsVisited = new List<int>();
        }

        public Player(string name, GenderType gender, int islandLocationID) : base(name, gender, islandLocationID)
        {
            _islandLocationsVisited = new List<int>();
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
        /// displays breif informatio abut each ship type
        /// </summary>
        public string ShipInfo(Player gamePirate)
        {            
            if (_shipOwner)
            {
                switch (gamePirate.Ship)
                {
                    case ShipType.Sloop:
                        return $"{_ship}; A small, fast, lightweight ship, ideal for speed but not for battle.";
                        
                    case ShipType.Frigate:
                        return $"{_ship}; A slow, large ship designed for extended, intense battles.";

                    case ShipType.Galleon:
                        return $"{_ship}; A semi-fast large ship designed for treasure transporatation/battle.";

                    case ShipType.BritishManOWar:
                        return "British Man-O-War; A massive English Naval warship capable of devastating amounts of destruction.";

                    case ShipType.SpanishGalleon:
                        return "Spanish Galleon; An ornate Spanish warship with almost an endless amount of cargo/crew space.";

                    case ShipType.Merchant:
                        return $"{_ship}; A standard merchant ship that is fast and durable with extra space for cagro.";

                    default:
                        return $"{_ship}, it is very important you have a ship in order to succeed.";
                }
            }
            else
            {
                return $"{_ship}, it is very important you have a ship in order to succeed.";
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
            
