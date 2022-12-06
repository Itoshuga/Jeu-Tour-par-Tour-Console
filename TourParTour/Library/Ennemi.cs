using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourParTour.Library
{
    internal class Ennemi
    {
        #region Champs
        public int _vieEnnemi;
        public int _degatEnnemi;
        #endregion

        #region Constructeur
        public Ennemi(int vieEnnemi, int degatEnnemi)
        {
            this._vieEnnemi = vieEnnemi;
            this._degatEnnemi = degatEnnemi;
        }
        #endregion

        #region Get / Set
        public int vieEnnemi
        {
            get { return _vieEnnemi; }
            set { _vieEnnemi = value; }
        }

        public int degatEnnemi
        {
            get { return _degatEnnemi; }
            set { _degatEnnemi = value; }
        }
        #endregion
    }
}
