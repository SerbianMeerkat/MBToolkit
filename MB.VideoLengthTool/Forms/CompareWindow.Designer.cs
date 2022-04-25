namespace MB.VideoLengthTool.Forms
{
    partial class CompareWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareWindow));
            this.videoFileLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.spreadsheetButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editSchemaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // videoFileLayout
            // 
            this.videoFileLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoFileLayout.AutoScroll = true;
            this.videoFileLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.videoFileLayout.Location = new System.Drawing.Point(12, 12);
            this.videoFileLayout.Name = "videoFileLayout";
            this.videoFileLayout.Size = new System.Drawing.Size(497, 178);
            this.videoFileLayout.TabIndex = 0;
            this.videoFileLayout.WrapContents = false;
            // 
            // spreadsheetButton
            // 
            this.spreadsheetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spreadsheetButton.Location = new System.Drawing.Point(395, 196);
            this.spreadsheetButton.Name = "spreadsheetButton";
            this.spreadsheetButton.Size = new System.Drawing.Size(114, 23);
            this.spreadsheetButton.TabIndex = 1;
            this.spreadsheetButton.Text = "Export Spreadsheet";
            this.spreadsheetButton.UseVisualStyleBackColor = true;
            this.spreadsheetButton.Click += new System.EventHandler(this.spreadsheetButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(314, 196);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editSchemaButton
            // 
            this.editSchemaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSchemaButton.Location = new System.Drawing.Point(12, 196);
            this.editSchemaButton.Name = "editSchemaButton";
            this.editSchemaButton.Size = new System.Drawing.Size(81, 23);
            this.editSchemaButton.TabIndex = 3;
            this.editSchemaButton.Text = "Edit Schema";
            this.editSchemaButton.UseVisualStyleBackColor = true;
            this.editSchemaButton.Click += new System.EventHandler(this.editSchemaButton_Click);
            // 
            // CompareWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 231);
            this.Controls.Add(this.editSchemaButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.spreadsheetButton);
            this.Controls.Add(this.videoFileLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "CompareWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompareWindow";
            this.Load += new System.EventHandler(this.CompareWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel videoFileLayout;
        private System.Windows.Forms.Button spreadsheetButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button editSchemaButton;
    }
}