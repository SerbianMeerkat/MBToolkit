using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB.VideoLengthTool.Forms
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            UpdateSelectedButton();

            recentSchemas.SelectedIndexChanged += (s, a) => UpdateSelectedButton();
            recentSchemas.DoubleClick += (s, a) =>
            {
                if (recentSchemas.SelectedItem != null)
                    OpenSchemaFile((string)recentSchemas.SelectedItem);
            };

            RecentSchemas.RecentSchemasChanged += (s, a) => UpdateRecentSchemas();
            UpdateRecentSchemas();
        }

        void OpenSchemaFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"This file ({filePath}) doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CompareWindow.Open(Schema.LoadFromFile(filePath));

            Hide();
        }

        void UpdateRecentSchemas()
        {
            recentSchemas.Items.Clear();

            if (Properties.Settings.Default.RecentSchemas != null && Properties.Settings.Default.RecentSchemas.Count > 0)
            {
                var array = RecentSchemas.GetRecentSchemas().Reverse().ToArray();

                recentSchemas.Items.AddRange(array);
            }
        }

        void UpdateSelectedButton()
        {
            openSelectedButton.Enabled = recentSchemas.SelectedItem != null;
        }

        private void openSelectedButton_Click(object sender, EventArgs e)
        {
            OpenSchemaFile((string)recentSchemas.SelectedItem);
        }

        private void openSchemaButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "Schema file (*.hschema)|*.hschema";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenSchemaFile(dialog.FileName);
            }
        }

        private void NewSchemaButton_Click(object sender, EventArgs e)
        {
            SchemaEditor.NewSchema(() => new LandingPage().Show());
            Close();
        }
    }
}
