using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace Sudoku
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ConstructGrid(int level)
        {
            g = new Grille();
            g.generateGrid();

            dataGrid.ColumnCount = Grille.TAILLE_LIGNE;
            dataGrid.RowCount = Grille.TAILLE_COL;

            for(int i=0; i< Grille.TAILLE_COL; i++)
            {
                dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns[i].Width = 55;
                dataGrid.Rows[i].Height = 55;
                dataGrid.Columns[i].DefaultCellStyle.Font = new Font(dataGrid.DefaultCellStyle.Font.FontFamily, 22, FontStyle.Bold);
                for(int j=0; j< Grille.TAILLE_LIGNE; j++)
                {
                    dataGrid[j,i].Value = g.Tableau[i, j].Valeur;
                    dataGrid[j, i].ReadOnly = true;
                    dataGrid[j, i].Style.BackColor = Color.LightYellow;
                }
            }

            Random random = new Random();

            switch(level)
            {
                case 1:
                    //On dévoile 50 cases, on en cache donc 31
                    int cpt = 0;
                    while(cpt<31)
                    {
                        int randomCol = random.Next(0, Grille.TAILLE_LIGNE);
                        int randomLigne = random.Next(0, Grille.TAILLE_LIGNE);
                        this.dataGrid[randomLigne, randomCol].Value = "";
                        this.dataGrid[randomLigne, randomCol].ReadOnly = false;
                        this.dataGrid[randomLigne, randomCol].Style.BackColor = Color.White;
                        cpt++;
                    }
                    break;
            }
         }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.titre = new System.Windows.Forms.Label();
            this.difficulteLabel = new System.Windows.Forms.Label();
            this.levelChooser = new System.Windows.Forms.NumericUpDown();
            this.genererNouvelleGrille = new System.Windows.Forms.Button();
            this.grilleActuelLabel = new System.Windows.Forms.Label();
            this.nivActuel = new System.Windows.Forms.Label();
            this.restart = new System.Windows.Forms.Button();
            this.verify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelChooser)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(10, 10);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidth = 4;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGrid.RowTemplate.Height = 28;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(498, 498);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGrid_CellBeginEdit);
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            // 
            // titre
            // 
            this.titre.AutoSize = true;
            this.titre.Font = new System.Drawing.Font("Segoe Print", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.Location = new System.Drawing.Point(550, 10);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(213, 85);
            this.titre.TabIndex = 1;
            this.titre.Text = "Sudoku";
            this.titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficulteLabel
            // 
            this.difficulteLabel.AutoSize = true;
            this.difficulteLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulteLabel.Location = new System.Drawing.Point(518, 111);
            this.difficulteLabel.Name = "difficulteLabel";
            this.difficulteLabel.Size = new System.Drawing.Size(108, 33);
            this.difficulteLabel.TabIndex = 2;
            this.difficulteLabel.Text = "Difficulté:";
            this.difficulteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levelChooser
            // 
            this.levelChooser.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelChooser.Location = new System.Drawing.Point(629, 115);
            this.levelChooser.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.levelChooser.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelChooser.Name = "levelChooser";
            this.levelChooser.Size = new System.Drawing.Size(120, 30);
            this.levelChooser.TabIndex = 3;
            this.levelChooser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.levelChooser.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // genererNouvelleGrille
            // 
            this.genererNouvelleGrille.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genererNouvelleGrille.Location = new System.Drawing.Point(565, 160);
            this.genererNouvelleGrille.Name = "genererNouvelleGrille";
            this.genererNouvelleGrille.Size = new System.Drawing.Size(184, 38);
            this.genererNouvelleGrille.TabIndex = 4;
            this.genererNouvelleGrille.Text = "Générer une grille";
            this.genererNouvelleGrille.UseVisualStyleBackColor = true;
            this.genererNouvelleGrille.Click += new System.EventHandler(this.genererNouvelleGrille_Click);
            // 
            // grilleActuelLabel
            // 
            this.grilleActuelLabel.AutoSize = true;
            this.grilleActuelLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grilleActuelLabel.Location = new System.Drawing.Point(518, 264);
            this.grilleActuelLabel.Name = "grilleActuelLabel";
            this.grilleActuelLabel.Size = new System.Drawing.Size(152, 33);
            this.grilleActuelLabel.TabIndex = 5;
            this.grilleActuelLabel.Text = "Grille actuelle:";
            this.grilleActuelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nivActuel
            // 
            this.nivActuel.AutoSize = true;
            this.nivActuel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nivActuel.Location = new System.Drawing.Point(676, 268);
            this.nivActuel.Name = "nivActuel";
            this.nivActuel.Size = new System.Drawing.Size(57, 28);
            this.nivActuel.TabIndex = 6;
            this.nivActuel.Text = "niv. -";
            // 
            // restart
            // 
            this.restart.Enabled = false;
            this.restart.Font = new System.Drawing.Font("Segoe Print", 12F);
            this.restart.Location = new System.Drawing.Point(561, 311);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(202, 34);
            this.restart.TabIndex = 7;
            this.restart.Text = "Recommencer la grille";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // verify
            // 
            this.verify.Enabled = false;
            this.verify.Font = new System.Drawing.Font("Segoe Print", 12F);
            this.verify.Location = new System.Drawing.Point(580, 369);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(159, 33);
            this.verify.TabIndex = 8;
            this.verify.Text = "Vérifier la grille";
            this.verify.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.nivActuel);
            this.Controls.Add(this.grilleActuelLabel);
            this.Controls.Add(this.genererNouvelleGrille);
            this.Controls.Add(this.levelChooser);
            this.Controls.Add(this.difficulteLabel);
            this.Controls.Add(this.titre);
            this.Controls.Add(this.dataGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelChooser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private Label titre;
        private Label difficulteLabel;
        private NumericUpDown levelChooser;
        private Button genererNouvelleGrille;
        private Label grilleActuelLabel;
        private Label nivActuel;
        private Button restart;
        private Button verify;

    }
}

