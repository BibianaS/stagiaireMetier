using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exo9
{
    public class CtrlNouveauStagiaire
    {
        /// <summary>
        /// reference au formulaire d'ajout
        /// </summary>
        private frmAjoutStagiaire frmAjout;
        /// <summary>
        /// reference au stagiaire saisie
        /// </summary>
        private MStagiaire leStagiaire;
        /// <summary>
        /// reference a la section du stagiaire
        /// </summary>
        private MSection laSection;
        private DialogResult resultat;
        
        public CtrlNouveauStagiaire(MSection uneSection)
        {
            this.laSection = uneSection;
            this.frmAjout = new frmAjoutStagiaire();
            // personnaliser le titre du form
            this.frmAjout.Text = uneSection.ToString();
            this.frmAjout.btnOK.Click += new EventHandler(this.btnOK_Click);
            // afficher le form détail en modal
            resultat = this.frmAjout.ShowDialog();
        }

        private void btnOK_Click(Object sender, EventArgs e)
        {
            if (this.frmAjout.Controle())
            {
                if (this.frmAjout.Instancie())
                {
                    //fermer le form
                    this.frmAjout.DialogResult = DialogResult.OK;

                    //recuperation le resultat de la saissie
                    this.resultat = this.frmAjout.DialogResult;

                    //recuperer la la ref du stagiaire  instancié par le form
                    this.leStagiaire =this.frmAjout.LeStagiaire; 
                    //this.laSection.Ajouter(LeStagiaire);
                }
                else
                {
                    this.resultat = DialogResult.No;
                }
            }
        }

        /// <summary>
        /// objet le résultat du dialogue modal assuré par le form frmAjoutStagiaire
        /// </summary>
        public DialogResult Resultat
        {
            get
            {
                return resultat;
            }          
        }

        public MStagiaire LeStagiaire
        {
            get
            {
                return leStagiaire;
            }
        }
    }
}
