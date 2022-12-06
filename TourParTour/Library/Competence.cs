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
        public string _keyForUse;
        #endregion

        #region Constructeur
        public Competence(string nomCompetence, int degatCompetence, string keyForUse)
        {
            this._nomCompetence = nomCompetence;
            this._degatCompetence = degatCompetence;
            this._keyForUse = keyForUse;
        }
        #endregion

        #region Get / Set
        public string NomCompetence
        {
            get { return _nomCompetence; }
            set { _nomCompetence = value; }
        }

        public int DegatCompetence
        {
            get { return _degatCompetence; }
            set { _degatCompetence = value; }
        }
        public string KeyForUse
        {
            get { return _keyForUse; }
            set { _keyForUse = value; }
        }
        #endregion
    }
}
