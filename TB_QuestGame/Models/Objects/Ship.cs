using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Ship : GameObject
    {
        #region ENUMS

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

        private ShipType _type;

        #endregion

        #region PROPERTIES

        public ShipType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

        #region CONSTRCUTORS

        #endregion

        #region METHODS

        #endregion



       


        /// <summary>
        /// displays breif informatio abut each ship type
        /// </summary>
        //public string ShipInfo(Player gamePirate)
        //{
        //    if (gamePirate.ShipOwner)
        //    {
        //        switch (gamePirate.)
        //        {
        //            case ShipType.Sloop:
        //                return $"{_type}; A small, fast, lightweight ship, ideal for speed but not for battle.";

        //            case ShipType.Frigate:
        //                return $"{_type}; A slow, large ship designed for extended, intense battles.";

        //            case ShipType.Galleon:
        //                return $"{_type}; A semi-fast large ship designed for treasure transporatation/battle.";

        //            case ShipType.BritishManOWar:
        //                return "British Man-O-War; A massive English Naval warship capable of devastating amounts of destruction.";

        //            case ShipType.SpanishGalleon:
        //                return "Spanish Galleon; An ornate Spanish warship with almost an endless amount of cargo/crew space.";

        //            case ShipType.Merchant:
        //                return $"{_type}; A standard merchant ship that is fast and durable with extra space for cagro.";

        //            default:
        //                return $"{_type}, it is very important you have a ship in order to succeed.";
        //        }
        //    }
        //    else
        //    {
        //        return $"{_type}, it is very important you have a ship in order to succeed.";
        //    }
        //}
    }
}
