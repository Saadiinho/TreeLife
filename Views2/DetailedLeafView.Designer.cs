using System.Windows.Forms;

namespace TreeLife.Views2
{
    partial class DetailedLeafView
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxLeaf = new System.Windows.Forms.GroupBox();
            this.pnlParent = new System.Windows.Forms.Panel();
            this.lblParentToGet = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.pnlPhylesis = new System.Windows.Forms.Panel();
            this.lblPhylesisToGet = new System.Windows.Forms.Label();
            this.lblPhylesis = new System.Windows.Forms.Label();
            this.pnlConfidence = new System.Windows.Forms.Panel();
            this.lblConfidenceToGet = new System.Windows.Forms.Label();
            this.lblConfidence = new System.Windows.Forms.Label();
            this.pnlExtinct = new System.Windows.Forms.Panel();
            this.lblExtinctToGet = new System.Windows.Forms.Label();
            this.lblExtinct = new System.Windows.Forms.Label();
            this.pnlLink = new System.Windows.Forms.Panel();
            this.lblLinkToGet = new System.Windows.Forms.LinkLabel();
            this.lblLink = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.lblNameToGet = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbxLeaf.SuspendLayout();
            this.pnlParent.SuspendLayout();
            this.pnlPhylesis.SuspendLayout();
            this.pnlConfidence.SuspendLayout();
            this.pnlExtinct.SuspendLayout();
            this.pnlLink.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxLeaf
            // 
            this.gbxLeaf.Controls.Add(this.pnlParent);
            this.gbxLeaf.Controls.Add(this.pnlPhylesis);
            this.gbxLeaf.Controls.Add(this.pnlConfidence);
            this.gbxLeaf.Controls.Add(this.pnlExtinct);
            this.gbxLeaf.Controls.Add(this.pnlLink);
            this.gbxLeaf.Controls.Add(this.pnlName);
            this.gbxLeaf.Location = new System.Drawing.Point(14, 23);
            this.gbxLeaf.Name = "gbxLeaf";
            this.gbxLeaf.Size = new System.Drawing.Size(262, 519);
            this.gbxLeaf.TabIndex = 0;
            this.gbxLeaf.TabStop = false;
            this.gbxLeaf.Text = "Fiche de renseignement";
            this.gbxLeaf.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnlParent
            // 
            this.pnlParent.Controls.Add(this.lblParentToGet);
            this.pnlParent.Controls.Add(this.lblParent);
            this.pnlParent.Location = new System.Drawing.Point(16, 118);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(227, 58);
            this.pnlParent.TabIndex = 2;
            // 
            // lblParentToGet
            // 
            this.lblParentToGet.AutoSize = true;
            this.lblParentToGet.Location = new System.Drawing.Point(14, 29);
            this.lblParentToGet.Name = "lblParentToGet";
            this.lblParentToGet.Size = new System.Drawing.Size(0, 16);
            this.lblParentToGet.TabIndex = 1;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParent.Location = new System.Drawing.Point(0, 0);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(49, 16);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "Parent:";
            // 
            // pnlPhylesis
            // 
            this.pnlPhylesis.Controls.Add(this.lblPhylesisToGet);
            this.pnlPhylesis.Controls.Add(this.lblPhylesis);
            this.pnlPhylesis.Location = new System.Drawing.Point(16, 361);
            this.pnlPhylesis.Name = "pnlPhylesis";
            this.pnlPhylesis.Size = new System.Drawing.Size(227, 58);
            this.pnlPhylesis.TabIndex = 2;
            // 
            // lblPhylesisToGet
            // 
            this.lblPhylesisToGet.AutoSize = true;
            this.lblPhylesisToGet.Location = new System.Drawing.Point(14, 29);
            this.lblPhylesisToGet.Name = "lblPhylesisToGet";
            this.lblPhylesisToGet.Size = new System.Drawing.Size(0, 16);
            this.lblPhylesisToGet.TabIndex = 1;
            // 
            // lblPhylesis
            // 
            this.lblPhylesis.AutoSize = true;
            this.lblPhylesis.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhylesis.Location = new System.Drawing.Point(0, 0);
            this.lblPhylesis.Name = "lblPhylesis";
            this.lblPhylesis.Size = new System.Drawing.Size(59, 16);
            this.lblPhylesis.TabIndex = 0;
            this.lblPhylesis.Text = "Phylèse:";
            // 
            // pnlConfidence
            // 
            this.pnlConfidence.Controls.Add(this.lblConfidenceToGet);
            this.pnlConfidence.Controls.Add(this.lblConfidence);
            this.pnlConfidence.Location = new System.Drawing.Point(16, 276);
            this.pnlConfidence.Name = "pnlConfidence";
            this.pnlConfidence.Size = new System.Drawing.Size(227, 58);
            this.pnlConfidence.TabIndex = 3;
            // 
            // lblConfidenceToGet
            // 
            this.lblConfidenceToGet.AutoSize = true;
            this.lblConfidenceToGet.Location = new System.Drawing.Point(14, 29);
            this.lblConfidenceToGet.Name = "lblConfidenceToGet";
            this.lblConfidenceToGet.Size = new System.Drawing.Size(0, 16);
            this.lblConfidenceToGet.TabIndex = 1;
            // 
            // lblConfidence
            // 
            this.lblConfidence.AutoSize = true;
            this.lblConfidence.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfidence.Location = new System.Drawing.Point(0, 0);
            this.lblConfidence.Name = "lblConfidence";
            this.lblConfidence.Size = new System.Drawing.Size(183, 16);
            this.lblConfidence.TabIndex = 0;
            this.lblConfidence.Text = "Confiance (chance de survie):";
            // 
            // pnlExtinct
            // 
            this.pnlExtinct.Controls.Add(this.lblExtinctToGet);
            this.pnlExtinct.Controls.Add(this.lblExtinct);
            this.pnlExtinct.Location = new System.Drawing.Point(16, 200);
            this.pnlExtinct.Name = "pnlExtinct";
            this.pnlExtinct.Size = new System.Drawing.Size(227, 58);
            this.pnlExtinct.TabIndex = 2;
            // 
            // lblExtinctToGet
            // 
            this.lblExtinctToGet.AutoSize = true;
            this.lblExtinctToGet.Location = new System.Drawing.Point(14, 29);
            this.lblExtinctToGet.Name = "lblExtinctToGet";
            this.lblExtinctToGet.Size = new System.Drawing.Size(0, 16);
            this.lblExtinctToGet.TabIndex = 1;
            // 
            // lblExtinct
            // 
            this.lblExtinct.AutoSize = true;
            this.lblExtinct.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExtinct.Location = new System.Drawing.Point(0, 0);
            this.lblExtinct.Name = "lblExtinct";
            this.lblExtinct.Size = new System.Drawing.Size(100, 16);
            this.lblExtinct.TabIndex = 0;
            this.lblExtinct.Text = "Espèce éteinte:";
            // 
            // pnlLink
            // 
            this.pnlLink.Controls.Add(this.lblLinkToGet);
            this.pnlLink.Controls.Add(this.lblLink);
            this.pnlLink.Location = new System.Drawing.Point(16, 438);
            this.pnlLink.Name = "pnlLink";
            this.pnlLink.Size = new System.Drawing.Size(227, 58);
            this.pnlLink.TabIndex = 2;
            // 
            // lblLinkToGet
            // 
            this.lblLinkToGet.AutoSize = true;
            this.lblLinkToGet.Location = new System.Drawing.Point(14, 33);
            this.lblLinkToGet.Name = "lblLinkToGet";
            this.lblLinkToGet.Size = new System.Drawing.Size(0, 16);
            this.lblLinkToGet.TabIndex = 1;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lblLinkToGet, lblLinkToGet.Text);

            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLink.Location = new System.Drawing.Point(0, 0);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(35, 16);
            this.lblLink.TabIndex = 0;
            this.lblLink.Text = "Lien:";
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.lblNameToGet);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Location = new System.Drawing.Point(16, 39);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(227, 58);
            this.pnlName.TabIndex = 0;
            // 
            // lblNameToGet
            // 
            this.lblNameToGet.AutoSize = true;
            this.lblNameToGet.Location = new System.Drawing.Point(14, 29);
            this.lblNameToGet.Name = "lblNameToGet";
            this.lblNameToGet.Size = new System.Drawing.Size(0, 16);
            this.lblNameToGet.TabIndex = 1;
            this.lblNameToGet.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nom:";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // DetailedLeafView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxLeaf);
            this.Name = "DetailedLeafView";
            this.Size = new System.Drawing.Size(300, 800);
            this.Load += new System.EventHandler(this.DetailedNodeView_Load);
            this.gbxLeaf.ResumeLayout(false);
            this.pnlParent.ResumeLayout(false);
            this.pnlParent.PerformLayout();
            this.pnlPhylesis.ResumeLayout(false);
            this.pnlPhylesis.PerformLayout();
            this.pnlConfidence.ResumeLayout(false);
            this.pnlConfidence.PerformLayout();
            this.pnlExtinct.ResumeLayout(false);
            this.pnlExtinct.PerformLayout();
            this.pnlLink.ResumeLayout(false);
            this.pnlLink.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLeaf;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameToGet;
        private System.Windows.Forms.Panel pnlLink;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.LinkLabel lblLinkToGet;
        private System.Windows.Forms.Panel pnlExtinct;
        private System.Windows.Forms.Label lblExtinctToGet;
        private System.Windows.Forms.Label lblExtinct;
        private System.Windows.Forms.Panel pnlConfidence;
        private System.Windows.Forms.Label lblConfidenceToGet;
        private System.Windows.Forms.Label lblConfidence;
        private System.Windows.Forms.Panel pnlPhylesis;
        private System.Windows.Forms.Label lblPhylesisToGet;
        private System.Windows.Forms.Label lblPhylesis;
        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.Label lblParentToGet;
        private System.Windows.Forms.Label lblParent;
    }
}
