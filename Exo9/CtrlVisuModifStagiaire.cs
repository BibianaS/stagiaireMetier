using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exo9
{
    public class CtrlVisuModifStagiaire
    {

        private MStagiaire leStagiaire;
        private frmVisuStagiaire frmVisu;

        /// <summary>
        /// COnstructeur visu modi stagiaire
        /// recoit en parametre une ref de MStagiares
        /// </summary>
        /// <param name="unStagiaire"></param>
        public CtrlVisuModifStagiaire(MStagiaire unStagiaire)
        {
            //Recupere la reference du stagiaire
            this.leStagiaire = unStagiaire;
            // instancier un form détail pour ce stagiaire
            this.frmVisu = new frmVisuStagiaire(leStagiaire);
            // personnaliser le titre du form
            this.frmVisu.Text = leStagiaire.ToString();

            this.frmVisu.btnSaisirNote.Click += new System.EventHandler(this.btnSaisirNote_Click);
            this.frmVisu.btnValider.Click += new System.EventHandler(this.btnValider_Click);

            // afficher le form détail en modal
            this.frmVisu.ShowDialog();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            this.frmVisu.Valider();
        }

        /// <summary>
        /// bouton saisir note : afficher le form complémentaire en modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSaisirNote_Click(object sender, EventArgs e)
        {
            // instancier et impacter la note saisie sur le stagiaire
            frmSaisieNote frmSaisie = new frmSaisieNote(this.leStagiaire);
            if (frmSaisie.ShowDialog() == DialogResult.OK)
            {
                // réafficher le stagiaire à jour de la nouvelle note
                this.frmVisu.AfficheStagiaire(this.leStagiaire);
            }
        }






    }
}
