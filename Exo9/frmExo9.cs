using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections; // ajout� manuellement


namespace Exo9
{
    /// <summary>
    /// form de d�marrage : datagridview des stagiaires de la section DI
    /// </summary>
    public partial class frmExo9 : Form
    {

        /// <summary>
        /// la section de stagiaires g�r�e par ce form
        /// </summary>
        private MSection laSection;

        /// <summary>
        /// Constructeur 
        /// (initialise la collection de sections et ins�re en dur la section DI)
        /// </summary>
        public frmExo9(MSection uneSection)
        {
            laSection = uneSection;
            InitializeComponent();
            //this.afficheStagiaires();
        }

        /// <summary>
        /// r�tablit la source de donn�es de la dataGridView
        /// et rafra�chit son affichage
        /// </summary>
        public void AfficheStagiaires(MSection laSection)
        {
            // d�terminer l'origine des donn�es � afficher : 
            // appel de la m�thode de la classe MSection 
            // qui alimente et retourne une datatable
            // � partir de sa collection de stagiaires
            this.grdStagiaires.DataSource = laSection.ListerStagiaires();
            // refra�chir l'affichage
            this.grdStagiaires.Refresh();
            // gestion bouton supprimer
            // admirer la syntaxe...
            this.btnSupprimer.Enabled = (this.grdStagiaires.CurrentRow == null ? false : true);
        }


        /// <summary>
        /// bouton fermer : fermer le form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Active ou desactive le bouton supprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdStagiaires_SelectionChanged(Object sender, EventArgs e)
        {
               btnSupprimer.Enabled = true;
        }


    }

}