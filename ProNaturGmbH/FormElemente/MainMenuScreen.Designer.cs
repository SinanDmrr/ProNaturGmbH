namespace ProNaturGmbH
{
    partial class MainMenuScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuScreen));
            this.btn_Products = new System.Windows.Forms.Button();
            this.btn_Bill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Products
            // 
            this.btn_Products.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Products.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Products.Image = ((System.Drawing.Image)(resources.GetObject("btn_Products.Image")));
            this.btn_Products.Location = new System.Drawing.Point(49, 65);
            this.btn_Products.Name = "btn_Products";
            this.btn_Products.Size = new System.Drawing.Size(275, 125);
            this.btn_Products.TabIndex = 0;
            this.btn_Products.Text = "Produkte verwalten";
            this.btn_Products.UseVisualStyleBackColor = true;
            this.btn_Products.Click += new System.EventHandler(this.btn_Products_Click);
            // 
            // btn_Bill
            // 
            this.btn_Bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Bill.Image = ((System.Drawing.Image)(resources.GetObject("btn_Bill.Image")));
            this.btn_Bill.Location = new System.Drawing.Point(362, 65);
            this.btn_Bill.Name = "btn_Bill";
            this.btn_Bill.Size = new System.Drawing.Size(275, 125);
            this.btn_Bill.TabIndex = 1;
            this.btn_Bill.Text = "Rechnungen verwalten";
            this.btn_Bill.UseVisualStyleBackColor = true;
            this.btn_Bill.Click += new System.EventHandler(this.btn_Bill_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.btn_Bill);
            this.Controls.Add(this.btn_Products);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "MainMenuScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Products;
        private System.Windows.Forms.Button btn_Bill;
    }
}