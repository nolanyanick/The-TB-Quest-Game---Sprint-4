using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    class Food : GameObject
    {

        #region ENUMS




        #endregion

        #region FIELDS

        private bool _isSpoiled;
        private int _healthPoints;

        #endregion

        #region PROPERTIES

        public bool IsSpoiled
        {
            get { return _isSpoiled; }
            set { _isSpoiled = value; }
        }

        public int HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }      

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion

       




    }
}
