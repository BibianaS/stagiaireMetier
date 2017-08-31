using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections; // ajouté manuellement


namespace Exo9
{
    /// <summary>
    /// form de démarrage : datagridview des stagiaires de la section DI
    /// </summary>
    public partial class frmExo9 : Form
    {

        /// <summary>
        /// la section de stagiaires gérée par ce form
        /// </summary>
        private MSection laSection;

        /// <summary>
        /// Constructeur 
        /// (initialise la collection de sections et insère en dur la section DI)
        /// </summary>
        public frmExo9(MSection uneSection)
        {
            laSection = uneSection;
            InitializeComponent();
            //this.afficheStagiaires();
        }

        /// <summary>
        /// rétablit la source de données de la dataGridView
        /// et rafraîchit son affichage
        /// </summary>
        public void AfficheStagiaires(MSection laSection)
        {
            // déterminer l'origine des données à afficher : 
            // appel de la méthode de la classe MSection 
            // qui alimente et retourne une datatable
            // à partir de sa collection de stagiaires
            this.grdStagiaires.DataSource = laSection.ListerStagiaires();
            // refraîchir l'affichage
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