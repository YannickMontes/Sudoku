using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class FenetrePrincipale : Form
    {
        /// <summary>
        /// Permet de stocket l'ancienne valeur de la cellule, utilisée en cas de passage de mauvaise valeur par l'utilisateur.
        /// </summary>
        private object oldValue;
        /// <summary>
        /// Stocke la grille de sudoku actuelle.
        /// </summary>
        private Grille g;
        /// <summary>
        /// Permet de recommencer la grille (avec les trous déjà placés).
        /// </summary>
        private object[,] grilleActuelleDebut;

        /// <summary>
        /// Initialise la fênetre
        /// </summary>
        public FenetrePrincipale()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction d'action du début d'édition d'une cellule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.oldValue = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value;
        }

        /// <summary>
        /// Fonction d'action de fin d'édition d'une cellule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int newValue = int.Parse(((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value.ToString());
                if (newValue > 9 || newValue < 1)
                {
                    ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = oldValue;
                }
            }
            catch (Exception ex)
            {
                if (!(((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value == null))
                {
                    ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = oldValue;
                }
            }
            this.verify.Enabled = this.grilleRemplie();
        }

        /// <summary>
        /// Fonction d'action de génération d'une nouvelle grille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genererNouvelleGrille_Click(object sender, EventArgs e)
        {
            int level = (int)this.levelChooser.Value;

            g = new Grille();
            g.generateGrid();

            this.grilleActuelleDebut = new object[Grille.TAILLE_COL, Grille.TAILLE_LIGNE];
            dataGrid.ColumnCount = Grille.TAILLE_LIGNE;
            dataGrid.RowCount = Grille.TAILLE_COL;

            for (int i = 0; i < Grille.TAILLE_COL; i++)
            {
                dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns[i].Width = 55;
                dataGrid.Rows[i].Height = 55;
                dataGrid.Columns[i].DefaultCellStyle.Font = new Font(dataGrid.DefaultCellStyle.Font.FontFamily, 22, FontStyle.Bold);
                for (int j = 0; j < Grille.TAILLE_LIGNE; j++)
                {
                    dataGrid[j, i].Value = g.Tableau[i, j].Valeur;
                    dataGrid[j, i].ReadOnly = true;
                    dataGrid[j, i].Style.BackColor = Color.LightYellow;
                    grilleActuelleDebut[j, i] = g.Tableau[i, j].Valeur;
                }
            }

            Random random = new Random();

            switch (level)
            {
                case 1:
                    //On dévoile 50 cases, on en cache donc 31
                    int cpt = 0;
                    while (cpt < 31)
                    {
                        int randomCol = random.Next(0, Grille.TAILLE_LIGNE);
                        int randomLigne = random.Next(0, Grille.TAILLE_LIGNE);
                        this.dataGrid[randomLigne, randomCol].Value = null;
                        this.dataGrid[randomLigne, randomCol].ReadOnly = false;
                        this.dataGrid[randomLigne, randomCol].Style.BackColor = Color.White;
                        this.grilleActuelleDebut[randomLigne, randomCol] = null;
                        cpt++;
                    }
                    break;
            }
            this.restart.Enabled = true;
        }

        /// <summary>
        /// Fonction d'action de recommencement d'une grille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Grille.TAILLE_COL; i++)
            {
                for (int j = 0; j < Grille.TAILLE_LIGNE; j++)
                {
                    this.dataGrid[j, i].Value = this.grilleActuelleDebut[j, i];
                }
            }
        }

        /// <summary>
        /// Fonction permetant de vérifier si la grille est remplie par l'utilisateur ou non.
        /// </summary>
        /// <returns>Vrai si la grille est remplie, faux sinon.</returns>
        private bool grilleRemplie()
        {
            for (int i = 0; i < Grille.TAILLE_COL; i++)
            {
                for (int j = 0; j < Grille.TAILLE_LIGNE; j++)
                {
                    if (this.dataGrid[j, i].Value == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
