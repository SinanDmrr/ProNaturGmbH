namespace ProNaturGmbH
{
    partial class LoadingScreen
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.lbl_ProgressInPercent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 226);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(660, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.ForeColor = System.Drawing.Color.White;
            this.lbl_Loading.Location = new System.Drawing.Point(310, 210);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(45, 13);
            this.lbl_Loading.TabIndex = 1;
            this.lbl_Loading.Text = "Loading";
            // 
            // lbl_ProgressInPercent
            // 
            this.lbl_ProgressInPercent.AutoSize = true;
            this.lbl_ProgressInPercent.ForeColor = System.Drawing.Color.White;
            this.lbl_ProgressInPercent.Location = new System.Drawing.Point(361, 210);
            this.lbl_ProgressInPercent.Name = "lbl_ProgressInPercent";
            this.lbl_ProgressInPercent.Size = new System.Drawing.Size(21, 13);
            this.lbl_ProgressInPercent.TabIndex = 2;
            this.lbl_ProgressInPercent.Text = "0%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = "";
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::ProNaturGmbH.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(660, 195);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_ProgressInPercent);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "LoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProNatur Biomarkt GmbH";
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.Label lbl_ProgressInPercent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

