using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exo9
{
    public partial class frmSaisieNote : Form
    {
        // ref du stagiaire qui reçoit la note
        private MStagiaire leStagiaire;

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="unStagiaire">ref du stagiaire qui reçoit la note</param>
        public frmSaisieNote(MStagiaire unStagiaire)
        {
            InitializeComponent();
            this.leStagiaire = unStagiaire;
            // personnalisation titre form
            this.Text += unStagiaire.ToString();
        }

        
        /// <summary>
        /// prise en compte de la note saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            // appel méthode prise en compte note
            this.leStagiaire.RecevoirNote((float)(this.nudNote.Value));
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// abandon 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}