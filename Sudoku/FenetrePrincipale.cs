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
        private Grille grille;
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

            grille = new Grille();
            grille.generateGrid();

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
                    dataGrid[i, j].Value = grille.Tableau[i, j].Valeur;
                    dataGrid[i, j].ReadOnly = true;
                    dataGrid[i, j].Style.BackColor = Color.LightYellow;
                    grilleActuelleDebut[i, j] = grille.Tableau[i, j].Valeur;
                }
            }


            switch (level)
            {
                case 1:
                    //On dévoile 50 cases, on en cache donc 31
                    cacherCellules(31);
                    break;
                case 2:
                    cacherCellules(40);
                    break;
                case 3:
                    cacherCellules(50);
                    break;
            }
            this.restart.Enabled = true;
            this.nivActuel.Text = "Niv. " + level;
            this.dataGrid.Enabled = true ;
        }

        /// <summary>
        /// Fonction permettant de cacher un certains nombre de cellules de la grille.
        /// </summary>
        /// <param name="nb">Nombre de cellules à cacher.</param>
        private void cacherCellules(int nb)
        {
            Random random = new Random();

            int cpt = 0;
            while (cpt < nb)
            {
                int randomCol = random.Next(0, Grille.TAILLE_LIGNE);
                int randomLigne = random.Next(0, Grille.TAILLE_LIGNE);
                this.dataGrid[randomLigne, randomCol].Value = null;
                this.dataGrid[randomLigne, randomCol].ReadOnly = false;
                this.dataGrid[randomLigne, randomCol].Style.BackColor = Color.White;
                this.grilleActuelleDebut[randomLigne, randomCol] = null;
                cpt++;
            }
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
                    this.dataGrid[i, j].Value = this.grilleActuelleDebut[i, j];
                    if(this.dataGrid[i,j].Value == null)
                    {
                        this.dataGrid[i, j].Style.BackColor = Color.White;
                    }
                }
            }
            this.dataGrid.Enabled = true;
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
                    if (this.dataGrid[i, j].Value == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Fonction d'action de vérification de la grille une fois remplie par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verify_Click(object sender, EventArgs e)
        {
            bool correct = true;
            for (int i = 0; i < Grille.TAILLE_COL; i++)
            {
                for (int j = 0; j < Grille.TAILLE_LIGNE; j++)
                {
                    if (int.Parse(this.dataGrid[i,j].Value.ToString()) != grille.Tableau[i,j].Valeur)
                    {
                        correct = false;
                        this.dataGrid[i, j].Style.BackColor = Color.Red;
                    }
                }
            }
            if(correct)
            {
                this.resultat.Text = "Vous avez gagné! Pour rejouer, regénérez une grille.";
                this.resultat.ForeColor = Color.Green;
                this.dataGrid.Enabled = false;
            }
            else 
            {
                this.resultat.Text = "La grille proposée n'est pas correcte..";
                this.resultat.ForeColor = Color.Red;
            }
            this.resultat.Visible = true;
        }
    }
}
