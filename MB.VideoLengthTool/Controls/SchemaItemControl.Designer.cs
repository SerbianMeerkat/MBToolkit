namespace MB.VideoLengthTool.Controls
{
    partial class SchemaItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.schemaItemName = new System.Windows.Forms.TextBox();
            this.schemaItemTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // schemaItemName
            // 
            this.schemaItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.schemaItemName.Location = new System.Drawing.Point(0, 0);
            this.schemaItemName.Name = "schemaItemName";
            this.schemaItemName.Size = new System.Drawing.Size(230, 20);
            this.schemaItemName.TabIndex = 0;
            // 
            // schemaItemTime
            // 
            this.schemaItemTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.schemaItemTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.schemaItemTime.Location = new System.Drawing.Point(236, 0);
            this.schemaItemTime.Name = "schemaItemTime";
            this.schemaItemTime.ShowUpDown = true;
            this.schemaItemTime.Size = new System.Drawing.Size(94, 20);
            this.schemaItemTime.TabIndex = 1;
            // 
            // SchemaItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.schemaItemTime);
            this.Controls.Add(this.schemaItemName);
            this.Name = "SchemaItemControl";
            this.Size = new System.Drawing.Size(330, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox schemaItemName;
        private System.Windows.Forms.DateTimePicker schemaItemTime;
    }
}
