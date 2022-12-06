using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourParTour.Library
{
    public class Joueur
    {
        #region Champs
        public int _vieJoueur;
        public int _degatJoueur;
        #endregion

        #region Constructeur
        public Joueur(int vieJoueur, int degatJoueur)
        {
            this._vieJoueur = vieJoueur;
            this._degatJoueur = degatJoueur;
        }
        #endregion

        #region Get / Set
        public int vieJoueur
        {
            get { return _vieJoueur; }
            set { _vieJoueur = value; }
        }

        public int degatJoueur
        {
            get { return _degatJoueur; }
            set { _degatJoueur = value; }
        }
        #endregion
    }
}
