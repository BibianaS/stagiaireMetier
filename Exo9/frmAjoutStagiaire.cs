using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exo9
{
    /// <summary>
    /// classe d�riv�e de frmStagiaire : form sp�cialis� pour cr�ation d'un stagiaire
    /// </summary>
    public partial class frmAjoutStagiaire : frmStagiaire
    {
        /// <summary>
        /// la section du stagiaire en cours
        /// </summary>
        MStagiaire nouveauStagiaire;

        public MStagiaire LeStagiaire
        {
            get
            {
                return nouveauStagiaire;
            }
        }

        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="uneSection">la section de ce stagiaire</param>
        public frmAjoutStagiaire()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// fonction qui instancie un nouvel objet MStagiaire sp�cialis�
        /// puis tente d'affecter ses membres (attributs ou prop.)
        /// avec interception erreur �ventuelle lev�e par la classe MStagiaire
        /// et ajoute la r�f�rence de ce stagiaire dans la collection de sa section
        /// </summary>
        /// <returns>Boolean : true = OK, false = erreur</returns>
        internal Boolean Instancie()
        {
            // cr�er une r�f�rence d'objet MStagiaire 
            try
            {

                if (this.rbtDE.Checked) // c'est un DE
                {
                    // instancier un stagiaire sp�cialis� DE et lui affecter toutes ses propri�t�s
                    nouveauStagiaire = new MStagiaireDE(
                        Int32.Parse(base.txtOSIA.Text.Trim()),
                        base.txtNom.Text,
                        base.txtPrenom.Text,
                        base.txtAdresse.Text,
                        base.txtVille.Text,
                        base.txtCodePostal.Text.Trim(),
                        this.chkRemuAfpa.Checked);
                }
                else // c'est un CIF
                {
                    // d�terminer le type de CIF
                    String leTypeCIF;
                    if (this.rbtCDD.Checked)
                    {
                        leTypeCIF = "CDD";
                    }
                    else if (this.rbtCDI.Checked)
                    {
                        leTypeCIF = "CDI";
                    }
                    else
                    {
                        leTypeCIF = "TT";
                    }

                    // instancier un stagiaire sp�cialis� CIF et lui affecter toutes ses propri�t�s
                    nouveauStagiaire = new MStagiaireCIF(
                        Int32.Parse(base.txtOSIA.Text.Trim()),
                        base.txtNom.Text,
                        base.txtPrenom.Text,
                        base.txtAdresse.Text,
                        base.txtVille.Text,
                        base.txtCodePostal.Text.Trim(),
                        this.txtFongecif.Text,
                        leTypeCIF);

                }

                // dans tous les cas, ajouter la r�f�rence d'objet MStagiaire dans la collection de sa section
                // this.laSection.Ajouter(nouveauStagiaire);
                return true;

            }
            catch (Exception ex)
            {
                nouveauStagiaire = null;
                MessageBox.Show("Erreur : \n" + ex.Message, "Ajout de stagiaire");
                return false;
            }

        }

        /// <summary>
        /// fonction de contr�le de vraissemblance des diff�rents champs du form
        /// (appel�e avant d'instancier un objet MStagiaire et d'affecter ses membres)
        /// </summary>
        /// <returns>Boolean : true = OK, false = erreurs de saisie sur code postal ou numosia</returns>
        internal Boolean Controle()
        {
            // contr�ler la vraissemblance de tous les champs
            Boolean code = true; // le code de retour ; OK a priori

            if (!(Outils.EstEntier(this.txtOSIA.Text))) // appel fonction g�n�rique de contr�le
            {
                // la cha�ne re�ue n'est pas convertible
                code = false;
                MessageBox.Show("le code OSIA saisi n'est pas un entier valide", "ERREUR", MessageBoxButtons.OK);
            }
            if (!(Outils.EstEntier(this.txtCodePostal.Text)))
            {
                code = false;
                MessageBox.Show("le code postal saisi n'est pas correct", "ERREUR", MessageBoxButtons.OK);
            }
            return code;
        }

        /// <summary>
        /// bouton annuler : fermer sans suite la boite de dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            // fermeture de la boite de dialogue par abandon
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// checkbox CIF : activer/d�sactiver les options supp du form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtCIF_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtCIF.Checked)
            {
                this.grpTypeCIF.Enabled = true;

            }
            else
            {
                this.grpTypeCIF.Enabled = false;
            }
        }

        /// <summary>
        /// checkbox DE : activer/d�sactiver les options supp du form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtDE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtDE.Checked)
            {
                this.chkRemuAfpa.Enabled = true;
            }
            else
            {
                this.chkRemuAfpa.Enabled = false;
            }
        }
    }
}


