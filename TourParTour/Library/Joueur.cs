using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TourParTour.Library
{
    internal class Joueur
    {
        #region Champs
        public int _vieJoueur;
        public int _degatJoueur;
        public int _manaJoueur;
        public int _puissanceMagique;
        #endregion

        #region Constructeur
        public Joueur(int vieJoueur, int degatJoueur, int manaJoueur, int puissanceMagique)
        {
            this._vieJoueur = vieJoueur;
            this._degatJoueur = degatJoueur;
            this._manaJoueur = manaJoueur;
            this._puissanceMagique = puissanceMagique;
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

        public int manaJoueur
        {
            get { return _manaJoueur; }
            set { _manaJoueur = value; }
        }

        public int puissanceMagique
        {
            get { return _puissanceMagique; }
            set { _puissanceMagique = value; }
        }
        #endregion

        #region Méthode
        public int Attaque(Ennemi unEnnemi)
        {
            int vieDeEnnemi = unEnnemi.vieEnnemi - degatJoueur;

            return vieDeEnnemi;
        }
        #endregion
    }
}
