using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Treasure : GameObject
    {
        #region ENUMS

        public enum RarityLevel
        {
            Common,
            Uncommon,
            Unique,
            Rare,
            Legendary
        }

        #endregion

        #region FIELDS

        private int _quantity;
        private RarityLevel _rarityLevel;

        #endregion

        #region PROPERTIES

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public RarityLevel Rarity
        {
            get { return _rarityLevel; }
            set { _rarityLevel = value; }
        }

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion
    }
}
