using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Grille
    {
        /// <summary>
        /// Représente le nombre de case que comporte une ligne, en nombre entier.
        /// </summary>
        public const int TAILLE_LIGNE = 9;
        /// <summary>
        /// Représente le nombre de case que comporte une colonne, en nombre entier.
        /// </summary>
        public const int TAILLE_COL = 9;
        /// <summary>
        /// Représente le nombre de case par côté du carré.
        /// </summary>
        public const int TAILLE_SQUARE = 3;
        /// <summary>
        /// Permet de stocket la valeur de chaque case de la grille.
        /// </summary>
        private Case[,] tableau;

        /// <summary>
        /// Permet d'accéder au tableau contenant chaque case de la grille et leurs valeurs.
        /// </summary>
        public Case[,] Tableau
        {
            get
            {
                return tableau;
            }
            set
            {
                tableau = value;
            }
        }

        /// <summary>
        /// Contructeur de base, initialisant le tableau, et toutes ses cases avec la valeur -1.
        /// </summary>
        public Grille()
        {
            this.tableau = new Case[TAILLE_LIGNE, TAILLE_COL];
            for (int i = 0; i < TAILLE_LIGNE; i++)
            {
                for (int j = 0; j < TAILLE_COL; j++)
                {
                    this.tableau[i, j] = new Case(-1);
                }
            }
        }

        //Methods

        /// <summary>
        /// Vérifie si la valeur passée en paramètre est dans la ligne passée en paramètre.
        /// </summary>
        /// <returns><c>true</c> si la valeur est dans la ligne, <c>false</c> sinon.</returns>
        /// <param name="val">Value.</param>
        /// <param name="ligne">Ligne.</param>
        private bool isInLine(int val, int ligne)
        {
            for (int i = 0; i < TAILLE_LIGNE; i++) //Pour chaque case de la ligne
            {
                if (tableau[ligne, i].Valeur == val) //Si la valeur de la case est égale à la valeur passée en paramètre 
                {
                    return true;
                }
                if (this.tableau[ligne, i].Valeur == -1)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Vérfie si la valeur passée en paramètre est dans la colonne passée en paramètre.
        /// </summary>
        /// <returns><c>true</c> si la valeur est dans la colonne, <c>false</c> sinon.</returns>
        /// <param name="val">Value.</param>
        /// <param name="col">Col.</param>
        private bool isInColumn(int val, int col)
        {
            for (int i = 0; i < TAILLE_COL; i++) //Pour chaque case de la colonne
            {
                if (tableau[i, col].Valeur == val) //Si la valeur de la case est égale à la valeur passée en paramètre 
                {
                    return true;
                }
                if (this.tableau[i, col].Valeur == -1)
                {
                    return false;
                }
            }

            return false;
        }
        /// <summary>
        /// Vérifie si la valeur passée en paramètre est dans le carré défini par les colonnes et lignes passé en paramètre
        /// </summary>
        /// <returns><c>true</c> si la valeur est dans le carré, <c>false</c> sinon.</returns>
        /// <param name="val">Value.</param>
        /// <param name="ligne">Ligne.</param>
        /// <param name="col">Col.</param>
        private bool isInSquare(int val, int ligne, int col)
        {
            //Obtention des délimitations du carré
            int minLigne = TAILLE_SQUARE * (ligne / TAILLE_SQUARE);
            int minCol = TAILLE_SQUARE * (col / TAILLE_SQUARE);
            int maxLigne = minLigne + TAILLE_SQUARE-1;
            int maxCol = minCol + TAILLE_SQUARE-1;
            //Vérification de l'apparance du chiffre dans le carré
            for (int i = minLigne; i <= maxLigne; i++)
            {
                for (int j = minCol; j <= maxCol; j++)
                {
                    if (this.tableau[i, j].Valeur == val)
                    {
                        return true;
                    }
                    if (this.tableau[i, j].Valeur == -1)
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Permet de générer une grille aléatoirement, en respectant les règles du sudoku.
        /// </summary>
        public void generateGrid()
        {
            Random random = new Random();
            for (int i = 0; i < TAILLE_LIGNE; i++)
            {
                List<int> valeursUtilises = new List<int>();
                for (int k = 1; k <= TAILLE_LIGNE; k++)
                {
                    valeursUtilises.Add(k);
                }
                for (int j = 0; j < TAILLE_COL; j++)
                {
                    int randomVal,cpt=1;
                    do
                    {
                        randomVal = random.Next(0, valeursUtilises.Count);
                        cpt++;
                    } while (cpt<1000 && (isInColumn(valeursUtilises.ElementAt(randomVal), j) || isInLine(valeursUtilises.ElementAt(randomVal), i) || isInSquare(valeursUtilises.ElementAt(randomVal), i, j)));
                    if (cpt >= 1000)
                    {
                        for (int l = 0; l < TAILLE_COL; l++ )
                        {
                            this.tableau[i, l].Valeur = -1;
                        }
                        j = TAILLE_COL;
                        i--;
                    }
                    else
                    {
                        this.tableau[i, j].Valeur = valeursUtilises.ElementAt(randomVal);
                        valeursUtilises.RemoveAt(randomVal);
                    }           
                }
            }
        }

        /// <summary>
        /// Surcharge de la méthode ToString.
        /// </summary>
        /// <returns>Une chaîne de caractère contenant la grille. Peut directement être affiché dans un Console.WriteLine.</returns>
        public override string ToString()
        {
            string ret = "Grille:\n";
            for (int i = 0; i < TAILLE_LIGNE; i++) //Pour chaque case de la ligne
            {
                for (int j = 0; j < TAILLE_COL; j++)
                {
                    ret += this.tableau[i, j].ToString();
                }
                ret += "\n";
            }
            return ret;
        }
    }
}
