using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Case
    {
        /// <summary>
        /// Champ contenant la valeur actuelle entière de la case.
        /// </summary>
        private int valeur;

        /// <summary>
        /// Permet d'accéder au champ valeur de la classe case.
        /// </summary>
        public int Valeur
        {
            get
            {
                return valeur;
            }
            set
            {
                valeur = value;
            }
        }

        /// <summary>
        /// Constructeur de base, permettant de construire une case avec une valeur passée en paramètre.
        /// </summary>
        /// <param name="val">Valeur à attribuer a la case.</param>
        public Case(int val)
        {
            this.valeur = val;
        }

        /// <summary>
        /// Méthode ToString surchargée.
        /// </summary>
        /// <returns>La valeur de la case sous forme de string, avec un espace avant et après la valeur.</returns>
        public override string ToString()
        {
            return string.Format(" {0} ", Valeur);
        }
    }
}
