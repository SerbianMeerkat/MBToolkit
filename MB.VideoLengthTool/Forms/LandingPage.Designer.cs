namespace MB.VideoLengthTool.Forms
{
    partial class LandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            this.recentSchemas = new System.Windows.Forms.ListBox();
            this.openSelectedButton = new System.Windows.Forms.Button();
            this.openSchemaButton = new System.Windows.Forms.Button();
            this.newSchemaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recentSchemas
            // 
            this.recentSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recentSchemas.FormattingEnabled = true;
            this.recentSchemas.IntegralHeight = false;
            this.recentSchemas.Location = new System.Drawing.Point(12, 12);
            this.recentSchemas.Name = "recentSchemas";
            this.recentSchemas.Size = new System.Drawing.Size(299, 167);
            this.recentSchemas.TabIndex = 0;
            // 
            // openSelectedButton
            // 
            this.openSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSelectedButton.Location = new System.Drawing.Point(317, 12);
            this.openSelectedButton.Name = "openSelectedButton";
            this.openSelectedButton.Size = new System.Drawing.Size(95, 23);
            this.openSelectedButton.TabIndex = 1;
            this.openSelectedButton.Text = "Open Selected";
            this.openSelectedButton.UseVisualStyleBackColor = true;
            this.openSelectedButton.Click += new System.EventHandler(this.openSelectedButton_Click);
            // 
            // openSchemaButton
            // 
            this.openSchemaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSchemaButton.Location = new System.Drawing.Point(317, 41);
            this.openSchemaButton.Name = "openSchemaButton";
            this.openSchemaButton.Size = new System.Drawing.Size(95, 23);
            this.openSchemaButton.TabIndex = 2;
            this.openSchemaButton.Text = "Open Schema";
            this.openSchemaButton.UseVisualStyleBackColor = true;
            this.openSchemaButton.Click += new System.EventHandler(this.openSchemaButton_Click);
            // 
            // newSchemaButton
            // 
            this.newSchemaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newSchemaButton.Location = new System.Drawing.Point(317, 70);
            this.newSchemaButton.Name = "newSchemaButton";
            this.newSchemaButton.Size = new System.Drawing.Size(95, 23);
            this.newSchemaButton.TabIndex = 3;
            this.newSchemaButton.Text = "New Schema";
            this.newSchemaButton.UseVisualStyleBackColor = true;
            this.newSchemaButton.Click += new System.EventHandler(this.NewSchemaButton_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 191);
            this.Controls.Add(this.newSchemaButton);
            this.Controls.Add(this.openSchemaButton);
            this.Controls.Add(this.openSelectedButton);
            this.Controls.Add(this.recentSchemas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Schema";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox recentSchemas;
        private System.Windows.Forms.Button openSelectedButton;
        private System.Windows.Forms.Button openSchemaButton;
        private System.Windows.Forms.Button newSchemaButton;
    }
}