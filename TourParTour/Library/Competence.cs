using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourParTour.Library
{
    public class Competence
    {
        #region Champs
        public string _nomCompetence;
        public int _degatCompetence;
        public int _manaCompetence;
        public string _keyForUse;
        #endregion

        #region Constructeur
        public Competence(string nomCompetence, int degatCompetence, int manaCompetence, string keyForUse)
        {
            this._nomCompetence = nomCompetence;
            this._degatCompetence = degatCompetence;
            this._manaCompetence = manaCompetence;
            this._keyForUse = keyForUse;
        }
        #endregion

        #region Get / Set
        public string nomCompetence
        {
            get { return _nomCompetence; }
            set { _nomCompetence = value; }
        }

        public int degatCompetence
        {
            get { return _degatCompetence; }
            set { _degatCompetence = value; }
        }
        public int manaCompetence
        {
            get { return _manaCompetence; }
            set { _manaCompetence = value; }
        }
        public string keyForUse
        {
            get { return _keyForUse; }
            set { _keyForUse = value; }
        }
        #endregion
    }
}
