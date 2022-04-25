namespace MB.VideoLengthTool.Forms
{
    partial class SchemaEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaEditor));
            this.itemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.createSchemaButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addSchemaItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemPanel
            // 
            this.itemPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemPanel.AutoScroll = true;
            this.itemPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.itemPanel.Location = new System.Drawing.Point(12, 12);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(310, 178);
            this.itemPanel.TabIndex = 0;
            this.itemPanel.WrapContents = false;
            // 
            // createSchemaButton
            // 
            this.createSchemaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createSchemaButton.Location = new System.Drawing.Point(230, 196);
            this.createSchemaButton.Name = "createSchemaButton";
            this.createSchemaButton.Size = new System.Drawing.Size(92, 23);
            this.createSchemaButton.TabIndex = 1;
            this.createSchemaButton.Text = "Save Schema";
            this.createSchemaButton.UseVisualStyleBackColor = true;
            this.createSchemaButton.Click += new System.EventHandler(this.createSchemaButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(149, 196);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addSchemaItemButton
            // 
            this.addSchemaItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSchemaItemButton.Location = new System.Drawing.Point(12, 196);
            this.addSchemaItemButton.Name = "addSchemaItemButton";
            this.addSchemaItemButton.Size = new System.Drawing.Size(59, 23);
            this.addSchemaItemButton.TabIndex = 3;
            this.addSchemaItemButton.Text = "Add";
            this.addSchemaItemButton.UseVisualStyleBackColor = true;
            this.addSchemaItemButton.Click += new System.EventHandler(this.addSchemaItemButton_Click);
            // 
            // SchemaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 231);
            this.Controls.Add(this.addSchemaItemButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createSchemaButton);
            this.Controls.Add(this.itemPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 150);
            this.Name = "SchemaEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchemaEditor";
            this.Load += new System.EventHandler(this.SchemaEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemPanel;
        private System.Windows.Forms.Button createSchemaButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addSchemaItemButton;
    }
}