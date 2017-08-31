using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exo9
{
    public class CtrlListerStagiairesSection
    {
        private MSection laSection;
        private frmExo9 leForm;
        /// <summary>
        /// Constructeur : instancie et personalise le formExo
        /// l'affiche en non modal
        /// </summary>
        public CtrlListerStagiairesSection()
        {

            this.init();

            //instancier le form initial
            this.leForm = new frmExo9(this.laSection);
            this.leForm.AfficheStagiaires(this.laSection);
            this.leForm.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.leForm.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.leForm.grdStagiaires.DoubleClick += new System.EventHandler(this.grdStagiaires_DoubleClick);

            //affichage du form
            this.leForm.MdiParent = Donnees.FrmMDI; ;
            leForm.Show();
        }

        /// <summary>
        /// Initialisation d'un jeu d'essai
        /// </summary>
        private void init()
        {
            // initialisation de la collection de sections
            Donnees.Sections = new MSections();
            // pour commencer, une seule section référencée "en dur" dans ce programme
            // instancie la section
            this.laSection = new MSection("DL", "Développeur Informatique 2009");
            // l'ajoute dans la collection des sections gérée par la classe de collection
            Donnees.Sections.Ajouter(this.laSection);
            // ajoute en dur un stagiaire à cette section
            MStagiaire unStagiaire;
            unStagiaire = new MStagiaireDE(11111, "DUPOND", "Albert", "12 rue des Fleurs", "NICE", "06300", false);
            this.laSection.Ajouter(unStagiaire);

            // ajoute en dur un stagiaire à cette section
            MStagiaire unStagiaire2 = new MStagiaireDE(45544, "WINTZ", "BIBIANA", "12 rue des Fleurs", "NICE", "06300", false);
            this.laSection.Ajouter(unStagiaire2);

        }

        /// <summary>
        /// Bouton  ajouter : instancie un form de saisie stagiaire
        /// et lui passe la référence à la section en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // instancier un form de saisie de stagiaire et l'afficher en modal
            // il faut préciser la référence à la section que l'on traite
            CtrlNouveauStagiaire nouvStag = new CtrlNouveauStagiaire(this.laSection);
            if (nouvStag.Resultat == DialogResult.OK)
            {
                this.laSection.Ajouter(nouvStag.LeStagiaire);
                this.leForm.AfficheStagiaires(this.laSection);
            }            
        }

        /// <summary>
        /// Double-clic sur le datagridview :
        /// ouvrir la feuille détail en y affichant
        /// le stagiaire correspondant à la ligne double-cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdStagiaires_DoubleClick(object sender, EventArgs e)
        {
            // ouvrir la feuille détail en y affichant 
            // le stagiaire correspondant à la ligne double-cliquée
            MStagiaire leStagiaire;
            Int32 laCle; // clé (=numOSIA) du stagiaire dans la collection

            // récupérer clé du stagiaire cliqué en DataGridView
            laCle = (Int32)this.leForm.grdStagiaires.CurrentRow.Cells[0].Value;
            // instancier un objet stagiaire pointant vers 
            // le stagiaire d'origine dans la collection
            leStagiaire = this.laSection.RestituerStagiaire(laCle);

            //Instanciation du controleur visu Modif stagiaire
            CtrlVisuModifStagiaire ctrlVisu = new CtrlVisuModifStagiaire(leStagiaire);
         
            // en sortie du form détail, refraichir la datagridview
            this.leForm.AfficheStagiaires(this.laSection);

        }


        /// <summary>
        /// bouton supprimer : gérer la suppression du stagiaire pointé dans la datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // si un stagiaire est pointé dans la datagridview
            if (this.leForm.grdStagiaires.CurrentRow != null)
            {
                // récupérer la clé du stagiaire pointé
                Int32 cleStagiaire;
                cleStagiaire = (Int32)this.leForm.grdStagiaires.CurrentRow.Cells[0].Value;
                // demander confirmation de la suppression
                // NB: messagebox retourne une valeur exploitable !
                if (MessageBox.Show("Voulez-vous supprimer le stagiaire numéro :" + cleStagiaire.ToString(), "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // supprimer et compacter la collection
                    //this.laSection.Supprimer(this.laSection.RestituerStagiaire(cleStagiaire));
                    this.laSection.Supprimer(cleStagiaire);
                    // réafficher la datagridview
                    this.leForm.AfficheStagiaires(laSection);
                }
            }

        }


    }
}
